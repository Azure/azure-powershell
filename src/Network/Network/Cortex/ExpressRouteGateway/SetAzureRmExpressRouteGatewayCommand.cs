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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using System.Linq;

    [Cmdlet(VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSExpressRouteGateway))]
    public class UpdateAzureRmExpressRouteGatewayCommand : ExpressRouteGatewayBaseCmdlet
    {

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "ExpressRouteGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
            Mandatory = true,
            HelpMessage = "The express route gateway name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ExpressRouteGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The express route gateway object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the ExpressRouteGateway to be modified.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Min for the scale units for this ExpressRouteGateway.")]
        [ValidateRange(1, 100)]
        public uint MinScaleUnits { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Max for the scale units for this ExpressRouteGateway.")]
        [ValidateRange(1, 100)]
        public uint MaxScaleUnits { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            PSExpressRouteGateway existingExpressRouteGateway = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayObject))
            {
                existingExpressRouteGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else 
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingExpressRouteGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.Name);
            }

            if (existingExpressRouteGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.ExpressRouteGatewayNotFound);
            }

            if (this.MinScaleUnits > 0 || this.MaxScaleUnits > 0)
            {
                if (this.MinScaleUnits > this.MaxScaleUnits)
                {
                    throw new PSArgumentException(string.Format(Properties.Resources.InvalidAutoScaleConfiguration, this.MinScaleUnits, this.MaxScaleUnits));
                }

                existingExpressRouteGateway.AutoScaleConfiguration.Bounds.Min = Convert.ToInt32(this.MinScaleUnits);
                existingExpressRouteGateway.AutoScaleConfiguration.Bounds.Max = Convert.ToInt32(this.MaxScaleUnits);
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateExpressRouteGateway(this.ResourceGroupName, this.Name, existingExpressRouteGateway, this.Tag));
                    });
        }
    }
}
