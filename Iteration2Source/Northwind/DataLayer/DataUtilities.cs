#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DataLayer
{
	public class DataUtilities
	{
		public static string connectionString =
			"Driver={Microsoft Access Driver (*.mdb)};DBQ=c:\\xpnet\\database\\Northwind";

		public DataUtilities()
		{

		}

		public static string ConnectionString
		{
			get
			{
				return connectionString;
			}

			set
			{
				DataUtilities.connectionString = value;
			}
		}
	}
}
