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
        if (User.IsInRole("admin"))
        {
            Products_datasource.SelectCommand = "SELECT [barcode], [name], [picture], [price], [active] FROM [Product]";
        }
        else
        {
            Products_datasource.SelectCommand = "SELECT [barcode], [name], [picture], [price], [active] FROM [Product] WHERE [active] = 1";
        }
    }

    protected void AddItemToCart_Click(object sender, EventArgs e)
    {

        if (Session.Count > 0 && Session["cart"] != null)
        {
            Cart_item cartItem = new Cart_item();
            List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
            int found = 0;
            Cart_item found_item = new Cart_item();
            foreach(Cart_item c in cart_list)
            {
                if (c.product_barcode == Convert.ToInt64(ListView1.SelectedDataKey.Value))
                {
                     found = 1;
                     found_item = c;
                     break;
                 }
            }
            cart_list.Remove(found_item);

            if(found == 1){
                cartItem.product_quantity = found_item.product_quantity + 1;
                cartItem.product_name = found_item.product_name;
                cartItem.product_barcode = found_item.product_barcode;
                cartItem.product_price = found_item.product_price;
                cart_list.Add(cartItem);
            }
            else
            {
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
            }

            Session["cart"] = cart_list;
        } 
        else 
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
        }

    }
}