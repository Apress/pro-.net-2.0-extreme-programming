#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;

#endregion

namespace DataLayer
{
	interface IUserData
	{
		User GetUser(string username, string password);
	}
}
