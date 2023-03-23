using System;
using Renci.SshNet;

namespace changepassword
{
	public class RenciSshNet : IChangePassword
	{

		public void ChangePassword(string host, int port, string username, string password, string newPassword)
        {
            // Create a new SSH client with the hostname, port, username, and current password
            var client = new SshClient(host, port, username, password);

            // Connect to the SSH server
            client.Connect();

            // Use the SSH client to create a new shell stream
            var shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);

            Thread.Sleep(1000);
            // Wait for the shell to start up
            while (!shellStream.DataAvailable) { }

            // Send the 'passwd' command to the shell
            shellStream.WriteLine("passwd");

            Thread.Sleep(1000);
            // Wait for the 'passwd' command prompt to appear
            while (!shellStream.DataAvailable) { }

            // Send the current password to the shell
            shellStream.WriteLine(password);

            Thread.Sleep(1000);
            // Wait for the shell to prompt for a new password
            while (!shellStream.DataAvailable) { }

            // Send the new password to the shell
            shellStream.WriteLine(newPassword);

            Thread.Sleep(1000);
            // Wait for the shell to prompt to confirm the new password
            while (!shellStream.DataAvailable) { }

            // Send the new password again to confirm it
            shellStream.WriteLine(newPassword);

            Thread.Sleep(1000);
            // Wait for the 'passwd' command to complete
            while (!shellStream.DataAvailable) { }

            // Read the output of the 'passwd' command

            Thread.Sleep(1000);

            var reader = new StreamReader(shellStream);

            var output = reader.ReadToEnd();

            Console.WriteLine(output);
            // Disconnect from the SSH server
            client.Disconnect();
        }
    }
}

