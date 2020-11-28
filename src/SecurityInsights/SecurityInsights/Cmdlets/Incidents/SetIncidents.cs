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
using Microsoft.Azure.Management.SecurityInsights;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Incidents
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncident", DefaultParameterSetName = ParameterSetNames.IncidentId), OutputType(typeof(PSSentinelIncident))]
    public class SetIncidents : SecurityInsightsCmdletBase
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
        public string IncidentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Etag)]
        [ValidateNotNullOrEmpty]
        public string Etag { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.Classificaton)]
        [ValidateSet("BenignPositive", "FalsePositive", "TruePositive", "Undetermined")] 
        public string Classification { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.ClassificationComment)] 
        public string ClassificationComment { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.ClassificationReason)]
        [ValidateSet("InaccurateData", "IncorrectAlertLogic", "SuspiciousActivity", "SuspiciousButExpected")] 
        public string ClassificationReason { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, HelpMessage = ParameterHelpMessages.Description)] 
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Labels)]
        public IList<PSSentinelIncidentLabel> Labels { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Owner)]
        public PSSentinelIncidentOwner Owner { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Severity)]
        [ValidateSet("High", "Informational", "Low", "Medium")] 
        public string Severity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Status)]
        [ValidateSet("Active", "Closed", "New")] 
        public string Status { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.Title)] 
        public string Title { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSentinelIncident InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.IncidentId:
                    break;
                case ParameterSetNames.InputObject:
                    ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    WorkspaceName = AzureIdUtilities.GetWorkspaceName(InputObject.Id);
                    IncidentId = InputObject.Name;
                    Etag = InputObject.Etag;
                    Title = InputObject.Title;
                    Status = InputObject.Status;
                    Severity = InputObject.Severity;
                    Classification = InputObject.Classification;
                    ClassificationComment = InputObject.ClassificationComment;
                    ClassificationReason = InputObject.ClassificationReason;
                    Description = InputObject.Description;
                    Labels = (IList<PSSentinelIncidentLabel>) InputObject.Labels;
                    Owner = (PSSentinelIncidentOwner)InputObject.Owner;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            var name = IncidentId;
            Incident incident = new Incident
            {
                Etag = Etag,
                Title = Title,
                Status = Status,
                Severity = Severity,
                Classification = Classification,
                ClassificationComment = ClassificationComment,
                ClassificationReason = ClassificationReason,
                Description = Description,
                Labels = Labels?.CreatePSType(),
                Owner = Owner?.CreatePSType()
            };


            if (ShouldProcess(name, VerbsCommon.Set))
            {
                var outputIncident = SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, incident);

                WriteObject(outputIncident.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}
