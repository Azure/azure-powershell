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
// ------------------------------------

using System.Linq;
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Tasks;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Tasks
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityTask", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityTask))]
    public class GetTasks : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var tasks = SecurityCenterClient.Tasks.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    WriteObject(tasks.ConvertToPSType(), enumerateCollection: true);
                    break;
                case ParameterSetNames.ResourceGroupScope:
                    SecurityCenterClient.AscLocation = SecurityCenterClient.Locations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.First().Name;

                    tasks = SecurityCenterClient.Tasks.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                    WriteObject(tasks.ConvertToPSType(), enumerateCollection: true);
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    SecurityCenterClient.AscLocation = SecurityCenterClient.Locations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.First().Name;

                    var task = SecurityCenterClient.Tasks.GetSubscriptionLevelTaskWithHttpMessagesAsync(Name).GetAwaiter().GetResult().Body;
                    WriteObject(task.ConvertToPSType());
                    break;
                case ParameterSetNames.ResourceGroupLevelResource:
                    SecurityCenterClient.AscLocation = SecurityCenterClient.Locations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.First().Name;

                    task = SecurityCenterClient.Tasks.GetResourceGroupLevelTaskWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(task.ConvertToPSType());
                    break;
                case ParameterSetNames.ResourceId:
                    SecurityCenterClient.AscLocation = AzureIdUtilities.GetResourceLocation(ResourceId);

                    var rg = AzureIdUtilities.GetResourceGroup(ResourceId);

                    if (string.IsNullOrEmpty(rg))
                    {
                        task = SecurityCenterClient.Tasks.GetSubscriptionLevelTaskWithHttpMessagesAsync(AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    }
                    else
                    {
                        task = SecurityCenterClient.Tasks.GetResourceGroupLevelTaskWithHttpMessagesAsync(rg, AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    }

                    WriteObject(task.ConvertToPSType());
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
