using System;
using DataLayer;

public partial class AddUser : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
    }

    private void submitButton_Click(object sender, System.EventArgs e)
    {
        bool saveSuccessful = UserData.SaveNewUser(userNameTextBox.Text,
                                Request.Params["passwordTextBox"],
                                roleDropDownList.SelectedItem.Text);

        if (saveSuccessful)
        {
            // Go back to main admin area
            Response.Redirect("Admin.aspx", true);
        }
        else
        {
            // Go back to this page to let the user try again
            successLabel.Text = "New user save failed, gasp!";
        }
    }
}
