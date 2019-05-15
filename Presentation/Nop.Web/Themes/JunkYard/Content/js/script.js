// don`t hide nav item on small screen size

const nav_item_third = () => {
  const third_nav_item = document.getElementById("third_nav_ul");
  third_nav_item.style.opacity = "1";
};

const toggleSearchBox = () => {
  // get the target element
  const search_box = document.getElementById("search_box_container");
  const third_nav_item = document.getElementById("third_nav_ul");

  // Do the toggling
  if (search_box.style.display === "block") {
    search_box.style.display = "none";
    document.getElementById("searchbox_icon").className = "lnr lnr-magnifier";
    third_nav_item.style.opacity = "1";
  } else {
    search_box.style.display = "block";
    document.getElementById("searchbox_icon").className = "lnr lnr-cross";
    third_nav_item.style.opacity = "0";
  }

  // Show Nav item on small screen
  let width = parseInt(window.innerWidth);

  if (width < 992) {
    nav_item_third();
  }
};

// Image Slider

//const current = document.querySelector("#current");
//const imgs = document.querySelector(".imgs");
//const img = document.querySelectorAll(".imgs img");
//const opacity = 0.6;

//// Set first img opacity
//img[0].style.opacity = opacity;

//imgs.addEventListener("click", imgClick);

//function imgClick(e) {
//  // Reset the opacity
//  img.forEach(img => (img.style.opacity = 1));

//  // Change current image to src of clicked image
//  current.src = e.target.src;

//  // Add fade in class
//  current.classList.add("fade-in");

//  // Remove fade-in class after .5 seconds
//  setTimeout(() => current.classList.remove("fade-in"), 500);

//  // Change the opacity to opacity var
//  e.target.style.opacity = opacity;
//}
