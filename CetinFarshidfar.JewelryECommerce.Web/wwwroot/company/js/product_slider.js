document.body.addEventListener('click', (event) => {
    if (event.target.classList.contains('thumbnail')) {
        const thumbnails = document.querySelectorAll('.thumbnail');
        const mainImage = document.getElementById('mainImage');
        const index = Array.from(thumbnails).indexOf(event.target);

        thumbnails.forEach((thumb) => thumb.classList.remove('active'));
        event.target.classList.add('active');
        mainImage.src = event.target.src;

        clearInterval(autoSlideTimer);
        currentIndex = index;
        startAutoSlide();
    }
});

let currentIndex = 0;
let autoSlideTimer;

function startAutoSlide() {
    const thumbnails = document.querySelectorAll('.thumbnail');
    const mainImage = document.getElementById('mainImage');

    autoSlideTimer = setInterval(() => {
        currentIndex = (currentIndex + 1) % thumbnails.length;
        mainImage.src = thumbnails[currentIndex].src;

        thumbnails.forEach((thumb) => thumb.classList.remove('active'));
        thumbnails[currentIndex].classList.add('active');
    }, 3000);
}
