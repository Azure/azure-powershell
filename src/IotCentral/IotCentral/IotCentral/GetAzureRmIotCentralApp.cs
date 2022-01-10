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

using Microsoft.Azure.Commands.IotCentral.Common;
using Microsoft.Azure.Commands.IotCentral.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.IotCentral;
using Microsoft.Azure.Management.IotCentral.Models;
using System.Collections.Generic;
using System.Management.Automation;

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

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InteractiveIotCentralParameterSet:
                    App iotCentralApp = this.IotCentralClient.Apps.Get(this.ResourceGroupName, this.Name);
                    this.WriteObject(IotCentralUtils.ToPSIotCentralApp(iotCentralApp));
                    break;
                case ListIotCentralAppsParameterSet:
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        IEnumerable<App> iotCentralAppsBySubscription = this.IotCentralClient.Apps.ListBySubscription();
                        this.WriteObject(IotCentralUtils.ToPSIotCentralApps(iotCentralAppsBySubscription), enumerateCollection: true);
                        break;
                    }
                    else
                    {
                        IEnumerable<App> iotCentralAppsByResourceGroup = this.IotCentralClient.Apps.ListByResourceGroup(this.ResourceGroupName);
                        this.WriteObject(IotCentralUtils.ToPSIotCentralApps(iotCentralAppsByResourceGroup), enumerateCollection: true);
                        break;
                    }
                case ResourceIdParameterSet:
                    ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                    var app = this.IotCentralClient.Apps.Get(identifier.ResourceGroupName, identifier.ResourceName);
                    this.WriteObject(IotCentralUtils.ToPSIotCentralApp(app));
                    break;
                default:
                    throw new PSArgumentException("BadParameterSetName");
            }
        }

    }
}
