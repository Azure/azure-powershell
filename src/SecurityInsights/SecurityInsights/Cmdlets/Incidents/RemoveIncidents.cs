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
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.Incidents;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Incidents
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncident", DefaultParameterSetName = ParameterSetNames.IncidentId, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveIncidents : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [ValidateNotNullOrEmpty]
        public string IncidentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSentinelIncident InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = IncidentId;

            switch (ParameterSetName)
            {
                case ParameterSetNames.IncidentId:
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(name, VerbsCommon.Remove))
            {
                SecurityInsightsClient.Incidents.Delete(ResourceGroupName, WorkspaceName, name);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
