<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_profile.aspx.cs" Inherits="Users_user_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="data-block">
        <h1><%= name %> <%= surname %></h1>
        <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Username:</b> <%= username %></h4>
        <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Email:</b> <%= email %></h4>
        <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">Address:</b> <%= address %></h4>
        <asp:LoginView ID="LoginView2" runat="server">
            <RoleGroups>

                <asp:RoleGroup Roles="admin">
                  <ContentTemplate>
                    <h4 style="margin:5px;font-weight:normal;"><b style="color:#545454;">IBAN:</b> <%= IBAN %></h4>
                    <asp:Button ID="EditUserButton" runat="server" Text="Edit User" />
                    <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" OnClick="OnClick_delete_user" />
                  </ContentTemplate>
                </asp:RoleGroup>

                <asp:RoleGroup Roles="picker">
                  <ContentTemplate>
                    <p>IBAN: <%= IBAN %></p>
                    <asp:Button ID="EditUserButton" runat="server" Text="Edit User" />
                  </ContentTemplate>
                </asp:RoleGroup>

                <asp:RoleGroup Roles="customer">
                  <ContentTemplate>
                    <asp:Button ID="EditUserButton" runat="server" Text="Edit User" />
                    <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" OnClick="OnClick_delete_user" />
                  </ContentTemplate>
                </asp:RoleGroup>

              </RoleGroups>
        </asp:LoginView>
        
        
    </div>
    <div id="image-block">
        <asp:Image ID="image" runat="server" AlternateText="Profile Image"/>
    </div>
</asp:Content>

