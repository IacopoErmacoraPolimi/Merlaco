<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="Products_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="Products_datasource" GroupItemCount="3">
        <AlternatingItemTemplate>
            <td runat="server" style="background-color: #FAFAD2;color: #284775;">name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />picture:
                <asp:Label ID="pictureLabel" runat="server" Text='<%# Eval("picture") %>' />
                <br />price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                <br /></td>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <td runat="server" style="background-color: #FFCC66;color: #000080;">name:
                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                <br />picture:
                <asp:TextBox ID="pictureTextBox" runat="server" Text='<%# Bind("picture") %>' />
                <br />price:
                <asp:TextBox ID="priceTextBox" runat="server" Text='<%# Bind("price") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                <br /></td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">name:
                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                <br />picture:
                <asp:TextBox ID="pictureTextBox" runat="server" Text='<%# Bind("picture") %>' />
                <br />price:
                <asp:TextBox ID="priceTextBox" runat="server" Text='<%# Bind("price") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                <br /></td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td runat="server" style="background-color: #FFFBD6;color: #333333;">name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />picture:
                <asp:Label ID="pictureLabel" runat="server" Text='<%# Eval("picture") %>' />
                <br />price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                <br /></td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="background-color: #FFCC66;font-weight: bold;color: #000080;">name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />picture:
                <asp:Label ID="pictureLabel" runat="server" Text='<%# Eval("picture") %>' />
                <br />price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                <br /></td>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Products_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [name], [picture], [price] FROM [Product]"></asp:SqlDataSource>
</asp:Content>

