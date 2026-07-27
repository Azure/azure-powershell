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


using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkVirtualAppliancePrepareMigration", DefaultParameterSetName = ResourceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSNetworkVirtualAppliance))]
    public class InvokeNetworkVirtualAppliancePrepareMigrationCommand : NetworkVirtualApplianceBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualApplianceName", "NvaName", "NetworkVirtualApplianceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Network Virtual Appliance name.")]
        [ResourceNameCompleter("Microsoft.Network/networkVirtualAppliances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "The resource Id.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of migration to prepare.")]
        [PSArgumentCompleter("MigrateToNewOSVersion", "MigrateToNewILBArchitecture")]
        [ValidateNotNullOrEmpty]
        public string MigrationType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The marketplace version to migrate to.")]
        public string MarketPlaceVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                this.Name = GetResourceName(this.ResourceId, "Microsoft.Network/networkVirtualAppliances");
            }

            if (this.ShouldProcess(this.Name, String.Format($"Preparing NetworkVirtualAppliance '{this.Name}' for migration")))
            {
                if (!this.IsNetworkVirtualAppliancePresent(this.ResourceGroupName, this.Name))
                {
                    throw new ArgumentException(Properties.Resources.ResourceNotFound);
                }

                var request = new NetworkVirtualAppliancePrepareMigrationRequest()
                {
                    Properties = new NetworkVirtualAppliancePrepareMigrationRequestProperties()
                    {
                        MigrationType = this.MigrationType,
                        MarketPlaceVersion = this.MarketPlaceVersion
                    }
                };

                this.NetworkVirtualAppliancesClient.PrepareMigrationWithHttpMessagesAsync(resourceGroupName: this.ResourceGroupName, networkVirtualApplianceName: this.Name, body: request).GetAwaiter().GetResult();

                var nva = this.GetNetworkVirtualAppliance(this.ResourceGroupName, this.Name);
                WriteObject(nva);
            }
        }
    }
}
