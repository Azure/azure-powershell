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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountNetworkRule", SupportsShouldProcess = true, DefaultParameterSetName = NetWorkRuleStringParameterSet)]
    [OutputType(typeof(PSVirtualNetworkRule), ParameterSetName = new string[] { NetWorkRuleStringParameterSet, NetworkRuleObjectParameterSet })]
    [OutputType(typeof(PSIpRule), ParameterSetName = new string[] { IpRuleStringParameterSet, IpRuleObjectParameterSet })]
    [OutputType(typeof(PSResourceAccessRule), ParameterSetName = new string[] { ResourceAccessRuleStringParameterSet, ResourceAccessRuleObjectParameterSet })]
    public class AddAzureStorageAccountNetworkRuleCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// NetWorkRule in String parameter set name
        /// </summary>
        private const string NetWorkRuleStringParameterSet = "NetWorkRuleString";

        /// <summary>
        /// IpRule in String paremeter set name
        /// </summary>
        private const string IpRuleStringParameterSet = "IpRuleString";

        /// <summary>
        /// NetWorkRule Objects pipeline parameter set
        /// </summary>
        private const string NetworkRuleObjectParameterSet = "NetworkRuleObject";

        /// <summary>
        /// IpRule Objects pipeline parameter set
        /// </summary>
        private const string IpRuleObjectParameterSet = "IpRuleObject";

        /// <summary>
        /// ResourceAccess Objects pipeline parameter set
        /// </summary>
        private const string ResourceAccessRuleStringParameterSet = "ResourceAccessRuleString";

        /// <summary>
        /// ResourceAccess Objects pipeline parameter set
        /// </summary>
        private const string ResourceAccessRuleObjectParameterSet = "ResourceAccessRuleObject";

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
            Mandatory = true,
            HelpMessage = "Storage Account NetworkRule IPRules.",
            ValueFromPipeline = true, ParameterSetName = IpRuleObjectParameterSet)]
        public PSIpRule[] IPRule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account NetworkRule VirtualNetworkRules.",
            ValueFromPipeline = true, ParameterSetName = NetworkRuleObjectParameterSet)]
        public PSVirtualNetworkRule[] VirtualNetworkRule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account NetworkRule ResourceAccessRules.",
            ValueFromPipeline = true, ParameterSetName = ResourceAccessRuleObjectParameterSet)]
        public PSResourceAccessRule[] ResourceAccessRule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account NetworkRule IPRules IPAddressOrRange in string.",
            ParameterSetName = IpRuleStringParameterSet)]
        public string[] IPAddressOrRange { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account NetworkRule VirtualNetworkRules VirtualNetworkResourceId in string.",
            ParameterSetName = NetWorkRuleStringParameterSet)]
        [Alias("SubnetId", "VirtualNetworkId")]
        public string[] VirtualNetworkResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account ResourceAccessRule TenantId  in string.",
            ParameterSetName = ResourceAccessRuleStringParameterSet)]
        public string TenantId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account ResourceAccessRule ResourceId  in string.",
            ParameterSetName = ResourceAccessRuleStringParameterSet)]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Add Storage Account NetworkRules"))
            {
                var storageAccount = this.StorageClient.StorageAccounts.GetProperties(
                this.ResourceGroupName,
                this.Name);
                NetworkRuleSet storageACL = storageAccount.NetworkRuleSet;

                if (storageACL == null)
                {
                    storageACL = new NetworkRuleSet();
                }
                bool ruleChanged = false;

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                        if (storageACL.VirtualNetworkRules == null)
                            storageACL.VirtualNetworkRules = new List<VirtualNetworkRule>();
                        foreach (string s in VirtualNetworkResourceId)
                        {
                            bool ruleExist = false;
                            foreach (VirtualNetworkRule originRule in storageACL.VirtualNetworkRules)
                            {
                                if (originRule.VirtualNetworkResourceId.Equals(s, System.StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ruleExist = true;
                                    WriteDebug(string.Format("Skip add VirtualNetworkRule as it already exist: {0}", s));
                                    break;
                                }
                            }
                            if (!ruleExist)
                            {
                                VirtualNetworkRule rule = new VirtualNetworkRule(s);
                                storageACL.VirtualNetworkRules.Add(rule);
                                ruleChanged = true;
                            }
                        }
                        break;
                    case IpRuleStringParameterSet:
                        if (storageACL.IpRules == null)
                            storageACL.IpRules = new List<IPRule>();
                        foreach (string s in IPAddressOrRange)
                        {
                            bool ruleExist = false;
                            foreach (IPRule originRule in storageACL.IpRules)
                            {
                                if (originRule.IPAddressOrRange.Equals(s, System.StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ruleExist = true;
                                    WriteDebug(string.Format("Skip add IPAddressOrRange as it already exist: {0}", s));
                                    break;
                                }
                            }
                            if (!ruleExist)
                            {
                                IPRule rule = new IPRule(s);
                                storageACL.IpRules.Add(rule);
                                ruleChanged = true;
                            }
                        }
                        break;
                    case ResourceAccessRuleStringParameterSet:
                        if (storageACL.ResourceAccessRules == null)
                        {
                            storageACL.ResourceAccessRules = new List<ResourceAccessRule>();
                        }
                        bool ResourceAccessruleExist = false;
                        foreach (ResourceAccessRule originRule in storageACL.ResourceAccessRules)
                        {
                            if (originRule.TenantId.Equals(this.TenantId, System.StringComparison.InvariantCultureIgnoreCase)
                            && originRule.ResourceId.Equals(this.ResourceId, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                ResourceAccessruleExist = true;
                                WriteDebug(string.Format("Skip add ResourceAccessRule as it already exist, TenantId: {0}, ResourceId: {1}", this.TenantId, this.ResourceId));
                                break;
                            }
                        }
                        if (!ResourceAccessruleExist)
                        {
                            ResourceAccessRule rule = new ResourceAccessRule(this.TenantId, this.ResourceId);
                            storageACL.ResourceAccessRules.Add(rule);
                            ruleChanged = true;
                        }
                        break;
                    case NetworkRuleObjectParameterSet:
                        if (storageACL.VirtualNetworkRules == null)
                            storageACL.VirtualNetworkRules = new List<VirtualNetworkRule>();
                        foreach (PSVirtualNetworkRule rule in VirtualNetworkRule)
                        {
                            bool ruleExist = false;
                            foreach (VirtualNetworkRule originRule in storageACL.VirtualNetworkRules)
                            {
                                if (originRule.VirtualNetworkResourceId.Equals(rule.VirtualNetworkResourceId, System.StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ruleExist = true;
                                    WriteDebug(string.Format("Skip add IPAddressOrRange as it already exist: {0}", rule.VirtualNetworkResourceId));
                                    break;
                                }
                            }
                            if (!ruleExist)
                            {
                                storageACL.VirtualNetworkRules.Add(PSNetworkRuleSet.ParseStorageNetworkRuleVirtualNetworkRule(rule));
                                ruleChanged = true;
                            }
                        }
                        break;
                    case ResourceAccessRuleObjectParameterSet:
                        if (storageACL.ResourceAccessRules == null)
                        {
                            storageACL.ResourceAccessRules = new List<ResourceAccessRule>();
                        }
                        foreach (PSResourceAccessRule rule in ResourceAccessRule)
                        {
                            bool ruleExist = false;
                            foreach (ResourceAccessRule originRule in storageACL.ResourceAccessRules)
                            {
                                if (originRule.TenantId.Equals(rule.TenantId, System.StringComparison.InvariantCultureIgnoreCase)
                                && originRule.ResourceId.Equals(rule.ResourceId, System.StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ruleExist = true;
                                    WriteDebug(string.Format("Skip add ResourceAccessRule as it already exist, TenantId: {0}, ResourceId: {1}", rule.TenantId, rule.ResourceId));
                                    break;
                                }
                            }
                            if (!ruleExist)
                            {

                                storageACL.ResourceAccessRules.Add(PSNetworkRuleSet.ParseStorageResourceAccessRule(rule));
                                ruleChanged = true;
                            }
                        }
                        break;
                    case IpRuleObjectParameterSet:
                        if (storageACL.IpRules == null)
                            storageACL.IpRules = new List<IPRule>();
                        foreach (PSIpRule rule in IPRule)
                        {
                            bool ruleExist = false;
                            foreach (IPRule originRule in storageACL.IpRules)
                            {
                                if (originRule.IPAddressOrRange.Equals(rule.IPAddressOrRange, System.StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ruleExist = true;
                                    WriteDebug(string.Format("Skip add IPAddressOrRange as it already exist: {0}", rule.IPAddressOrRange));
                                    break;
                                }
                            }
                            if (!ruleExist)
                            {

                                storageACL.IpRules.Add(PSNetworkRuleSet.ParseStorageNetworkRuleIPRule(rule));
                                ruleChanged = true;
                            }
                        }
                        break;
                }

                if (ruleChanged)
                {
                    StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters();
                    updateParameters.NetworkRuleSet = storageACL;

                    var updatedAccountResponse = this.StorageClient.StorageAccounts.Update(
                        this.ResourceGroupName,
                        this.Name,
                        updateParameters);

                    storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);
                }

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                    case NetworkRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.NetworkRuleSet).VirtualNetworkRules);
                        break;
                    case IpRuleStringParameterSet:
                    case IpRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.NetworkRuleSet).IpRules);
                        break;
                    case ResourceAccessRuleStringParameterSet:
                    case ResourceAccessRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.NetworkRuleSet).ResourceAccessRules);
                        break;
                }
            }
        }
    }
}
