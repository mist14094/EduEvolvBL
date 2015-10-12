<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FirstLogin.aspx.cs" Inherits="AaruthraEduEvolvWeb.FirstLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
     <meta charset="utf-8">
    <title>Subscription Signup | Marketo</title>
    <link rel="stylesheet" href="validation/bootstrap.css" />
    <link rel="stylesheet" href="validation/bootstrapValidator.css" />
    <script type="text/javascript" src="validation/jquery.min.js"></script>
    <script type="text/javascript" src="validation/bootstrap.min.js"></script>
    <script type="text/javascript" src="validation/bootstrapValidator.js"></script>
     <script type="text/javascript" src="validation/jquery.cookie.js"></script>
     
    <asp:Panel ID="p" runat="server" >
    <div class="row">
        <section>
    <div class="page-header">
                    <h3> Thanks for sign up with us, We will help to get better in Hindi!!!</h3>
        <br /><br/>
        <h4>We sent you a confirmation email, Please check your email and confirm the subscription.</h4>
                </div>
                <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
    <div class="col-lg-8 col-lg-offset-2">



     
     <div class="form-group">
                                <div class="col-lg-5 col-lg-offset-3">
                                    <div style="align-content: center;"><a href="signin.aspx"> <strong>Click here to Login</strong></a> </div>
                                    
                                </div>
                            </div>
    <div class="form-group">
        <div class="col-lg-9 col-lg-offset-3">
       
            <%--<button type="submit" class="btn btn-primary" runat="server" OnServerClick="Submit_Click" CausesValidation="True">
                Login</button>--%>
        </div>
    </div>
    </div>
    </section>
    </div>
    </asp:Panel>
    
    

</asp:Content>
