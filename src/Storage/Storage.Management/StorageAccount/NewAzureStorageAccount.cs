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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccount"), OutputType(typeof(PSStorageAccount))]
    public class NewAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.")]
        [Alias(StorageAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Sku Name.")]
        [Alias(StorageAccountTypeAlias, AccountTypeAlias, Account_TypeAlias)]
        [ValidateSet(AccountTypeString.StandardLRS,
            AccountTypeString.StandardZRS,
            AccountTypeString.StandardGRS,
            AccountTypeString.StandardRAGRS,
            AccountTypeString.PremiumLRS,
            IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Location.")]
        [LocationCompleter("Microsoft.Storage/storageAccounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Kind.")]
        [ValidateSet(AccountKind.Storage,
            AccountKind.StorageV2,
            AccountKind.BlobStorage,
            AccountKind.BlockBlobStorage,
            IgnoreCase = true)]
        public string Kind { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Access Tier.")]
        [ValidateSet(AccountAccessTier.Hot,
            AccountAccessTier.Cool,
            IgnoreCase = true)]
        public string AccessTier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Custom Domain.")]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To Use Sub Domain.")]
        [ValidateNotNullOrEmpty]
        public bool? UseSubDomain { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Tags.")]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account EnableHttpsTrafficOnly.")]
        public bool EnableHttpsTrafficOnly
        {
            get
            {
                return enableHttpsTrafficOnly != null ? enableHttpsTrafficOnly.Value : false;
            }
            set
            {
                enableHttpsTrafficOnly = value;
            }
        }
        private bool? enableHttpsTrafficOnly = null;

        [Parameter(
        Mandatory = false,
        HelpMessage = "Generate and assign a new Storage Account Identity for this storage account for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(HelpMessage = "Storage Account NetworkRule",
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSNetworkRuleSet NetworkRuleSet
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable HierarchicalNamespace for the Storage account.")]
        [ValidateNotNullOrEmpty]
        public bool EnableHierarchicalNamespace
        {
            get
            {
                return enableHierarchicalNamespace != null ? enableHierarchicalNamespace.Value : false;
            }
            set
            {
                enableHierarchicalNamespace = value;
            }
        }
        private bool? enableHierarchicalNamespace = null;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            CheckNameAvailabilityResult checkNameAvailabilityResult = this.StorageClient.StorageAccounts.CheckNameAvailability(this.Name);
            if (!checkNameAvailabilityResult.NameAvailable.Value)
            {
                throw new System.ArgumentException(checkNameAvailabilityResult.Message, "Name");
            }

            StorageAccountCreateParameters createParameters = new StorageAccountCreateParameters()
            {
                Location = this.Location,
                Sku = new Sku(ParseSkuName(this.SkuName)),
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
            };

            if (this.CustomDomainName != null)
            {
                createParameters.CustomDomain = new CustomDomain()
                {
                    Name = CustomDomainName,
                    UseSubDomainName = UseSubDomain
                };
            }
            else if (UseSubDomain != null)
            {
                throw new System.ArgumentException(string.Format("UseSubDomain must be set together with CustomDomainName."));
            }

            if (Kind != null)
            {
                createParameters.Kind = ParseAccountKind(Kind);
            }

            if (this.AccessTier != null)
            {
                createParameters.AccessTier = ParseAccessTier(AccessTier);
            }
            if (enableHttpsTrafficOnly != null)
            {
                createParameters.EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
            }

            if (AssignIdentity.IsPresent)
            {
                createParameters.Identity = new Identity();
            }
            if (NetworkRuleSet != null)
            {
                createParameters.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(NetworkRuleSet);
            }
            if (enableHierarchicalNamespace != null)
            {
                createParameters.IsHnsEnabled = enableHierarchicalNamespace;
            }

            var createAccountResponse = this.StorageClient.StorageAccounts.Create(
                this.ResourceGroupName,
                this.Name,
                createParameters);

            var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

            this.WriteStorageAccount(storageAccount);
        }
    }
}
