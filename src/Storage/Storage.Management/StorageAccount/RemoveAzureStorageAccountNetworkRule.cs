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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.WebSites.Version2016_09_01.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountNetworkRule", SupportsShouldProcess = true, DefaultParameterSetName = NetWorkRuleStringParameterSet)]
    [OutputType(typeof(PSVirtualNetworkRule), ParameterSetName = new string[] { NetWorkRuleStringParameterSet, NetworkRuleObjectParameterSet })]
    [OutputType(typeof(PSIpRule), ParameterSetName = new string[] { IpRuleStringParameterSet, IpRuleObjectParameterSet })]
    [OutputType(typeof(PSResourceAccessRule), ParameterSetName = new string[] { ResourceAccessRuleStringParameterSet, ResourceAccessRuleObjectParameterSet })]
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
        public Guid? TenantId { get; set; }

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

            if (ShouldProcess(this.Name, "Remove Storage Account Networkrules"))
            {
                Track2.StorageAccountResource storageAccount = this.StorageClientTrack2
                    .GetStorageAccount(this.ResourceGroupName, this.Name)
                    .Get();
                Track2Models.NetworkRuleSet storageACL = storageAccount.Data.NetworkRuleSet;

                if (storageACL == null)
                {
                    storageACL = new Track2Models.NetworkRuleSet(Track2Models.DefaultAction.Allow);
                }

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                        foreach (string s in VirtualNetworkResourceId)
                        {
                            Track2Models.VirtualNetworkRule rule = new Track2Models.VirtualNetworkRule(s);
                            if (!RemoveNetworkRule(storageACL.VirtualNetworkRules, rule))
                                throw new ArgumentOutOfRangeException("VirtualNetworkResourceId", String.Format("Can't remove VirtualNetworkRule with specific ResourceId since not exist: {0}", rule.VirtualNetworkResourceId));
                        }
                        break;
                    case IpRuleStringParameterSet:
                        foreach (string s in IPAddressOrRange)
                        {
                            Track2Models.IPRule rule = new Track2Models.IPRule(s);
                            if (!RemoveIpRule(storageACL.IPRules, rule))
                                throw new ArgumentOutOfRangeException("IPAddressOrRange", String.Format("Can't remove IpRule with specific IPAddressOrRange since not exist: {0}", rule.IPAddressOrRange));
                        }
                        break;
                    case ResourceAccessRuleStringParameterSet:
                        Track2Models.ResourceAccessRule resourceaccessrule = new Track2Models.ResourceAccessRule
                        {
                            ResourceId = this.ResourceId,
                            TenantId = this.TenantId
                        };
                        if (!RemoveResourceAccessRule(storageACL.ResourceAccessRules, resourceaccessrule))
                                throw new ArgumentOutOfRangeException("TenantId, ResourceId", String.Format("Can't remove ResourceAccessRule since not exist, TenantId: {0}, ResourceId : {1}", resourceaccessrule.TenantId, resourceaccessrule.ResourceId));
                        
                        break;
                    case NetworkRuleObjectParameterSet:
                        foreach (PSVirtualNetworkRule rule in VirtualNetworkRule)
                        {
                            if (!RemoveNetworkRule(storageACL.VirtualNetworkRules, PSNetworkRuleSet.ParseStorageNetworkRuleVirtualNetworkRule(rule)))
                                throw new ArgumentOutOfRangeException("VirtualNetworkRule", String.Format("Can't remove VirtualNetworkRule with specific ResourceId since not exist: {0}", rule.VirtualNetworkResourceId));
                        }
                        break;
                    case IpRuleObjectParameterSet:
                        foreach (PSIpRule rule in IPRule)
                        {
                            if (!RemoveIpRule(storageACL.IPRules, PSNetworkRuleSet.ParseStorageNetworkRuleIPRule(rule)))
                                throw new ArgumentOutOfRangeException("IPRule", String.Format("Can't remove IpRule with specific IPAddressOrRange since not exist: {0}", rule.IPAddressOrRange));
                        }
                        break;
                    case ResourceAccessRuleObjectParameterSet:
                        foreach (PSResourceAccessRule rule in this.ResourceAccessRule)
                        {
                            if (!RemoveResourceAccessRule(storageACL.ResourceAccessRules, PSNetworkRuleSet.ParseStorageResourceAccessRule(rule)))
                                throw new ArgumentOutOfRangeException("ResourceAccessRule", String.Format("Can't remove ResourceAccessRule since not exist, TenantId: {0}, ResourceId : {1}", rule.TenantId, rule.ResourceId));
                        }
                        break;
                }

                Track2Models.StorageAccountPatch patch = new Track2Models.StorageAccountPatch();
                patch.NetworkRuleSet = storageACL;
                var updatedStorageAccount = this.StorageClientTrack2
                    .GetStorageAccount(this.ResourceGroupName, this.Name)
                    .Update(patch);

                storageAccount = this.StorageClientTrack2.GetStorageAccount(this.ResourceGroupName, this.Name).Get();

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                    case NetworkRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.Data.NetworkRuleSet).VirtualNetworkRules);
                        break;
                    case IpRuleStringParameterSet:
                    case IpRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.Data.NetworkRuleSet).IpRules);
                        break;
                    case ResourceAccessRuleStringParameterSet:
                    case ResourceAccessRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.Data.NetworkRuleSet).ResourceAccessRules);
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
        public bool RemoveIpRule(IList<Track2Models.IPRule> ruleList, Track2Models.IPRule ruleToRemove)
        {
            foreach (Track2Models.IPRule rule in ruleList)
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
        /// Remove one ResourceAccessRule from ResourceAccessRule List
        /// </summary>
        /// <param name="ruleList">The ResourceAccessRule List</param>
        /// <param name="ruleToRemove">The ResourceAccessRule to remove</param>
        /// <returns>true if reove success</returns>
        public bool RemoveResourceAccessRule(IList<Track2Models.ResourceAccessRule> ruleList, Track2Models.ResourceAccessRule ruleToRemove)
        {
            foreach (Track2Models.ResourceAccessRule rule in ruleList)
            {
                if (rule.TenantId.ToString().Equals(ruleToRemove.TenantId.ToString(), System.StringComparison.InvariantCultureIgnoreCase)
                   && rule.ResourceId.Equals(ruleToRemove.ResourceId, System.StringComparison.InvariantCultureIgnoreCase))
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
        public bool RemoveNetworkRule(IList<Track2Models.VirtualNetworkRule> ruleList, Track2Models.VirtualNetworkRule ruleToRemove)
        {
            foreach (Track2Models.VirtualNetworkRule rule in ruleList)
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
