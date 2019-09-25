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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkServiceConnection", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSPrivateLinkServiceConnection))]
    public class NewAzurePrivateLinkServiceConnectionCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of private link service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResource",
            ValueFromPipeline = true,
            HelpMessage = "The private link service.")]
        [ValidateNotNullOrEmpty]
        public PSPrivateLinkService PrivateLinkService { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResourceId",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of private link service.")]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkServiceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of group id.")]
        public string[] GroupId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The request message.")]
        public string RequestMessage { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.PrivateLinkService != null)
                {
                    this.PrivateLinkServiceId = this.PrivateLinkService.Id;
                }
            }

            var psPlsConnection = new PSPrivateLinkServiceConnection
            {
                Name = Name,
                PrivateLinkServiceId = PrivateLinkServiceId
            };

            if (!string.IsNullOrEmpty(this.RequestMessage))
            {
                psPlsConnection.RequestMessage = this.RequestMessage;
            }

            psPlsConnection.GroupIds = this.GroupId?.ToList();


            WriteObject(psPlsConnection);
        }
    }
}
