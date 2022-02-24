
$(document).ready(function(){
    $(".image-enlarged-container--background").hide();
    //$(".image-enlarged").hide();

    $("#image1").click(function() {
      $(this).clone().addClass("image-enlarged").appendTo(".image-enlarged-container");
      $(".image-enlarged-container--background").show();
    });

    $("#image2").click(function() {
      $(this).clone().addClass("image-enlarged").appendTo(".image-enlarged-container");
      $(".image-enlarged-container--background").show();
    });

    $("#image3").click(function() {
      $(this).clone().addClass("image-enlarged").appendTo(".image-enlarged-container");
      $(".image-enlarged-container--background").show();
    });

    
    $("#image4").click(function() {
      $(this).clone().addClass("image-enlarged").appendTo(".image-enlarged-container");
      $(".image-enlarged-container--background").show();
    });
    
    $(".image-enlarged-container--background").click(function() {
        $(".image-enlarged").remove();
        $(".image-enlarged-container--background").hide();
    });
    
});