// Initialize cart count from session storage to persist across pages (optional)
document.addEventListener('DOMContentLoaded', () => {
    const cartCounter = sessionStorage.getItem('cartCounter') || 0;
    document.getElementById('cart-counter').textContent = cartCounter;
});

// Increment cart counter
function incrementCartCounter() {
    const counterElement = document.getElementById('cart-counter');
    let currentCount = parseInt(counterElement.textContent, 10);
    counterElement.textContent = ++currentCount;
    sessionStorage.setItem('cartCounter', currentCount); // Save count in session storage
}

// Decrement cart counter
function decrementCartCounter() {
    const counterElement = document.getElementById('cart-counter');
    let currentCount = parseInt(counterElement.textContent, 10);
    if (currentCount > 0) {
        counterElement.textContent = --currentCount;
        sessionStorage.setItem('cartCounter', currentCount); // Save updated count
    }
}

function resetCartCounter() {
    const counterElement = document.getElementById('cart-counter');
    let currentCount = parseInt(counterElement.textContent, 10);
    counterElement.textContent = 0;
    sessionStorage.setItem('cartCounter', currentCount);
}