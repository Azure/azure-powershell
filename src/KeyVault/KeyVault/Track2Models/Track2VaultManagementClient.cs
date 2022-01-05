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

        private IClientFactory _clientFactory;
        private IAzureContext _context;

        private Track2KeyVaultManagementClient Track2KeyVaultManagementClient => 
            _track2KeyVaultManagementClient ?? (_track2KeyVaultManagementClient = new Track2KeyVaultManagementClient(_clientFactory, _context));
        private Track2KeyVaultManagementClient _track2KeyVaultManagementClient;

        public Track2VaultManagementClient(IClientFactory clientFactory , IAzureContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));

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

        private Track2ManagedHsmManagementClient Track2ManagedHsmManagementClient => 
            _track2ManagedHsmManagementClient ?? (_track2ManagedHsmManagementClient = new Track2ManagedHsmManagementClient());
        private Track2ManagedHsmManagementClient _track2ManagedHsmManagementClient;

        #region ManagedHsm-related METHODS

        #endregion
    }
}
