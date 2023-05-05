using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart_cart : System.Web.UI.Page
{
    public List<Cart_item> cart_list;
    protected void Page_Load(object sender, EventArgs e)
    {
        cart_list = (List<Cart_item>)Session["cart"];
    }
}