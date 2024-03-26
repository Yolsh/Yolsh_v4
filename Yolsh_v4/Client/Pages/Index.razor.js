export function observeTitle() {
    const observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                setTimeout(function () {
                    entry.target.classList.add('typing-anim');
                    entry.target.classList.remove('hidden');
                }, 2000);
            } else {
                entry.target.classList.add('hidden');
                entry.target.classList.remove('typing-anim');
            }
        });
    });

    const title = document.getElementById('title2')
    observer.observe(title)
}