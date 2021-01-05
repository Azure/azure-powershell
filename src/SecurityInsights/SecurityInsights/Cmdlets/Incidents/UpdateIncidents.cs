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
using System;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Incidents
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncident", DefaultParameterSetName = ParameterSetNames.IncidentId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelIncident))]
    public class UpdateIncidents : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.IncidentId, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        public string IncidentID { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNull]
        public PSSentinelIncident InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Classificaton)]
        [ValidateSet("BenignPositive", "FalsePositive", "TruePositive", "Undetermined")]
        public string Classification { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.ClassificationComment)]
        public string ClassificationComment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.ClassificationReason)]
        [ValidateSet("InaccurateData", "IncorrectAlertLogic", "SuspiciousActivity", "SuspiciousButExpected")]
        public string ClassificationReason { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Description)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Labels)]
        public IList<PSSentinelIncidentLabel> Label { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.Owner)]
        public PSSentinelIncidentOwner Owner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Severity)]
        [ValidateSet("High", "Informational", "Low", "Medium")]
        public string Severity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Status)]
        [ValidateSet("Active", "Closed", "New")]
        public string Status { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Title)]
        public string Title { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(InputObject.Id);
                this.IncidentID = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.ResourceId);
                this.IncidentID = resourceIdentifier.ResourceName;
            }

            PSSentinelIncident incident = null;
            try
            {
                incident = this.SecurityInsightsClient.Incidents.Get(this.ResourceGroupName, this.WorkspaceName, this.IncidentID).ConvertToPSType();
            }
            catch
            {
                incident = null;
            }

            if (incident == null)
            {
                throw new Exception(string.Format("An Incident with IncidentID '{0}' in resource group '{1}' under parent workspace '{2}' does not exist. Please use New-AzSentinelBookmark to create a Bookmark with these properties.", this.IncidentID, this.ResourceGroupName, this.WorkspaceName));
            }

            incident.Etag = incident.Etag;
            incident.Classification = this.IsParameterBound(c => c.Classification) ? this.Classification : incident.Classification;
            incident.ClassificationComment = this.IsParameterBound(c => c.ClassificationComment) ? this.ClassificationComment : incident.ClassificationComment;
            incident.ClassificationReason = this.IsParameterBound(c => c.ClassificationReason) ? this.ClassificationReason : incident.ClassificationReason;
            incident.Description = this.IsParameterBound(c => c.Description) ? this.Description : incident.Description;
            incident.Labels = this.IsParameterBound(c => c.Label) ? this.Label : incident.Labels;
            incident.Owner = this.IsParameterBound(c => c.Owner) ? this.Owner : incident.Owner;
            incident.Severity = this.IsParameterBound(c => c.Severity) ? this.Severity : incident.Severity;
            incident.Status = this.IsParameterBound(c => c.Status) ? this.Status : incident.Status;
            incident.Title = this.IsParameterBound(c => c.Title) ? this.Title : incident.Title;

            if (this.ShouldProcess(this.IncidentID, string.Format("Updating IncidentID '{0}' in resource group '{1}' under workspace '{2}'.", this.IncidentID, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = this.SecurityInsightsClient.Incidents.CreateOrUpdate(this.ResourceGroupName, this.WorkspaceName, this.IncidentID, incident.CreatePSType()).ConvertToPSType();
                WriteObject(result);
            }
        }
    }
}
