<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="AaruthraEduEvolvWeb.PasswordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Account Activation</title>
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
                    
                    <%=txt_passowrd.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The password is required and can\'t be empty'
                            },
                            stringLength: {
                                min: 6,
                                max: 30,
                                message: 'The username must be more than 6 and less than 30 characters long'
                            },
                            identical: {
                                field: 'confirmPassword',
                                message: 'The password and its confirm are not the same'
                            }
                        }
                    },
                    <%=txt_cpassowrd.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The confirm password is required and can\'t be empty'
                            },
                            identical: {
                                field: '<%=txt_passowrd.UniqueID %>',
                                message: 'The password and its confirm are not the same'
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
                    <h1>Reset Password</h1>
                </div>
                <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
                </section>
                </div>
<div class="row" style="display:block;" runat="server" ID="ChangePassword">
        <section>
    <div class="col-lg-8 col-lg-offset-2">
    
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Password:</label>
        <div class="col-lg-5">
             <asp:TextBox ID="txt_passowrd"  ClientIDMode="Static" runat="server" TextMode="Password" name="txt_passowrd" CssClass="form-control"  placeholder="Password"></asp:TextBox>
           
            <%--<input type="password" class="form-control" name="txt_passowrd" />--%>
        </div>
    </div>
     <div class="form-group">
        <label class="col-lg-3 control-label">
            Conform:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_cpassowrd"  ClientIDMode="Static" runat="server" TextMode="Password" name="txt_cpassowrd" CssClass="form-control"  placeholder="Password"></asp:TextBox>
           <%-- <input type="password" class="form-control" name="txt_cpassowrd" />--%>
        </div>
    </div>
     
    <div class="form-group">
        <div class="col-lg-9 col-lg-offset-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Reset Password" 
                        class="btn btn-primary" onclick="btnSubmit_Click" />
                          </div>
    </div>
    </div>
    </section>
    </div>

</asp:Content>
