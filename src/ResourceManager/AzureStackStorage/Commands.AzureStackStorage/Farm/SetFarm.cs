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


using System.Globalization;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    ///     SYNTAX
    ///          Set-Farm  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [[-SettingPollingIntervalInSeconds] {int}] [-FarmName] {string} [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.AdminFarm, SupportsShouldProcess = true)]
    public sealed class SetAdminFarm : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNull]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? SettingsPollingIntervalInSecond { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpsPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public string CorsAllowedOriginsList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public string DataCenterUriHostSuffixes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public bool? BandwidthThrottleIsEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? UsageCollectionIntervalInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? RetentionPeriodForDeletedStorageAccountsInDays { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? FeedbackRefreshIntervalInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? NumberOfAccountsToSync { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? DefaultThrottleProbabilityDecayIntervalInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public int? GracePeriodForFullThrottlingInRefreshIntervals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? GracePeriodMaxThrottleProbability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallRequestThresholdInTps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultRequestThresholdInTps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumRequestThresholdInTps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIngress { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIntranetIngress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForEgress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIntranetEgress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTotalIngress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTotalEgress { get; set; }

        protected override void Execute()
        {
            string confirmString;
            FarmSettings settings = Tools.ToSettingsObject<SetAdminFarm, FarmSettings>(this, out confirmString);

            if (ShouldProcess(
                Resources.SetFarmDescription.FormatInvariantCulture(FarmName, confirmString),
                Resources.SetFarmWarning.FormatInvariantCulture(FarmName, confirmString),
                Resources.ShouldProcessCaption))
            {

                FarmUpdateParameters parameters = new FarmUpdateParameters
                {
                    Farm = new FarmBase {Settings = settings}
                };

                FarmGetResponse response = Client.Farms.Update(ResourceGroupName, FarmName, parameters);

                WriteObject(new FarmResponse(response.Farm));
            }
        }
    }
}