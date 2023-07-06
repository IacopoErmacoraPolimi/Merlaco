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
        //Set error message if item wasn't increased in quantity
        if (Request.QueryString["na"] == "0")
        {
            MessageCart.InnerText = "Item quantity not increased, the request exceeds the quantity in stock";
        }
        
        //If there's a session named cart, create a list and bind the data to the repeater
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

        //Search for the item with the barcode the user wants to remove
        foreach (Cart_item c in cart_list)
        {
            if (c.product_barcode == Convert.ToInt64(btn.CommandArgument))
            {
                found_item = c;
                break;
            }
        }

        //Remove found item
        cart_list.Remove(found_item);

        //Order the list to be always in alphabetical order
        cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));

        //Remove session cart or update it if there are values in the cart_list
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

        //Search for the item with the barcode the user wants to increase in quantity
        foreach (Cart_item c in cart_list)
        {
            if (c.product_barcode == Convert.ToInt64(btn.CommandArgument))
            {
                found_item = c;
                break;
            }
        }
        cart_list.Remove(found_item);

        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to select the quantity in stock for the wanted item
        string sqlStr_check_stock = "SELECT quantity_in_stock FROM Product WHERE barcode = " + found_item.product_barcode;

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_check_stock = new SqlCommand(sqlStr_check_stock, con);

        //Create a reader for the SQL returned data and register the data in a variable
        SqlDataReader DR1 = sqlCmd_check_stock.ExecuteReader();

        int stock_quantity  = 0;
        if (DR1.Read())
        {
            stock_quantity = Convert.ToInt16(DR1.GetValue(0).ToString());
        }

        DR1.Close();

        //Check if the item quantity requested is compatible with the quantity present in the database
        string item_updated = "0";
        if (stock_quantity > found_item.product_quantity)
        {

            Cart_item new_item = new Cart_item();
            new_item = found_item;
            new_item.product_quantity = new_item.product_quantity + 1;
            cart_list.Add(new_item);
            item_updated = "1";
        }
        else
        {
            cart_list.Add(found_item);
            
        }
        cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));

        //Remove session cart or update it if there are values in the cart_list
        if (cart_list.Count == 0)
        {
            Session.Remove("cart");
        }
        else
        {
            Session["cart"] = cart_list;
        }

        //Reload the page with the correct query parameter
        Response.Redirect("cart.aspx?na="+item_updated);
    }

    protected void Btn_Decrease(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
        Cart_item found_item = new Cart_item();

        //Search for the item with the barcode the user wants to decrease in quantity
        foreach (Cart_item c in cart_list)
        {
            if (c.product_barcode == Convert.ToInt64(btn.CommandArgument))
            {
                found_item = c;
                break;
            }
        }
        cart_list.Remove(found_item);

        /*If there's at least one as quantity for the selected item, decrease it and add it back in the
        list, otherwise don't add it back to the list*/
        if (found_item.product_quantity > 1)
        {
            Cart_item new_item = new Cart_item();
            new_item = found_item;
            new_item.product_quantity = new_item.product_quantity - 1;
            cart_list.Add(new_item);
        }

        //Order the list to be always in alphabetical order
        cart_list.Sort((x, y) => string.Compare(x.product_name, y.product_name));

        //Remove session cart or update it if there are values in the cart_list
        if (cart_list.Count == 0)
        {
            Session.Remove("cart");
        }
        else
        {
            Session["cart"] = cart_list;
        }

        //Reload the page with the correct query parameter
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

        // The SQL statements to order the items requested
        string sqlStr_order = "INSERT INTO [Order] (product_bar_code, order_number, username, quantity, picked, date) VALUES (@theProduct_bar_code, @theOrder_number, @theUsername, @theQuantity, 0, @theDate)";
        string sqlStr_order_picker = "INSERT INTO [order_picker] (picker, order_number, picked) VALUES (@thePicker, @theOrder_number, 0)";
        string sqlStr_pick_picker = "SELECT TOP 1 [Users].[username] FROM [Users], [aspnet_Users], [aspnet_Membership], [aspnet_Roles], [aspnet_UsersInRoles] WHERE [Users].[username]=[aspnet_Users].[UserName] AND [aspnet_Users].[UserId]=[aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1 AND [aspnet_UsersInRoles].[UserId] IN (SELECT [aspnet_Users].[UserId] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName]=[Users].[username]) AND [aspnet_Roles].[RoleId]=[aspnet_UsersInRoles].[RoleId] AND [aspnet_Roles].[RoleName]='picker' ORDER BY NEWID()";

        Guid guid = Guid.NewGuid();
        string order_number = guid.ToString("N");

        // Open the database connection
        con.Open();

        List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
        List<Cart_item> cart_list_survivors = new List<Cart_item>();

        //Add each item of the cart to the database as an order
        foreach (Cart_item c in cart_list)
        {
            string sqlStr_check_stock = "SELECT quantity_in_stock FROM Product WHERE barcode = " + c.product_barcode;

            // Create an executable SQL command containing our SQL statement and the database connection
            SqlCommand sqlCmd_order = new SqlCommand(sqlStr_order, con);
            SqlCommand sqlCmd_check_stock = new SqlCommand(sqlStr_check_stock, con);

            SqlDataReader DR1 = sqlCmd_check_stock.ExecuteReader();

            int stock_quantity  = 0;
            if (DR1.Read())
            {
                stock_quantity = Convert.ToInt16(DR1.GetValue(0).ToString());
            }

            DR1.Close();

            //Check if there's enough quantity for the requested product in the database
            if (stock_quantity >= c.product_quantity)
            {
                string sqlStr_update_quantity = "UPDATE Product SET quantity_in_stock = quantity_in_stock - @theQuantity WHERE barcode = " + c.product_barcode;
                SqlCommand sqlCmd_update_quantity = new SqlCommand(sqlStr_update_quantity, con);


                sqlCmd_order.Parameters.AddWithValue("@theProduct_bar_code", c.product_barcode);
                sqlCmd_order.Parameters.AddWithValue("@theOrder_number", order_number);
                sqlCmd_order.Parameters.AddWithValue("@theUsername", Membership.GetUser().UserName);
                sqlCmd_order.Parameters.AddWithValue("@theQuantity", c.product_quantity);
                sqlCmd_update_quantity.Parameters.AddWithValue("@theQuantity", c.product_quantity);
                SqlParameter dateParameter = new SqlParameter("@theDate", System.Data.SqlDbType.DateTime);
                dateParameter.Value = DateTime.Today;
                sqlCmd_order.Parameters.Add(dateParameter);

                // Execute the SQL command
                sqlCmd_order.ExecuteNonQuery();
                sqlCmd_update_quantity.ExecuteNonQuery();

            } else {
                /*If there's not enough products in stock to allow the requested quantity, add the product
                to a list of the non-ordered products*/
                cart_list_survivors.Add(c);
            }
        }

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_pick_picker = new SqlCommand(sqlStr_pick_picker, con);

        SqlDataReader DR2 = sqlCmd_pick_picker.ExecuteReader();

        string picked_picker = "test";
        if (DR2.Read())
        {
            picked_picker = DR2.GetValue(0).ToString();
        }

        DR2.Close();

        SqlCommand sqlCmd_order_picker = new SqlCommand(sqlStr_order_picker, con);

        sqlCmd_order_picker.Parameters.AddWithValue("@theOrder_number", order_number);
        sqlCmd_order_picker.Parameters.AddWithValue("@thePicker", picked_picker);

        // Execute the SQL command
        sqlCmd_order_picker.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        Session.Remove("cart");

        //If some products haven't been ordered, set them as the "cart" session again
        if(cart_list_survivors.Count > 0){
            Session["cart"] = cart_list_survivors;
        }

        //Redirect to the success page with the order number as a query parameter
        Response.Redirect("cart_success.aspx?on=" + order_number);
    }
}