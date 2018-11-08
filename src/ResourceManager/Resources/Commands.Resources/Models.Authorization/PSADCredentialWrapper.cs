using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using System.Security;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class PSADCredentialWrapper : PSADCredential
    {
        public PSADCredentialWrapper(PSADCredential cred)
        {
            StartDate = cred.StartDate;
            EndDate = cred.EndDate;
            KeyId = cred.KeyId;
            Type = cred.Type;
        }

        public SecureString Secret { get; set; }
    }
}
