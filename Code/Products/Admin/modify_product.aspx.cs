using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

using System.Web.Security;

using System.IO;

public partial class Products_modify_product : System.Web.UI.Page
{

    public string barcode { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Gets the default connection string/path to our database from the web.config file
            string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Creates a connection to our database
            SqlConnection Conn = new SqlConnection(dbstring);

            // The SQL statement to select the data from the product the user wants to modify.
            string sqlStr = "SELECT * FROM [Product] WHERE [barcode] = @theBarcode";

            // Create an executable SQL command containing our SQL statement and the database connection
            SqlCommand Comm1 = new SqlCommand(sqlStr, Conn);

            //Set the parameter for the query
            string thebc = Request.QueryString["bc"];
            Comm1.Parameters.AddWithValue("@theBarcode", thebc);

            Conn.Open();

            //Create a Datareader for the selected data
            SqlDataReader DR1 = Comm1.ExecuteReader();

            //Assign the values to variables accessible from the frontend
            if (DR1.Read())
            {
                barcode = DR1.GetValue(0).ToString();
                Name.Text = DR1.GetValue(1).ToString();
                image.ImageUrl = DR1.GetValue(2).ToString();
                Origin.Text = DR1.GetValue(3).ToString();
                Eco_or_not.Text = DR1.GetValue(4).ToString();
                Quantity_in_stock.Text = DR1.GetValue(5).ToString();
                Description.Text = DR1.GetValue(6).ToString();
                Price.Text = DR1.GetValue(7).ToString();
                Place.Text = DR1.GetValue(8).ToString();
                Alternative.Text = DR1.GetValue(9).ToString();
            }

            Conn.Close();
        }
    }

    protected void EditProductButton_Click(object sender, EventArgs e)
    {
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to update a product
        string sqlStr = "UPDATE Product SET name = @Thename, picture = @Thepicture, origin = @Theorigin, eco_or_not = @Theeco_or_not, quantity_in_stock = @Thequantity_in_stock, description = @Thedescription, price = @Theprice, place = @Theplace, alternative = @Thealternative WHERE barcode = @Thebarcode";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        string thebc = Request.QueryString["bc"];

        string filePath = image.ImageUrl;

        //Check if the user has selected an image file that should be used instead of the default
        if (ImageFileUpload.HasFile)
        {
            //Check if the file has a valid extension
            string extension = System.IO.Path.GetExtension(ImageFileUpload.PostedFile.FileName);

            if (extension == ".png" || extension == ".gif" || extension == ".jpg" || extension == ".bmp")
            {
                //Save the file in the Products folder on the server. I want the filename to be the barcode of the product,
                string PrdBarcode = thebc;

                filePath = "~/images/Products/" + PrdBarcode + extension;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                //Now save the file
                ImageFileUpload.SaveAs(Server.MapPath("~/images/Products/" + PrdBarcode + extension));
            }
        }

        // Fill in the parameters in our prepared SQL statement
        sqlCmd.Parameters.AddWithValue("@Thebarcode", thebc);
        sqlCmd.Parameters.AddWithValue("@Thename", Name.Text);
        sqlCmd.Parameters.AddWithValue("@Thepicture", filePath);
        sqlCmd.Parameters.AddWithValue("@Theorigin", Origin.Text);
        sqlCmd.Parameters.AddWithValue("@Theeco_or_not", Eco_or_not.Text);
        sqlCmd.Parameters.AddWithValue("@Thequantity_in_stock", Quantity_in_stock.Text);
        sqlCmd.Parameters.AddWithValue("@Thedescription", Description.Text);
        sqlCmd.Parameters.AddWithValue("@Theprice", Price.Text);
        sqlCmd.Parameters.AddWithValue("@Theplace", Place.Text);
        sqlCmd.Parameters.AddWithValue("@Thealternative", Alternative.Text);

        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        // Show the user that the product has been added
        resultLabel.Text = "Product modified";

    }
}