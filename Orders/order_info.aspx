<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order_info.aspx.cs" Inherits="Orders_order_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="Order_info_datasource">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF;color: #284775;">
                <td>
                    <asp:Label ID="product_bar_codeLabel" runat="server" Text='<%# Eval("product_bar_code") %>' />
                </td>
                <td>
                    <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                </td>
                <td>
                    <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                </td>
                <td>
                    <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="false" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #999999;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="product_bar_codeTextBox" runat="server" Text='<%# Bind("product_bar_code") %>' />
                </td>
                <td>
                    <asp:TextBox ID="quantityTextBox" runat="server" Text='<%# Bind("quantity") %>' />
                </td>
                <td>
                    <asp:TextBox ID="placeTextBox" runat="server" Text='<%# Bind("place") %>' />
                </td>
                <td>
                    <asp:TextBox ID="alternativeTextBox" runat="server" Text='<%# Bind("alternative") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Bind("picked") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="product_bar_codeTextBox" runat="server" Text='<%# Bind("product_bar_code") %>' />
                </td>
                <td>
                    <asp:TextBox ID="quantityTextBox" runat="server" Text='<%# Bind("quantity") %>' />
                </td>
                <td>
                    <asp:TextBox ID="placeTextBox" runat="server" Text='<%# Bind("place") %>' />
                </td>
                <td>
                    <asp:TextBox ID="alternativeTextBox" runat="server" Text='<%# Bind("alternative") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Bind("picked") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF;color: #333333;">
                <td>
                    <asp:Label ID="product_bar_codeLabel" runat="server" Text='<%# Eval("product_bar_code") %>' />
                </td>
                <td>
                    <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                </td>
                <td>
                    <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                </td>
                <td>
                    <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="false" />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                <th runat="server">product_bar_code</th>
                                <th runat="server">quantity</th>
                                <th runat="server">place</th>
                                <th runat="server">alternative</th>
                                <th runat="server">picked</th>
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
                    <asp:Label ID="product_bar_codeLabel" runat="server" Text='<%# Eval("product_bar_code") %>' />
                </td>
                <td>
                    <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                </td>
                <td>
                    <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                </td>
                <td>
                    <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="false" />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Order_info_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Order].[product_bar_code], [quantity], [Product].[place], [Product].[alternative], [Order].[picked]
FROM [Order], [Product]
WHERE [Order].[product_bar_code] = [Product].[barcode]"></asp:SqlDataSource>
</asp:Content>

