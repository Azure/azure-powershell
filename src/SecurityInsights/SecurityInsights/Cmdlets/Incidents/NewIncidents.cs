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
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Incidents
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncident", DefaultParameterSetName = ParameterSetNames.IncidentId), OutputType(typeof(PSSentinelIncident))]
    public class NewIncidents : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty] 
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.Classificaton)] 
        public string Classificaton { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.ClassificationComment)] 
        public string ClassificationComment { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.ClassificationReason)] 
        public string ClassificationReason { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.Description)] 
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Labels)]
        public IList<IncidentLabel> Labels { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Owner)]
        public IncidentOwnerInfo Owner { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Severity)] 
        public string Severity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Status)] 
        public string Status { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Title)] 
        public string Title { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Id;

            Incident incident = new Incident
            {
                Title = Title,
                Status = Status,
                Severity = Severity,
                Classification = Classificaton,
                ClassificationComment = ClassificationComment,
                ClassificationReason = ClassificationReason,
                Description = Description,
                Labels = Labels,
                Owner = Owner
            };

            if (ShouldProcess(name, VerbsCommon.Set))
            {
                var outputIncidnet = SecurityInsightsClient.Incidents.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, incident).GetAwaiter().GetResult().Body;

                WriteObject(outputIncidnet?.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
