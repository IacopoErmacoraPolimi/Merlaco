<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="Cart_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin:20px">
        <p style="margin:20px" id="MessageCart" runat="server"></p>
        <table style="width: 70vw; border-spacing: 5px;">
            <tr style="background-color: white;">
                <th style="padding: 5px;">Name</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Total Price</th>
                <th>Delete</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" ItemType="Cart_item">
                <ItemTemplate>
                    <tr style="text-align: center; background-color: white;">
                        <td style="padding: 5px;"><%# Item.product_name %></td>
                        <td>
                            <asp:Button ID="ButtonDecrease" runat="server" CommandArgument='<%# Item.product_barcode %>' OnClick="Btn_Decrease" Text="-" /><%# Item.product_quantity %><asp:Button ID="ButtonIncrease" runat="server" CommandArgument='<%# Item.product_barcode %>' OnClick="Btn_Increase" Text="+" /></td>
                        <td><%# Item.product_price %></td>
                        <td><%# Item.product_quantity*Item.product_price %></td>
                        <td>
                            <asp:Button ID="ButtonDelete" runat="server" CommandArgument='<%# Item.product_barcode %>' OnClick="Btn_Delete" Text="Delete" /></td>
                        <td id='<%# Item.product_barcode %>'></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <div style="text-align: right; width: 70vw;">
            <asp:Button ID="test" runat="server" OnClick="Btn_Order" Text="Order" />
        </div>
    </div>
</asp:Content>

