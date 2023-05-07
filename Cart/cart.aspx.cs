using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

using System.Web.Security;

public partial class Cart_cart : System.Web.UI.Page
{
    public List<Cart_item> cart_list;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count > 0 && Session["cart"] != null)
        {
            cart_list = (List<Cart_item>)Session["cart"];
            cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));
        }

        if (!Page.IsPostBack)
        {
            Repeater1.DataSource = cart_list;
            Repeater1.DataBind();
        }
    }

    protected void Btn_Delete(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
        Cart_item found_item = new Cart_item();
        foreach (Cart_item c in cart_list)
        {
            if (c.product_barcode == Convert.ToInt64(btn.CommandArgument))
            {
                found_item = c;
                break;
            }
        }
        cart_list.Remove(found_item);

        cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));

        if (cart_list.Count == 0)
        {
            Session.Remove("cart");
        }
        else
        {
            Session["cart"] = cart_list;
        }

        Response.Redirect(Request.RawUrl);
    }

    protected void Btn_Increase(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
        Cart_item found_item = new Cart_item();
        foreach (Cart_item c in cart_list)
        {
            if (c.product_barcode == Convert.ToInt64(btn.CommandArgument))
            {
                found_item = c;
                break;
            }
        }
        cart_list.Remove(found_item);

        Cart_item new_item = new Cart_item();
        new_item = found_item;
        new_item.product_quantity = new_item.product_quantity + 1;
        cart_list.Add(new_item);
        cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));

        if (cart_list.Count == 0)
        {
            Session.Remove("cart");
        }
        else
        {
            Session["cart"] = cart_list;
        }

        Response.Redirect(Request.RawUrl);
    }

    protected void Btn_Decrease(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
        Cart_item found_item = new Cart_item();
        foreach (Cart_item c in cart_list)
        {
            if (c.product_barcode == Convert.ToInt64(btn.CommandArgument))
            {
                found_item = c;
                break;
            }
        }
        cart_list.Remove(found_item);
        if (found_item.product_quantity > 1)
        {
            Cart_item new_item = new Cart_item();
            new_item = found_item;
            new_item.product_quantity = new_item.product_quantity - 1;
            cart_list.Add(new_item);
        }

        cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));

        if (cart_list.Count == 0)
        {
            Session.Remove("cart");
        }
        else
        {
            Session["cart"] = cart_list;
        }

        Response.Redirect(Request.RawUrl);
    }

    protected void Btn_Order(Object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["cart"] == null)
        {
            Response.Redirect(Request.RawUrl);
        }
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a user. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr_order = "INSERT INTO [Order] (product_bar_code, order_number, username, quantity, picked, date) VALUES (@theProduct_bar_code, @theOrder_number, @theUsername, @theQuantity, 0, @theDate)";
        string sqlStr_order_picker = "INSERT INTO [order_picker] (picker, order_number, picked) VALUES (@thePicker, @theOrder_number, 0)";
        string sqlStr_pick_picker = "SELECT TOP 1 [Users].[username] FROM [Users], [aspnet_Users], [aspnet_Membership], [aspnet_Roles], [aspnet_UsersInRoles] WHERE [Users].[username]=[aspnet_Users].[UserName] AND [aspnet_Users].[UserId]=[aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1 AND [aspnet_UsersInRoles].[UserId] IN (SELECT [aspnet_Users].[UserId] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName]=[Users].[username]) AND [aspnet_Roles].[RoleId]=[aspnet_UsersInRoles].[RoleId] AND [aspnet_Roles].[RoleName]='picker' ORDER BY NEWID()";

        Guid guid = Guid.NewGuid();
        string order_number = guid.ToString("N");

        // Open the database connection
        con.Open();

        List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
        foreach (Cart_item c in cart_list)
        {
            // Create an executable SQL command containing our SQL statement and the database connection
            SqlCommand sqlCmd_order = new SqlCommand(sqlStr_order, con);

            sqlCmd_order.Parameters.AddWithValue("@theProduct_bar_code", c.product_barcode);
            sqlCmd_order.Parameters.AddWithValue("@theOrder_number", order_number);
            sqlCmd_order.Parameters.AddWithValue("@theUsername", Membership.GetUser().UserName);
            sqlCmd_order.Parameters.AddWithValue("@theQuantity", c.product_quantity);
            SqlParameter dateParameter = new SqlParameter("@theDate", System.Data.SqlDbType.DateTime);
            dateParameter.Value = DateTime.Today;
            sqlCmd_order.Parameters.Add(dateParameter);

            // Execute the SQL command
            sqlCmd_order.ExecuteNonQuery();
        }

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_pick_picker = new SqlCommand(sqlStr_pick_picker, con);

        SqlDataReader DR1 = sqlCmd_pick_picker.ExecuteReader();

        string picked_picker = "test";
        if (DR1.Read())
        {
            picked_picker = DR1.GetValue(0).ToString();
        }

        DR1.Close();

        SqlCommand sqlCmd_order_picker = new SqlCommand(sqlStr_order_picker, con);

        sqlCmd_order_picker.Parameters.AddWithValue("@theOrder_number", order_number);
        sqlCmd_order_picker.Parameters.AddWithValue("@thePicker", picked_picker);

        // Execute the SQL command
        sqlCmd_order_picker.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        Session.Remove("cart");

        Response.Redirect("cart_success.aspx?on=" + order_number);
    }
}