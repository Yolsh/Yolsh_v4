export function scrollDown(e) {
    if (e === 'Enter') {
        console.log(e);
        const scroll = document.querySelector("html");
        scroll.scrollTop = scroll.scrollHeight;
    }
}