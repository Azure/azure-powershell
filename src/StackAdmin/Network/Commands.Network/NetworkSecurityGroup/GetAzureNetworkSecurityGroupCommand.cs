﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmNetworkSecurityGroup"), OutputType(typeof(PSNetworkSecurityGroup))]
    public class GetAzureNetworkSecurityGroupCommand : NetworkSecurityGroupBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var nsg = this.GetNetworkSecurityGroup(this.ResourceGroupName, this.Name, this.ExpandResource);

                WriteObject(nsg);
            }
            else
            {
                IPage<NetworkSecurityGroup> nsgPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    nsgPage = this.NetworkSecurityGroupClient.List(this.ResourceGroupName);
                }
                else
                {
                    nsgPage = this.NetworkSecurityGroupClient.ListAll();                    
                }

                // Get all resources by polling on next page link
                var nsgList = ListNextLink<NetworkSecurityGroup>.GetAllResourcesByPollingNextLink(nsgPage, this.NetworkSecurityGroupClient.ListNext);

                var psNsgs = new List<PSNetworkSecurityGroup>();

                foreach (var networkSecurityGroup in nsgList)
                {
                    var psNsg = this.ToPsNetworkSecurityGroup(networkSecurityGroup);
                    psNsg.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkSecurityGroup.Id);
                    psNsgs.Add(psNsg);
                }

                WriteObject(psNsgs, true);
            }
        }
    }
}
