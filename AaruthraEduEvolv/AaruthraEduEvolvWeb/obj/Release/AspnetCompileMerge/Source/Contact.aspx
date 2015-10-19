<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AaruthraEduEvolvWeb.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    <%=txtName.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Name is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txtEmail.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Email is required and can\'t be empty'
                            },
                            emailAddress: {
                                message: 'The input is not a valid email address'
                            }
                        }
                    }, 
                    <%=txtPhone.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Phone No. is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txtAddress.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Address is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txtMessage.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Message is required and can\'t be empty'
                            }
                        }
                    },
                    <%=txtAnswer.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Answer is required and can\'t be empty'
                            }
                        }
                    }
                }


            });

        });
        $("#<%=txtAnswer.ClientID%>").keypress(function(e) {
            debugger;
            if (e.which == '13') {
                var btn = $("#<%=SendEmail.ClientID%>");
        btn.click();
    }
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="subheader">
        <img src="images/map.jpg" />
        <div id="map">
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



                        <%--<form id="SendMailForm" runat="server" action=""  method="post" class="form-horizontal">--%>
                        <div class="row">
                            <section>
                                <div class="page-header">
                                    <h3>Send Enquiry</h3>
                                </div>
                                <div class="col-lg-8 col-lg-offset-2">

                                    <div class="form-group">

                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" ID="txtName" Text="" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                        <label class="col-lg-2 control-Rlabel">
                                            Name</label>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" ID="txtEmail" Text="" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                        <label class="col-lg-2 control-Rlabel">
                                            E-mail</label>

                                    </div>
                                    <div class="form-group">

                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" ID="txtPhone" Text="" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                        <label class="col-lg-2 control-Rlabel">
                                            Phone No.</label>
                                    </div>

                                    <div class="form-group">

                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" ID="txtAddress" Text="" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                        <label class="col-lg-2 control-Rlabel">
                                            Address</label>
                                    </div>

                                    <div class="form-group">

                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" ID="txtCompanyName" Text="" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>

                                        </div>
                                        <label class="col-lg-2 control-Rlabel">
                                            Company Name</label>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-8">
                                            <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" Text="" CssClass="form-control" ClientIDMode="Static" placeholder="Message"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">
                                            <asp:Label ID="lblNumber1" runat="server" Text=""></asp:Label>
                                            + 
                           
                                            <asp:Label ID="lblNumber2" runat="server" Text=""></asp:Label>
                                            =
        
                                        </label>
                                        <div class="col-lg-2">
                                            <asp:TextBox runat="server" ID="txtAnswer" Text="" CssClass="form-control" ClientIDMode="Static"></asp:TextBox><br />

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-9 col-lg-offset-3">
                                            <asp:Button ID="SendEmail" runat="server" Text="Submit" ClientIDMode="Static"
                                                class="btn btn-primary" OnClick="SendEmail_Click" />

                                        </div>
                                    </div>

                                    <%--  <p class="submit">
                                        <asp:Button runat="server" class="button large blue" ID=""  ClientIDMode="Static" Text="Submit" 
                                                onclick="SendEmail_Click"/>
                                        </p>--%>

                                    <br />
                                </div>
                            </section>

                        </div>
                        <div class="alert alert-success" style="display: none;" runat="server" id="alert">
                            <asp:Label runat="server" ID="lblResult" Text=""></asp:Label>
                        </div>
                        <%--</form>--%>
                    </div>

                </div>
                <!-- content -->
            </div>
            <!-- main -->
        </div>
        <!-- maincontent -->
    </div>
    <!-- pagemid -->
</asp:Content>

