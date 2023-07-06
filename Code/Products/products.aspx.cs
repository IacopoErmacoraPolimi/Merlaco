using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

public partial class Products_products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check the user role and select the correct data from the database based on it
        if (User.IsInRole("admin"))
        {
            Products_datasource.SelectCommand = "SELECT [barcode], [name], [picture], [price], [active], [quantity_in_stock] FROM [Product]";
        }
        else
        {
            Products_datasource.SelectCommand = "SELECT [barcode], [name], [picture], [price], [active], [quantity_in_stock] FROM [Product] WHERE [active] = 1";

            //Set, if necessary, the error messages from the AddItemToCart_Click function
            if (Request.QueryString["a"] == "0")
            {
                MessageCart.InnerText = "Item not added, the request exceeds the quantity in stock";
            }

            if (Request.QueryString["a"] == "1")
            {
                MessageCart.InnerText = "Item added to the cart!";
            }
        }
    }

    protected void AddItemToCart_Click(object sender, EventArgs e)
    {
        string item_inserted = "nada";
        //If there's a cart session already, add the item to it
        if (Session.Count > 0 && Session["cart"] != null)
        {
            Cart_item cartItem = new Cart_item();
            List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
            int found = 0;
            Cart_item found_item = new Cart_item();

            //Find out if the item is already present in the cart
            foreach (Cart_item c in cart_list)
            {
                if (c.product_barcode == Convert.ToInt64(ListView1.SelectedDataKey.Value))
                {
                    found = 1;
                    found_item = c;
                    break;
                }
            }
            cart_list.Remove(found_item);

            // Gets the default connection string/path to our database from the web.config file
            string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Creates a connection to our database
            SqlConnection con = new SqlConnection(dbstring);

            // The SQL statement to select the quantity in stock of the item we want to add to the cart
            string sqlStr_check_stock = "SELECT quantity_in_stock FROM Product WHERE barcode = " + found_item.product_barcode;

            // Open the database connection
            con.Open();

            // Create an executable SQL command containing our SQL statement and the database connection
            SqlCommand sqlCmd_check_stock = new SqlCommand(sqlStr_check_stock, con);

            SqlDataReader DR1 = sqlCmd_check_stock.ExecuteReader();

            //Read the data and set the stock quantity
            int stock_quantity = 0;
            if (DR1.Read())
            {
                stock_quantity = Convert.ToInt16(DR1.GetValue(0).ToString());
            }

            DR1.Close();

            con.Close();

            //Add (or not) the product to the orders, based on quantity availability on the database
            if (found == 1 && stock_quantity > found_item.product_quantity)
            {
                cartItem.product_quantity = found_item.product_quantity + 1;
                cartItem.product_name = found_item.product_name;
                cartItem.product_barcode = found_item.product_barcode;
                cartItem.product_price = found_item.product_price;
                cart_list.Add(cartItem);
                item_inserted = "1";
            }
            else if (found == 1 && stock_quantity <= found_item.product_quantity)
            {
                cart_list.Add(found_item);
                item_inserted = "0";
            } 
            else 
            {
                cartItem.product_quantity = 1;
                cartItem.product_barcode = Convert.ToInt64(ListView1.SelectedDataKey.Value);

                string dbstring2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                SqlConnection Conn = new SqlConnection(dbstring2);

                string sqlStr = "SELECT name, price FROM Product WHERE barcode = @theBarcode";

                SqlCommand Comm1 = new SqlCommand(sqlStr, Conn);

                Conn.Open();

                Comm1.Parameters.AddWithValue("@theBarcode", Convert.ToInt64(ListView1.SelectedDataKey.Value));

                SqlDataReader DR2 = Comm1.ExecuteReader();

                if (DR2.Read())
                {
                    cartItem.product_name = DR2.GetValue(0).ToString();
                    cartItem.product_price = Convert.ToInt16(DR2.GetValue(1));
                }

                Conn.Close();

                cart_list.Add(cartItem);
                item_inserted = "1";
            }

            Session["cart"] = cart_list;
        }
        else
        //if there isn't a cart session already, create it and add the new item
        {
            Cart_item cartItem = new Cart_item();
            List<Cart_item> cart_list = new List<Cart_item>();

            cartItem.product_quantity = 1;
            cartItem.product_barcode = Convert.ToInt64(ListView1.SelectedDataKey.Value);

            string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection Conn = new SqlConnection(dbstring);

            string sqlStr = "SELECT name, price FROM Product WHERE barcode = @theBarcode";

            SqlCommand Comm1 = new SqlCommand(sqlStr, Conn);

            Conn.Open();

            Comm1.Parameters.AddWithValue("@theBarcode", Convert.ToInt64(ListView1.SelectedDataKey.Value));

            SqlDataReader DR1 = Comm1.ExecuteReader();

            if (DR1.Read())
            {
                cartItem.product_name = DR1.GetValue(0).ToString();
                cartItem.product_price = Convert.ToInt16(DR1.GetValue(1));
            }

            Conn.Close();

            cart_list.Add(cartItem);

            Session["cart"] = cart_list;
            item_inserted = "1";
        }

        //Reload the page
        Response.Redirect("products.aspx?a=" + item_inserted);

    }
}