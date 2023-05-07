<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="products_info.aspx.cs" Inherits="Products_products_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="image-block">
        <asp:Image ID="image" runat="server" AlternateText="Product Image"/>
    </div>
    <div id="data-block">
        <h1><%= name %></h1>
        <h3 style="margin-bottom:15px;color:green;"><%= price %> kr</h3>
        <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Origin:</b> <%= origin %></h4>
        <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Eco or not:</b> <%= eco_or_not %></h4>

        <asp:LoginView ID="LoginView2" runat="server">
            <RoleGroups>

                <asp:RoleGroup Roles="admin">
                  <ContentTemplate>
                    <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Quantity in stock:</b> <%= quantity_in_stock %></h4>
                    <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Place:</b> <%= place %></h4>
                    <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Alternative:</b> <%= alternative %></h4>
                    <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Active:</b> <%= active %></h4>
                    <asp:Button ID="EditProductButton" runat="server" Text="Edit Product" />
                    <asp:Button ID="Button3" runat="server" Text="Activate/Deactivate" OnClick="OnClick_active_deactive_btn" />
                  </ContentTemplate>
                </asp:RoleGroup>

                <asp:RoleGroup Roles="picker">
                  <ContentTemplate>
                    <h3>Quantity in stock: <%= quantity_in_stock %></h3>
                    <h3>Place: <%= place %></h3>
                    <h3>Alternative: <%= alternative %></h3>
                  </ContentTemplate>
                </asp:RoleGroup>

              </RoleGroups>
        </asp:LoginView>

    </div>
    <p><b style="color:#545454;">Description:</b> <%= description %></p>
</asp:Content>

