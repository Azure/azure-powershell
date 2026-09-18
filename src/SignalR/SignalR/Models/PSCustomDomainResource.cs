using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSCustomDomainResource : PSResource
    {
        public string DomainName { get; }
        public string CustomCertificateId { get; }
        public string ProvisioningState { get; }

        public PSCustomDomainResource(CustomDomain domain)
            : base(domain)
        {
            DomainName = domain.DomainName;
            CustomCertificateId = domain.CustomCertificate?.Id;
            ProvisioningState = domain.ProvisioningState;
        }
    }
}
