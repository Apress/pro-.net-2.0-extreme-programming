#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace BusinessLayer
{
	public class Product
	{
		private int productID;
		private int categoryID;
		private string productName;
		private decimal price;
		private int quantity;

		public Product()
		{
		}

		public Product(int productID,
			int categoryID,
			string productName,
			decimal price,
			int quantity)
		{
			this.productID = productID;
			this.categoryID = categoryID;
			this.productName = productName;
			this.price = price;
			this.quantity = quantity;
		}

		public int ProductID
		{
			get
			{
				return this.productID;
			}

			set
			{
				this.productID = value;
			}
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

		public string ProductName
		{
			get
			{
				return this.productName;
			}

			set
			{
				this.productName = value;
			}
		}

		public decimal Price
		{
			get
			{
				return this.price;
			}

			set
			{
				this.price = value;
			}
		}

		public int Quantity
		{
			get
			{
				return this.quantity;
			}

			set
			{
				this.quantity = value;
			}
		}
	}
}
