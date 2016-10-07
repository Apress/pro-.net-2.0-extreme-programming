using System;
using System.Collections;
using System.Drawing;
using BusinessLayer;
using DataLayer;

public partial class Categories_ascx : System.Web.UI.UserControl
{
	protected ArrayList categories;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		categories = CategoryData.GetAllCategories();
	}
}
