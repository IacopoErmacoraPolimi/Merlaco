<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="Products_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:right;width:75vw;margin-top:20px;margin-bottom:15px;">
        <p style="margin:20px" id="MessageCart" runat="server"></p>
        <asp:LoginView ID="LoginView2" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="admin">
                <ContentTemplate>
                    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" PostBackUrl = "Admin/add_product.aspx"/>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
    </div>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="barcode" DataSourceID="Products_datasource" GroupItemCount="3"  OnSelectedIndexChanged="AddItemToCart_Click">
        <AlternatingItemTemplate>
            <td id="Td1" runat="server" style="background-color: white;color: black;width:25vw;border-width:5px;border-color:#e9eef2;border-style:solid;padding:10px;">
                <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("picture").ToString() == "" ? "~/images/Products/NoImage.png" : Eval("picture") %>' AlternateText="Product Image"/>
                <br />
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' Font-Bold="True" Height="40" />
                <br />
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") + " kr" %>' Height="30" />
                <br />
                <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("products_info.aspx?bc={0}", Eval("barcode")) %>' />
                <br />
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup Roles="customer">
                          <ContentTemplate>
                            <asp:Button ID="AddToCartButton" runat="server" Text='<%# (int)Eval("quantity_in_stock") > 0 ? "Add To Cart" : "Out of stock" %>' CommandName="select" />
                            <br />
                          </ContentTemplate>
                        </asp:RoleGroup>

                        <asp:RoleGroup Roles="admin">
                            <ContentTemplate>
                            <asp:Label ID="priceLabel" runat="server" Text='<%# (bool)Eval("active") ? "Active product" : "Inactive product" %>' ForeColor="#999999" Height="30" />
                            <br />
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
                </asp:LoginView>
                </td>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td runat="server" style="background-color: white;color: black;width:25vw;border-width:5px;border-color:#e9eef2;border-style:solid;padding:10px;"/>
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td runat="server" style="background-color: white;color: black;width:25vw;border-width:5px;border-color:#e9eef2;border-style:solid;padding:10px;">
                <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("picture").ToString() == "" ? "~/images/Products/NoImage.png" : Eval("picture") %>' AlternateText="Product Image"/>
                <br />
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' Font-Bold="True" Height="40" />
                <br />
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") + " kr" %>' Height="30" />
                <br />
                <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("products_info.aspx?bc={0}", Eval("barcode")) %>' />
                <br />
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup Roles="customer">
                          <ContentTemplate>
                            <asp:Button ID="AddToCartButton" runat="server" Enabled='<%# (int)Eval("quantity_in_stock") > 0 ? true : false %>' Text='<%# (int)Eval("quantity_in_stock") > 0 ? "Add To Cart" : "Out of stock" %>' CommandName="select" />
                            <br />
                          </ContentTemplate>
                        </asp:RoleGroup>

                        <asp:RoleGroup Roles="admin">
                            <ContentTemplate>
                            <asp:Label ID="priceLabel" runat="server" Text='<%# (bool)Eval("active") ? "Active product" : "Inactive product" %>' ForeColor="#999999" Height="30" />
                            <br />
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
                </asp:LoginView>
                </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="text-align: center;background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: white;color: black;border-width:5px;border-color:#e9eef2;border-style:solid;padding:10px;font-family: Verdana, Arial, Helvetica, sans-serif;color: black;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Products_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
</asp:Content>

