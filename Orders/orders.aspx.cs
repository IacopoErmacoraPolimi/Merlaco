using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

public partial class Orders_Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //IN THE MAKING, SELECT STATEMENT ARE STILL GENERAL AND INCORRECT, STILL HAVE TO VERIFY WHICH ROLE CAN SEE WHAT!
        if (User.IsInRole("admin"))
        {
            Orders_datasource.SelectCommand = "SELECT [Order].[order_number], [Order_picker].[picker], [Order_picker].[picked], SUM([Order].[quantity]) as N_items FROM [Order], [Order_picker] WHERE [Order].[order_number] = [Order_picker].[order_number] GROUP BY [Order].[order_number],  [Order_picker].[picker], [Order_picker].[picked]";
        }
        else if (User.IsInRole("picker"))
        {
            Orders_datasource.SelectCommand = "SELECT [Order].[order_number], [Order_picker].[picker], [Order_picker].[picked], SUM([Order].[quantity]) as N_items FROM [Order], [Order_picker] WHERE [Order].[order_number] = [Order_picker].[order_number] AND [Order_picker].[picker] = '" + Membership.GetUser().UserName + "' GROUP BY [Order].[order_number],  [Order_picker].[picker], [Order_picker].[picked]";
        }
        else if (User.IsInRole("customer"))
        {
            Orders_datasource.SelectCommand = "SELECT [Order].[order_number], [Order_picker].[picker], [Order_picker].[picked], SUM([Order].[quantity]) as N_items FROM [Order], [Order_picker], [Users], [aspnet_Membership], [aspnet_Users] WHERE [Order].[order_number] = [Order_picker].[order_number] AND [Order].[user_email] = [aspnet_Membership].[email] AND [aspnet_Membership].[UserId] = [aspnet_Users].[UserId] AND [aspnet_Users].[UserName] = '" + Membership.GetUser().UserName + "' GROUP BY [Order].[order_number], [Order_picker].[picker], [Order_picker].[picked]";
        }
    }

    protected void lstView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        // save button Clicked
        if (e.CommandName == "ButtonClick")
        {
            ListViewItem itemClicked = e.Item;
            // Find Controls/Retrieve values from the item  here
        }
    }

    protected void DeleteOrderButton_Click(object sender, EventArgs e)
    {

    }
}