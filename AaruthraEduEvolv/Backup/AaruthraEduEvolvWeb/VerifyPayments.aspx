<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="VerifyPayments" Codebehind="VerifyPayments.aspx.cs" %>
<%@ Import Namespace="System.Activities.Expressions" %>
<%@ Import Namespace="System.ServiceModel.Activities.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8">
    <title>Subscription Signup | Marketo</title>
    <link rel="stylesheet" href="validation/bootstrap.css" />
    <link rel="stylesheet" href="validation/bootstrapValidator.css" />
    <script type="text/javascript" src="validation/jquery.min.js"></script>
    <script type="text/javascript" src="validation/bootstrap.min.js"></script>
    <script type="text/javascript" src="validation/bootstrapValidator.js"></script>
     <script type="text/javascript" src="validation/jquery.cookie.js"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    
    <div class="row">
        <section>
    <div class="page-header">
                    <h1>Payment Verify</h1>
                </div>
                <div class="alert alert-success" style="display: none;" runat="server" ID="alert"></div>
    <div>
        <asp:GridView ID="gvPayments" AutoGenerateColumns="False" GridLines="None" runat="server" DataKeyNames="payment_id" onrowcommand="gridMembersList_RowCommand"  ><%--AllowPaging="True" PageSize="10"--%>
        <Columns>
            
        <asp:TemplateField HeaderText="Payment ID">
        <ItemTemplate>
            <asp:Literal ID="ltrlpayment_id" runat="server" 
            Text='<%# Eval("payment_id") %>'></asp:Literal>
            
            <asp:Literal ID="ltrlTransactionID" runat="server" 
            Text='<%# Eval("TransactionID") %>' Visible="False"></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="Buyer Name">
        <ItemTemplate>
            <asp:Literal ID="ltrlbuyer_name" runat="server" 
            Text='<%# Eval("buyer_name") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount">
        <ItemTemplate>
            <asp:Literal ID="ltrlamount" runat="server" 
            Text='<%# Eval("amount") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField HeaderText="Title">
        <ItemTemplate>
            <asp:Literal ID="ltrloffer_title" runat="server" 
            Text='<%# Eval("offer_title") %>'></asp:Literal>
        </ItemTemplate>
       </asp:TemplateField>
        
        <asp:TemplateField HeaderText="verify">
        <ItemTemplate>
           
     <asp:Button ID="btnViewmore"  class="btn btn-primary"
            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Verify" runat="server" Text="Verify" Visible='<%# VerifiyValue(Eval("verified")) %>' />

    <asp:Literal ID="ltrlVirifiedtitle" runat="server" Visible='<%# !VerifiyValue(Eval("verified")) %>' 
            Text='Verified'></asp:Literal>


            
             
        </ItemTemplate>
        </asp:TemplateField> 
        </Columns>
        </asp:GridView>  
    </div>
    </section>
    </div>
</asp:Content>
