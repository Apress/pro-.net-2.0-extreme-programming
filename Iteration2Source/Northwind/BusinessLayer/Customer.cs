#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace BusinessLayer
{
	public class Customer
	{
		private string customerID;
		private string userName;
		private string companyName;
		private string address;
		private string city;
		private string postalCode;
		private string country;
		private string phoneNumber;

		public Customer()
		{
		}

		public Customer(string customerID,
			string userName,
			string companyName,
			string address,
			string city,
			string postalCode,
			string country,
			string phoneNumber)
		{
			this.customerID = customerID;
			this.userName = userName;
			this.companyName = companyName;
			this.address = address;
			this.city = city;
			this.postalCode = postalCode;
			this.country = country;
			this.phoneNumber = phoneNumber;
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

		public string UserName
		{
			get
			{
				return this.userName;
			}

			set
			{
				this.userName = value;
			}
		}

		public string CompanyName
		{
			get
			{
				return this.companyName;
			}

			set
			{
				this.companyName = value;
			}
		}

		public string Address
		{
			get
			{
				return this.address;
			}

			set
			{
				this.address = value;
			}
		}

		public string City
		{
			get
			{
				return this.city;
			}

			set
			{
				this.city = value;
			}
		}

		public string PostalCode
		{
			get
			{
				return this.postalCode;
			}

			set
			{
				this.postalCode = value;
			}
		}

		public string Country
		{
			get
			{
				return this.country;
			}

			set
			{
				this.country = value;
			}
		}

		public string PhoneNumber
		{
			get
			{
				return this.phoneNumber;
			}

			set
			{
				this.phoneNumber = value;
			}
		}
	}
}
