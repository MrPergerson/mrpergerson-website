$(document).ready(function(){
    // if window resize call responsive function
    $(window).resize(function(e) {
        screen_resize();
    });

});

/* Toggle between showing and hiding the navigation menu links when the user clicks on the hamburger menu / bar icon */
function toggleMobileDirectory() {
    var x = document.getElementById("dirLinks");
    if (x.style.display === "block") {
      x.style.display = "none";
    } else {
      x.style.display = "block";
    }
} 

function screen_resize() {
    var h = parseInt(window.innerHeight);
    var w = parseInt(window.innerWidth);

    if(w >= 600) {
        $("#dirLinks").css("display", "block");
    } 
    else
    {
        $("#dirLinks").css("display", "none");
    }

}