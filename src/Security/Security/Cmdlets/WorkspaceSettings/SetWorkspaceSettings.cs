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
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.WorkspaceSettings;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.WorkspaceSettings
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityWorkspaceSetting", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityWorkspaceSetting))]
    public class SetWorkspaceSettings : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Scope)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.WorkspaceId)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var wssl = SecurityCenterClient.WorkspaceSettings.CreateWithHttpMessagesAsync(Name, WorkspaceId, Scope).GetAwaiter().GetResult().Body;
                WriteObject(wssl.ConvertToPSType(), enumerateCollection: false); 
            }
        }
    }
}
