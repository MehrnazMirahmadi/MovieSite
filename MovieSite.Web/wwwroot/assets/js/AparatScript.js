$('#owlCarousel').owlCarousel({
    loop: true,
    rtl: true,
    margin: 2,
    nav: false,
    responsive: {
        0: {
            items: 1,
        },
        576: {
            items: 2,
        },
        768: {
            items: 3,
        },
        992: {
            items: 4,
        },
        1400: {
            items: 4,
        }
    }
});

$('#owlCarousel2').owlCarousel({
    loop: true,
    rtl: true,
    margin: 2,
    nav: false,
    responsive: {
        0: {
            items: 1,
        },
        576: {
            items: 2,
        },
        768: {
            items: 3,
        },
        992: {
            items: 4,
        },
        1400: {
            items: 4,
        }
    }
});

$('#owlCarousel3').owlCarousel({
    loop: true,
    rtl: true,
    margin: 2,
    nav: false,
    responsive: {
        0: {
            items: 1,
        },
        576: {
            items: 2,
        },
        768: {
            items: 3,
        },
        992: {
            items: 4,
        },
        1400: {
            items: 4,
        }
    }
});

let menu= document.querySelector(".asideMenu");
function toggolmenu(id) {
    if (menu.style.display === "none") {
        menu.style.display = "flex";
    } else {
        menu.style.display = "none";
    }
  }
  