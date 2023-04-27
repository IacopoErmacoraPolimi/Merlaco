<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_profile.aspx.cs" Inherits="Users_user_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="data-block">
        <h1>NAME SURNAME</h1>
        <p>Picker n #######</p>
        <p>Username</p>
        <p>Password</p>
        <p>Address</p>
        <p>Emergency contact</p>
        <p>Bank details</p>
        <h3>123$/Kg</h3>
        <asp:Button ID="Button1" runat="server" Text="Edit user" />
    </div>
    <div id="image-block">
        a
    </div>
</asp:Content>

