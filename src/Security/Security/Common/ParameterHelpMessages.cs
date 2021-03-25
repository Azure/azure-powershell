﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Security.Common
{
    public static class ParameterHelpMessages
    {
        #region General

        public const string SubscriptionId = "Subscription ID.";
        public const string ResourceGroupName = "Resource group name.";
        public const string ResourceName = "Resource name.";
        public const string SolutionName = "Solution name"; 
        public const string ResourceId = "ID of the security resource that you want to invoke the command on.";
        public const string Scope = "Scope.";
        public const string Kind = "Kind.";
        public const string InputObject = "Input Object.";
        public const string InputObjectV3 = "Input Object V3.";
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

        #region Workspace Settings

        public const string WorkspaceId = "Workspace ID.";

        #endregion

        #region Alerts

        public const string ActionType = "Action Type.";

        #endregion

        #region Security Contacts

        public const string Email = "E-Mail.";
        public const string Phone = "Phone.";
        public const string AlertsToAdmins = "Alerts To Administrators.";
        public const string AlertNotifications = "Alert Notifications.";

        #endregion

        #region Pricings

        public const string PricingTier = "Pricing Tier.";

        #endregion

        #region Auto Provisioning Settings

        public const string AutoProvision = "Automatic Provisioning.";

        #endregion

        #region Settings

        public const string SettingName = "Setting name.";
        public const string Setting = "Setting.";
        public const string SettingKind = "Setting kind.";
        public const string Enabled = "Enables the setting.";

        #endregion

        #region JIT Network Access Policies

        public const string VirutalMachines = "Virtual Machines.";

        #endregion

        #region Threat Detection Settings

        public const string Disable = "Disables Threat Protection Policy";
        public const string Enable = "Enables Threat Protection Policy";

        #endregion

        #region RegulatoryCompliance

        public const string StandardName = "Standard Name.";
        public const string ControlName = "Control Name.";
      
        #endregion

        #region Device Security Groups

        public const string ThresholdRules = "Threshold rules.";
        public const string TimeWindowRules = "Time window rules.";
        public const string AllowlistRules = "Allow list rules.";
        public const string DenylistRules = "Deny list rules.";
        public const string TimeWindowSize = "Time window size.";
        public const string MinThreshold = "Minimum threshold.";
        public const string MaxThreshold = "Maximum threshold.";
        public const string IsEnabled = "Is rule enabled.";
        public const string RuleType = "Rule type.";
        public const string ValueType = "Value type.";
        public const string AllowlistValues = "Allow list values.";
        public const string DenylistValues = "Deny list values.";

        #endregion

        #region Security Assessments

        public const string AssessedResourceId = "Full resource ID of the resource that the assessment is calculated on.";
        public const string Description = "Detailed string that will help users to understand the meaning of this assessment and how it was calculated.";
        public const string RemediationDescription = "Detailed string that will help users to understand the different ways to mitigate or fix the security issue.";
        public const string Severity = "Indicates the importance of the security risk if the assessment is unhealthy.";
        public const string StatusCode = "Progremmatic code for the result of the assessment. can be \"Healthy\", \"Unhealthy\" or \"NotApplicable\"";
        public const string StatusCause = "Progremmatic code for the cause of the assessment's result.";
        public const string StatusDescription = "Human readable description of the cause of the assessment's result.";
        public const string AdditionalData = "Data that is attached to the assessment result for better investigations or status clarity.";
        public const string AssessmentsName = "Name of the assessment resource.";

        #endregion

        #region Adaptive Network Hardenings

        public const string ResourceNamespace = "Resource namespace";
        public const string ResourceType = "Resource type";
        public const string RulesToEnforce = "Rule to enforce";
        public const string AdaptiveNetworkHardeningResourceName = "Adaptive Network Hardening resource name";
        public const string AdaptiveNetworkHardeningEnforceAction = "Adaptive Network Hardening enforce action";
        public const string EffectiveNetworkSecurityGroups = "The Azure resource IDs of the effective network security groups";

        #endregion
 
        #region Adaptive Application Controls

        public const string AdaptiveApplicationControlsGroupName = "Name of an application control VM/server group";
        public const string AscLocation = "The location where ASC stores the data of the subscription. can be retrieved from Get locations";
        public const string IncludePathRecommendation = "Include the policy rules";
        public const string Summary = "Return output in a summarized form";

        #endregion

        #region SQL Vulnerability Assessment

        public const string Server = "Server name";
        public const string Database = "Database name";
        public const string ComputerName = "Computer full name - on premise parameter";
        public const string VmUuid = "Virtual machine universal unique identifier - on premise parameter";
        public const string AgentId = "Agent ID - on premise parameter";
        public const string WorkspaceResourceId = "Workspace resource ID - on premise parameter";
        public const string UseLatest = "Use latest results for the operation";
        public const string RuleId = "Vulnerability Assessment rule ID";
        public const string ScanId = "Vulnerability Assessment scan ID - use scanId = 'latest' to get latest results";
        public const string Baseline = "Vulnerability Assessment baseline object";
        public const string ForceRemoveBaseline = "Force remove baseline without confirmation";
        public const string ForceSetBaseline = "Force set baseline without confirmation";

        #endregion
    }
}