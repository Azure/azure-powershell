// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Gateway
{
    using System;
    using System.Management.Automation;
    using System.Net;
    using Base;
    using Management.ServerManagement;
    using Management.ServerManagement.Models;
    using Model;

    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementGateway", DefaultParameterSetName = "NoParams"),
     OutputType(typeof(Gateway))]
    public class GetServerManagementGatewayCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "Many-ByResourceGroup", Position = 0)]
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "Single-ByName", Position = 0)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway to get the status for.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "Single-ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The gateway to get the status for.", ValueFromPipeline = true,
            ParameterSetName = "Single-ByObject", Position = 0)]
        [ValidateNotNull]
        public Gateway Gateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (Gateway != null)
            {
                WriteVerbose("Using Gateway object for resource/gateway name");
                ResourceGroupName = Gateway.ResourceGroupName;
                GatewayName = Gateway.Name;
            }

            // a single gateway? 
            if (!string.IsNullOrWhiteSpace(GatewayName))
            {
                WriteVerbose(string.Format("Getting gateway status for {0}/{1}", ResourceGroupName, GatewayName));
                WriteObject(
                    Gateway.Create(Client.Gateway.Get(ResourceGroupName, GatewayName, GatewayExpandOption.Status)));
                return;
            }

            try
            {
                // multiple gateways
                if (!string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    // list the gateways for the Resource Group
                    WriteVerbose(string.Format("Listing gateways in resource group {0}", ResourceGroupName));

                    foreach (var gateway in Client.Gateway.ListForResourceGroup(ResourceGroupName))
                    {
                        WriteObject(Gateway.Create(gateway));
                    }

                    return;
                }

                WriteVerbose("Listing gateways in whole subscription");
                // list the gateways for the subscription
                foreach (var gateway in Client.Gateway.List())
                {
                    WriteObject(Gateway.Create(gateway));
                }
            }
            catch (ErrorException e)
            {
                // PowerShell cmdlets that query for multiple results should not throw 
                // if they return zero results. 
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }
        }
    }
}