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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Adapters;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSStorageAccount : IStorageContextProvider
    {
        public PSStorageAccount(StorageModels.StorageAccount storageAccount)
        {
            this.ResourceGroupName = new ResourceIdentifier(storageAccount.Id).ResourceGroupName;
            this.StorageAccountName = storageAccount.Name;
            this.Id = storageAccount.Id;
            this.Location = storageAccount.Location;
            this.Sku = storageAccount.Sku;
            this.Encryption = storageAccount.Encryption;
            this.Kind = storageAccount.Kind;
            this.AccessTier = storageAccount.AccessTier;
            this.CreationTime = storageAccount.CreationTime;
            this.CustomDomain = storageAccount.CustomDomain is null ? null : new PSCustomDomain(storageAccount.CustomDomain);
            this.Identity = storageAccount.Identity;
            this.LastGeoFailoverTime = storageAccount.LastGeoFailoverTime;
            this.PrimaryEndpoints = storageAccount.PrimaryEndpoints;
            this.PrimaryLocation = storageAccount.PrimaryLocation;
            this.ProvisioningState = storageAccount.ProvisioningState;
            this.SecondaryEndpoints = storageAccount.SecondaryEndpoints;
            this.SecondaryLocation = storageAccount.SecondaryLocation;
            this.StatusOfPrimary = storageAccount.StatusOfPrimary;
            this.StatusOfSecondary = storageAccount.StatusOfSecondary;
            this.Tags = storageAccount.Tags;
            this.EnableHttpsTrafficOnly = storageAccount.EnableHttpsTrafficOnly;
            this.NetworkRuleSet = PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.NetworkRuleSet);
            this.EnableHierarchicalNamespace = storageAccount.IsHnsEnabled;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 1)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table, Position = 0)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Location", Target = ViewControl.Table, Position = 2)]
        public string Location { get; set; }

        [Ps1Xml(Label = "SkuName", Target = ViewControl.Table, ScriptBlock = "$_.Sku.Name", Position = 3)]
        public Sku Sku { get; set; }

        [Ps1Xml(Label = "Kind", Target = ViewControl.Table, Position = 4)]
        public string Kind { get; set; }
        public Encryption Encryption { get; set; }

        [Ps1Xml(Label = "AccessTier", Target = ViewControl.Table, Position = 5)]
        public AccessTier? AccessTier { get; set; }

        [Ps1Xml(Label = "CreationTime", Target = ViewControl.Table, Position = 6)]
        public DateTime? CreationTime { get; set; }

        public PSCustomDomain CustomDomain { get; set; }

        public Identity Identity { get; set; }

        public DateTime? LastGeoFailoverTime { get; set; }

        public Endpoints PrimaryEndpoints { get; set; }

        public string PrimaryLocation { get; set; }

        [Ps1Xml(Label = "ProvisioningState", Target = ViewControl.Table, Position = 7)]
        public ProvisioningState? ProvisioningState { get; set; }

        public Endpoints SecondaryEndpoints { get; set; }

        public string SecondaryLocation { get; set; }

        public AccountStatus? StatusOfPrimary { get; set; }

        public AccountStatus? StatusOfSecondary { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        [Ps1Xml(Label = "EnableHttpsTrafficOnly", Target = ViewControl.Table, Position = 8)]
        public bool? EnableHttpsTrafficOnly { get; set; }
        
        public bool? EnableHierarchicalNamespace { get; set; }

        public PSNetworkRuleSet NetworkRuleSet { get; set; }

        public static PSStorageAccount Create(StorageModels.StorageAccount storageAccount, IStorageManagementClient client)
        {
            var result = new PSStorageAccount(storageAccount);
             result.Context = new LazyAzureStorageContext((s) => 
             { 
                return (new ARMStorageProvider(client)).GetCloudStorageAccount(s, result.ResourceGroupName);  
             }, result.StorageAccountName) as AzureStorageContext; 

            return result;
        }

        public IStorageContext Context { get; private set; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

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

    public class PSCustomDomain
    {
        public string Name { get; set; }
        public bool? UseSubDomain { get; set; }

        public PSCustomDomain(CustomDomain input)
        {
            this.Name = input.Name;
            this.UseSubDomain = input.UseSubDomainName;
        }

        public CustomDomain ParseCustomDomain()
        {
            return new CustomDomain(this.Name, this.UseSubDomain);
        }
    }
}
