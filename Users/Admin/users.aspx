<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="Users_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="Users_datasource">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF;color: #284775;">
                <td>
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                </td>
                <td>
                    <asp:Label ID="LoweredUserNameLabel" runat="server" Text='<%# Eval("LoweredUserName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsAnonymousCheckBox" runat="server" Checked='<%# Eval("IsAnonymous") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="LastActivityDateLabel" runat="server" Text='<%# Eval("LastActivityDate") %>' />
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
                    <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LoweredUserNameTextBox" runat="server" Text='<%# Bind("LoweredUserName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsAnonymousCheckBox" runat="server" Checked='<%# Bind("IsAnonymous") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LastActivityDateTextBox" runat="server" Text='<%# Bind("LastActivityDate") %>' />
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
                    <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LoweredUserNameTextBox" runat="server" Text='<%# Bind("LoweredUserName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsAnonymousCheckBox" runat="server" Checked='<%# Bind("IsAnonymous") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LastActivityDateTextBox" runat="server" Text='<%# Bind("LastActivityDate") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF;color: #333333;">
                <td>
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                </td>
                <td>
                    <asp:Label ID="LoweredUserNameLabel" runat="server" Text='<%# Eval("LoweredUserName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsAnonymousCheckBox" runat="server" Checked='<%# Eval("IsAnonymous") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="LastActivityDateLabel" runat="server" Text='<%# Eval("LastActivityDate") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                <th runat="server">UserName</th>
                                <th runat="server">LoweredUserName</th>
                                <th runat="server">IsAnonymous</th>
                                <th runat="server">LastActivityDate</th>
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
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                </td>
                <td>
                    <asp:Label ID="LoweredUserNameLabel" runat="server" Text='<%# Eval("LoweredUserName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsAnonymousCheckBox" runat="server" Checked='<%# Eval("IsAnonymous") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="LastActivityDateLabel" runat="server" Text='<%# Eval("LastActivityDate") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="Users_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [UserName], [LoweredUserName], [IsAnonymous], [LastActivityDate] FROM [vw_aspnet_Users]"></asp:SqlDataSource>
</asp:Content>

