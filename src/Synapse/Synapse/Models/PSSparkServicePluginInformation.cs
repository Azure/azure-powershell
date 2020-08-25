using Azure.Analytics.Synapse.Spark.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkServicePluginInformation
    {
        public PSSparkServicePluginInformation(SparkServicePlugin pluginInfo)
        {
            this.PreparationStartedAt = pluginInfo?.PreparationStartedAt;
            this.ResourceAcquisitionStartedAt = pluginInfo?.ResourceAcquisitionStartedAt;
            this.SubmissionStartedAt = pluginInfo?.SubmissionStartedAt;
            this.MonitoringStartedAt = pluginInfo?.MonitoringStartedAt;
            this.CleanupStartedAt = pluginInfo?.CleanupStartedAt;
            this.CurrentState = pluginInfo?.CurrentState;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? PreparationStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ResourceAcquisitionStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? SubmissionStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? MonitoringStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? CleanupStartedAt { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Preparation',
        /// 'ResourceAcquisition', 'Queued', 'Submission', 'Monitoring',
        /// 'Cleanup', 'Ended'
        /// </summary>
        public PluginCurrentState? CurrentState { get; set; }
    }
}