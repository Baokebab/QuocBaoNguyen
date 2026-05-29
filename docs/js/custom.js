window.initCarousel = function () {

    const intervalMs = 10000; 
    const carousel = document.getElementById('carousel-example-generic');

    if (!carousel) return;

    const items = carousel.querySelectorAll('.carousel-inner .item');
    const indicators = carousel.querySelectorAll('.carousel-indicators button');

    let current = 0;
    let intervalId;
    let isAnimating = false;

    function showItem(index, direction = 'next') {
        if (isAnimating || index === current) return;
        isAnimating = true;

        const currentItem = items[current];
        const nextItem = items[index];

        currentItem.classList.remove('slide-in-right', 'slide-out-left', 'slide-in-left', 'slide-out-right', 'active');
        nextItem.classList.remove('slide-in-right', 'slide-out-left', 'slide-in-left', 'slide-out-right', 'active');

        if (direction === 'next') {
            nextItem.classList.add('slide-in-right');
            void nextItem.offsetWidth;
            currentItem.classList.add('slide-out-left');
            nextItem.classList.remove('slide-in-right');
        } else {
            nextItem.classList.add('slide-in-left');
            void nextItem.offsetWidth;
            currentItem.classList.add('slide-out-right');
            nextItem.classList.remove('slide-in-left');
        }
        nextItem.classList.add('active');


        items.forEach((item, i) => {
            item.classList.toggle('active', i === index);
            if (i === index) {
                item.style.transform = '';
            } else {
                item.style.transform = 'translateX(100%)';
            }
            if (indicators[i]) {
                indicators[i].classList.toggle('active', i === index);
                indicators[i].setAttribute('aria-current', i === index ? 'true' : 'false');
            }
        });

        setTimeout(() => {
            currentItem.classList.remove('slide-out-left', 'slide-out-right', 'active');
            nextItem.classList.add('active');
            isAnimating = false;
        }, 600);

        current = index;
    }

    function nextItem() {
        let next = (current + 1) % items.length;
        showItem(next, 'next');
    }

    function prevItem() {
        let prev = (current - 1 + items.length) % items.length;
        showItem(prev, 'prev');
    }

    indicators.forEach((indicator, i) => {
        indicator.addEventListener('click', () => {
            if (i > current) {
                showItem(i, 'next');
            } else if (i < current) {
                showItem(i, 'prev');
            }
            resetInterval();
        });
    });

    function resetInterval() {
        clearInterval(intervalId);
        intervalId = setInterval(nextItem, intervalMs);
    }

    intervalId = setInterval(nextItem, intervalMs);

    // Initialisation
    items.forEach((item, i) => {
        item.classList.remove('active', 'slide-in-right', 'slide-out-left', 'slide-in-left', 'slide-out-right');
        if (i === 0) {
            item.classList.add('active');
            item.style.transform = '';
        } else {
            item.style.transform = 'translateX(100%)';
        }
    });
    showItem(current, 'next');
}

window.scrollToElement = (elementId) => {

    const offset = 20;
    const element = document.getElementById(elementId);

    if (element) {
        const elementPosition = element.getBoundingClientRect().top + window.scrollY;
        const targetPosition = elementPosition - offset;
        window.scrollTo({
            top: targetPosition,
            behavior: 'smooth'
        });
    } else {
        console.error("id " + { elementId } + " not found");
    }
}

window.downloadFileFromStream = async (filename, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer], { type: "text/csv" });
    const url = URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.href = url;
    a.download = filename;
    a.click();

    URL.revokeObjectURL(url);
};
