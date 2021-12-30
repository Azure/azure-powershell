using Azure.ResourceManager;
using Azure.ResourceManager.KeyVault.Models;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;

using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;


namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    public class Track2VaultManagementClient
    {

        private IAuthenticationFactory _authFactory;
        private IAzureContext _context;

        private Track2KeyVaultManagementClient Track2KeyVaultManagementClient => 
            _track2KeyVaultManagementClient ?? (_track2KeyVaultManagementClient = new Track2KeyVaultManagementClient(_authFactory, _context));
        private Track2KeyVaultManagementClient _track2KeyVaultManagementClient;

        public Track2VaultManagementClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authFactory = authFactory ?? throw new ArgumentNullException(nameof(authFactory));

            if (context.Environment == null)
            {
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);
            }
        }

        #region Vault-related METHODS
        public PSKeyVault CreateVault(string resourcegroup, string vaultName, VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient msGraphClient = null) =>
            new PSKeyVault(Track2KeyVaultManagementClient.CreateVault(resourcegroup, vaultName, parameters.ToTrack2VaultCreateOrUpdateParameters()), msGraphClient);

        public IList<PSKeyVault> ListVaults(string resourcegroup, IMicrosoftGraphClient msGraphClient = null)
        {
            var vaults = new List<PSKeyVault>();
            var response = Track2KeyVaultManagementClient.ListVaults(resourcegroup);
            response?.ForEach(vault =>
            {
                vaults.Add(new PSKeyVault(vault, msGraphClient));
            });
            return vaults;
        }

        public PSKeyVault GetVault(string resourcegroup, string vaultName, IMicrosoftGraphClient msGraphClient = null) =>
            new PSKeyVault(Track2KeyVaultManagementClient.GetVault(resourcegroup, vaultName), msGraphClient);

        #endregion

        private Track2ManagedHsmCollection Track2ManagedHsmManagementClient => 
            _track2ManagedHsmManagementClient ?? (_track2ManagedHsmManagementClient = new Track2ManagedHsmCollection());
        private Track2ManagedHsmCollection _track2ManagedHsmManagementClient;


        public const string ResourceGroupType = "resourceGroups";
        public const string VaultsResourceType = "Microsoft.KeyVault/vaults";
        public const string ManagedHsmResourceType = "Microsoft.KeyVault/managedHSMs";
        #region ManagedHsm-related METHODS

        #endregion
        public static ResourceIdentifier ConstructResourceIdentifier(string subscription, string resourceGroupName, string resourceType = ResourceGroupType, string resourceName = null)
        {
            string id = null;
            switch (resourceType)
            {
                case ResourceGroupType:
                    id = string.Format("/subscriptions/{0}/resourceGroups/{1}", subscription, resourceGroupName);
                    break;
                case VaultsResourceType:
                case ManagedHsmResourceType:
                    id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/vaults/{3}",
                        subscription, resourceGroupName, resourceType, resourceName);
                    break;
                default:
                    throw new NotImplementedException("");
            }
            return new ResourceIdentifier(id);
        }
    }
}
