let currentlyExpandedCard = null;

function expandCard(event, productId) {
    // Prevent the event from propagating to document
    event.stopPropagation();

    // Get the clicked card
    const card = document.getElementById(`product-card-${productId}`);

    // Collapse the currently expanded card if there is one and it's not the clicked card
    if (currentlyExpandedCard && currentlyExpandedCard !== card) {
        currentlyExpandedCard.classList.remove('expanded');
    }

    // Toggle the expanded class on the clicked card
    card.classList.toggle('expanded');

    // Show or hide the overlay based on expansion
    document.getElementById('overlay').style.display = card.classList.contains('expanded') ? 'block' : 'none';

    // Update the currently expanded card if the clicked card is expanded, otherwise set it to null
    currentlyExpandedCard = card.classList.contains('expanded') ? card : null;
}

function collapseCard() {
    if (currentlyExpandedCard) {
        currentlyExpandedCard.classList.remove('expanded');
        document.getElementById('overlay').style.display = 'none';
        currentlyExpandedCard = null;
    }
}

// Listen for clicks outside the card to collapse it
document.addEventListener('click', function handleClickOutside(e) {
    if (currentlyExpandedCard && !currentlyExpandedCard.contains(e.target)) {
        collapseCard(); // Collapse the card on outside click
        document.removeEventListener('click', handleClickOutside);
    }
});