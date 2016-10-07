using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
	public class LineItem
	{
		private int quantity;
		private Product item;
		string message;

		public LineItem()
		{
		}

		public LineItem(int quantity, Product item)
		{
			this.quantity = quantity;
			this.item = item;
			this.message = "";
		}

		public int ProductID
		{
			get 
			{
				return this.item.ProductID;
			}
			set
			{
				this.item.ProductID= value;
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

		public Product Item
		{
			get 
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}

		public string Message
		{
			get
			{
				return this.message;
			}
			set
			{
				this.message = value;
			}
		}
	}
}
