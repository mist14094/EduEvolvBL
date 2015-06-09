<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="AaruthraEduEvolvWeb.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="utf-8">
    <title>Subscription Signup</title>
    <link rel="stylesheet" href="validation/bootstrap.css" />
    <link rel="stylesheet" href="validation/bootstrapValidator.css" />
    <script type="text/javascript" src="validation/jquery.min.js"></script>
    <script type="text/javascript" src="validation/bootstrap.min.js"></script>
    <script type="text/javascript" src="validation/bootstrapValidator.js"></script>
     <script type="text/javascript" src="validation/jquery.cookie.js"></script>
     <script type="text/javascript">
        $(document).ready(function () {
            $('#defaultForm').bootstrapValidator({
                message: 'This value is not valid',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    <%=txt_EmailID.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The email address is required and can\'t be empty'
                            },
                            emailAddress: {
                                message: 'The input is not a valid email address'
                            }
                        }
                    }
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <section>
    <div class="page-header">
                    <h1>Reset Your Password</h1>
                </div>
                <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
    <div class="col-lg-8 col-lg-offset-2">
    

    <br />
    Forgot your password? Enter the e-mail address you used to create your account. We'll email you a link to a page where you can easily create a new password.

    <br />
   
    <br />
    <div class="form-group">
        <label class="col-lg-3 control-label">
            E-mail Address:</label>
        <div class="col-lg-5">
             <asp:TextBox ID="txt_EmailID"  ClientIDMode="Static" runat="server" TextMode="SingleLine" name="txt_EmailID" CssClass="form-control"  placeholder="Registered Email ID"></asp:TextBox>
           
            <%--<input type="password" class="form-control" name="txt_passowrd" />--%>
        </div>
    </div>
     
    <div class="form-group">
        <div class="col-lg-9 col-lg-offset-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Reset Password" ClientIDMode="Static"
                        class="btn btn-primary" onclick="btnSubmit_Click" />
            <%--<button type="submit" class="btn btn-primary" runat="server" OnServerClick="Submit_Click" CausesValidation="True">
                Login</button>--%>
        </div>
    </div>
    </div>
    </section>
    </div>
</asp:Content>
