<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_profile.aspx.cs" Inherits="Users_user_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="data-block">
        <h1><%= name %> <%= surname %></h1>
        <p>Username: <%= username %></p>
        <p>Email: <%= email %></p>
        <p>Address: <%= address %></p>
        <asp:LoginView ID="LoginView2" runat="server">
            <RoleGroups>

                <asp:RoleGroup Roles="admin">
                  <ContentTemplate>
                    <p>IBAN: <%= IBAN %></p>
                    <asp:Button ID="EditUserButton" runat="server" Text="Edit User" />
                  </ContentTemplate>
                </asp:RoleGroup>

                <asp:RoleGroup Roles="picker">
                  <ContentTemplate>
                    <p>IBAN: <%= IBAN %></p>
                  </ContentTemplate>
                </asp:RoleGroup>

              </RoleGroups>
        </asp:LoginView>
        
    </div>
    <div id="image-block">
        <asp:Image ID="image" runat="server" AlternateText="Profile Image"/>
    </div>
</asp:Content>

