using Azure.Security.KeyVault.Administration;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultEkmPrivateEndpoint
    {
        public string HsmName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ProvisioningState { get; set; }
        public PSKeyVaultEkmPrivateEndpointProperties Properties { get; set; }
        public PSKeyVaultEkmPrivateEndpointConnectionState PrivateLinkServiceConnectionState { get; set; }

        public PSKeyVaultEkmPrivateEndpoint() { }

        internal PSKeyVaultEkmPrivateEndpoint(KeyVaultEkmPrivateEndpoint endpoint, string hsmName)
        {
            HsmName = hsmName;
            Name = endpoint.Name;
            Location = endpoint.Location;
            ProvisioningState = endpoint.ProvisioningState?.ToString();
            if (endpoint.Properties != null)
            {
                Properties = new PSKeyVaultEkmPrivateEndpointProperties
                {
                    PrivateLinkServiceAlias = endpoint.Properties.PrivateLinkServiceAlias,
                    PrivateLinkServiceConnectionName = endpoint.Properties.PrivateLinkServiceConnectionName
                };
            }
            if (endpoint.PrivateLinkServiceConnectionState != null)
            {
                PrivateLinkServiceConnectionState = new PSKeyVaultEkmPrivateEndpointConnectionState
                {
                    Status = endpoint.PrivateLinkServiceConnectionState.Status?.ToString(),
                    Description = endpoint.PrivateLinkServiceConnectionState.Description,
                    ActionsRequired = endpoint.PrivateLinkServiceConnectionState.ActionsRequired
                };
            }
        }
    }

    public class PSKeyVaultEkmPrivateEndpointProperties
    {
        public string PrivateLinkServiceAlias { get; set; }
        public string PrivateLinkServiceConnectionName { get; set; }
    }

    public class PSKeyVaultEkmPrivateEndpointConnectionState
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string ActionsRequired { get; set; }
    }
}