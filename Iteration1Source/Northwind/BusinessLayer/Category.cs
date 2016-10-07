#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace BusinessLayer
{
	public class Category
	{
		private int categoryID;
		private string categoryName;

		public Category()
		{
		}

		public Category(int categoryID, string categoryName)
		{
			this.categoryID = categoryID;
			this.categoryName = categoryName;
		}

		public int CategoryID
		{
			get
			{
				return this.categoryID;
			}

			set
			{
				this.categoryID = value;
			}
		}

		public string CategoryName
		{
			get
			{
				return this.categoryName;
			}

			set
			{
				this.categoryName = value;
			}
		}
	}
}
