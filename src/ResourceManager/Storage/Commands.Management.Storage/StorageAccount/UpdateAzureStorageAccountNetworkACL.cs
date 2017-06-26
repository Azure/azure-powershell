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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet(VerbsData.Update, StorageAccountACLNounStr, SupportsShouldProcess = true), OutputType(typeof(PSNetworkACL))]
    public class UpdateAzureStorageAccountACLCommand : StorageAccountBaseCmdlet
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Network ACL Bypass.")]
        [ValidateNotNullOrEmpty]
        public PSNetWorkACLBypassEnum Bypass
        {
            get
            {
                return bypass == null ? PSNetWorkACLBypassEnum.None : bypass.Value;
            }
            set
            {
                bypass = value;
            }
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Network ACL DefaultAction.")]
        [ValidateNotNullOrEmpty]
        public PSNetWorkACLDefaultActionEnum DefaultAction
        {
            get
            {
                return defaultAction == null ? PSNetWorkACLDefaultActionEnum.Allow : defaultAction.Value;
            }
            set
            {
                defaultAction = value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Storage Account Network ACL IPRules.")]
        public PSIpRule[] IPRule
        {
            get
            {
                return iPRules;
            }
            set
            {
                isIpRuleSet = true;
                iPRules = value == null? new List<PSIpRule>().ToArray(): value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Storage Account Network ACL VirtualNetworkRules.")]
        public PSVirtualNetworkRule[] VirtualNetworkRule
        {
            get
            {
                return virtualNetworkRules;
            }
            set
            {
                isNetworkRuleSet = true;
                virtualNetworkRules = value == null ? new List<PSVirtualNetworkRule>().ToArray() : value;
            }
        }

        private PSNetWorkACLBypassEnum? bypass = null;
        private PSNetWorkACLDefaultActionEnum? defaultAction = null;
        private PSIpRule[] iPRules = null;
        private PSVirtualNetworkRule[] virtualNetworkRules = null;
        private bool isIpRuleSet = false;
        private bool isNetworkRuleSet = false;


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Update Storage Account NetworkACL"))
            {
                if (IPRule == null && VirtualNetworkRule == null && bypass == null && defaultAction == null)
                {
                    throw new System.ArgumentNullException("IPRules, VirtualNetworkRules, Bypass, DefaultAction", "Request must specify an account NetworkACL property to update.");
                }

                var storageAccount = this.StorageClient.StorageAccounts.GetProperties(
                    this.ResourceGroupName,
                    this.Name);
                StorageNetworkAcls storageACL = storageAccount.NetworkAcls;

                if (storageACL == null)
                {
                    storageACL = new StorageNetworkAcls();
                }

                PSNetworkACL psACL = PSNetworkACL.ParsePSNetworkACL(storageACL);

                if (isIpRuleSet)
                {
                    psACL.IpRules = IPRule;
                }

                if (isNetworkRuleSet)
                {
                    psACL.VirtualNetworkRules = VirtualNetworkRule;
                }

                if (bypass != null)
                {
                    psACL.Bypass = bypass;
                }

                if (defaultAction != null)
                {
                    psACL.DefaultAction = defaultAction.Value;
                }
                
                StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters();
                updateParameters.NetworkAcls = PSNetworkACL.ParseStorageNetworkACL(psACL);

                var updatedAccountResponse = this.StorageClient.StorageAccounts.Update(
                    this.ResourceGroupName,
                    this.Name,
                updateParameters);

                storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

                WriteObject(PSNetworkACL.ParsePSNetworkACL(storageAccount.NetworkAcls));
            }
        }
    }
}
