<%@ Page Language="C#" AutoEventWireup="true" Inherits="Video" CodeBehind="Video.aspx.cs" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
  <head id="Head1" runat="server">
    <title>Veera's Education</title>
	
	<!-- based on work by Theirry Koblentz http://alistapart.com/article/creating-intrinsic-ratios-for-video -->
	<!-- and Anders Andersen http://amobil.se/2011/11/responsive-embeds/ -->
	
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">

	<link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
	
	<link href="css/bootstrap3.min.css" rel="stylesheet">
	<link href="css/animate.css" rel="stylesheet">
	<script src="js/jquery.min.js"></script>
	<script src="js/bootstrap3.min.js"></script>   
    <script src="js/uri.js"></script>
	
	<style>

	* {
		font-family: "Open Sans", sans-serif !important;
		font-weight: "300";
	}
	
	.embed-container {
		position: relative; 
		padding-bottom: 56.25%; 
		/*padding-top: 30px; */
		height: 0; 
		overflow: hidden; 
	} 

	.embed-container-squarish {
		position: relative; 
		padding-bottom: 120%; 
		/*padding-top: 30px; */
		height: 0; 
		overflow: hidden; 
	} 
	
	.embed-container iframe, 
	.embed-container object, 
	.embed-container embed { 
		position: absolute; 
		top: 0; 
		left: 0; 
		width: 100%; 
		height: 100%; 
	}
	
	.codebox {
		width: 97%;
		font-family: monospace !important; 
		font-size: 14px;
	}
	
	.pad-right {
			padding-right: 15px;
	}
	
	.well {
			min-height: 120px;
			margin-bottom: 70px;
	}
	
	.control-label {
			padding-top:5px;
	}
	
	@media only screen and (max-device-width: 480px) {
		.inputfix {
			width: 66% !important;
		}
	}
	
	@media only screen and (min-device-width: 768px) and (max-device-width: 1024px) {
		.inputfix {
			width: 66% !important;
		}
	}
			
	</style>
	
	<script>

	    var embedLabel = "<br/><p class='control-label'>Embed code:</p>";
	    var embedContainerCSS = "&lt;style&gt;.embed-container { position: relative; padding-bottom: 56.25%; height: 0; overflow: hidden; max-width: 100%; } .embed-container iframe, .embed-container object, .embed-container embed { position: absolute; top: 0; left: 0; width: 100%; height: 100%; }&lt;/style&gt;";
	    var embedGettyContainerCSSFront = "&lt;style&gt;.embed-container { position: relative; padding-bottom: ";
	    var embedGettyContainerCSSBack = "%; height: 0; overflow: hidden; max-width: 100%; } .embed-container iframe, .embed-container object, .embed-container embed { position: absolute; top: 0; left: 0; width: 100%; height: 100%; }&lt;/style&gt;";
	    var embedSquareContainerCSS = "&lt;style&gt;.embed-container {position: relative; padding-bottom: 100%; height: 0; overflow: hidden;} .embed-container iframe, .embed-container object, .embed-container embed { position: absolute; top: 0; left: 0; width: 100%; height: 100%; }&lt;/style&gt;";
	    var embedSquarishContainerCSS = "&lt;style&gt;.embed-container {position: relative; padding-bottom: 120%; height: 0; overflow: hidden;} .embed-container iframe, .embed-container object, .embed-container embed { position: absolute; top: 0; left: 0; width: 100%; height: 100%; }&lt;/style&gt;";
	    var embedContainerDivOpen = "&lt;div class='embed-container'&gt;";
	    var embedContainerDivClose = "&lt;/div&gt;";

	    var previewLabel = "<p class='control-label'>Preview:</p>";
	    var previewPrefix = "<div class='embed-container'>";
	    var previewPrefixSquarish = "<div id='squarish' class='embed-container'>";
	    var previewPrefixGettyFront = "<div id='getty' class='embed-container'";
	    var previewSuffix = "</div>";



	    function createVimeoEmbed() {
	        var vimeoURL = $("#vimeo-url").val();
	        var protocol = vimeoURL.slice(0, 5);
	        if (protocol == "https") {
	            //then the video is served via https, doy
	            var vimeoID = vimeoURL.substring(18);
	        } else {
	            protocol = "http";
	            var vimeoID = vimeoURL.substring(17);
	        }

	        var vimeoEmbed = "&lt;iframe src='" + protocol + "://player.vimeo.com/video/" + vimeoID + "' frameborder='0' webkitAllowFullScreen mozallowfullscreen allowFullScreen&gt;&lt;/iframe&gt;";
	        var vimeopreview = "<iframe src='" + protocol + "://player.vimeo.com/video/" + vimeoID + "'  frameborder='0' webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";

	        $("#vimeoembedCode").html(embedLabel + "<textarea rows='12' class='codebox'>" + embedContainerCSS + embedContainerDivOpen + vimeoEmbed + embedContainerDivClose + "</textarea>");
	        $("#vimeopreview").html(previewLabel + previewPrefix + vimeopreview + previewSuffix);

	    }


	    function createGenericEmbed() {
	        var genericURL = $("#generic-url").val();
	        var escapediFrameURL = genericURL.replace(/\"/g, '\'');
	        var escapediFrameURLCode = escapediFrameURL.replace(/</g, '&lt;');
	        var escapediFrameURLCodeFinal = escapediFrameURLCode.replace(/>/g, '&gt;');

	        //alert(escapediFrameURL);
	        $("#genericembedNote").fadeIn();
	        $("#genericembedCode").html(embedLabel + "<textarea rows='12' class='codebox'>" + embedContainerCSS + embedContainerDivOpen + escapediFrameURLCodeFinal + embedContainerDivClose + "</textarea>");
	        $("#genericpreview").html(previewLabel + previewPrefix + escapediFrameURL + previewSuffix);

	    }
		
	</script>
	
  </head>
  <body id="Body1" runat="server">
	<form id="form1" runat="server">
	  <nav class="navbar navbar-static-top navbar-inverse" role="navigation">
	    <div class="container-fluid">
	      <!-- Brand and toggle get grouped for better mobile display -->
	      <div class="navbar-header">
	        <a class="navbar-brand" href="#about" data-toggle="modal" data-target="#about">
	            
                <img src="img/vlogo.png" />
	        </a>
	      </div>

	      <!-- Collect the nav links, forms, and other content for toggling -->
	      <div class="collapse navbar-collapse" id="bs-example-navbar-collapse">
	                      <ul class="nav navbar-nav navbar-right pad-right" style="color: white">
            Welcome <asp:Label runat="server" ID="lblUserName"></asp:Label>
                    <a href="CourseDetails.aspx" role="button" class="btn btn-info navbar-btn" >Home</a> 
                    <asp:Button runat="server" ID="btnLogOff" role="button" 
                        class="btn btn-info navbar-btn" Text="Log off" onclick="btnLogOff_Click" />
                    
                </ul>
	      </div><!-- /.navbar-collapse -->
	    </div><!-- /.container-fluid -->
	  </nav>
	    
	<div class="container">
		
  	  <div class="row hidden" id="lenscap-promo">
		  <strong><div class="alert text-center" role="alert" id="header" runat="server">
			  Title of the video
		  </div></strong>
	  </div>
		
	  <div class="row">
	    <div class="col-md-10 col-md-offset-1">
			
			<div class="visible-desktop" style="height: 12px"></div>
			
          

            
			  
              <div id="leTabContent" class="tab-content">
             
                <div class="tab-pane fade in active well" id="vimeo">
					
					<form>
					  <fieldset>
					    
						
						<br/><br/>

					  </fieldset>
					</form>
  	  			  
				  <div id="vimeopreview">
				        <style>.embed-container { position: relative; padding-bottom: 56.25%; height: 0; overflow: hidden; max-width: 100%; } .embed-container iframe, .embed-container object, .embed-container embed { position: absolute; top: 0; left: 0; width: 100%; height: 100%; }</style><div class='embed-container'><iframe runat="server" ID="player" src="https://player.vimeo.com/video/1275552"  frameborder='0' webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe></div>
                           <br/><br/>     <div runat="server" ID="Description"></div>
				  </div>
			  
      
  	  			  <div class="code" id="vimeoembedCode"></div>
				 <center>	<asp:Button ID="Button1" runat="server" Text="Practical Test" OnClick="Button1_Click" />    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <asp:Button ID="Button2" runat="server" Text="Speech Test" OnClick="Button2_Click" />	</center> 		       
				</div>
              </div>
			  
	    </div>
	  </div>
	</div>

	<!--footer-->
	<nav class="navbar navbar-default navbar-fixed-bottom" role="navigation">
	  <div class="container">
		<p class="text-muted text-center" style="padding-top: 12px"><small><a  target="_blank" href="http://aaruthra.com/">Powered by Aaruthra Technologies</a>. 
		 ©  2015 - Veera's Education</small></p>
	  </div>
	</nav>

	<!-- about box -->
	<div id="about" class="modal fade">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <h4 class="modal-title">About us</h4>
	      </div>
	      <div class="modal-body">
			  
	  		<p><strong>Veera's Education</strong>  is formed by group of experienced and dedicated professionals, acadamacians in 2012 with one core concept in mind: to provide affordable, professional technology services to small & medium organizations. Our team consists of award winning experienced programmers and talented desgin professionals. We utilise a comprehensive development approach to define your goals, establish your objectives, and provide you with the most effective solutions that are tailored to meet your needs and philosophy.</p>
		
	  			
	      </div>
	      <div class="modal-footer">
			  <div class="pull-left">Powered by <a target="_blank" href="http://aaruthra.com/">Aaruthra Technologies</a></div>
	        <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>
	      </div>
	    </div><!-- /.modal-content -->
	  </div><!-- /.modal-dialog -->
	</div><!-- /.modal -->
		
	<script>

	    $('#lenscap-promo').addClass('animated bounceInDown');
	    $('#lenscap-promo').removeClass('hidden');

	    (function (i, s, o, g, r, a, m) {
	        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
	            (i[r].q = i[r].q || []).push(arguments)
	        }, i[r].l = 1 * new Date(); a = s.createElement(o),
	  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
	    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

	    ga('create', 'UA-59418-18', 'embedresponsively.com');
	    ga('send', 'pageview');

	</script>
	
    </form>
  </body>

</html>
