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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmNetworkWatcherSecurityGroupView", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSSecurityGroupViewResult))]

    public class GetAzureNeyworkWatcherSecurityGroupViewCommand : NetworkWatcherBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target VM Id")]
        [ValidateNotNullOrEmpty]
        public string TargetVirtualMachineId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            MNM.SecurityGroupViewParameters properties = new MNM.SecurityGroupViewParameters();
            properties.TargetResourceId = this.TargetVirtualMachineId;

            PSSecurityGroupViewResult securityGroupView = new PSSecurityGroupViewResult();

            if (ParameterSetName.Contains("SetByResource"))
            {
                securityGroupView = GetSecurityGroupView(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, properties);
            }
            else
            {
                securityGroupView = GetSecurityGroupView(this.ResourceGroupName, this.NetworkWatcherName, properties);
            }
            WriteObject(securityGroupView);
        }

        public PSSecurityGroupViewResult GetSecurityGroupView(string resourceGroupName, string name, MNM.SecurityGroupViewParameters properties, string expandResource = null)
        {
            MNM.SecurityGroupViewResult securityGroupView = this.NetworkWatcherClient.GetVMSecurityRules(resourceGroupName, name, properties);
            var networkInterfaces = new PSSecurityGroupViewResult();
            networkInterfaces.NetworkInterfaces = new List<PSSecurityGroupView>();

            foreach (var view in securityGroupView.NetworkInterfaces)
            {
                PSSecurityGroupView securityRules = new PSSecurityGroupView();

                securityRules.NetworkInterfaceId = view.Id;

                if (view.SecurityRuleAssociations.NetworkInterfaceAssociation != null)
                {
                    securityRules.NetworkInterfaceSecurityRules = new List<PSSecurityRule>();
                    var customSecurityRulesList = view.SecurityRuleAssociations.NetworkInterfaceAssociation.SecurityRules;

                    foreach (var rule in customSecurityRulesList)
                    {
                        PSSecurityRule psRule = NetworkResourceManagerProfile.Mapper.Map<PSSecurityRule>(rule);
                        securityRules.NetworkInterfaceSecurityRules.Add(psRule);
                    }
                }

                if (view.SecurityRuleAssociations.SubnetAssociation != null)
                {
                    securityRules.SubnetId = view.SecurityRuleAssociations.SubnetAssociation.Id;
                    securityRules.SubnetSecurityRules = new List<PSSecurityRule>();

                    var subnetSecurityRulesList = view.SecurityRuleAssociations.SubnetAssociation.SecurityRules;

                    foreach (var rule in subnetSecurityRulesList)
                    {
                        PSSecurityRule psRule = NetworkResourceManagerProfile.Mapper.Map<PSSecurityRule>(rule);
                        securityRules.SubnetSecurityRules.Add(psRule);
                    }
                }

                securityRules.DefaultSecurityRules = new List<PSSecurityRule>();
                var defaultSecurityRulesList = view.SecurityRuleAssociations.DefaultSecurityRules;

                foreach (var rule in defaultSecurityRulesList)
                {
                    PSSecurityRule psRule = NetworkResourceManagerProfile.Mapper.Map<PSSecurityRule>(rule);
                    securityRules.DefaultSecurityRules.Add(psRule);
                }

                securityRules.EffectiveSecurityRules = new List<PSEffectiveSecurityRule>();
                var effectiveSecurityRulesList = view.SecurityRuleAssociations.EffectiveSecurityRules;

                foreach (var rule in effectiveSecurityRulesList)
                {
                    PSEffectiveSecurityRule psRule = NetworkResourceManagerProfile.Mapper.Map<PSEffectiveSecurityRule>(rule);
                    securityRules.EffectiveSecurityRules.Add(psRule);
                }

                networkInterfaces.NetworkInterfaces.Add(securityRules);
            }

            return networkInterfaces;
        }
    }
}
