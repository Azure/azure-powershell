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

namespace Microsoft.Azure.Commands.Security.Common
{
    public static class ParameterSetNames
    {
        public const string GeneralScope = "GeneralScope";
        public const string SubscriptionScope = "SubscriptionScope";
        public const string ResourceGroupScope = "ResourceGroupScope";
        public const string ResourceIdScope = "ResourceIdScope";
        public const string SolutionScope = "SolutionScope";
        public const string ScopeLevelResource = "ScopeLevelResource";
        public const string SubscriptionLevelResource = "SubscriptionLevelResource";
        public const string ResourceGroupLevelResource = "ResourceGroupLevelResource";
        public const string SolutionLevelResource = "SolutionLevelResource";
        public const string ResourceIdLevelResource = "ResourceIdLevelResource";
        public const string ResourceId = "ResourceId";
        public const string InputObject = "InputObject";
        public const string InputObjectV3 = "InputObjectV3";
        public const string PolicyOn = "PolicyOn";
        public const string PolicyOff = "PolicyOff";

        #region Settings

        public const string SettingsScope = "SettingsScope";

        #endregion

        #region Sql Vulnerability Assessment

        public const string OnPremMachines = "OnPremMachines";

        public const string ResourceIdWithBaselineObject = "ResourceIdWithBaselineObject";
        public const string ResourceIdWithBaselineLatest = "ResourceIdWithBaselineLatest";
        public const string OnPremMachinesWithBaselineObject = "OnPremMachinesWithBaselineObject";
        public const string InputObjectBaselineWithResourceId = "InputObjectWithResourceId";
        public const string InputObjectBaselineWithOnPrem = "InputObjectBaselineWithOnPrem";
        public const string ResourceIdWithScanId = "ResourceIdWithScanId";
        public const string OnPremMachinesWithScanId = "OnPremMachinesWithScanId";

        #endregion

        #region AlertsSuppressionRules

        public const string RuleNameWithParameters = "RuleNameWithParameters";

        #endregion

        #region Security Automation

        public const string SecurityAutomationScope = "SecurityAutomationScope";
        public const string SecurityAutomationActionWorkspace = "SecurityAutomationActionWorkspace";
        public const string SecurityAutomationActionEventHub = "SecurityAutomationActionEventHub";
        public const string SecurityAutomationActionLogicApp = "SecurityAutomationActionLogicApp";
        public const string SecurityAutomationRule = "SecurityAutomationRule";
        public const string SecurityAutomationRuleSet = "SecurityAutomationRuleSet";
        public const string SecurityAutomationSource = "SecurityAutomationSource";

        #endregion
    }
}
