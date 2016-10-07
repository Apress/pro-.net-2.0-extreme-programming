using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
	public class ShoppingCart
	{
		private Hashtable table;
		private int quantity;

		public ShoppingCart()
		{
			table = new Hashtable();
			quantity = 0;
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

		protected void UpdateQuantity()
		{
			this.quantity = 0;
			IDictionaryEnumerator cartEnumerator = table.GetEnumerator();

			while ( cartEnumerator.MoveNext() )
			{
				LineItem lineItem = (LineItem)cartEnumerator.Value;
				this.quantity += lineItem.Quantity;
			}
		}

		public void AddLineItem(LineItem lineItem)
		{
			if (!table.Contains(lineItem.ProductID))
			{
				table.Add(lineItem.ProductID, lineItem);    
			}
			else
			{
				LineItem existingItem = (LineItem)table[lineItem.ProductID];
				existingItem.Quantity += lineItem.Quantity;
			}

			UpdateQuantity();
		}

		public LineItem GetLineItem(int productID)
		{
			LineItem lineItem = (LineItem)table[productID];
			return lineItem;
		}

		public void UpdateLineItemMessage(int productID, string message)
		{
			LineItem lineItem = (LineItem)table[productID];

            if (lineItem != null)
            {
                lineItem.Message = message;
            }
		}

		public void UpdateLineItemQuantity(int productID, int quantity)
		{
			if ( quantity > 0 )
			{
				LineItem lineItem = (LineItem)table[productID];
				lineItem.Quantity = quantity;
			}
			else
			{
				table.Remove(productID);
			}

			UpdateQuantity();
		}

		public IDictionaryEnumerator GetCartContents()
		{
			return table.GetEnumerator();
		}
	}
}
