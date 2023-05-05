<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="Cart_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <th>Barcode</th>
        <th>Quantity</th>
    </tr>
    <% foreach (Cart_item item in cart_list)
       { %>
        <tr>
            <td><%= item.product_barcode %></td>
            <td><%= item.product_quantity %></td>
        </tr>
    <% } %>
</table>
</asp:Content>

