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

namespace Microsoft.Azure.Commands.Shared.Config
{
    /// <summary>
    /// This class stores keys of all the pre-defined configs.
    /// </summary>
    /// <remarks>
    /// All keys should be defined here.
    /// If the key is used in Azure/azure-powershell-common repo, duplicate it in ConfigKeysForCommon class.
    /// Keys defined here should NEVER be removed or changed to prevent breaking change.
    /// </remarks>
    internal static class ConfigKeys
    {
        public const string EnableInterceptSurvey = "DisplaySurveyMessage";
        public const string DisplayBreakingChangeWarning = "DisplayBreakingChangeWarning";
        public const string DefaultSubscriptionForLogin = "DefaultSubscriptionForLogin";
        public const string EnableDataCollection = "EnableDataCollection";
        public const string EnableTestCoverage = "EnableTestCoverage";
        public const string EnableLoginByWam = "EnableLoginByWam";
        public const string TestCoverageLocation = "TestCoverageLocation";
        public const string DisplayRegionIdentified = "DisplayRegionIdentified";
        //Use DisableErrorRecordsPersistence as opt-out for now, will replace it with EnableErrorRecordsPersistence as opt-in at next major release (November 2023)
        public const string DisableErrorRecordsPersistence = "DisableErrorRecordsPersistence";
        public const string EnableErrorRecordsPersistence = "EnableErrorRecordsPersistence";
        public const string DisableInstanceDiscovery = "DisableInstanceDiscovery";
        public const string CheckForUpgrade = "CheckForUpgrade";
        public const string EnvCheckForUpgrade = "AZUREPS_CHECK_FOR_UPGRADE";
        public const string DisplaySecretsWarning = "DisplaySecretsWarning";
    }
}
