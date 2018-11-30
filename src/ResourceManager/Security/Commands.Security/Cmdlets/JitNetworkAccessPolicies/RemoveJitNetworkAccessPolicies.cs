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

using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.JitNetworkAccessPolicies
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "JitNetworkAccessPolicy", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveJitNetworkAccessPolicies : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Security/jitNetworkAccessPolicies")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSecurityJitNetworkAccessPolicy InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Name;
            var rg = ResourceGroupName;
            var location = Location;

            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceGroupLevelResource:
                    break;
                case ParameterSetNames.ResourceId:
                    location = AzureIdUtilities.GetResourceLocation(ResourceId); ;

                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    rg = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    rg = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    location = AzureIdUtilities.GetResourceLocation(InputObject.Id);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(name, VerbsCommon.Set))
            {
                SecurityCenterClient.AscLocation = location;
                SecurityCenterClient.JitNetworkAccessPolicies.DeleteWithHttpMessagesAsync(rg, name).GetAwaiter().GetResult();
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
