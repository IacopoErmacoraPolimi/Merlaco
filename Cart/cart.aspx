<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="Cart_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <th>Name</th>
        <th>Quantity</th>
        <th>Price</th>
        <th>Total Price</th>
    </tr>
    <% if (Session.Count > 0 && Session["cart"] != null)
       {
           foreach (Cart_item item in cart_list)
           { %>
            <tr>
                <td><%= item.product_name %></td>
                <td><%= item.product_quantity %></td>
                <td><%= item.product_price %></td>
                <td><%= item.product_quantity*item.product_price %></td>
            </tr>
        <% }
       } else { %>
            <p>TEST OLE OLE</p>
    <% } %>
</table>
</asp:Content>

