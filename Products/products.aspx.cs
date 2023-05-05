using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products_products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Products_datasource.SelectCommand = "SELECT [barcode], [name], [picture], [price] FROM [Product]";

        AddProductButton.PostBackUrl = "Admin/add_product.aspx";
    }

    protected void AddItemToCart_Click(object sender, EventArgs e)
    {

        if (Session.Count > 0 && Session["cart"] != null)
        {
            Cart_item cartItem = new Cart_item();
            List<Cart_item> cart_list = (List<Cart_item>)Session["cart"];
            int found = 0;
            int prev_quantity = 0;

            foreach(Cart_item c in cart_list)
            {
                if (c.product_barcode == Convert.ToInt64(ListView1.SelectedDataKey.Value))
                { //
                     found = 1;
                     prev_quantity = c.product_quantity;
                     cart_list.Remove(c);
                 }
            }

            if(found == 1){
                cartItem.product_quantity = prev_quantity + 1;
                cartItem.product_barcode = Convert.ToInt64(ListView1.SelectedDataKey.Value);
                cart_list.Add(cartItem);
            }
            else
            {
                cart_list.Add(cartItem);
            }
        } 
        else 
        {
            Cart_item cartItem = new Cart_item();
            List<Cart_item> cart_list = new List<Cart_item>();             
            
            cartItem.product_quantity = 1;
            cartItem.product_barcode = Convert.ToInt64(ListView1.SelectedDataKey.Value);
            cart_list.Add(cartItem);
            //Response.Write(ListView1.SelectedDataKey.Value);
        }
    }
}