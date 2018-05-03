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
using System;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet(VerbsCommon.Remove, StorageAccountRuleNounStr, SupportsShouldProcess = true, DefaultParameterSetName = NetWorkRuleStringParameterSet)]
    [OutputType(typeof(PSVirtualNetworkRule), ParameterSetName = new string[] { NetWorkRuleStringParameterSet, NetworkRuleObjectParameterSet })]
    [OutputType(typeof(PSIpRule), ParameterSetName = new string[] { IpRuleStringParameterSet, IpRuleObjectParameterSet })]
    public class RemoveAzureStorageAccountNetworkRuleCommand : StorageAccountBaseCmdlet
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
            HelpMessage = "Storage Account NetworkRule IPRules IPAddressOrRange in string.",
            ParameterSetName = IpRuleStringParameterSet)]
        public string[] IPAddressOrRange { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Storage Account NetworkRule VirtualNetworkRules VirtualNetworkResourceId in string.",
            ParameterSetName = NetWorkRuleStringParameterSet)]
        [Alias("SubnetId", "VirtualNetworkId")]
        public string[] VirtualNetworkResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Remove Storage Account Networkrules"))
            {
                var storageAccount = this.StorageClient.StorageAccounts.GetProperties(
                                        this.ResourceGroupName,
                                        this.Name);
                NetworkRuleSet storageACL = storageAccount.NetworkRuleSet;

                if (storageACL == null)
                {
                    storageACL = new NetworkRuleSet();
                }

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                        if (storageACL.VirtualNetworkRules == null)
                            storageACL.VirtualNetworkRules = new List<VirtualNetworkRule>();
                        foreach (string s in VirtualNetworkResourceId)
                        {
                            VirtualNetworkRule rule = new VirtualNetworkRule(s);
                            if (!RemoveNetworkRule(storageACL.VirtualNetworkRules, rule))
                                throw new ArgumentOutOfRangeException("VirtualNetworkResourceId", String.Format("Can't remove VirtualNetworkRule with specific ResourceId since not exist: {0}", rule.VirtualNetworkResourceId));
                        }
                        break;
                    case IpRuleStringParameterSet:
                        if (storageACL.IpRules == null)
                            storageACL.IpRules = new List<IPRule>();
                        foreach (string s in IPAddressOrRange)
                        {
                            IPRule rule = new IPRule(s);
                            if (!RemoveIpRule(storageACL.IpRules, rule))
                                throw new ArgumentOutOfRangeException("IPAddressOrRange", String.Format("Can't remove IpRule with specific IPAddressOrRange since not exist: {0}", rule.IPAddressOrRange));
                        }
                        break;
                    case NetworkRuleObjectParameterSet:
                        if (storageACL.VirtualNetworkRules == null)
                            storageACL.VirtualNetworkRules = new List<VirtualNetworkRule>();
                        foreach (PSVirtualNetworkRule rule in VirtualNetworkRule)
                        {
                            if (!RemoveNetworkRule(storageACL.VirtualNetworkRules, PSNetworkRuleSet.ParseStorageNetworkRuleVirtualNetworkRule(rule)))
                                throw new ArgumentOutOfRangeException("VirtualNetworkRule", String.Format("Can't remove VirtualNetworkRule with specific ResourceId since not exist: {0}", rule.VirtualNetworkResourceId));
                        }
                        break;
                    case IpRuleObjectParameterSet:
                        if (storageACL.IpRules == null)
                            storageACL.IpRules = new List<IPRule>();
                        foreach (PSIpRule rule in IPRule)
                        {
                            if (!RemoveIpRule(storageACL.IpRules, PSNetworkRuleSet.ParseStorageNetworkRuleIPRule(rule)))
                                throw new ArgumentOutOfRangeException("IPRule", String.Format("Can't remove IpRule with specific IPAddressOrRange since not exist: {0}", rule.IPAddressOrRange));
                        }
                        break;
                }

                StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters();
                updateParameters.NetworkRuleSet = storageACL;

                var updatedAccountResponse = this.StorageClient.StorageAccounts.Update(
                    this.ResourceGroupName,
                    this.Name,
                    updateParameters);

                storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

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
                }
            }     
        }

        /// <summary>
        /// Remove one IpRule from IpRule List
        /// </summary>
        /// <param name="ruleList">The IpRule List</param>
        /// <param name="ruleToRemove">The IP Rule to remove</param>
        /// <returns>true if reove success</returns>
        public bool RemoveIpRule(IList<IPRule> ruleList, IPRule ruleToRemove)
        {
            foreach (IPRule rule in ruleList)
            {
                if (rule.IPAddressOrRange == ruleToRemove.IPAddressOrRange)
                {
                    ruleList.Remove(rule);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove one NetworkRule from NetworkRule List
        /// </summary>
        /// <param name="ruleList">The NetworkRule List</param>
        /// <param name="ruleToRemove">The NetworkRulee to remove</param>
        /// <returns>true if reove success</returns>
        public bool RemoveNetworkRule(IList<VirtualNetworkRule> ruleList, VirtualNetworkRule ruleToRemove)
        {
            foreach (VirtualNetworkRule rule in ruleList)
            {
                if (rule.VirtualNetworkResourceId == ruleToRemove.VirtualNetworkResourceId)
                {
                    ruleList.Remove(rule);
                    return true;
                }
            }
            return false;
        }
    }
}
