export function scrollDown(e) {
    if (e.key === 'Enter') {
        const scroll = document.querySelector("html");
        scroll.scrollTop = scroll.scrollHeight;
    }
}