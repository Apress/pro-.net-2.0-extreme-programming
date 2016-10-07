#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace BusinessLayer
{
    public class OrderDetail
    {
        private int orderID;
        private int productID;
        private decimal unitPrice;
        private int quantityOrdered;
        private float discount;

        public OrderDetail()
        {
        }

        public OrderDetail(int orderID,
                           int productID,
                           decimal unitPrice,
                           int quantityOrdered,
                           float discount)
        {
            this.orderID = orderID;
            this.productID = productID;
            this.unitPrice = unitPrice;
            this.quantityOrdered = quantityOrdered;
            this.discount = discount;
        }

        public int OrderID
        {
            get
            {
                return this.orderID;
            }
            set
            {
                this.orderID = value;
            }
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

        public decimal UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public int QuantityOrdered
        {
            get
            {
                return this.quantityOrdered;
            }
            set
            {
                this.quantityOrdered = value;
            }
        }

        public float Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                this.discount = value;
            }
        }
    }
}
