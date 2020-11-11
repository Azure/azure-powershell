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

namespace Microsoft.Azure.Commands.SecurityInsights.Common
{
    public static class ParameterHelpMessages
    {
        #region General

        public const string SubscriptionId = "Subscription ID.";
        public const string ResourceGroupName = "Resource group name.";
        public const string WorkspaceName = "Workspace name.";
        public const string ResourceName = "Resource name.";
        public const string SolutionName = "Solution name"; 
        public const string ResourceId = "ID of the security resource that you want to invoke the command on.";
        public const string Scope = "Scope.";
        public const string Kind = "Kind.";
        public const string InputObject = "Input Object.";
        public const string Location = "Location.";
        public const string PassThru = "Return whether the operation was successful.";
        public const string Tags = "Tags.";
        public const string DisplayName = "Human readable title for this object.";
        public const string Status = "Status .";
        public const string Export = "Export data.";
        public const string DisabledDataSources = "Disabled data sources.";
        public const string IotHubs = "Iot hubs.";
        public const string UserDefinedResources = "User defined resources.";
        public const string AutoDiscoveredResources = "Auto discovered resources.";
        public const string RecommendationsConfiguration = "Recommendations configuration.";
        public const string UnmaskedIpLoggingStatus = "Unmasked ip logging status.";
        public const string HubResourceId = "IoT Hub resource Id.";
        public const string IsDefualt = "If present, get the default analytics set, otherwise, get the list of all analytics sets.";
        public const string RecommendationType = "Recommendation type.";
        public const string Query = "Query.";
        public const string QuerySubscriptions = "Query subscriptions.";
        public const string AsJob = "Run cmdlet in the background";

        #endregion

        #region Incidents
        public const string IncidentId = "Incident Id.";

        #endregion
    }
}