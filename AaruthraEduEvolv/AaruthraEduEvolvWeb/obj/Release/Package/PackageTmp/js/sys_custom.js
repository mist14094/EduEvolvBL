// Image Hover and Hovertype Icons
function hoverimage() {

		jQuery('.hover_type').animate({opacity: 0});

		jQuery(".port_img, .sort_img").hover(function() {
			jQuery(this).find('.hover_type').css({display:'block'}).animate({
				opacity: 1, 
				bottom: (jQuery('.port_img, .sort_img').height())/2 - 20+'px'}, 300, 'easeInSine');
			jQuery(this).find('img').animate({"opacity": "0.7"}, 200);
			
		},function() {
			jQuery(this).find('.hover_type').animate({
				opacity: 0,
				bottom: '100%'}, 300, 'easeInSine', function() {
				jQuery(this).css({'bottom':'0'});
				});
			jQuery(this).find('img').animate({"opacity": "1"}, 200);
		}
	);
}

/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
Custom jQuery
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/

function atp_sociables() {
	jQuery('ul.atpsocials li').find("img").css({opacity:'0.8'});
	jQuery("ul.atpsocials li").hover(function(){
		jQuery(this).find("img").animate({top:"-4px", opacity:'1'}, "fast")
		},function(){
		jQuery(this).find("img").animate({top:"-2px",opacity:'0.8'}, "fast")
	});
}

//Custom Toggle
	function sys_toggle() {
		jQuery(".toggle_content").append("<div class='arrow'></div>").hide();

		jQuery("span.toggle").toggle(function(){
			jQuery(this).addClass("active");
			}, function () {
			jQuery(this).removeClass("active");
		});

		jQuery("span.toggle").click(function(){
			jQuery(this).next(".toggle_content").slideToggle();
		});
	}

	function pricingboxes(){
	jQuery('.pricetable .block').hover(
			function(){
				jQuery(this).addClass('active');
				jQuery(this).animate({'padding-top': '20px','padding-bottom': '20px','margin-top': '-20px'},{
					duration: 'slow',
					easing: 'easeOutCirc'
				});
				jQuery(this).siblings().removeClass('active');
			}, function() {
				jQuery(this).animate({'padding-top': '0px','padding-bottom': '0px','margin-top': '0px'},{
					duration: 'slow',
					easing: 'easeOutCirc'
				});
			}
		);
			
		jQuery('.pricetable .block').eq(0).addClass('first');
		jQuery('.pricetable .block').eq(1).addClass('second active');
		jQuery('.pricetable .block').eq(2).addClass('third');
		jQuery('.pricetable .block').eq(3).addClass('fourth');

	}
/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
FUNCTION CALLBACKS
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/
jQuery(function(){
   	jQuery(".sf-menu").superfish({ 
            pathClass:  'current' 
    }); 
	atp_sociables();
	jQuery('.sf-menu').mobileMenu();
	hoverimage();
	sys_toggle();
	pricingboxes();
	jQuery("ul.tabs").tabs(".panes > .tab_content", {tabs:'li',effect: 'fade', fadeOutSpeed: -600,fadeInSpeed: -100});

	//To switch directions up/down and left/right just place a "-" in front of the top/left attribute
	//Vertical Sliding
	jQuery('.plan_box').hover(function(){
		jQuery(".plan_info", this).fadeOut(500);
	}, function() {
		jQuery(".plan_info", this).fadeIn(500);
	});
});	
