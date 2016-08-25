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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    /// <summary>
    /// Lists all storage services underneath the subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, StorageAccountNounStr, SupportsShouldProcess = true), OutputType(typeof(StorageModels.StorageAccount))]
    public class SetAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
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

        [Parameter(HelpMessage = "Force to Set the Account")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force = false;

        [Parameter(
            Mandatory = false,
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
            Mandatory = false,
            HelpMessage = "Storage Account Access Tier.")]
        [ValidateSet(AccountAccessTier.Hot,
            AccountAccessTier.Cool,
            IgnoreCase = true)]
        public string AccessTier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Custom Domain.")]
        [ValidateNotNull]
        public string CustomDomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To Use Sub Domain.")]
        [ValidateNotNullOrEmpty]
        public bool? UseSubDomain { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Service that will enable encryption.")]
        public EncryptionSupportServiceEnum? EnableEncryptionService { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Service that will disable encryption.")]
        public EncryptionSupportServiceEnum? DisableEncryptionService { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Tags.")]
        [AllowEmptyCollection]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Set Storage Account"))
            {
                if (this.force || this.AccessTier == null || ShouldContinue("Changing the access tier may result in additional charges. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.", ""))
                {
                    StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters();
                    if (this.SkuName != null)
                    {
                        updateParameters.Sku = new Sku(ParseSkuName(this.SkuName));
                    }

                    if (this.Tag != null)
                    {
                        Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
                        updateParameters.Tags = tagDictionary ?? new Dictionary<string, string>();
                    }

                    if (this.CustomDomainName != null)
                    {
                        updateParameters.CustomDomain = new CustomDomain()
                        {
                            Name = CustomDomainName,
                            UseSubDomain = UseSubDomain
                        };
                    }
                    else if (UseSubDomain != null)
                    {
                        throw new System.ArgumentException(string.Format("UseSubDomain must be set together with CustomDomainName."));
                    }

                    if (this.EnableEncryptionService != null || this.DisableEncryptionService != null)
                    {
                        updateParameters.Encryption = ParseEncryption(EnableEncryptionService, DisableEncryptionService);
                    }

                    if (this.AccessTier != null)
                    {
                        updateParameters.AccessTier = ParseAccessTier(AccessTier);
                    }

                    var updatedAccountResponse = this.StorageClient.StorageAccounts.Update(
                        this.ResourceGroupName,
                        this.Name,
                        updateParameters);

                    var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

                    WriteStorageAccount(storageAccount);
                }
            }
        }
    }
}
