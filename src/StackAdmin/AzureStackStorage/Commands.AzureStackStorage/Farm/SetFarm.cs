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


using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Modifies the Storage settings and service configurations for the region/farm.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.AdminFarm, SupportsShouldProcess = true)]
    [Alias("Set-ACSFarm")]
    public sealed class SetAdminFarm : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Settings polling interval in second.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? SettingsPollingIntervalInSecond { get; set; }

        /// <summary>
        /// The host style HTTP port.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpPort { get; set; }

        /// <summary>
        /// The host style HTTPS port.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpsPort { get; set; }

        /// <summary>
        /// The cors allowed origins list.
        /// </summary>
        [Parameter]
        [SettingField]
        public string CorsAllowedOriginsList { get; set; }

        /// <summary>
        /// The data center URI host suffixes.
        /// </summary>
        [Parameter]
        [SettingField]
        public string DataCenterUriHostSuffixes { get; set; }

        /// <summary>
        ///  True if the bandwidth throttle is enabled.
        /// </summary>
        [Parameter]
        [SettingField]
        public bool? BandwidthThrottleIsEnabled { get; set; }

        /// <summary>
        /// The usage collection interval in seconds.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? UsageCollectionIntervalInSeconds { get; set; }

        /// <summary>
        /// The retention period for deleted storage accounts in days.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? RetentionPeriodForDeletedStorageAccountsInDays { get; set; }

        /// <summary>
        ///The feedback refresh interval in seconds.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? FeedbackRefreshIntervalInSeconds { get; set; }

        /// <summary>
        /// The number of accounts to synchronize.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? NumberOfAccountsToSync { get; set; }

        /// <summary>
        /// The default throttle probability decay interval in seconds.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? DefaultThrottleProbabilityDecayIntervalInSeconds { get; set; }

        /// <summary>
        /// The grace period for full throttling in refresh intervals.
        /// </summary>
        [Parameter]
        [SettingField]
        public int? GracePeriodForFullThrottlingInRefreshIntervals { get; set; }

        /// <summary>
        /// The grace period maximum throttle probability.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? GracePeriodMaxThrottleProbability { get; set; }

        /// <summary>
        /// The overall request threshold in TPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallRequestThresholdInTps { get; set; }

        /// <summary>
        /// The default request threshold in TPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultRequestThresholdInTps { get; set; }

        /// <summary>
        /// The minimum request threshold in TPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumRequestThresholdInTps { get; set; }

        /// <summary>
        /// The tolerance factor for TPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTps { get; set; }

        /// <summary>
        /// The overall ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The default ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The minimum ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The tolerance factor for ingress.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIngress { get; set; }


        /// <summary>
        /// The overall intranet ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The default intranet ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The minimum intranet ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The tolerance factor for intranet ingress.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIntranetIngress { get; set; }

        /// <summary>
        /// The overall egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The default egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The minimum egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The tolerance factor for egress.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForEgress { get; set; }

        /// <summary>
        /// The overall intranet egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The default intranet egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The minimum intranet egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The tolerance factor for intranet egress.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIntranetEgress { get; set; }

        /// <summary>
        /// The overall total ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The default total ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The minimum total ingress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// The tolerance factor for total ingress.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTotalIngress { get; set; }

        /// <summary>
        /// The overall total egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? OverallTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The default total egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? DefaultTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The minimum total egress threshold in GBPS.
        /// </summary>
        [Parameter]
        [SettingField]
        public double? MinimumTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// The tolerance factor for total egress.
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