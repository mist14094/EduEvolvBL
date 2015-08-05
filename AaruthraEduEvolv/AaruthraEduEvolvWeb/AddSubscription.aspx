<%@ Page Language="C#" AutoEventWireup="true" Inherits="AddSubscription" CodeBehind="AddSubscription.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>Veera's Education</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet'
        type='text/css'>
    <link href="css/bootstrap3.min.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap3.min.js"></script>
    <script src="js/uri.js"></script>
    <link rel="stylesheet" href="validation/bootstrap.css" />
    <link rel="stylesheet" href="validation/bootstrapValidator.css" />
    <script type="text/javascript" src="validation/jquery.min.js"></script>
    <script type="text/javascript" src="validation/bootstrap.min.js"></script>
    <script type="text/javascript" src="validation/bootstrapValidator.js"></script>
     <script type="text/javascript" src="validation/jquery.cookie.js"></script>
    <style>
        *
        {
            font-family: "Open Sans" , sans-serif !important;
            font-weight: "300";
        }
        
        .embed-container
        {
            position: relative;
            padding-bottom: 56.25%; /*padding-top: 30px; */
            height: 0;
            overflow: hidden;
        }
        
        .embed-container-squarish
        {
            position: relative;
            padding-bottom: 120%; /*padding-top: 30px; */
            height: 0;
            overflow: hidden;
        }
        
        .embed-container iframe, .embed-container object, .embed-container embed
        {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
        }
        
        .codebox
        {
            width: 97%;
            font-family: monospace !important;
            font-size: 14px;
        }
        
        .pad-right
        {
            padding-right: 15px;
        }
        
        .well
        {
            min-height: 120px;
            margin-bottom: 70px;
        }
        
        .control-label
        {
            padding-top: 5px;
        }
        
        @media only screen and (max-device-width: 480px)
        {
            .inputfix
            {
                width: 66% !important;
            }
        }
        
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px)
        {
            .inputfix
            {
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
<body runat="server">
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
                    <asp:HyperLink ID="HyperLink1" runat="server" style="color: white" Text="Subscription" NavigateUrl="CourseSubscription.aspx"></asp:HyperLink> &nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="hpVerifyPayment" runat="server" style="color: white" Text="Payment Verfication" NavigateUrl="PaymentVerification.aspx"></asp:HyperLink> &nbsp;&nbsp;&nbsp;
                   <asp:HyperLink ID="hpSubscribe" runat="server" style="color: white" Text="Subscription Mgmnt." NavigateUrl="AddSubscription.aspx"></asp:HyperLink> &nbsp;&nbsp;&nbsp; Welcome <asp:Label runat="server" ID="lblUserName"></asp:Label>
                    <a href="CourseDetails.aspx" role="button" class="btn btn-info navbar-btn" >Home</a> 
                    <asp:Button runat="server" ID="btnLogOff" role="button" 
                        class="btn btn-info navbar-btn" Text="Log off" onclick="btnLogOff_Click" />
                    
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        
        <!-- /.container-fluid -->
        </div>
    </nav>
    <div class="container">
       
    
           
               
     
    <div class="page-header">
                    <h1>Subscription Management</h1>
                </div>
            
    <div>
        Select User : <asp:DropDownList runat="server" ID="ddlUserList" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlUserList_SelectedIndexChanged"/>
        <br/>
        <br/>

        <asp:GridView ID="gvSubscription"  AutoGenerateColumns="False" GridLines="Horizontal" Width="100%"  runat="server" DataKeyNames="SubscriptionID"
             BackColor="White" BorderColor="#336666" BorderWidth="3px" CellPadding="4"  ><%--AllowPaging="True" PageSize="10"--%>
        <Columns>
            
        <asp:TemplateField HeaderText="Subscription ID">
        <ItemTemplate>
            <asp:Literal ID="SubscriptionID" runat="server" 
            Text='<%# Eval("SubscriptionID") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="User ID">
        <ItemTemplate>
            <asp:Literal ID="ltrlUserID" runat="server" 
            Text='<%# Eval("UserID") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="Course ID">
        <ItemTemplate>
            <asp:Literal ID="ltrlCourseID" runat="server" 
            Text='<%# Eval("CourseID") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="Activation Date">
        <ItemTemplate>
            <asp:Literal ID="ltrlActivationDate" runat="server" 
            Text='<%# Eval("ActivationDate") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
      <asp:TemplateField HeaderText="Expiration Date">
        <ItemTemplate>
            <asp:Literal ID="ltrlExpirationDate" runat="server" 
            Text='<%# Eval("ExpiredOn") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
             <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
            <asp:HyperLink NavigateUrl='<%#string.Concat("ChangeSubscription.aspx?ID=", Eval("SubscriptionID")) %>' Text="Edit" runat="server"/>
             </ItemTemplate>
       </asp:TemplateField>

        </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
            <EmptyDataTemplate>
                <div style="text-align: center; margin: 2% ">No Subscription Found
                    <br/>
                <br/> Set Expiration Date for Free Test Plan <br/><br/> <center> <asp:Calendar  ID="Calendar1" runat="server"></asp:Calendar>
                    
                    <br/><asp:Button runat="server" ID="btnActivate" Text="Activate" OnClick="btnActivate_OnClick"/>
                <br/>    <asp:Label runat="server" ID="idError" Text=""></asp:Label>
                                          </center></div>
            </EmptyDataTemplate>
        </asp:GridView>  
    </div>


               
                <br />
                <br />
                <br />
 
 
    </div>
    <!--footer-->
    <nav class="navbar navbar-default navbar-fixed-bottom" role="navigation">
        <div class="container">
            <p class="text-muted text-center" style="padding-top: 12px">
                <small><a target="_blank" href="http://aaruthra.com/">Powered by Aaruthra Technologies</a>.
                    © 2015 - Veera's Education</small></p>
        </div>
    </nav>
    <!-- about box -->
    <div id="about" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        About us</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <strong>Veera's Education</strong> is formed by group of experienced and dedicated
                        professionals, acadamacians in 2012 with one core concept in mind: to provide affordable,
                        professional technology services to small & medium organizations. Our team consists
                        of award winning experienced programmers and talented desgin professionals. We utilise
                        a comprehensive development approach to define your goals, establish your objectives,
                        and provide you with the most effective solutions that are tailored to meet your
                        needs and philosophy.</p>
                </div>
                <div class="modal-footer">
                    <div class="pull-left">
                        Powered by <a target="_blank" href="http://aaruthra.com/">Aaruthra Technologies</a></div>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        OK</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
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
