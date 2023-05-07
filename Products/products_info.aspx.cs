using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

using System.Web.Security;

public partial class Products_products_info : System.Web.UI.Page
{

    public string barcode { get; set; }
    public string name { get; set; }
    public string picture { get; set; }
    public string origin { get; set; }
    public string eco_or_not { get; set; }
    public string quantity_in_stock { get; set; }
    public string description { get; set; }
    public string price { get; set; }
    public string place { get; set; }
    public string alternative { get; set; }
    public bool active { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        string product_bc = Request.QueryString["bc"];

        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection Conn = new SqlConnection(dbstring);

        string sqlStr = "SELECT * FROM [Product] WHERE [barcode] = @theBarcode";

        SqlCommand Comm1 = new SqlCommand(sqlStr, Conn);

        string thebc = Request.QueryString["bc"];
        Comm1.Parameters.AddWithValue("@theBarcode", thebc);

        Conn.Open();

        SqlDataReader DR1 = Comm1.ExecuteReader();

        if (DR1.Read())
        {
            barcode = DR1.GetValue(0).ToString();
            name = DR1.GetValue(1).ToString();
            image.ImageUrl = DR1.GetValue(2).ToString();
            origin = DR1.GetValue(3).ToString();
            eco_or_not = DR1.GetValue(4).ToString();
            quantity_in_stock = DR1.GetValue(5).ToString();
            description = DR1.GetValue(6).ToString();
            price = DR1.GetValue(7).ToString();
            place = DR1.GetValue(8).ToString();
            alternative = DR1.GetValue(9).ToString();
            active = Convert.ToBoolean(DR1.GetValue(10).ToString());
        }

        Conn.Close();

        if (User.IsInRole("admin"))
        {
            Button btn = (Button)LoginView2.FindControl("EditProductButton");
            btn.PostBackUrl = "Admin/modify_product.aspx?bc=" + barcode;
        }
    }

    protected void OnClick_active_deactive_btn(object sender, EventArgs e)
    {
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a booking. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr_o = "UPDATE Product SET active = ~active WHERE barcode = @theBarcode";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd_o = new SqlCommand(sqlStr_o, con);

        // Fill in the parameters in our prepared SQL statement
        sqlCmd_o.Parameters.AddWithValue("@theBarcode", barcode);

        // Execute the SQL command
        sqlCmd_o.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();
    }
}