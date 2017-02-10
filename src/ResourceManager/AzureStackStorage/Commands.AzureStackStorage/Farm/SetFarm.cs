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
        /// Gets or sets the settings polling interval in second.
        /// </summary>
        /// <value>
        /// The settings polling interval in second.
        /// </value>
        [Parameter]
        [SettingField]
        public int? SettingsPollingIntervalInSecond { get; set; }

        /// <summary>
        /// Gets or sets the host style HTTP port.
        /// </summary>
        /// <value>
        /// The host style HTTP port.
        /// </value>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpPort { get; set; }

        /// <summary>
        /// Gets or sets the host style HTTPS port.
        /// </summary>
        /// <value>
        /// The host style HTTPS port.
        /// </value>
        [Parameter]
        [SettingField]
        public int? HostStyleHttpsPort { get; set; }

        /// <summary>
        /// Gets or sets the CORS allowed origins list for the Farm.
        /// </summary>
        /// <value>
        /// The cors allowed origins list.
        /// </value>
        [Parameter]
        [SettingField]
        public string CorsAllowedOriginsList { get; set; }

        /// <summary>
        /// Gets or sets the host suffixes of data center URI.
        /// </summary>
        /// <value>
        /// The data center URI host suffixes.
        /// </value>
        [Parameter]
        [SettingField]
        public string DataCenterUriHostSuffixes { get; set; }

        /// <summary>
        /// Gets or sets the indicator of whether enabled bandwidth throttling.
        /// </summary>
        /// <value>
        /// True if the bandwidth throttle is enabled.
        /// </value>
        [Parameter]
        [SettingField]
        public bool? BandwidthThrottleIsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the usage collection interval in seconds.
        /// </summary>
        /// <value>
        /// The usage collection interval in seconds.
        /// </value>
        [Parameter]
        [SettingField]
        public int? UsageCollectionIntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the retention period for deleted storage accounts in days.
        /// </summary>
        /// <value>
        /// The retention period for deleted storage accounts in days.
        /// </value>
        [Parameter]
        [SettingField]
        public int? RetentionPeriodForDeletedStorageAccountsInDays { get; set; }

        /// <summary>
        /// Gets or sets the feedback refresh interval in seconds.
        /// </summary>
        /// <value>
        /// The feedback refresh interval in seconds.
        /// </value>
        [Parameter]
        [SettingField]
        public int? FeedbackRefreshIntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the number of accounts to synchronize.
        /// </summary>
        /// <value>
        /// The number of accounts to synchronize.
        /// </value>
        [Parameter]
        [SettingField]
        public int? NumberOfAccountsToSync { get; set; }

        /// <summary>
        /// Gets or sets the default throttle probability decay interval in seconds.
        /// </summary>
        /// <value>
        /// The default throttle probability decay interval in seconds.
        /// </value>
        [Parameter]
        [SettingField]
        public int? DefaultThrottleProbabilityDecayIntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the grace period for full throttling in refresh intervals.
        /// </summary>
        /// <value>
        /// The grace period for full throttling in refresh intervals.
        /// </value>
        [Parameter]
        [SettingField]
        public int? GracePeriodForFullThrottlingInRefreshIntervals { get; set; }

        /// <summary>
        /// Gets or sets the grace period maximum throttle probability.
        /// </summary>
        /// <value>
        /// The grace period maximum throttle probability.
        /// </value>
        [Parameter]
        [SettingField]
        public double? GracePeriodMaxThrottleProbability { get; set; }

        /// <summary>
        /// Gets or sets the overall request threshold in TPS.
        /// </summary>
        /// <value>
        /// The overall request threshold in TPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallRequestThresholdInTps { get; set; }

        /// <summary>
        /// Gets or sets the default request threshold in TPS.
        /// </summary>
        /// <value>
        /// The default request threshold in TPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultRequestThresholdInTps { get; set; }

        /// <summary>
        /// Gets or sets the minimum request threshold in TPS.
        /// </summary>
        /// <value>
        /// The minimum request threshold in TPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumRequestThresholdInTps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for TPS.
        /// </summary>
        /// <value>
        /// The tolerance factor for TPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTps { get; set; }

        /// <summary>
        /// Gets or sets the overall ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The overall ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the default ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The default ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the minimum ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The minimum ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for ingress.
        /// </summary>
        /// <value>
        /// The tolerance factor for ingress.
        /// </value>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIngress { get; set; }


        /// <summary>
        /// Gets or sets the overall intranet ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The overall intranet ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the default intranet ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The default intranet ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the minimum intranet ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The minimum intranet ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumIntranetIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for intranet ingress.
        /// </summary>
        /// <value>
        /// The tolerance factor for intranet ingress.
        /// </value>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIntranetIngress { get; set; }

        /// <summary>
        /// Gets or sets the overall egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The overall egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the default egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The default egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the minimum egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The minimum egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for egress.
        /// </summary>
        /// <value>
        /// The tolerance factor for egress.
        /// </value>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForEgress { get; set; }

        /// <summary>
        /// Gets or sets the overall intranet egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The overall intranet egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the default intranet egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The default intranet egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the minimum intranet egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The minimum intranet egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumIntranetEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for intranet egress.
        /// </summary>
        /// <value>
        /// The tolerance factor for intranet egress.
        /// </value>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForIntranetEgress { get; set; }

        /// <summary>
        /// Gets or sets the overall total ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The overall total ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the default total ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The default total ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the minimum total ingress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The minimum total ingress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumTotalIngressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for total ingress.
        /// </summary>
        /// <value>
        /// The tolerance factor for total ingress.
        /// </value>
        [Parameter]
        [SettingField]
        public double? ToleranceFactorForTotalIngress { get; set; }

        /// <summary>
        /// Gets or sets the overall total egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The overall total egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? OverallTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the default total egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The default total egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? DefaultTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the minimum total egress threshold in GBPS.
        /// </summary>
        /// <value>
        /// The minimum total egress threshold in GBPS.
        /// </value>
        [Parameter]
        [SettingField]
        public double? MinimumTotalEgressThresholdInGbps { get; set; }

        /// <summary>
        /// Gets or sets the tolerance factor for total egress.
        /// </summary>
        /// <value>
        /// The tolerance factor for total egress.
        /// </value>
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