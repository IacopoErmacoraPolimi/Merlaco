using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user_role = Request.QueryString["ur"];

        switch(user_role){    
            case "c":
                users_datasource.SelectCommand = "SELECT [Users].[username], [Users].[name], [Users].[surname], [aspnet_Membership].[Email] FROM [Users], [aspnet_Users], [aspnet_Membership], [aspnet_Roles], [aspnet_UsersInRoles] WHERE [Users].[username]=[aspnet_Users].[UserName] AND [aspnet_Users].[UserId]=[aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1 AND [aspnet_UsersInRoles].[UserId] IN (SELECT [aspnet_Users].[UserId] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName]=[Users].[username]) AND [aspnet_Roles].[RoleId]=[aspnet_UsersInRoles].[RoleId] AND [aspnet_Roles].[RoleName]='customer'";
             break;  
            case "a":
             users_datasource.SelectCommand = "SELECT [Users].[username], [Users].[name], [Users].[surname], [aspnet_Membership].[Email] FROM [Users], [aspnet_Users], [aspnet_Membership], [aspnet_Roles], [aspnet_UsersInRoles] WHERE [Users].[username]=[aspnet_Users].[UserName] AND [aspnet_Users].[UserId]=[aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1 AND [aspnet_UsersInRoles].[UserId] IN (SELECT [aspnet_Users].[UserId] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName]=[Users].[username]) AND [aspnet_Roles].[RoleId]=[aspnet_UsersInRoles].[RoleId] AND [aspnet_Roles].[RoleName]='admin'";
             break;
            case "op":
             users_datasource.SelectCommand = "SELECT [Users].[username], [Users].[name], [Users].[surname], [aspnet_Membership].[Email] FROM [Users], [aspnet_Users], [aspnet_Membership], [aspnet_Roles], [aspnet_UsersInRoles] WHERE [Users].[username]=[aspnet_Users].[UserName] AND [aspnet_Users].[UserId]=[aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1 AND [aspnet_UsersInRoles].[UserId] IN (SELECT [aspnet_Users].[UserId] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName]=[Users].[username]) AND [aspnet_Roles].[RoleId]=[aspnet_UsersInRoles].[RoleId] AND [aspnet_Roles].[RoleName]='picker'";
             break;
            default:
             users_datasource.SelectCommand = "SELECT [Users].[username], [Users].[name], [Users].[surname], [aspnet_Membership].[Email] FROM [Users], [aspnet_Users], [aspnet_Membership], [aspnet_Roles], [aspnet_UsersInRoles] WHERE [Users].[username]=[aspnet_Users].[UserName] AND [aspnet_Users].[UserId]=[aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1 AND [aspnet_UsersInRoles].[UserId] IN (SELECT [aspnet_Users].[UserId] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName]=[Users].[username]) AND [aspnet_Roles].[RoleId]=[aspnet_UsersInRoles].[RoleId]";
             break;
            }

        AddUserButton.PostBackUrl = "add_user.aspx";
    }
}