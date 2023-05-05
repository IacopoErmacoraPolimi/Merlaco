<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="orders.aspx.cs" Inherits="Orders_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="order_number"  DataSourceID="Orders_datasource" OnSelectedIndexChanged="DeleteOrderButton_Click">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF;color: #284775;">
                <td>
                    <asp:Label ID="order_numberLabel" runat="server" Text='<%# Eval("order_number") %>' />
                </td>
                <td>
                    <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="N_itemsLabel" runat="server" Text='<%# Eval("N_items") %>' />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("order_info.aspx?o={0}", Eval("order_number")) %>' />
                </td>
                <td>
                    <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>You haven't made any order yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF;color: #333333;">
                <td>
                    <asp:Label ID="order_numberLabel" runat="server" Text='<%# Eval("order_number") %>' />
                </td>
                <td>
                    <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="N_itemsLabel" runat="server" Text='<%# Eval("N_items") %>' />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("order_info.aspx?o={0}", Eval("order_number")) %>' />
                </td>
                <td>
                    <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                <th runat="server">order_number</th>
                                <th runat="server">picker</th>
                                <th runat="server">picked</th>
                                <th runat="server">N_items</th>
                                <th runat="server">See Details</th>
                                <th id="Th1" runat="server">Delete Order</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                <td>
                    <asp:Label ID="order_numberLabel" runat="server" Text='<%# Eval("order_number") %>' />
                </td>
                <td>
                    <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="N_itemsLabel" runat="server" Text='<%# Eval("N_items") %>' />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("order_info.aspx?o={0}", Eval("order_number")) %>' />
                </td>
                <td>
                    <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Orders_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
</asp:Content>

