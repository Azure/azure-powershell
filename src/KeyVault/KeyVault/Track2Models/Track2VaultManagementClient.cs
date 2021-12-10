using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    public class Track2VaultManagementClient
    {
        private Track2VaultCollection VaultCollection => _vaultCollection ?? (_vaultCollection = new Track2VaultCollection());
        private Track2VaultCollection _vaultCollection;

        private Track2ManagedHsmCollection ManagedHsmCollection => _managedHsmCollection ?? (_managedHsmCollection = new Track2ManagedHsmCollection());
        private Track2ManagedHsmCollection _managedHsmCollection;

        public void test()
        {
            
        }
    }
}
