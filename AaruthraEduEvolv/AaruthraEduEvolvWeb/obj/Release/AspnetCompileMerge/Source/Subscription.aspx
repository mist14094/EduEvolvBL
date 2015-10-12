<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Subscription.aspx.cs" Inherits="AaruthraEduEvolvWeb.Subscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Veera's Education</title>
    <!-- based on work by Theirry Koblentz http://alistapart.com/article/creating-intrinsic-ratios-for-video -->
    <!-- and Anders Andersen http://amobil.se/2011/11/responsive-embeds/ -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet'
        type='text/css'>
    <link href="css/bootstrap3.min.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap3.min.js"></script>
    <script src="js/uri.js"></script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <nav class="navbar navbar-static-top navbar-inverse" role="navigation">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <a class="navbar-brand" href="#about" data-toggle="modal" data-target="#about">
                    <img src="img/vlogo.png" />
                </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            < class="collapse navbar-collapse" id="bs-example-navbar-collapse">
                <ul class="nav navbar-nav navbar-right pad-right" style="color: white">
            Welcome <asp:Label runat="server" ID="lblUserName"></asp:Label>
                    <a href="CourseDetails.aspx" role="button" class="btn btn-info navbar-btn" >Home</a> 
                    <asp:Button runat="server" ID="btnLogOff" role="button" 
                        class="btn btn-info navbar-btn" Text="Log off" />
                    
                </ul>
            </div>
            <!-- /.navbar-collapse -->
<b>There is no act
        <!-- /.container-fluid -->
    </nav>
    <div class="container">
        <div class="row hidden" id="lenscap-promo">
            <div class="alert text-center" role="alert" runat="server" id="header">
                <%-- <a  href=""><strong>Title of the video</strong>!</a>--%>
            </div>
        </div>
    <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="visible-desktop" style="height: 12px">
                </div>
                <asp:ListView ID="ListView1" GroupItemCount="4" runat="server" DataKeyNames="CourseID"  >
                    <LayoutTemplate>
                        <table cellpadding="2" runat="server" id="tblProducts" style="height: 320px">
                            <tr runat="server" id="groupPlaceholder">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr runat="server" id="productRow" style="height: 80px">
                            <td runat="server" id="itemPlaceholder">
                            </td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td id="Td1" valign="top" align="center" style="width: 300px;" runat="server">
                             <asp:ImageButton ID="ProductImage" runat="server"  style="margin-bottom:10px" Width="75%" 
           ImageUrl='<% #Eval("Thumbnail")%>' PostBackUrl='<% # string.Concat("CourseList.aspx?CourseID= " , Eval("CourseID"))%>' />
           <br />
                            <div style="font-weight: bold">
                                <asp:HyperLink ID="ProductLink" runat="server" Text='<% #Eval("CourseName")%>' Target="_blank"
                                    NavigateUrl='<% # string.Concat("CourseList.aspx?CourseID=" , Eval("CourseID"))%>' /></div>
                            <br />
                            <br />
                        </td>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                      <center> <b>There is no active course set for you, You can buy more course.<br/> <asp:Button runat="server" ID="btnBuyPlan" Text="Buy More" /></b> </center>
                    </EmptyDataTemplate>
                </asp:ListView>
                <br />
                <br />
                <br />
            </div>
        </div>
        </div>
     </b>
</asp:Content>
