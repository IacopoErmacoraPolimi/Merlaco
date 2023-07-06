<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="servererror.aspx.cs" Inherits="error_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
      We are currently experiencing an Internal Server Error...<br /><br />
      Please return to the <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products/products.aspx" runat="server">home page</asp:HyperLink> and try again. 
   </h3> 
</asp:Content>

