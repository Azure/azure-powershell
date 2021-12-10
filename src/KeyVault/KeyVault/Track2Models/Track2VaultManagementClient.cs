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


        private Track2VaultCollection VaultCollection => _vaultCollection ?? (_vaultCollection = new Track2VaultCollection(_authFactory, _context));
        private Track2VaultCollection _vaultCollection;

        private Track2ManagedHsmCollection ManagedHsmCollection => _managedHsmCollection ?? (_managedHsmCollection = new Track2ManagedHsmCollection());
        private Track2ManagedHsmCollection _managedHsmCollection;

        public Track2VaultManagementClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _authFactory = authFactory ?? throw new ArgumentNullException(nameof(authFactory));
            _context = context ?? throw new ArgumentNullException(nameof(context));

            if (context.Environment == null)
            {
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);
            }
        }

        public IList<PSKeyVault> ListVaults(string subscription, string resourcegroup, IMicrosoftGraphClient msGraphClient = null)
        {
            var vaults = new List<PSKeyVault>();
            var response = VaultCollection.ListVaults(subscription, resourcegroup);
            response?.ForEach(vault =>
            {
                vaults.Add(new PSKeyVault(vault, msGraphClient));
            });
            return vaults;
        }
    }
}
