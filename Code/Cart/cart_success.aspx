<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart_success.aspx.cs" Inherits="Cart_cart_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    The order was submitted! Your Order has order number #<%= order_number %>

    <% if (Session.Count > 0 && Session["cart"] != null)
       { %>
    <p>The following items where not in stock anymore (or the quantity is more than what we have in stock) and so the're not part of the order</p>
    <div style="margin: 20px">
        <table style="width: 70vw; border-spacing: 5px;">
            <tr style="background-color: white;">
                <th style="padding: 5px;">Name</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Total Price</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" ItemType="Cart_item">
                <ItemTemplate>
                    <tr style="text-align: center; background-color: white;">
                        <td style="padding: 5px;"><%# Item.product_name %></td>
                        <td><%# Item.product_quantity %></td>
                        <td><%# Item.product_price %></td>
                        <td><%# Item.product_quantity*Item.product_price %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <% } %>
</asp:Content>

