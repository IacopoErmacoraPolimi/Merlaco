<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="accessnotallowed.aspx.cs" Inherits="error_accessnotallowed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
      Unfortunately you don't have the rights to access this page.<br /><br />
      Please return to the <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products/products.aspx" runat="server">home page</asp:HyperLink> and try again. 
   </h3> 
</asp:Content>

