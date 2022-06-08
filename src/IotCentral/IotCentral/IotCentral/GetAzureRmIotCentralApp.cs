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

using Microsoft.Azure.Commands.IotCentral.Common;
//using Microsoft.Azure.Commands.IotCentral.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
//using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Azure.ResourceManager.IotCentral;
using Azure.Core;

//using Microsoft.Azure.Management.IotCentral;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;

using System.Linq;
using System.Threading.Tasks;
using Azure.ResourceManager;
using Microsoft.Azure.Commands.IotCentral.Models;

namespace Microsoft.Azure.Commands.Management.IotCentral
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotCentralApp", DefaultParameterSetName = ListIotCentralAppsParameterSet)]
    [OutputType(typeof(PSIotCentralApp))]
    public class GetAzureRmIotCentralApp : IotCentralBaseCmdlet
    {
        const string ListIotCentralAppsParameterSet = "ListIotCentralAppsParameterSet";

        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "Name of the Resource Group.",
            ParameterSetName = InteractiveIotCentralParameterSet)]
        [Parameter(
            Mandatory = false,
            Position = 0,
            HelpMessage = "Name of the Resource Group.",
            ParameterSetName = ListIotCentralAppsParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public new string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Iot Central Application Resource Id.",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override async void ExecuteCmdlet()
        {

            switch (ParameterSetName)
            {
                case InteractiveIotCentralParameterSet:
                    var rg = this.IotCentralClient.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{ResourceGroupName}"));
                    var appFromInterative = await rg.GetIotCentralAppAsync(Name);
                    this.WriteObject(IotCentralUtils.ToPSIotCentralApp(appFromInterative));
                    break;
                case ListIotCentralAppsParameterSet:
                    if (string.IsNullOrEmpty(ResourceGroupName)) // list by subscription, not receiving arm client?
                    {
                        IEnumerable<IotCentralAppResource> iotCentralAppsBySubscription = (IEnumerable<IotCentralAppResource>)IotCentralClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{this.DefaultContext.Subscription.Id}"));
                        this.WriteObject(IotCentralUtils.ToPSIotCentralApps(iotCentralAppsBySubscription), enumerateCollection: true);
                        break;
                    }
                    else  // list by resource group
                    {
                        var resourceGroupResource = this.IotCentralClient.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{ResourceGroupName}"));
                        var iotCentralAppCollection = resourceGroupResource.GetIotCentralApps();
                        var iotCentralAppResource = iotCentralAppCollection.GetAll();
                        IEnumerable<IotCentralAppResource> iotCentralAppsByResourceGroup = iotCentralAppResource;
                        this.WriteObject(IotCentralUtils.ToPSIotCentralApps(iotCentralAppsByResourceGroup), enumerateCollection: true);
                        break;
                    }
                case ResourceIdParameterSet:
                    ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                    var app = IotCentralClient.GetIotCentralAppResource(identifier);
                    //var app = this.IotCentralClient.Apps.Get(identifier.ResourceGroupName, identifier.ResourceName);
                    this.WriteObject(IotCentralUtils.ToPSIotCentralApp(app));
                    break;
                default:
                    throw new PSArgumentException("BadParameterSetName");
            }
        }

    }
}
