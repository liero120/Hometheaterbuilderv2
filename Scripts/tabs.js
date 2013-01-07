/***************************/
//@Author: Adrian "yEnS" Mato Gondelle & Ivan Guardado Castro
//@website: www.yensdesign.com
//@email: yensamg@gmail.com
//@license: Feel free to use it, but keep this credits please!					
/***************************/

var mylinks = new Array("htpc", "mediaplayer", "television", "audio", "control", "forum", "wishlist");

$(document).ready(function(){
	$(".menu > li").click(function(e){
		switch(e.target.id){
			case "htpc":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "htpc")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
						$("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "htpc")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
					    $("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			case "television":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "television")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
						$("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "television")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
						$("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			
			case "mediaplayer":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "mediaplayer")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
						$("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "mediaplayer")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
						$("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			
			case "audio":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "audio")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
						$("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "audio")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
						$("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			
			case "control":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "control")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
						$("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "control")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
						$("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			
			case "forum":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "forum")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
						$("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "forum")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
						$("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			
			case "wishlist":
				//change status & style menu
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "wishlist")
					{
						$("#" + mylinks[i]).removeClass("active");
					}
					else
					{
					    $("#" + mylinks[i]).addClass("active");
					}
				}
				
				//display selected division, hide others
				for (var i=0; i < mylinks.length; i++)
				{
					if(mylinks[i] != "wishlist")
					{
						$("div." + mylinks[i]).css("display", "none");
					}
					else
					{
						$("div." + mylinks[i]).fadeIn();
					}
				}			
			break;
			/*case "htpc":
				//change status & style menu
				$("#news").removeClass("active");
				$("#tutorials").removeClass("active");
				$("#htpc").addClass("active");
				
				
				//display selected division, hide others
				$("div.htpc").fadeIn();
				$("div.news").css("display", "none");
				$("div.tutorials").css("display", "none");
			break;*/
			default:
			//change status & style menu
				for (var i=0; i < mylinks.length + 1; i++)
				{
						$("#" + mylinks[i]).removeClass("active");
						$("div." + mylinks[i]).css("display", "none");
				}			
		}
		//alert(e.target.id);
		return false;
	});
});