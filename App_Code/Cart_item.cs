using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Class for session-based cart
public class Cart_item
{

    public long product_barcode { get; set; }
    public string product_name { get; set; }
    public int product_quantity { get; set; }
    public int product_price { get; set; }

	public Cart_item()
	{
	}
}