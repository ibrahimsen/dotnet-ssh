using System;
namespace changepassword
{
	public interface IChangePassword
	{
		void ChangePassword(string host, int port, string username, string password, string newPassword);
	}
}

