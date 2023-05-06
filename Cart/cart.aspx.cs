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

        Session["cart"] = cart_list;

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

        Session["cart"] = cart_list;

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

        Session["cart"] = cart_list;

        Response.Redirect(Request.RawUrl);
    }

    protected void Btn_Order(Object sender, EventArgs e)
    {
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a user. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr_order = "INSERT INTO [Order] (product_bar_code, order_number, username, quantity, picked) VALUES (@theProduct_bar_code, @theOrder_number, @theUsername, @theQuantity, 0)";
        string sqlStr_order_picker = "INSERT INTO [order_picker] (picker, order_number, picked) VALUES (0, @theOrder_number, 0)";


        Guid guid = Guid.NewGuid();
        string order_number = guid.ToString();

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

            // Execute the SQL command
            sqlCmd_order.ExecuteNonQuery();
        }

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_order_picker = new SqlCommand(sqlStr_order_picker, con);

        sqlCmd_order_picker.Parameters.AddWithValue("@theOrder_number", order_number);

        // Execute the SQL command
        sqlCmd_order_picker.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        Session.Remove("cart");

        Response.Redirect("cart_success.aspx?on=" + order_number);
    }
}