<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="Products_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" />
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="barcode" DataSourceID="Products_datasource" GroupItemCount="3"  OnSelectedIndexChanged="AddItemToCart_Click">
        <AlternatingItemTemplate>
            <td runat="server" style="background-color: #FAFAD2;color: #284775;">
                <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("picture").ToString() == "" ? "~/images/Products/NoImage.png" : Eval("picture") %>' AlternateText="Product Image"/>
                <br />name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                <br />Details:
                <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("products_info.aspx?bc={0}", Eval("barcode")) %>' />
                <br />Add to Cart:
                <asp:Button ID="AddToCartButton" runat="server" Text="Add To Cart" CommandName="select" />
                <br /></td>
        </AlternatingItemTemplate>
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
        <ItemTemplate>
            <td runat="server" style="background-color: #FFFBD6;color: #333333;">
                <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("picture").ToString() == "" ? "~/images/Products/NoImage.png" : Eval("picture") %>' AlternateText="Product Image"/>
                <br />name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                <br />Details:
                <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("products_info.aspx?bc={0}", Eval("barcode")) %>' />
                <br />Add to Cart:
                <asp:Button ID="AddToCartButton" runat="server" Text="Add To Cart" CommandName="select" />
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
            <td runat="server" style="background-color: #FFCC66;font-weight: bold;color: #000080;">
                <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("picture").ToString() == "" ? "~/images/Products/NoImage.png" : Eval("picture") %>' AlternateText="Product Image"/>
                <br />name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                <br />Details:
                <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("products_info.aspx?bc={0}", Eval("barcode")) %>' />
                <br />Add to Cart:
                <asp:Button ID="AddToCartButton" runat="server" Text="Add To Cart" CommandName="select" />
                <br /></td>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Products_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
</asp:Content>

