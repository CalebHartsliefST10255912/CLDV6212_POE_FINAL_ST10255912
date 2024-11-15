﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Retail_ST10255912_POE.Data;
using ABC_Retail_ST10255912_POE.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ABC_Retail_ST10255912_POE.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("AdminIndex");
                }
                else
                {
                    return RedirectToAction("ClientIndex");
                }
            }
            else
            {
                return RedirectToAction("ClientIndex"); // Default view for non-logged in users
            }
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex(OrderStatus? statusFilter)
        {
            // Start the query with the necessary includes
            var query = _context.Order
                                .Include(o => o.User)
                                .Include(o => o.OrderItems)
                                .ThenInclude(oi => oi.Product) // Include related Product if needed
                                .AsQueryable();

            // Apply the status filter if provided
            if (statusFilter.HasValue)
            {
                query = query.Where(o => o.OrderStatus == statusFilter.Value);
            }

            // Store the current filter in ViewData to use in the view
            ViewData["CurrentFilter"] = statusFilter;

            // Execute the query and get the list of orders
            var orders = await query.ToListAsync();

            // Return the view with the list of orders
            return View(orders);
        }



        public async Task<IActionResult> ClientIndex()
        {
            var user = await _userManager.GetUserAsync(User);


            var userOrders = await _context.Order
                .Where(o => o.UserID == user.Id && o.OrderStatus == OrderStatus.Pending)
                .ToListAsync();
            return View(userOrders);
        }

        public async Task<IActionResult> ClientOrderHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var orders = await _context.Order
                                       .Where(o => o.UserID == user.Id && o.OrderStatus != OrderStatus.Pending)
                                       .ToListAsync();
            return View(orders);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeStatus(int orderID, OrderStatus orderStatus)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var order = await _context.Order.FindAsync(orderID);
            if (order == null)
            {
                return NotFound();
            }



            order.OrderStatus = orderStatus;
            order.ModifiedDate = DateTime.Now;

            _context.Update(order);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(AdminIndex));

        }



        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                 .Include(o => o.User)
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (!isAdmin)
            {
                if (order == null || order.UserID != user.Id)
                {
                    return NotFound();
                }
            }


            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            if (order.OrderStatus != OrderStatus.Pending)
            {
                return Unauthorized("Order has been processed and can no longer be cancelled.");

            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order
                                .Include(o => o.OrderItems)
                                .ThenInclude(oi => oi.Product)
                                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            if (order.OrderItems != null && order.OrderItems.Any())
            {

                foreach (var orderItem in order.OrderItems)
                {

                    if (orderItem.Product != null)
                    {
                        orderItem.Product.InStock = true;
                        _context.Products.Update(orderItem.Product);
                    }


                }
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}
