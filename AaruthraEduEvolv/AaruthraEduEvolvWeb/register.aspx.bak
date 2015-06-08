<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="register" Codebehind="register.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    <%=txt_username.UniqueID%>: {
                        message: 'The username is not valid',
                        validators: {
                            notEmpty: {
                                message: 'The username is required and can\'t be empty'
                            },
                            stringLength: {
                                min: 6,
                                max: 30,
                                message: 'The username must be more than 6 and less than 30 characters long'
                            },
                            regexp: {
                                regexp: /^[a-zA-Z0-9_\.]+$/,
                                message: 'The username can only consist of alphabetical, number, dot and underscore'
                            }
                        }
                    },
                    <%=txt_firstname.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The First Name is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txt_lastname.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The Last Name is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txt_address.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The Address is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txt_city.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The City is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txt_state.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The State is required and can\'t be empty'
                            }
                        }
                    },
                    acceptTerms: {
                        validators: {
                            notEmpty: {
                                message: 'You have to accept the terms and policies'
                            }
                        }
                    },
                    <%=txt_email.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The email address is required and can\'t be empty'
                            },
                            emailAddress: {
                                message: 'The input is not a valid email address'
                            }
                        }
                    },
                    website: {
                        validators: {
                            uri: {
                                allowLocal: true,
                                message: 'The input is not a valid URL'
                            }
                        }
                    },
                    <%=txt_phone.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The mobile number is required and can\'t be empty'
                            },
                            stringLength: {
                                min: 10,
                                max: 10,
                                message: 'The mobile number must be 10 digit'
                            },
                            integer: true
                        }

                    },
//                    color: {
//                        validators: {
//                            color: {
//                                type: ['hex', 'rgb', 'hsl', 'keyword'],
//                                message: 'Must be a valid %s color'
//                            }
//                        }
//                    },
                    colorAll: {
                        validators: {
                            color: {}
                        }
                    },
                    <%=txt_Pincode.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The pincode is required and can\'t be empty'
                            },
                            stringLength: {
                                min: 6,
                                max: 6,
                                message: 'The pincode number must be 6 digit'
                            },
                            integer: true
                        }
                    },
                    <%=txt_passowrd.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'The password is required and can\'t be empty'
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
                    },
                    ages: {
                        validators: {
                            lessThan: {
                                value: 100,
                                inclusive: true,
                                message: 'The ages has to be less than 100'
                            },
                            greaterThan: {
                                value: 10,
                                inclusive: false,
                                message: 'The ages has to be greater than or equals to 10'
                            }
                        }
                    }
                }

            });
//            .on('success.form.bv', function (e) {
//                // Prevent submit form
//                e.preventDefault();
//               // var $form = $(e.target),
//                //validator = $form.data('bootstrapValidator');

//               return  bootstrapValidator();
//            });
//            $('#btnSubmit').on('click', function() {
//                $("#defaultForm").valid();
//            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <div class="row">
        <section>
    <div class="page-header">
                    <h1>New User Registration</h1>
                </div>
                <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
    <div class="col-lg-8 col-lg-offset-2">

    <div class="form-group">
        <label class="col-lg-3 control-label">
            First Name:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_firstname"  ClientIDMode="Static" runat="server" type="text" name="txt_firstname" CssClass="form-control"  placeholder="First Name" ></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_firstname" ClientIDMode="Static" ID="txt_firstname" runat="server" />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Last Name:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_lastname"  ClientIDMode="Static" runat="server" type="text" name="txt_lastname" CssClass="form-control"  placeholder="Last Name" ></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_lastname"  />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Company Name:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_companyname"  ClientIDMode="Static" runat="server" type="text" name="txt_companyname" CssClass="form-control"  placeholder="Company Name (Optional)"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_companyname"  />--%>
        </div>
    </div>
     <legend>Address Details</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Address:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_address"  ClientIDMode="Static" runat="server" type="text" name="txt_address" CssClass="form-control"  placeholder="Address"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_address"  />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            City:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_city"  ClientIDMode="Static" runat="server" type="text" name="txt_city" CssClass="form-control"  placeholder="City"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_city"  />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            State:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_state"  ClientIDMode="Static" runat="server" type="text" name="txt_state" CssClass="form-control"  placeholder="State"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_state"  />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Pincode:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_Pincode"  ClientIDMode="Static" runat="server" type="text" name="txt_Pincode" CssClass="form-control"  placeholder="Pinode"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_Pincode"  />--%>
        </div>
    </div>
     <legend>Contact details</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Phone:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_phone"  ClientIDMode="Static" runat="server" type="text" name="txt_phone" CssClass="form-control"  placeholder="Mobile"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_phone" />--%>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Email:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_email"  ClientIDMode="Static" runat="server" type="text" name="txt_email" CssClass="form-control"  placeholder="Email"></asp:TextBox>
            <%--<input type="text" class="form-control" name="txt_email"  />--%>
        </div>
    </div>
    <legend>Login Information</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Username:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_username"  ClientIDMode="Static" runat="server" type="text" name="txt_username" CssClass="form-control"  placeholder="Email"></asp:TextBox>
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
        <label class="col-lg-3 control-label">
            Conform:</label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_cpassowrd"  ClientIDMode="Static" runat="server" TextMode="Password" name="txt_cpassowrd" CssClass="form-control"  placeholder="Password"></asp:TextBox>
           <%-- <input type="password" class="form-control" name="txt_cpassowrd" />--%>
        </div>
    </div>
     <div class="form-group">
                                <div class="col-lg-5 col-lg-offset-3">
                                    <div class="checkbox">
                                        <input type="checkbox" name="acceptTerms" /> Accept the terms and policies
                                    </div>
                                </div>
                            </div>
    <div class="form-group">
        <div class="col-lg-9 col-lg-offset-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Register Me" 
                        class="btn btn-primary" onclick="btnSubmit_Click"/>
            <%--<button name="btnSubmit" ClientIDMode="Static"  ID="btnSubmit" type="submit" class="btn btn-primary" runat="server" OnServerClick="Submit_Click" CausesValidation="True"> Submit
             </button>--%>
        </div>
    </div>
    </div>
    </section>
    </div>
    
</asp:Content>
