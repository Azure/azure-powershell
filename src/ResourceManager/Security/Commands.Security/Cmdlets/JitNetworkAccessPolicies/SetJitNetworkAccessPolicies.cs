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
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.JitNetworkAccessPolicies
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "JitNetworkAccessPolicy", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityJitNetworkAccessPolicy))]
    public class SetJitNetworkAccessPolicies : SecurityCenterCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.VirutalMachines)]
        [ValidateNotNullOrEmpty]
        public PSSecurityJitNetworkAccessPolicyVirtualMachine[] VirtualMachine { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Kind)]
        public string Kind { get; set; }

        public override void ExecuteCmdlet()
        {
            var jitPolicy = new JitNetworkAccessPolicy(VirtualMachine.ConvertToCSType());
            jitPolicy.Kind = Kind;

            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                SecurityCenterClient.AscLocation = Location;

                var aps = SecurityCenterClient.JitNetworkAccessPolicies.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, Name, jitPolicy).GetAwaiter().GetResult().Body;
                WriteObject(aps.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
