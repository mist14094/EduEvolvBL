<%@ Page Title="" Language="C#"  AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1"  runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0">	
	
  <title>Veera's Education </title>
	
	<!-- Stylesheets -->
	<link rel="stylesheet" type="text/css" media="all" href="css/style.css" />
	<link rel="stylesheet" type="text/css" media="all" href="css/flexslider.css" />
	<link rel="stylesheet" type="text/css" media="all" href="css/prettyPhoto.css" />
	<!-- / Stylesheets -->

	<!-- Javascripts -->
	<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
	<script type="text/javascript" src="js/hoverIntent.js"></script>
	<script type="text/javascript" src="js/superfish.js"></script>
	<script type="text/javascript" src="js/jquery.tools.min.js"></script>
	<script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
	<script type="text/javascript" src="js/sys_custom.js"></script>
	<!-- / Javascripts -->		


	<!-- CSS & Script for for Responsive Layouts -->
	<link rel="stylesheet" type="text/css" media="screen" href="css/responsive.css" />
	<script type="text/javascript" src="js/jquery.mobilemenu.js"></script>
	<!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
	<![endif]-->
	<!-- / CSS & Script for for Responsive Layouts -->

	<!--[if lt IE 9]>
	<script src="js/html5.js"></script>
	<![endif]-->
    </head>
