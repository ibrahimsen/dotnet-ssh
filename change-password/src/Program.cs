using Renci.SshNet;

string host = "192.168.1.107";
string username = "ssh";
var currentPassword = "supersecretpass";
string newPassword = "newsupersecretpass";
var port = 22;

// Create a new SSH client with the hostname, port, username, and current password
var client = new SshClient(host, port, username, currentPassword);

// Connect to the SSH server
client.Connect();

// Use the SSH client to create a new shell stream
var shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);

// Wait for the shell to start up
while (!shellStream.DataAvailable) { }

// Send the 'passwd' command to the shell
shellStream.WriteLine("passwd");

// Wait for the 'passwd' command prompt to appear
while (!shellStream.DataAvailable) { }

// Send the current password to the shell
shellStream.WriteLine(currentPassword);

// Wait for the shell to prompt for a new password
while (!shellStream.DataAvailable) { }

// Send the new password to the shell
shellStream.WriteLine(newPassword);

// Wait for the shell to prompt to confirm the new password
while (!shellStream.DataAvailable) { }

// Send the new password again to confirm it
shellStream.WriteLine(newPassword);

// Wait for the 'passwd' command to complete
while (!shellStream.DataAvailable) { }

// Read the output of the 'passwd' command
var reader = new StreamReader(shellStream);
var output = reader.ReadToEnd();

// Disconnect from the SSH server
client.Disconnect();