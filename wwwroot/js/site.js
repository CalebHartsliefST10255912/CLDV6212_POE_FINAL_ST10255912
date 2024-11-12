document.addEventListener('DOMContentLoaded', function () {
    // Retrieve cart count from localStorage
    const cartCount = localStorage.getItem('cartItemCount') || 0;
    document.getElementById('cart-counter').textContent = cartCount;
});

function updateCartCounter(count) {
    localStorage.setItem('cartItemCount', count);
    document.getElementById('cart-counter').textContent = count;
}