<body>

	<div id="boxed" class="fullwidth">
		<div id="wrapper">

			<header id="header">

				<div class="topbar">
					<div class="inner">

						
						<!-- /- .nav -->

						<ul class="atpsocials">
							<li><a class="facebook" href="#"><img src="images/sociables/facebook.png" /></a></li>
							<li><a class="twitter" href="#"><img src="images/sociables/twitter.png" /></a></li>
							<li><a class="dribbble" href="#"><img src="images/sociables/dribbble.png" /></a></li>
							<li><a class="pinterest" href="#"><img src="images/sociables/in.png" /></a></li>
							<li><a class="googleplus" href="#"><img src="images/sociables/googleplus.png" /></a></li>
						</ul>
						<!-- /- .atpsocials -->

					</div>
					<!-- /- .inner -->
				</div>
				<!-- /- .topbar -->

				<div id="head">

					<div class="logo">
						<a href="index-2.html"><img src="images/logo.png"></a>
					</div>
					<!-- /- .logo -->

					<nav>
						<div class="menu">
							<ul class="sf-menu">
								<li><a href="default.aspx">Home<span>Overview</span></a>
									
								</li>
								<li><a href="aboutus.aspx">About us<span>Who we are</span></a></li>
								<li><a href="services.aspx">Services<span>What we do</span></a></li>
								<li><a href="products.aspx">Products<span>What we offer</span></a>
									<ul>
										<li><a href="#">products1</a></li>
										<li><a href="#">products2</a></li>
										<li><a href="#">products3</a></li>
										<li><a href="#">products4</a></li>
									</ul>
								</li>
								
								
								<li><a href="contact.aspx">Contact<span>Get in Touch!</span></a></li>
                                <li><a href="signin.aspx">Login<span>Subscriber Login</span></a>
									<%--<ul>
										<li><a href="#">Columns</a></li>
										<li><a href="#">Typography</a></li>
										<li><a href="#">Icons</a></li>
										<li><a href="#">Tabs &amp; Toggles</a></li>
										<li><a href="#">Pricing Boxes</a></li>
									</ul>	--%>				
								</li>
							</ul>
						</div>
						<!-- /- .menu -->
					</nav>

				</div>
				<!-- /- #head -->	
			</header>
			<!-- /- <header> -->			
				
			<div id="featured_slider">
				<div class="slider_wrapper">

				<script type="text/javascript" src="js/jquery.flexslider-min.js"></script>
				<script type="text/javascript" charset="utf-8">
				    $(window).load(function () {
				        jQuery('.flexslider').flexslider();
				    });
				</script>
				<!-- /- <script> -->

					<div class="flexslider">
						<ul class="slides">

							<li>
								<a href="#"><img src="images/demo/slide1.png"  /></a>
							</li>
							<!-- / slide item -->
							<li>
								<img src="images/demo/slide2.png"  />
							</li>
							<!-- / slide item -->
							<li>
								<img src="images/demo/slide3.png"  />
							</li>
							<!-- / slide item -->
							<li>
								<img src="images/demo/slide4.png" />
								<div class="flex-caption">
									<div class="flex-title">Flex Title goes here</div>
									Captions and cupcakes. Winning combination.
								</div>
							</li>
							<!-- / slide item -->
						
						</ul>
					</div>
					<!-- /- .flexslider -->

				</div>
				<!-- /- .slider_wrapper -->
			</div>
			<!-- /- #featured_slider -->
			
			<div class="pagemid">
				<div class="maincontent">

					<div id="main">

						<div class="one_half">
							<h1>Fluid Layout</h1>
							<h4>Energetic HTML Template is Completely Fuild Layout with Boxed and Stretched Style</h4>
							<p>Fluid layout has a max-width range of 1280px wider and can be increased depending on your requirement without any hassle. Stretched Layout will have no shadow effect if applied.</p>
							<p>Change the layout to sidebar alignments including left/right and fullwidth by adding only one class to the main wrapper element of the layout.</p>
							<a href="#" class="button large orange"><span>more details</span></a>
						</div>
						<!-- /- .one_half -->
								
						<div class="one_half last">
							<figure>
								<span class="ribbon"><img src="images/ribbons/02.png"/></span>
								<img src="images/imac.png" />
							</figure>
						</div>
						<!-- /- .one_half last -->

						<div class="divider"></div>
						<!-- /- .divider -->

						<div class="one_fourth">
							<div class="fp-widget">
								<h3>Flexible Design</h3>
								<img alt="img" src="images/icon1.png" class="aligncenter" />
								<p>Maecenas id lorem nec antein nec venenatis condimentum. Curabitur commodo ipsum nibh iaculis.
								<br>
								<a href="#">Read more</a></p>
							</div>
						</div>
						<!-- /- .one_fourth -->

						<div class="one_fourth">
							<div class="fp-widget">
								<h3>Fluid Layout</h3>
								<img alt="img" src="images/icon2.png" class="aligncenter" />
								<p>Quisque elit purus id into Vivamus ipsumion dui, lobortis facilisis then placerat in, venenatis vel.
								<br>
								<a href="#">Read more</a></p>	
							</div>
						</div>
						<!-- /- .one_fourth -->

						<div class="one_fourth">
							<div class="fp-widget">
								<h3>Extensive Docs</h3>
								<img alt="img" src="images/icon3.png" class="aligncenter" />
								<p>Aenean egestas tristique justo, nec commodo orci Maecenas ultriciesn enim non luctus malesuada.
								<br>
								<a href="#">Read more</a></p>

							</div>
						</div>
						<!-- /- .one_fourth -->

						<div class="one_fourth last">
							<div class="fp-widget">
								<h3>Less Weight</h3>
								<img alt="img" src="images/icon4.png" class="aligncenter" />
								<p>Phasellus quam ipsum rutrum then aliquam rutrum ligula rictu lorem risus Sed vulputate tincidunt.
								<br>
								<a href="#">Read more</a></p>

							</div>
						</div>
						<!-- /- .one_fourth last -->
					
					</div>
					<!-- /- .main -->
				</div>
				<!-- /- .maincontent -->
			</div>
			<!-- /- .pagemid -->
			
            <footer id="footer">
				<div class="inner">
				
					<div class="one_fourth">
						<div class="widget_postslist">
							
						    
							<img src="images/lg.png" />
						</div>
					</div>
					<!-- /- .one_fourth -->
					
					<div class="one_fourth">
						<div class="syswidget">
				<h3>General Inquiries</h3>
							<p>For all general inquiries about the company, please use the contact form.</p>
					
						</div>
					</div>
					<!-- /- .one_fourth -->
					
					<div class="one_fourth">
						<div class="syswidget">
									<h3>Postal Address</h3>
							<p>Veera's Education,<br>
							2nd floor, Velichem Super Market Upstairs, Near Fly Over,<br>
							Engineering College Road, <br>
                            Annamalai Nagar, <br>Chidambaram - 608 002<br>
										
							
						</div>
					</div>
					<!-- /- .one_fourth -->
					
					<div class="one_fourth last">
						<div class="syswidget">
							<h3 class="widget-title">Get in Touch</h3>
							<p>Contact Person<br/>
							 +91 98941 69003 <br /> +91 97916 08122<br>
							mail id</p>						
						</div>
					</div>
					<!-- /- .one_fourth last -->

				</div>
				<!-- /- .inner(footer) -->
			</footer>
            <!-- /- <footer> -->
            <div class="copyright">
                <div class="inner">
                    <p>
                        © 2014 All Rights Reserved - Veera's Education - <a href="http://aaruthra.com/">Powered
                            By AARUTHRA TECHNOLOGIES</a> - <a href="#">Terms & Conditions</a> - <a href="#">Privacy
                                Policy</a></p>
                </div>
                <!-- /- .inner(copyright) -->
            </div>
            <!-
		<!-- /- #wrapper -->

	</div>
	<!-- /- #layout(boxed/stretched) -->
    <form id="Form1" runat="server"></form>
</body>
</body>
</html>
