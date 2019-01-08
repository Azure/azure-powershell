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
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.JitNetworkAccessPolicies
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "JitNetworkAccessPolicy", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityJitNetworkAccessPolicy))]
    public class StartJitNetworkAccessPolicies : SecurityCenterCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.AutoProvision)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AutoProvision)]
        [ValidateNotNullOrEmpty]
        public PSSecurityJitNetworkAccessPolicyInitiateVirtualMachine[] VirtualMachine { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSecurityJitNetworkAccessPolicyInitiateInputObject InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Name;
            var location = Location;
            var rgName = ResourceGroupName;
            var vms = VirtualMachine;

            switch (ParameterSetName)
            {
                case "ResourceGroupLevelResource":
                    break;
                case "ResourceId":
                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    location = AzureIdUtilities.GetResourceLocation(ResourceId);
                    rgName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case "InputObject":
                    name = InputObject.Name;
                    location = InputObject.Location;
                    rgName = InputObject.ResourceGroupName;
                    vms = InputObject.VirtualMachine;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(name, "Start"))
            {
                SecurityCenterClient.AscLocation = location;
                var aps = SecurityCenterClient.JitNetworkAccessPolicies.InitiateWithHttpMessagesAsync(rgName, name, vms.ConvertToCSType()).GetAwaiter().GetResult().Body;
                WriteObject(aps.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }

    public class PSSecurityJitNetworkAccessPolicyInitiateInputObject
    {
        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public PSSecurityJitNetworkAccessPolicyInitiateVirtualMachine[] VirtualMachine { get; set; }
    }
}
