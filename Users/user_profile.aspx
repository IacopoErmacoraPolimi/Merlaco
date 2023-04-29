<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_profile.aspx.cs" Inherits="Users_user_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="data-block">
        <h1><%= name %> <%= surname %></h1>
        <p>Username: <%= username %></p>
        <p>Email: <%= email %></p>
        <p>Address: <%= address %></p>
        <p>IBAN: <%= IBAN %></p>
        <asp:Button ID="Button1" runat="server" Text="Edit user" />
    </div>
    <div id="image-block">
        a
    </div>
</asp:Content>

