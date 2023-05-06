using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart_cart_success : System.Web.UI.Page
{
    public string order_number { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        order_number = Request.QueryString["on"];
    }
}