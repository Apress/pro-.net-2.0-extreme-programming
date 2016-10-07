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
        private string role;

		public User()
		{
		}

		public User(string userName, string password, string role)
		{
			this.userName = userName;
			this.password = password;
            this.role = role;
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

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }
    }
}
