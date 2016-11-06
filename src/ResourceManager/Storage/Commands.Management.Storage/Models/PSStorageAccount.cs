// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSStorageAccount : IStorageContextProvider
    {
        public PSStorageAccount(StorageModels.StorageAccount storageAccount)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(storageAccount.Id);
            this.StorageAccountName = storageAccount.Name;
            this.Id = storageAccount.Id;
            this.Location = storageAccount.Location;
            this.Sku = storageAccount.Sku;
            this.Encryption = storageAccount.Encryption;
            this.Kind = storageAccount.Kind;
            this.AccessTier = storageAccount.AccessTier;
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
            this.Tags = storageAccount.Tags;
        }

        public string ResourceGroupName { get; set; }

        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        public string Location { get; set; }

        public Sku Sku { get; set; }
        public Kind? Kind { get; set; }
        public Encryption Encryption { get; set; }
        public AccessTier? AccessTier { get; set; }

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

        public IDictionary<string, string> Tags { get; set; }

        public static PSStorageAccount Create(StorageModels.StorageAccount storageAccount, IStorageManagementClient client)
        {
            var result = new PSStorageAccount(storageAccount);
             result.Context = new LazyAzureStorageContext((s) => 
             { 
                var credentials = StorageUtilities.GenerateStorageCredentials(new ARMStorageProvider(client), result.ResourceGroupName, s); 
                 return new CloudStorageAccount(credentials, 
                     ARMStorageService.GetUri(storageAccount.PrimaryEndpoints.Blob), 
                     ARMStorageService.GetUri(storageAccount.PrimaryEndpoints.Queue), 
                     ARMStorageService.GetUri(storageAccount.PrimaryEndpoints.Table), 
                     ARMStorageService.GetUri(storageAccount.PrimaryEndpoints.File)); 
             }, result.StorageAccountName) as AzureStorageContext; 

            return result;
        }

        private static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }

        public AzureStorageContext Context { get; private set; }

        /// <summary>
        /// Return a string representation of this storage account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            // Allow listing storage contents through piping
            return null;
        }
    }
}
