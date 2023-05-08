using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

using System.Web.Security;

public partial class Users_user_profile : System.Web.UI.Page
{
    public string name { get; set; }
    public string surname { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string IBAN { get; set; }
    public string username { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Select from the database the data of the user whose profile we want to display
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection Conn = new SqlConnection(dbstring);

        string sqlStr = "SELECT [Users].[name], [Users].[surname], [Users].[address], [Users].[IBAN], [aspnet_Membership].[email], [Users].[username], [Users].[picture] FROM [Users], [aspnet_Users], [aspnet_membership] WHERE [Users].[username] = @theUsername AND [Users].[username] = [aspnet_Users].[UserName] AND [aspnet_Users].[UserId] = [aspnet_Membership].[UserId] AND [aspnet_Membership].[isApproved] = 1";

        SqlCommand Comm1 = new SqlCommand(sqlStr, Conn);

        Conn.Open();

        //Select the username based on the role of the user
        if (User.IsInRole("admin"))
        {
            if (Request.QueryString["u"] != null)
            {
                string usr = Request.QueryString["u"];
                Comm1.Parameters.AddWithValue("@theUsername", usr);
            }
            else
            {
                string usr = Membership.GetUser().UserName;
                Comm1.Parameters.AddWithValue("@theUsername", usr);
            }
        }
        else
        {
            string usr = Membership.GetUser().UserName;
            Comm1.Parameters.AddWithValue("@theUsername", usr);
        }
        
        SqlDataReader DR1 = Comm1.ExecuteReader();

        if (DR1.Read())
        {
            name = DR1.GetValue(0).ToString();
            surname = DR1.GetValue(1).ToString();
            address = DR1.GetValue(2).ToString();
            IBAN = DR1.GetValue(3).ToString();
            email = DR1.GetValue(4).ToString();
            username = DR1.GetValue(5).ToString();
            image.ImageUrl = DR1.GetValue(6).ToString();
        }


        Conn.Close();

        Button btn = (Button)LoginView2.FindControl("EditUserButton");
        btn.PostBackUrl = "modify_user.aspx?usr=" + username;
    }

    protected void OnClick_delete_user(object sender, EventArgs e)
    {
        // Gets the default connection string/path to our database from the web.config file
        string dbstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Creates a connection to our database
        SqlConnection con = new SqlConnection(dbstring);

        // The SQL statement to delete (or better, deactivate) a user
        string sqlStr = "UPDATE aspnet_Membership SET IsApproved = 0 WHERE UserId IN (SELECT UserId FROM aspnet_Users WHERE UserName = @theUsername)";

        // Open the database connection
        con.Open();

        // Create an executable SQL command containing our SQL statement and the database connection
        SqlCommand sqlCmd = new SqlCommand(sqlStr, con);

        sqlCmd.Parameters.AddWithValue("@theUsername", username);

        // Execute the SQL command
        sqlCmd.ExecuteNonQuery();

        // Close the connection to the database
        con.Close();

        //Logout the user if deleted himself, otherwise reload the page
        if (User.IsInRole("customer"))
        {
            FormsAuthentication.SignOut();
            Response.Cookies.Clear();

            Response.Redirect("/WEE_Project/Products/products.aspx");
        }
        else
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}