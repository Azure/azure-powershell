using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using System.Security;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class PSADServicePrincipalWrapper : PSADServicePrincipal
    {
        public PSADServicePrincipalWrapper(PSADServicePrincipal sp)
        {
            AdfsId = sp.AdfsId;
            ApplicationId = sp.ApplicationId;
            DisplayName = sp.DisplayName;
            Id = sp.Id;
            ServicePrincipalNames = sp.ServicePrincipalNames;
            Type = sp.Type;
        }
        public SecureString Secret { get; set; }
    }
}
