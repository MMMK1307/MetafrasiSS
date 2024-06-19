document.addEventListener("DOMContentLoaded", () => {
    console.log("something");

    var container = document.getElementsByClassName("error-container")[0];

    if (!container) {
        return;
    }

    var btn = document.getElementById("close-btn");

    btn.addEventListener("click", () => {
        container.className = "error-container msg-hide";
        container.html.className
    });

    setTimeout(() => {
        container.className = "error-container msg-hide";
    }, 5000);
});