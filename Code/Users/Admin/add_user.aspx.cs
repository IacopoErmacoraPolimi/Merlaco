using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using System.Data.SqlClient;
using System.Configuration; 

public partial class Users_add_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Only do the following when the page is actually loaded, not when we click on buttons, etc
        if (!IsPostBack)
        {
            // I create a DropDownList object representing the DropDownList in my page.
            // Since I converted the CreateUserWizard to a template the DropDownList is hidden inside the ContentTemplateContainer tag
            DropDownList theRoles = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleList");

            // I set the data source of the DropDownList to a list of all defined roles in the database, by
            // using the static Roles class
            theRoles.DataSource = Roles.GetAllRoles();

            // Bind the DropDownList object and its datasource to the actual DropDownList in my page
            theRoles.DataBind();

            // Run through the list of roles. If a "customer" role exist, then make that the start value in the DropDownList. 
            // If someone forgets to change the role it's better to create too many customers than admins.
            for (int i = 0; i < theRoles.Items.Count; i++)
            {
                if ((theRoles.Items[i].Value).Equals("customer"))
                {
                    theRoles.SelectedIndex = i;
                }
            }
        }
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        // Set the role of the created user to the selected role in the DropDownList
        Roles.AddUserToRole(CreateUserWizard1.UserName, ((DropDownList)(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleList"))).SelectedValue);

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
        string sqlStr = "INSERT INTO Users (username, name, surname, phone, date_of_birth, IBAN, address, picture) VALUES (@theUsername, @theName, @theSurname, @thePhone, @theDate, @theIBAN, @theAddress, @thePicture)";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        //Find out which path to store in the DB for the images of the conference room. First set it
        //to the default value
        string filePath = "~/images/Users/NoImage.png";

        //Check if the user has selected an image file that should be used instead of the default
        if (((FileUpload)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ImageFileUpload")).HasFile)
        {
            //Check if the file has a valid extension
            string extension = System.IO.Path.GetExtension(((FileUpload)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ImageFileUpload")).PostedFile.FileName);

            if (extension == ".png" || extension == ".gif" || extension == ".jpg" || extension == ".bmp")
            {
                //Save the file in the Users folder on the server. I want the filename to be the barcode of the product,
                string username = CreateUserWizard1.UserName;

                filePath = "~/images/Users/" + username + extension;

                //Now save the file
                ((FileUpload)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ImageFileUpload")).SaveAs(Server.MapPath("~/images/Users/" + username + extension));
            }
        }

        // Fill in the parameters in our prepared SQL statement
        sqlCmd.Parameters.AddWithValue("@theUsername", CreateUserWizard1.UserName);
        sqlCmd.Parameters.AddWithValue("@theName", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("name")).Text);
        sqlCmd.Parameters.AddWithValue("@theSurname", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("surname")).Text);
        sqlCmd.Parameters.AddWithValue("@theDate", theDate);
        sqlCmd.Parameters.AddWithValue("@thePhone", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("PhoneNumber")).Text);
        sqlCmd.Parameters.AddWithValue("@theAddress", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address")).Text);
        if (string.IsNullOrEmpty(((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("IBAN")).Text))
        {
            sqlCmd.Parameters.AddWithValue("@theIBAN", DBNull.Value);
        }
        else
        {
            sqlCmd.Parameters.AddWithValue("@theIBAN", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("IBAN")).Text);
        }
        sqlCmd.Parameters.AddWithValue("@thePicture", filePath);


        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();
    }
}