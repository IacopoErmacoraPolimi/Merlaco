using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

public partial class Orders_order_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string order_num = Request.QueryString["o"];
        Order_info_datasource.SelectCommand = "SELECT [Order].[order_number], [Product].[name], [Order].[product_bar_code], [quantity], [Product].[place], [Product].[alternative], [Order].[picked] FROM [Order], [Product] WHERE [Order].[product_bar_code] = [Product].[barcode] AND [Order].[order_number] = '" + order_num + "'";
    }

    protected void Picker_checkChanged(object sender, EventArgs e)
    {
        CheckBox checkhome = (CheckBox)sender;
        LoginView loginView = (LoginView)checkhome.NamingContainer;
        ListViewItem item = (ListViewItem)loginView.NamingContainer;
        ListViewDataItem dataItem = (ListViewDataItem)item;
        string ord_num = ListView1.DataKeys[dataItem.DisplayIndex].Values["order_number"].ToString();
        string prod_bc_str = ListView1.DataKeys[dataItem.DisplayIndex].Values["product_bar_code"].ToString();
        long prod_bc = Convert.ToInt64(prod_bc_str);

        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a user. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr = "UPDATE [Order] SET picked = @thePicked WHERE order_number = @theOrder_number AND product_bar_code = @theProduct_bar_code";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        sqlCmd.Parameters.AddWithValue("@thePicked", checkhome.Checked);
        sqlCmd.Parameters.AddWithValue("@theOrder_number", ord_num);
        sqlCmd.Parameters.AddWithValue("@theProduct_bar_code", prod_bc);

        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        Response.Redirect(Request.RawUrl);
    }
    
}