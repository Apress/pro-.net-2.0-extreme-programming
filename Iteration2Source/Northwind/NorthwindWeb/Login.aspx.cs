using System;
using BusinessLayer;
using DataLayer;

public partial class Login_aspx : System.Web.UI.Page
{
	protected void SubmitButton_Click(object sender, System.EventArgs e)
	{
		string passwordText = Request.Params["passwordTextBox"];
		UserData userData = new UserData();
		User user = userData.GetUser(usernameTextBox.Text, passwordText);

		successLabel.Visible = true;

		if (user != null)
		{
            Session["User"] = user;

            // Go to main Northwind Web page
			Response.Redirect("BrowseCatelog.aspx", true);
		}
		else
		{
			// Go back to this page to let the user try again
			successLabel.Text = "User login failed, gasp!";
		}
	}
}
