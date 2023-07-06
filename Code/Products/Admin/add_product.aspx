<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="Products_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="text-align: center; margin-top: 20px;">

        <h3>Add Product:</h3>

        <asp:Label ID="BarcodeLabel" runat="server" Text="Barcode"></asp:Label>
        <br />
        <asp:TextBox ID="Barcode" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="ImageFileUploadLabel" runat="server" Text="ImageFileUpload"></asp:Label>
        <br />
        <asp:FileUpload ID="ImageFileUpload" runat="server" />
        <br />
        <br />

        <asp:Label ID="OriginLabel" runat="server" Text="Origin"></asp:Label>
        <br />
        <asp:TextBox ID="Origin" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="Eco_or_notLabel" runat="server" Text="Eco_or_not"></asp:Label>
        <br />
        <asp:TextBox ID="Eco_or_not" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="Quantity_in_stockLabel" runat="server" Text="Quantity_in_stock"></asp:Label>
        <br />
        <asp:TextBox ID="Quantity_in_stock" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="DescriptionLabel" runat="server" Text="Description"></asp:Label>
        <br />
        <asp:TextBox ID="Description" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
        <br />
        <asp:TextBox ID="Price" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="PlaceLabel" runat="server" Text="Place"></asp:Label>
        <br />
        <asp:TextBox ID="Place" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="AlternativeLabel" runat="server" Text="Alternative"></asp:Label>
        <br />
        <asp:TextBox ID="Alternative" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Button ID="AddProductButton" runat="server" Text="Add Product" OnClick="AddProductButton_Click" />
        <br />
        <br />

        <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>

    </div>
</asp:Content>

