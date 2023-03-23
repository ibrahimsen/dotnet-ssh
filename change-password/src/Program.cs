using Renci.SshNet;
using changepassword;
string host = "192.168.1.107";
string username = "ssh";
var currentPassword = "123456789";
string newPassword = "12345678";
var port = 22;

Console.WriteLine("Changing SSH Password just started");
var sshNet = new RenciSshNet();

try
{
    sshNet.ChangePassword(host, port, username, currentPassword, newPassword);

    Console.WriteLine("Changing SSH Password finished");

}
catch (Exception ex)
{
    Console.WriteLine("An error is occured. Detail", ex.Message);
}

