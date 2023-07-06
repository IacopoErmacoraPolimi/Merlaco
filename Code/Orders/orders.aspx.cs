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
        //Based on the role of the user, select the correct data from the database
        if (User.IsInRole("admin"))
        {
            Orders_datasource.SelectCommand = "SELECT [Order].[order_number], [Order].[date], [Order_picker].[picker], [Order_picker].[picked], SUM([Order].[quantity]) as N_items FROM [Order], [Order_picker] WHERE [Order].[order_number] = [Order_picker].[order_number] GROUP BY [Order].[order_number],  [Order_picker].[picker], [Order_picker].[picked], [Order].[date]";
        }
        else if (User.IsInRole("picker"))
        {
            Orders_datasource.SelectCommand = "SELECT [Order].[order_number], [Order].[date], [Order_picker].[picker], [Order_picker].[picked], SUM([Order].[quantity]) as N_items FROM [Order], [Order_picker] WHERE [Order].[order_number] = [Order_picker].[order_number] AND [Order_picker].[picker] = '" + Membership.GetUser().UserName + "' GROUP BY [Order].[order_number],  [Order_picker].[picker], [Order_picker].[picked], [Order].[date]";
        }
        else if (User.IsInRole("customer"))
        {
            Orders_datasource.SelectCommand = "SELECT [Order].[order_number], [Order].[date], [Order_picker].[picker], [Order_picker].[picked], SUM([Order].[quantity]) as N_items FROM [Order], [Order_picker] WHERE [Order].[order_number] = [Order_picker].[order_number] AND [Order].[username] = '" + Membership.GetUser().UserName + "' GROUP BY [Order].[order_number], [Order_picker].[picker], [Order_picker].[picked], [Order].[date]";
        }
    }

    protected void DeleteOrderButton_Click(object sender, EventArgs e)
    {
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statements to delete an order
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

    protected void Picker_checkChanged(object sender, EventArgs e)
    {
        //Check which row of the listview had an interaction with the checkbox and retrieve the data related to that row
        CheckBox checkhome = (CheckBox)sender;
        LoginView loginView = (LoginView)checkhome.NamingContainer;
        ListViewItem item = (ListViewItem)loginView.NamingContainer;
        ListViewDataItem dataItem = (ListViewDataItem)item;
        string ord_num = ListView1.DataKeys[dataItem.DisplayIndex].Values["order_number"].ToString();

        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to update an order
        string sqlStr = "UPDATE order_picker SET picked = @thePicked WHERE order_number = @theOrder_number";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        sqlCmd.Parameters.AddWithValue("@thePicked", checkhome.Checked);
        sqlCmd.Parameters.AddWithValue("@theOrder_number", ord_num);

        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        //Reload the page
        Response.Redirect(Request.RawUrl);
    }
}