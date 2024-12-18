//function reveal() {
//    let reveals = document.querySelectorAll(".reveal");

//    for (let i = 0; i < reveals.length; i++) {
//        const windowHeight = window.innerHeight;
//        const elementTop = reveals[i].getBoundingClientRect().top;
//        const elementVisible = 150;

//        if (elementTop < windowHeight - elementVisible) {
//            reveals[i].classList.add("active");
//        } else {
//            reveals[i].classList.remove("active");
//        }
//    }
//}

//window.addEventListener("scroll", reveal);

const observer = new IntersectionObserver((entries) => {
    entries.forEach((entry) => {
        if (entry.isIntersecting) {
            entry.target.classList.add('active');
        } else {
            entry.target.classList.remove('active');
        }
    });
});

const hiddenElements = document.querySelectorAll('.reveal');
hiddenElements.forEach((el) => observer.observe(el));