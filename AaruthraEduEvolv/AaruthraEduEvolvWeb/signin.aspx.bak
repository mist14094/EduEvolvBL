<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="signin" Codebehind="signin.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8">
    <title>Subscription Signup | Marketo</title>
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
                                message: '* Password is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txt_username.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: '* Username is required and can\'t be empty'
                            }
                        }
                    }
                }

//            })
//            .on('success.form.bv', function (e) {
//                // Prevent submit form
//                e.preventDefault();
//                var $form = $(e.target),
//                validator = $form.data('bootstrapValidator');
//               
//                $.ajax({
//                    url: 'App_Code/WebMethodsCalls.cs/insertUser',
//                    type: 'POST',
//                  dataType:'JSON',
//                contentType: "application/json; charset=utf-8",
//                data: '{FirstName: "' + validator.getFieldElements('txt_firstname').val() + '",+ LastName: "' + validator.getFieldElements('txt_lastname').val() + '",+ CompanyName: "' + validator.getFieldElements('txt_companyname').val() + '",+ Address: "' + validator.getFieldElements('txt_address').val() + '",+ City: "' + validator.getFieldElements('txt_city').val() + '" ,+ State: "' + validator.getFieldElements('txt_state').val() + '" ,+ Pincode: "' + validator.getFieldElements('txt_Pincode').val() + '" ,+ Phone: "' + validator.getFieldElements('txt_phone').val() + '" ,+ Email: "' + validator.getFieldElements('txt_email').val() + '" ,+ Username: "' + validator.getFieldElements('txt_username').val() + '" ,+ Password: "' + validator.getFieldElements('txt_passowrd').val() + '" }',
//                

//                   // data: storeManager: '', uuid:'' ,
//                    success: function (result) {
//                        $form.find('.alert').html('Thanks for signing up. Now you can sign in as ' + result) ; //validator.getFieldElements('txt_username').val()).show();

//                    },
//                    failure:function(result) {
//                        $form.find('.alert').html('Thanks for signing up. Now you can sign in as ' + result); //validator.getFieldElements('txt_username').val()).show(); 
//                    }
//                    
//                });

                
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <div class="row">
        <section>
    <div class="page-header">
                    <h1> User Login</h1>
                </div>
                <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
    <div class="col-lg-8 col-lg-offset-2">


    <div class="form-group">
        <label class="col-lg-3 control-label">
            Login ID:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_username"  ClientIDMode="Static" runat="server" type="text" name="txt_username" CssClass="form-control"  placeholder="User Name"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_username" />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Password:</label>
        <div class="col-lg-5">
             <asp:TextBox ID="txt_passowrd"  ClientIDMode="Static" runat="server" TextMode="Password" name="txt_passowrd" CssClass="form-control"  placeholder="Password"></asp:TextBox>
           
            <%--<input type="password" class="form-control" name="txt_passowrd" />--%>
        </div>
    </div>
     
     <div class="form-group">
                                <div class="col-lg-5 col-lg-offset-3">
                                    <div><a href="#"> <strong>Forgot Password?</strong></a> / <a href="register.aspx">  <strong>Create Account</strong> </a></div>
                                    
                                </div>
                            </div>
    <div class="form-group">
        <div class="col-lg-9 col-lg-offset-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Login" 
                        class="btn btn-primary" onclick="btnSubmit_Click1"/>
            <%--<button type="submit" class="btn btn-primary" runat="server" OnServerClick="Submit_Click" CausesValidation="True">
                Login</button>--%>
        </div>
    </div>
    </div>
    </section>
    </div>
    
</asp:Content>
