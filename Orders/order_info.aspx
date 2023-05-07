<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="order_info.aspx.cs" Inherits="Orders_order_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="Order_info_datasource" DataKeyNames="order_number,product_bar_code">
        <AlternatingItemTemplate>
            <tr style="background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                <td>
                    <asp:Label ID="product_bar_codeLabel" runat="server" Text='<%# Eval("product_bar_code") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                </td>
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>

                        <asp:RoleGroup Roles="admin">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                            </td>
                            <td>
                                <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                        <asp:RoleGroup Roles="picker">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                            </td>
                            <td>
                                <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                      </RoleGroups>
                </asp:LoginView>
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
                    <asp:Label ID="product_bar_codeLabel" runat="server" Text='<%# Eval("product_bar_code") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>' />
                </td>
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>

                        <asp:RoleGroup Roles="admin">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                            </td>
                            <td>
                                <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                        <asp:RoleGroup Roles="picker">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                            </td>
                            <td>
                                <asp:Label ID="alternativeLabel" runat="server" Text='<%# Eval("alternative") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                      </RoleGroups>
                </asp:LoginView>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="width:75vw;background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="text-align: left;background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                                <th runat="server">product barcode</th>
                                <th runat="server">name</th>
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
    <asp:SqlDataSource ID="Order_info_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ></asp:SqlDataSource>
</asp:Content>

