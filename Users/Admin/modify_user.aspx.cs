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

public partial class Users_modify_user : System.Web.UI.Page
{
    public string username { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection Conn = new SqlConnection(dbstring);

            string sqlStr = "SELECT * FROM [Users] WHERE [username] = @Theusername";

            SqlCommand Comm1 = new SqlCommand(sqlStr, Conn);

            string theusr = Request.QueryString["usr"];
            Comm1.Parameters.AddWithValue("@Theusername", theusr);

            Conn.Open();

            SqlDataReader DR1 = Comm1.ExecuteReader();

            if (DR1.Read())
            {
                username = DR1.GetValue(0).ToString();
                Name.Text = DR1.GetValue(1).ToString();
                Surname.Text = DR1.GetValue(2).ToString();
                IBAN.Text = DR1.GetValue(3).ToString();
                Phone.Text = DR1.GetValue(4).ToString();
                Date_of_birth.Text = ((DateTime)DR1.GetValue(5)).ToShortDateString();
                Address.Text = DR1.GetValue(6).ToString();
                image.ImageUrl = DR1.GetValue(7).ToString();
            }

            Conn.Close();
        }
    }

    protected void EditUserButton_Click(object sender, EventArgs e)
    {

        //Get the date as a string from the dateTextBox
        string dateStr = Date_of_birth.Text;

        //Split the date string on every '-' or '/' found
        string[] splitDateStr = dateStr.Split(new char[] { '-', '/' });

        //Create a DateTime object from the chosen date. Constructor takes date in this order: year, month, date. So, last index of the array first
        DateTime theDate = new DateTime(Convert.ToInt32(splitDateStr[2]), Convert.ToInt32(splitDateStr[1]), Convert.ToInt32(splitDateStr[0]));

        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a booking. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr = "UPDATE Users SET name = @Thename, surname = @Thesurname, IBAN = @TheIBAN, phone = @Thephone, date_of_birth = @Thedate_of_birth, address = @Theaddress, picture = @Thepicture WHERE username = @Theusername";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        string theusr = Request.QueryString["usr"];

        string filePath = image.ImageUrl;

        //Check if the user has selected an image file that should be used instead of the default
        if (ImageFileUpload.HasFile)
        {
            //Check if the file has a valid extension
            string extension = System.IO.Path.GetExtension(ImageFileUpload.PostedFile.FileName);

            if (extension == ".png" || extension == ".gif" || extension == ".jpg" || extension == ".bmp")
            {
                //Save the file in the Products folder on the server. I want the filename to be the barcode of the product,
                string username = theusr;

                filePath = "~/images/Users/" + username + extension;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                //Now save the file
                ImageFileUpload.SaveAs(Server.MapPath("~/images/Users/" + username + extension));
            }
        }

        // Fill in the parameters in our prepared SQL statement
        sqlCmd.Parameters.AddWithValue("@Theusername", theusr);
        sqlCmd.Parameters.AddWithValue("@Thename", Name.Text);
        sqlCmd.Parameters.AddWithValue("@Thesurname", Surname.Text);
        sqlCmd.Parameters.AddWithValue("@TheIBAN", IBAN.Text);
        sqlCmd.Parameters.AddWithValue("@Thephone", Phone.Text);
        sqlCmd.Parameters.AddWithValue("@Thedate_of_birth", theDate);
        sqlCmd.Parameters.AddWithValue("@Theaddress", Address.Text);
        sqlCmd.Parameters.AddWithValue("@Thepicture", filePath);

        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        // Show the user that the booking has been added
        resultLabel.Text = "User modified";

    }
}