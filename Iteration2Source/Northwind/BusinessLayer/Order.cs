#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace BusinessLayer
{
    public class Order
    {
        private int orderID;
        private string customerID;
        private DateTime orderDate;
        private DateTime shipDate;
        private string shipName;
        private string shipAddress;
        private string shipCity;
        private string shipPostalCode;
        private string shipCountry;

        public Order()
        {
        }

        public Order(int orderID,
                     string customerID,
                     DateTime orderDate,
                     DateTime shipDate,
                     string shipName,
                     string shipAddress,
                     string shipCity,
                     string shipPostalCode,
                     string shipCountry)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.orderDate = orderDate;
            this.shipDate = shipDate;
            this.shipName = shipName;
            this.shipAddress = shipAddress;
            this.shipCity = shipCity;
            this.shipPostalCode = shipPostalCode;
            this.shipCountry = shipCountry;
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

        public string CustomerID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return this.orderDate;
            }
            set
            {
                this.orderDate = value;
            }
        }

        public DateTime ShipDate
        {
            get
            {
                return this.shipDate;
            }
            set
            {
                this.shipDate = value;
            }
        }

        public string ShipName
        {
            get
            {
                return this.shipName;
            }
            set
            {
                this.shipName = value;
            }
        }

        public string ShipAddress
        {
            get
            {
                return this.shipAddress;
            }
            set
            {
                this.shipAddress = value;
            }
        }

        public string ShipCity
        {
            get
            {
                return this.shipCity;
            }
            set
            {
                this.shipCity = value;
            }
        }

        public string ShipPostalCode
        {
            get
            {
                return this.shipPostalCode;
            }
            set
            {
                this.shipPostalCode = value;
            }
        }

        public string ShipCountry
        {
            get
            {
                return this.shipCountry;
            }
            set
            {
                this.shipCountry = value;
            }
        }
    }
}
