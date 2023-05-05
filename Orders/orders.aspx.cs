using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using System.Data.SqlClient;
using System.Configuration;

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
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a booking. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr_o = "DELETE FROM [Order] WHERE order_number = @theOrderNumber";
        string sqlStr_op = "DELETE FROM order_picker WHERE order_number = @theOrderNumber";


        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_o = new SqlCommand(sqlStr_o, con);

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_op = new SqlCommand(sqlStr_op, con);


        // Fill in the parameters in our prepared SQL statement
        sqlCmd_o.Parameters.AddWithValue("@theOrderNumber", ListView1.SelectedDataKey.Value.ToString());
        sqlCmd_op.Parameters.AddWithValue("@theOrderNumber", ListView1.SelectedDataKey.Value.ToString());

        // Execute the SQL command
        sqlCmd_o.ExecuteNonQuery();

        // Execute the SQL command
        sqlCmd_op.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();
    }
}