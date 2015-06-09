<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AaruthraEduEvolvWeb.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	<div id="subheader">
    <img src="images/map.jpg" />
				<div id="map" >
                    
                </div>
			</div>
			<!-- End subheader ####################### -->
						
			<div class="pagemid">
				<div class="maincontent">
					
						
					<div id="main">

						<div class="content">
							
							<div class="fullwidth">
							
								
								<h3>Directions</h3>
								<p>We are located conveniently in Engineering College road, next to fly over. We are just upstairs to vellicham super market. Visit us; We will help you to open up your horizons. </p>						
							
								<h3>Send Us Message</h3>
								<div id="result"></div>
								<div class="sysform">
									<form action="#" method="post" class="form">

										<p class="name">
										
                                            <asp:TextBox runat="server" ID="txtName" Text=""></asp:TextBox>
											<label for="name">Name</label>
										</p>

										<p class="email">
										  <asp:TextBox runat="server" ID="txtEmail" Text=""></asp:TextBox>
											<label for="email">E-mail</label>
										</p>

										<p class="web">
											  <asp:TextBox runat="server" ID="txtWebsite" Text=""></asp:TextBox>
											<label for="web">Website</label>
										</p>

										<p class="text">
											
                                              <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" Text=""></asp:TextBox>
                                              
                                             
										</p>

							<asp:Label ID = "lblNumber1" runat="server" Text=""></asp:Label> + 
                            <asp:Label ID="lblNumber2" runat="server" Text=""></asp:Label>
                            =
                            <asp:TextBox runat="server" ID="txtAnswer" Text="" Width="52px"></asp:TextBox><br/>
                            <br/>
                                        <p class="submit">
                                        <asp:Button runat="server" class="button large blue" ID="SendEmail" Text="Submit" 
                                                onclick="SendEmail_Click"/>
                                        </p>
                                        
                                        <br/>
                                        <asp:Label runat="server" ID="lblResult" Text=""></asp:Label>
									</form>
								</div>
							
							</div>

						</div><!-- content -->
					</div><!-- main -->
				</div><!-- maincontent -->
			</div><!-- pagemid -->
</asp:Content>

