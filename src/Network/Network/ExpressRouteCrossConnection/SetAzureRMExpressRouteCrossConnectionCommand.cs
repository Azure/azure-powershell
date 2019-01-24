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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCrossConnection", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteCrossConnection))]
    public class SetAzureRMExpressRouteCrossConnectionCommand : ExpressRouteCrossConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCrossConnection",
            ParameterSetName = "ModifyByCircuitReference")]
        public PSExpressRouteCrossConnection ExpressRouteCrossConnection { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ExpressRouteCrossConnection",
            ParameterSetName = "ModifyByParameterValues")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of express route cross connection.",
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "ModifyByParameterValues")]
        [ResourceNameCompleter("Microsoft.Network/expressRouteCrossConnections", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The service provider provisioning state to be set",
            ParameterSetName = "ModifyByParameterValues")]
        public string ServiceProviderProvisioningState { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The service provider notes",
            ParameterSetName = "ModifyByParameterValues")]
        public string ServiceProviderNotes { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The list of peerings for the cross connection",
            ParameterSetName = "ModifyByParameterValues")]
        public PSExpressRouteCrossConnectionPeering[] Peerings { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ExpressRouteCrossConnection != null)
            {
                // If ExpressRouteCrossConnection object is provided
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.OverwritingResource, ExpressRouteCrossConnection.Name),
                    Properties.Resources.CreatingResourceMessage,
                    ExpressRouteCrossConnection.Name,
                    () =>
                    {
                        var crossConnection = GetExistingExpressRouteCrossConnection(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name);
                        if (crossConnection == null)
                        {
                            throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                        }

                        // Map to the sdk operation
                        var crossConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteCrossConnection>(ExpressRouteCrossConnection);
                        crossConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(ExpressRouteCrossConnection.Tag, validate: true);

                        // Execute the Update ExpressRouteCrossConnection call
                        ExpressRouteCrossConnectionClient.CreateOrUpdate(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name, crossConnectionModel);

                        var getExpressRouteCircuit = GetExpressRouteCrossConnection(ExpressRouteCrossConnection.ResourceGroupName, ExpressRouteCrossConnection.Name);
                        WriteObject(getExpressRouteCircuit);
                    });
            }
            else
            {
                // If individual parameters are provided
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.OverwritingResource, Name),
                    Properties.Resources.CreatingResourceMessage,
                    Name,
                    () =>
                    {
                        var crossConnection = GetExistingExpressRouteCrossConnection(ResourceGroupName, Name);
                        if (crossConnection == null)
                        {
                            throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                        }

                        if (!string.IsNullOrWhiteSpace(ServiceProviderNotes))
                        {
                            crossConnection.ServiceProviderNotes = ServiceProviderNotes;
                        }

                        if (!string.IsNullOrWhiteSpace(ServiceProviderProvisioningState))
                        {
                            crossConnection.ServiceProviderProvisioningState = ServiceProviderProvisioningState;
                        }

                        if (Peerings != null && Peerings.Length > 0)
                        {
                            crossConnection.Peerings = Peerings?.ToList();
                        }

                        // Map to the sdk operation
                        var crossConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteCrossConnection>(crossConnection);
                        crossConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(crossConnection.Tag, validate: true);

                        // Execute the Update ExpressRouteCrossConnection call
                        ExpressRouteCrossConnectionClient.CreateOrUpdate(ResourceGroupName, Name, crossConnectionModel);

                        var getExpressRouteCrossConnection = GetExpressRouteCrossConnection(ResourceGroupName, Name);
                        WriteObject(getExpressRouteCrossConnection);
                    });
            }

            
        }
    }
}
