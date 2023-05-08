using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration; 

public partial class Products_add_product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddProductButton_Click(object sender, EventArgs e)
    {
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a new product
        string sqlStr = "INSERT INTO Product (barcode, name, picture, origin, eco_or_not, quantity_in_stock, description, price, place, alternative) VALUES (@Thebarcode, @Thename, @Thepicture, @Theorigin, @Theeco_or_not, @Thequantity_in_stock, @Thedescription, @Theprice, @Theplace, @Thealternative)";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        //Find out which path to store in the DB for the images of the product. 
        string filePath = "~/images/Products/NoImage.png";

        //Check if the user has selected an image file that should be used instead of the default
        if (ImageFileUpload.HasFile)
        {
            //Check if the file has a valid extension
            string extension = System.IO.Path.GetExtension(ImageFileUpload.PostedFile.FileName);

            if (extension == ".png" || extension == ".gif" || extension == ".jpg" || extension == ".bmp")
            {
                //Save the file in the Products folder on the server. I want the filename to be the barcode of the product,
                string PrdBarcode = Barcode.Text;

                filePath = "~/images/Products/" + PrdBarcode + extension;

                //Now save the file
                ImageFileUpload.SaveAs(Server.MapPath("~/images/Products/" + PrdBarcode + extension));
            }
        }

        // Fill in the parameters in our prepared SQL statement
        sqlCmd.Parameters.AddWithValue("@Thebarcode", Barcode.Text);
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
        resultLabel.Text = "Product added";

    }
}