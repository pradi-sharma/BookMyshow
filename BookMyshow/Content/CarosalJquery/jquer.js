$('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:false,
    pagination:false,
    //autoplay:0.1,

    autoplay:true,
    autoplayTimeout:1000,
    autoplayHoverPause: true,
    

    responsive:{
        0:{
            items:1
        },
        600:{
            items:5
        },
        1000:{
            items:5
        }
    }
})




   

    //owl.on('changed.owl.carousel', function (event) {
    //    var item = event.item.index - 2;     // Position of the current item
    //    $('h1').removeClass('animated bounce');
    //    $('.owl-item').not('.cloned').eq(item).find('h1').addClass('animated bounce');
    //});

