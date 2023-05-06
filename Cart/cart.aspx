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
    <asp:Repeater ID="Repeater1" runat="server" ItemType="Cart_item">
        <ItemTemplate>
            <tr>
                <td><%# Item.product_name %></td>
                <td><asp:Button ID="ButtonDecrease" runat="server" CommandArgument='<%# Item.product_barcode %>' OnClick="Btn_Decrease" Text="-" /><%# Item.product_quantity %><asp:Button ID="ButtonIncrease" runat="server" CommandArgument='<%# Item.product_barcode %>' OnClick="Btn_Increase" Text="+" /></td>
                <td><%# Item.product_price %></td>
                <td><%# Item.product_quantity*Item.product_price %></td>
                <td><asp:Button ID="ButtonDelete" runat="server" CommandArgument='<%# Item.product_barcode %>' OnClick="Btn_Delete" Text="Delete" /></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

<asp:Button ID="test" runat="server" OnClick="Btn_Order" Text="Order" />
</asp:Content>

