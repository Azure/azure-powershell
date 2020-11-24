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

using Microsoft.Azure.Management.WebSites.Version2016_09_01.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Common
{
    public static class ParameterHelpMessages
    {
        #region General

        public const string ResourceGroupName = "Resource group name.";
        public const string WorkspaceName = "Workspace Name.";
        public const string ResourceId = "Resource Id.";
        public const string InputObject = "InputObject.";
        public const string Description = "Description.";
        public const string PassThru = "PassThru";
        public const string AsJob = "Run cmdlet in the background";
        public const string Etag = "Etag";
        #endregion

        #region Actions
        public const string ActionId = "Action Id.";
        public const string LogicAppResourceId = "Action Logic App Resource Id.";
        public const string TriggerUri = "Action Logic App Trigger Uri.";

        #endregion
        #region AlertRules
        public const string AlertRuleId = "Alert Rule Id.";
        public const string Kind = "Alert Rule Kind.";
        public const string AlertRuleTemplateName = "Alert Rule Template.";
        public const string Enabled = "Alert Rule Enabled.";
        public const string DisplayName = "Alert Rule Display Name.";
        public const string ProductFilter = "Alert Rule Product Filter.";
        public const string DisplayNamesExcludeFilter = "Alert Rule Display Names Exclude Filter.";
        public const string DisplayNamesFilter = "Alert Rule Display Names Filter.";
        public const string SeveritiesFilter = "Alert Rule Severities Filter.";
        public const string SuppressionDuration = "Alert Rule Suppression Duration.";
        public const string SuppressionEnabled = "Alert Rule Suppression Enabled.";
        public const string Query = "Alert Rule Query.";
        public const string QueryFrequency = "Alert Rule Query Frequency.";
        public const string QueryPeriod = "Alert Rule Query Period.";
        public const string Tactics = "Alert Rule Tactics.";
        public const string TriggerOperator = "Alert Rule Trigger Operator.";
        public const string TriggerThreshold = "Alert Rule Trigger Threshold.";
        #endregion

        #region
        public const string AlertRuleTemplateId = "Template Alert Rule Id.";
        #endregion

        #region Bookmarks
        public const string BookmarkId = "Bookmark Id,";
        public const string RelationName = "Bookmark Relation Name.";
        public const string CreatedBy = "Bookmark Created By.";
        public const string BookmarkDisplayName = "Bookmark Rule Display Name.";
        public const string IncidentInfo = "Bookmark Incident Info.";
        public const string Notes = "Bookmark Notes.";
        public const string BookmarkQuery = "Bookmark Query.";
        public const string QueryResult = "Bookmark Query Result.";
        public const string UpdatedBy = "Bookmark Updated By.";
        #endregion

        #region DataConnectors
        public const string DataConnectorId = "Data Connector Id.";
        public const string DataConnectorKind = "Data Connector Kind.";
        public const string AzureActiveDirectory = "Data Connector Azure Active Directory";
        public const string AzureAdvancedThreatProtection = "Data Connector Azure Advanced Threat Protection";
        public const string AzureSecurityCenter = "Data Connector Azure Security Center";
        public const string AmazonWebServicesCloudTrail = "Data Connector Amazon Web Services Cloud Trail";
        public const string MicrosoftCloudAppSecurity = "Data Connector Microsoft Cloud App Security";
        public const string MicrosoftDefenderAdvancedThreatProtection = "Data Connector Microsoft Defender Advanced Threat Protection";
        public const string Office365 = "Data Connector Office 365";
        public const string ThreatIntelligence = "Data Connector Threat Intelligence";
        public const string Alerts = "Data Connector Alerts";
        public const string AwsRoleArn = "Data Connector AWS Role Arn";
        public const string Logs = "Data Connector Logs";
        public const string DiscoveryLogs = "Data Connector Discovery Logs";
        public const string Exchange = "Data Connector Exchange";
        public const string SharePoint = "Data Connector SharePoint";
        public const string Indicators = "Data Connector Indicators";
        public const string SubscriptionId = "Data connector Subscription Id";
        #endregion

        #region IncidentComments
        public const string IncidentCommentId = "Incident Comment Id.";
        public const string Message = "Incident Message.";
        #endregion

        #region Incidents
        public const string IncidentId = "Incident Id.";
        public const string Classificaton = "Incident Classificaiton.";
        public const string ClassificationComment = "Incident Classificaiton Comment.";
        public const string ClassificationReason = "Incident Classificaiton Reason.";
        public const string Labels = "Incident Labels.";
        public const string Owner = "Incident Owner.";
        public const string Severity = "Incident Severity.";
        public const string Status = "Incident Status.";
        public const string Title = "Incident Title.";
        public const string LabelName = "Incident Label Name.";
        public const string LabelType = "Incident Label Type.";
        public const string AssignedTo = "Incident Owner - Assigned To";
        public const string Email = "Incident Owner - Email";
        public const string ObjectId = "Incident Owner - ObjectId";
        public const string UserPrincipalName = "Incident Owner - User Principal Name";
        #endregion

        
    }
}