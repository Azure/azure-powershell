using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    class PSStorageAccount
    {
        public PSStorageAccount(StorageAccount storageAccount)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(storageAccount.Id);
            this.Name = storageAccount.Name;
            this.Id = storageAccount.Id;
            this.AccountType = storageAccount.AccountType;
            this.CreationTime = storageAccount.CreationTime;
            this.CustomDomain = storageAccount.CustomDomain;
            this.LastGeoFailoverTime = storageAccount.LastGeoFailoverTime;
            this.PrimaryEndpoints = storageAccount.PrimaryEndpoints;
            this.PrimaryLocation = storageAccount.PrimaryLocation;
            this.ProvisioningState = storageAccount.ProvisioningState;
            this.SecondaryEndpoints = storageAccount.SecondaryEndpoints;
            this.SecondaryLocation = storageAccount.SecondaryLocation;
            this.StatusOfPrimary = storageAccount.StatusOfPrimary;
            this.StatusOfSecondary = storageAccount.StatusOfSecondary;
        }

        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public AccountType? AccountType { get; set; }
        
        public DateTime? CreationTime { get; set; }
        
        public CustomDomain CustomDomain { get; set; }
        
        public DateTime? LastGeoFailoverTime { get; set; }
        
        public Endpoints PrimaryEndpoints { get; set; }

        public string PrimaryLocation { get; set; }

        public ProvisioningState? ProvisioningState { get; set; }
        
        public Endpoints SecondaryEndpoints { get; set; }

        public string SecondaryLocation { get; set; }

        public AccountStatus? StatusOfPrimary { get; set; }

        public AccountStatus? StatusOfSecondary { get; set; }

        private static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }
    }
}
