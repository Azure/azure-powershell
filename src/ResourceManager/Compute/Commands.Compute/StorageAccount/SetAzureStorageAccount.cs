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

namespace Microsoft.Azure.Commands.Compute
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Common;
    using Models;
    using WindowsAzure.Management.Srp;
    using WindowsAzure.Management.Srp.Models;

    /// <summary>
    /// Lists all storage services underneath the subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, StorageAccountNounStr, DefaultParameterSetName = UpdateAccountTypeParamSet), OutputType(typeof(StorageAccount))]
    public class SetAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {
        protected const string UpdateAccountTypeParamSet = "UpdateAccountType";
        protected const string UpdateCustomDomainParamSet = "UpdateCustomDomain";
        protected const string UpdateTagsParamSet = "UpdateTags";

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

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = UpdateAccountTypeParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Type.")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = UpdateCustomDomainParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Custom Domain Name.")]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(
            Position = 3,
            ParameterSetName = UpdateCustomDomainParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To Use Sub Domain Name.")]
        [ValidateNotNullOrEmpty]
        public bool? UseSubDomainName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = UpdateTagsParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Tags.")]
        [ValidateNotNullOrEmpty]
        public Hashtable[] Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            StorageAccountProperties storageAccountProperties = null;
            Dictionary<string, string> tagDictionary = null;

            if (ParameterSetName == UpdateAccountTypeParamSet)
            {
                storageAccountProperties = new StorageAccountProperties
                {
                    AccountType = this.Type,
                    CustomDomains = null,
                    PrimaryEndpoints = null,
                    SecondaryEndpoints = null
                };
            }
            else if (ParameterSetName == UpdateCustomDomainParamSet)
            {
                storageAccountProperties = new StorageAccountProperties
                {
                    AccountType = null,
                    CustomDomains = new List<StorageCustomDomain>()
                    {
                        new StorageCustomDomain
                        {
                            Name = CustomDomainName,
                            UseSubDomainName = UseSubDomainName
                        }
                    },
                    PrimaryEndpoints = null,
                    SecondaryEndpoints = null
                };
            }
            else
            {
                tagDictionary = TagsConversionHelper.CreateTagDictionary(Tags, validate: true);
            }

            var updatedAccount = this.StorageAccountService.PatchStorageAccount(
                base.SubscriptionId,
                this.ResourceGroupName,
                this.Name,
                new StorageAccount
                {
                    Tags = tagDictionary,
                    Properties = storageAccountProperties
                },
                base.ApiVersion,
                base.AuthorizationToken);

            WriteObject(updatedAccount);
        }
    }
}
