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

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// Show azure storage service properties
    /// </summary>
    [Cmdlet(VerbsCommon.Set, StorageNouns.StorageServiceMetrics),
        OutputType(typeof(MetricsProperties))]
    public class SetAzureStorageServiceMetricsCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = GetAzureStorageServiceLoggingCommand.ServiceTypeHelpMessage)]
        public StorageServiceType ServiceType { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Azure storage service metrics type(Hour, Minute).")]
        public ServiceMetricsType MetricsType { get; set; }

        [Parameter(HelpMessage = "Metrics version")]
        public double? Version { get; set; }

        [Parameter(HelpMessage = "Metrics retention days. -1 means disable Metrics retention policy, otherwise enable.")]
        [ValidateRange(-1, 365)]
        public int? RetentionDays { get; set; }

        [Parameter(HelpMessage = "Metrics level.(None/Service/ServiceAndApi)")]
        public MetricsLevel? MetricsLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display ServiceProperties")]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        public SetAzureStorageServiceMetricsCommand()
        {
            EnableMultiThread = false;
        }

        /// <summary>
        /// Update the specified service properties according to the input
        /// </summary>
        /// <param name="serviceProperties">Service properties</param>
        internal void UpdateServiceProperties(MetricsProperties metrics)
        {
            if (Version != null)
            {
                metrics.Version = Version.ToString();
            }

            if (RetentionDays != null)
            {
                if (RetentionDays == -1)
                {
                    //Disable metrics retention policy
                    metrics.RetentionDays = null;
                }
                else if (RetentionDays < 1 || RetentionDays > 365)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidRetentionDay, RetentionDays));
                }
                else
                {
                    metrics.RetentionDays = RetentionDays;
                }
            }

            if (MetricsLevel != null)
            {
                MetricsLevel metricsLevel = MetricsLevel.Value;
                metrics.MetricsLevel = metricsLevel;
                // Set default metrics version
                if (string.IsNullOrEmpty(metrics.Version))
                {
                    string defaultMetricsVersion = StorageNouns.DefaultMetricsVersion;
                    metrics.Version = defaultMetricsVersion;
                }
            }
        }

        /// <summary>
        /// Get metrics level
        /// </summary>
        /// <param name="MetricsLevel">The string type of Metrics level</param>
        /// <example>GetMetricsLevel("None"), GetMetricsLevel("Service")</example>
        /// <returns>MetricsLevel object</returns>
        internal MetricsLevel GetMetricsLevel(string MetricsLevel)
        {
            try
            {
                return (MetricsLevel)Enum.Parse(typeof(MetricsLevel), MetricsLevel, true);
            }
            catch
            {
                throw new ArgumentException(String.Format(Resources.InvalidEnumName, MetricsLevel));
            }
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            ServiceProperties currentServiceProperties = Channel.GetStorageServiceProperties(ServiceType, GetRequestOptions(ServiceType), OperationContext);
            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Clean();

            bool isHourMetrics = false;

            switch (MetricsType)
            {
                case ServiceMetricsType.Hour:
                    serviceProperties.HourMetrics = currentServiceProperties.HourMetrics;
                    UpdateServiceProperties(serviceProperties.HourMetrics);
                    isHourMetrics = true;
                    break;
                case ServiceMetricsType.Minute:
                    serviceProperties.MinuteMetrics = currentServiceProperties.MinuteMetrics;
                    UpdateServiceProperties(serviceProperties.MinuteMetrics);
                    isHourMetrics = false;
                    break;
            }

            Channel.SetStorageServiceProperties(ServiceType, serviceProperties,
                GetRequestOptions(ServiceType), OperationContext);

            if (PassThru)
            {
                if (isHourMetrics)
                {
                    WriteObject(serviceProperties.HourMetrics);
                }
                else
                {
                    WriteObject(serviceProperties.MinuteMetrics);
                }
            }
        }
    }
}
