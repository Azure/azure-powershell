using Microsoft.Azure.Commands.Common.Strategies;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    public sealed class Credential
    {
        public Parameter<string> AdminUserName { get; }

        public Parameter<SecureString> AdminPassword { get; }

        public Credential(PSCredential psCredential)
        {
            AdminUserName = Parameter.Create("adminUserName", psCredential.UserName);
            AdminPassword = Parameter.Create("adminPassword", psCredential.Password);
        }
    }
}
