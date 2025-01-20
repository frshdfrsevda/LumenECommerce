document.addEventListener('DOMContentLoaded', function () {
    const currentPath = window.location.pathname;
    const menuItems = document.querySelectorAll('.list-group-item-action');

    menuItems.forEach(item => {
        const itemPath = item.getAttribute('data-path');
        if (currentPath === itemPath) {
            item.classList.add('active');
        }
    });
});
