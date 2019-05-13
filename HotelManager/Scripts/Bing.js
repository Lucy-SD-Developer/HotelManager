/*
var currentImageId = 0;
var totalImage = 5;

function switchImage(next) {
    if (next) {
        currentImageId++;
    } else {
        currentImageId--;
    }
    currentImageId = (currentImageId + totalImage) % totalImage;
    //alert($("#divBgImg").css("background-image"));
    $("#divBgImg").css("background-image", "url(Images/th" + currentImageId + ".jpeg)");
}

$(document).ready(function () {
    $("#divNextImage").on("click", function () {
        //alert("next image");
        switchImage(true);
    });

    $("#divPrevImage").on("click", function () {
        //alert("previous image");
        switchImage(false);
    });
});
*/