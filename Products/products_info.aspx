<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="products_info.aspx.cs" Inherits="Products_products_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="image-block">
        a
    </div>
    <div id="data-block">
        <h1>Product name</h1>
        <h2>123$</h2>
        <h3>123$/Kg</h3>
        <asp:Button ID="Button1" runat="server" Text="Add to Cart" />
        <asp:Button ID="Button2" runat="server" Text="Edit" />
        <asp:Button ID="Button3" runat="server" Text="Delete" />
    </div>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
</asp:Content>

