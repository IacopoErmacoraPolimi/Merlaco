<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="orders.aspx.cs" Inherits="Orders_Orders" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="order_number"  DataSourceID="Orders_datasource" OnSelectedIndexChanged="DeleteOrderButton_Click">
        <AlternatingItemTemplate>
            <tr style="background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                <td>
                    <asp:Label ID="order_numberLabel" runat="server" Text='<%# Eval("order_number") %>' />
                </td>
                <td>
                    <asp:Label ID="N_itemsLabel" runat="server" Text='<%# Eval("N_items") %>' />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("date") %>' />
                </td>
                
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>

                        <asp:RoleGroup Roles="admin">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                        <asp:RoleGroup Roles="picker">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                      </RoleGroups>
                </asp:LoginView>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("order_info.aspx?o={0}", Eval("order_number")) %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>You haven't made any order yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                <td>
                    <asp:Label ID="order_numberLabel" runat="server" Text='<%# Eval("order_number") %>' />
                </td>
                <td>
                    <asp:Label ID="N_itemsLabel" runat="server" Text='<%# Eval("N_items") %>' />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("date") %>' />
                </td>
                <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>

                        <asp:RoleGroup Roles="admin">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                        <asp:RoleGroup Roles="picker">
                          <ContentTemplate>
                            <td>
                                <asp:Label ID="pickerLabel" runat="server" Text='<%# Eval("picker") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="pickedCheckBox" runat="server" Checked='<%# Eval("picked") %>' Enabled="true" OnCheckedChanged="Picker_checkChanged" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:Button ID="DeleteOrder" runat="server" Text="Delete Order" CommandName="select"/>
                            </td>
                          </ContentTemplate>
                        </asp:RoleGroup>

                      </RoleGroups>
                </asp:LoginView>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Details" PostBackUrl='<%# String.Format("order_info.aspx?o={0}", Eval("order_number")) %>' />
                </td>
                
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="width:75vw;background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="text-align: left;background-color: white;color: black;border-width:2px;border-color:#e9eef2;border-style:solid;">
                                <th runat="server">order_number</th>
                                <th runat="server">N_items</th>
                                <th runat="server">date</th>
                                <th runat="server">picker</th>
                                <th runat="server">picked</th>
                                <th runat="server">Delete Order</th>
                                <th runat="server">See Details</th>
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
    <asp:SqlDataSource ID="Orders_datasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>

    <asp:LoginView ID="LoginView2" runat="server">
                    <RoleGroups>

                        <asp:RoleGroup Roles="admin">
                          <ContentTemplate>
                            <asp:Chart ID="Chart1" runat="server" DataSourceID="DataSourceGraph">
                            <Series>
                                <asp:Series Name="Series1"  XValueMember="Date" YValueMembers="DailyOrders"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                            </asp:Chart>

                            <asp:SqlDataSource ID="DataSourceGraph" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT count([order_number]) as DailyOrders, date as Date FROM [Order] group by order_number, date">
                            </asp:SqlDataSource>
                          </ContentTemplate>
                        </asp:RoleGroup>

                      </RoleGroups>
                </asp:LoginView>
</asp:Content>

