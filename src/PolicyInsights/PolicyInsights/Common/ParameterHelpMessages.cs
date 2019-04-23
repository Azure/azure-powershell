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

namespace Microsoft.Azure.Commands.PolicyInsights.Common
{
    /// <summary>
    /// Parameter help messages
    /// </summary>
    public static class ParameterHelpMessages
    {
        public const string Name = "Resource name.";
        public const string Scope = "Scope of the resource. E.g. '/subscriptions/{subscriptionId}/resourceGroups/{rgName}'.";
        public const string ManagementGroupName = "Management group ID.";
        public const string SubscriptionId = "Subscription ID.";
        public const string ResourceGroupName = "Resource group name.";
        public const string ResourceId = "Resource ID.";
        public const string PolicySetDefinitionName = "Policy set definition name.";
        public const string PolicyDefinitionName = "Policy definition name.";
        public const string PolicyAssignmentName = "Policy assignment name.";
        public const string PolicyAssignmentId = "Policy assignment ID. E.g. '/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{assignmentName}'.";
        public const string PolicyDefinitionReferenceId = "Gets the policy definition reference ID of the individual definition that is being remediated. Required when the policy assignment assigns a policy set definition.";
        public const string Top = "Maximum number of records to return.";
        public const string OrderBy = "Ordering expression using OData notation. One or more comma-separated column names with an optional 'desc' (the default) or 'asc'.";
        public const string Select = "Select expression using OData notation. One or more comma-separated column names. Limits the columns on each record to just those requested.";
        public const string From = "ISO 8601 formatted timestamp specifying the start time of the interval to query. When not specified, defaults to 'To' parameter value minus 1 day.";
        public const string To = "ISO 8601 formatted timestamp specifying the end time of the interval to query. When not specified, defaults to time of request.";
        public const string Filter = "Filter expression using OData notation.";
        public const string Apply = "Apply expression for aggregations using OData notation.";
        public const string Expand = "Expand expression using OData notation.";
        public const string All = "Within the specified time interval, get all policy states instead of the latest only.";
        public const string RemediationObject = "The Remediation object.";
        public const string LocationFilter = "The resource locations that should be included in the remediation. Resources that don't reside in these locations will not be remediated.";
        public const string IncludeRemediationDetail = "Include details of the deployments created by the remediation.";
        public const string TopRemediationDeployments = "Number of deployment details to return.";
        public const string AsJob = "Run cmdlet in the background.";
        public const string AllowRemediationStop = "Allow the remediation to be canceled if it is in-progress.";
        public const string PassThru = "Return True if the command completes successfully.";
    }
}
