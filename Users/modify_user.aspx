<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="modify_user.aspx.cs" Inherits="Users_modify_user" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="text-align:center;margin-top:20px;">

        <h3>Modify User:</h3>

        <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="SurnameLabel" runat="server" Text="Surname"></asp:Label>
        <br />
        <asp:TextBox ID="Surname" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="IBANLabel" runat="server" Text="IBAN"></asp:Label>
        <br />
        <asp:TextBox ID="IBAN" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="PhoneLabel" runat="server" Text="Phone"></asp:Label>
        <br />
        <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="Date_of_birthLabel" runat="server" Text="Date_of_birth"></asp:Label>
        <br />
        <asp:TextBox ID="Date_of_birth" runat="server"></asp:TextBox>
        <asp:CalendarExtender TargetControlID="Date_of_birth" ID="CalendarExtender1" runat="server" FirstDayOfWeek="Monday" Format="dd/MM/yyyy"></asp:CalendarExtender>
        <br />
        <br />

        <asp:Label ID="AddressLabel" runat="server" Text="Address"></asp:Label>
        <br />
        <asp:TextBox ID="Address" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Image ID="image" runat="server" AlternateText="Profile Picture Image" />
        <br />
        <asp:Label ID="ImageFileUploadLabel" runat="server" Text="Profile Picture"></asp:Label>
        <br />
        <asp:FileUpload ID="ImageFileUpload" runat="server" />
        <br />
        <br />

        <asp:Button ID="ModifyUserButton" runat="server" Text="Modify User" OnClick="EditUserButton_Click" />
        <br />
        <br />

        <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

