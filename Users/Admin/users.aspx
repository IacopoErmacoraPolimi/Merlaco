<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="Users_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="AddUserButton" runat="server" Text="Add User" />
    <asp:ListView ID="ListView1" runat="server" DataSourceID="users_datasource">
        <AlternatingItemTemplate>
            <tr style="background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("username") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="surnameLabel" runat="server" Text='<%# Eval("surname") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("../user_profile.aspx?u={0}", Eval("username")) %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("username") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="surnameLabel" runat="server" Text='<%# Eval("surname") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("../user_profile.aspx?u={0}", Eval("username")) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="width:75vw;background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="text-align: left;background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                                <th runat="server">username</th>
                                <th runat="server">name</th>
                                <th runat="server">surname</th>
                                <th runat="server">Email</th>
                                <th runat="server">See Profile</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="users_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
</asp:Content>
