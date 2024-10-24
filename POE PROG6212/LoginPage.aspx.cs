using System;
using System.Web.UI;

namespace Programming_p2
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can add any additional logic here that needs to run on page load
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the username, password, and user type
            string username = txtUser.Text;
            string password = txtPass.Text;
            string userType = drpUser.SelectedValue;

            // Here, you should implement your authentication logic
            // This is just a simple example for demonstration purposes

            if (IsValidUser(username, password, userType))
            {
                // Redirect to different pages based on user type
                switch (userType)
                {
                    case "Lecture":
                        Response.Redirect("AddClaims.aspx"); // Redirect to Add Claims page
                        break;
                    case "Program Coordinator":
                        Response.Redirect("ViewClaims.aspx"); // Redirect to View Claims page
                        break;
                    case "Manager":
                        Response.Redirect("ClaimTracking.aspx"); // Redirect to Claim Tracking page
                        break;
                    default:
                        // Handle invalid user type
                        break;
                }
            }
            else
            {
                // Display an error message if the login fails
                // You can add a label for error messages in the ASPX page to show this
                Response.Write("<script>alert('Invalid username or password.');</script>");
            }
        }

        private bool IsValidUser(string username, string password, string userType)
        {
            // Implement your user validation logic here
            // This could involve checking a database or a list of users
            // For demonstration purposes, let's assume any non-empty username and password are valid

            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}
