#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;
using BusinessLayer;

#endregion

namespace DataLayer
{
	public class UserData
	{
		public UserData()
		{
		}

		public User GetUser(string username, string password)
		{
			User user = null;

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				//Build command string
				StringBuilder commandText = new StringBuilder("SELECT * FROM Users WHERE UserName = '");
				commandText.Append(username);
				commandText.Append("' AND Password = '");
				commandText.Append(password);
				commandText.Append("'");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				// Make sure that we found our user
				if (dataReader.Read())
				{
					user = new User(dataReader.GetString(0),
						dataReader.GetString(1),
                        dataReader.GetString(2));
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			return user;
		}

        public static bool SaveNewUser(string userName, string password, string role)
        {
            bool saveSuccessful = false;

            if ((userName != null) && (userName.Length > 0) &&
                (password != null) && (password.Length > 0) &&
                (role != null) && (role.Length > 0))
            {
                try
                {
                    OdbcConnection dataConnection = new OdbcConnection();
                    dataConnection.ConnectionString = DataUtilities.ConnectionString;
                    dataConnection.Open();

                    OdbcCommand dataCommand = new OdbcCommand();
                    dataCommand.Connection = dataConnection;

                    // Build Command String
                    StringBuilder commandText =
                      new StringBuilder("INSERT INTO Users VALUES ('");
                    commandText.Append(userName);
                    commandText.Append("', '");
                    commandText.Append(password);
                    commandText.Append("', '");
                    commandText.Append(role);
                    commandText.Append("')");

                    dataCommand.CommandText = commandText.ToString();
                    dataCommand.ExecuteNonQuery();
                    dataConnection.Close();
                    saveSuccessful = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }
            }

            return saveSuccessful;
        }
    }
}
