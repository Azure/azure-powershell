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
    using Base;
    using Management.ServerManagement;
    using Model;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Remove, "AzureRmServerManagementGateway")]
    [Obsolete("The AzureRM.ServerManagement module will be removed from AzureRM in May 2018")]
    public class RemoveServerManagementGatewayCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway to delete.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The gateway to delete.", ValueFromPipeline = true,
            ParameterSetName = "ByObject", Position = 0)]
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

            WriteVerbose(string.Format("Removing gateway for {0}/{1}", ResourceGroupName, GatewayName));
            // delete the gateway.
            Client.Gateway.Delete(ResourceGroupName, GatewayName);
        }
    }
}