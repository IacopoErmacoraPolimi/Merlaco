using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart_cart_success : System.Web.UI.Page
{
    public string order_number { get; set; }

    public List<Cart_item> cart_list;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Retrieve the order namber from the URL
        order_number = Request.QueryString["on"];

        //If there's a cart session set, create a list of Cart_items and bind it to the repeater
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
}