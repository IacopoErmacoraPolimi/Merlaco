using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Orders_order_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Order_info_datasource.SelectCommand = "SELECT [Order].[product_bar_code], [quantity], [Product].[place], [Product].[alternative], [Order].[picked] FROM [Order], [Product] WHERE [Order].[product_bar_code] = [Product].[barcode]";
    }
}