#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace BusinessLayer
{
	public class User
	{
		private string userName;
		private string password;

		public User()
		{
		}

		public User(string userName, string password)
		{
			this.userName = userName;
			this.password = password;
		}
	}
}
