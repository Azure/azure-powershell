using System.Net;

using System.Security;

namespace System.Management.Automation
{
    public sealed class PSCredential
    {
        public PSCredential(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public static PSCredential Empty { get; } = new PSCredential(null, null);

        public string Password { get; private set; }
        public string UserName { get; private set; }

        public NetworkCredential GetNetworkCredential()
        {
            return new NetworkCredential(UserName, Password);
        }

        public static explicit operator NetworkCredential(PSCredential credential)
        {
            return credential.GetNetworkCredential();
        }
    }
}
