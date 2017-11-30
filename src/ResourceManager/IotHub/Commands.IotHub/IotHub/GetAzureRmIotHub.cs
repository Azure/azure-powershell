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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Get, "AzureRmIotHub", DefaultParameterSetName = "ListIotHubsByResourceGroup")]
    [OutputType(typeof(PSIotHub), typeof(List<PSIotHub>))]
    public class GetAzureRmIotHub : IotHubBaseCmdlet
    {
        const string GetIotHubParameterSet = "GetIotHubByName";
        const string ListIotHubsByRGParameterSet = "ListIotHubsByResourceGroup";

        [Parameter(
            ParameterSetName = GetIotHubParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [Parameter(
            ParameterSetName = ListIotHubsByRGParameterSet,
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = GetIotHubParameterSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetIotHubParameterSet:
                    IotHubDescription iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
                    this.WriteObject(IotHubUtils.ToPSIotHub(iotHubDescription), false);
                    break;
                case ListIotHubsByRGParameterSet:
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        IEnumerable<IotHubDescription> iotHubDescriptionsBySubscription = this.IotHubClient.IotHubResource.ListBySubscription();
                        this.WriteObject(IotHubUtils.ToPSIotHubs(iotHubDescriptionsBySubscription), true);
                        break;
                    }
                    else
                    {
                        IEnumerable<IotHubDescription> iotHubDescriptions = this.IotHubClient.IotHubResource.ListByResourceGroup(this.ResourceGroupName);
                        this.WriteObject(IotHubUtils.ToPSIotHubs(iotHubDescriptions), true);
                        break;
                    }
                default:
                    throw new ArgumentException("BadParameterSetName");
            }
        }
    }
}
