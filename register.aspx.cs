using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using System.Data.SqlClient;
using System.Configuration; 

public partial class Access_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(CreateUserWizard1.UserName, "customer");

        //Get the date as a string from the dateTextBox
        string dateStr = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("dateTextBox")).Text;

        //Split the date string on every '-' or '/' found
        string[] splitDateStr = dateStr.Split(new char[] { '-', '/' });

        //Create a DateTime object from the chosen date. Constructor takes date in this order: year, month, date. So, last index of the array first
        DateTime theDate = new DateTime(Convert.ToInt32(splitDateStr[2]), Convert.ToInt32(splitDateStr[1]), Convert.ToInt32(splitDateStr[0]));

        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to insert a user. By using prepared statements,
        // we automatically get some protection against SQL injection.
        string sqlStr = "INSERT INTO Users (username, name, surname, phone, date_of_birth, address) VALUES (@theUsername, @theName, @theSurname, @thePhone, @theDate, @theAddress)";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        // Fill in the parameters in our prepared SQL statement
        sqlCmd.Parameters.AddWithValue("@theUsername", CreateUserWizard1.UserName);
        sqlCmd.Parameters.AddWithValue("@theName", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("name")).Text);
        sqlCmd.Parameters.AddWithValue("@theSurname", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("surname")).Text);
        sqlCmd.Parameters.AddWithValue("@theDate", theDate);
        sqlCmd.Parameters.AddWithValue("@thePhone", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("PhoneNumber")).Text);
        sqlCmd.Parameters.AddWithValue("@theAddress", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address")).Text);



        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();
    }
}