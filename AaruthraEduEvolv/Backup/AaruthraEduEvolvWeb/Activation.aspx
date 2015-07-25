<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="AaruthraEduEvolvWeb.Activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Account Activation</title>
    <link rel="stylesheet" href="validation/bootstrap.css" />
    <link rel="stylesheet" href="validation/bootstrapValidator.css" />
    <script type="text/javascript" src="validation/jquery.min.js"></script>
    <script type="text/javascript" src="validation/bootstrap.min.js"></script>
    <script type="text/javascript" src="validation/bootstrapValidator.js"></script>
     <script type="text/javascript" src="validation/jquery.cookie.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
</asp:Content>
