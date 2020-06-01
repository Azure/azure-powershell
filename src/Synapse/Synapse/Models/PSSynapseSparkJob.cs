using Microsoft.Azure.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkJob : PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkJob(ExtendedLivyBatchResponse batchJob) :
            base(batchJob?.Name,
                batchJob?.WorkspaceName,
                batchJob?.SparkPoolName,
                batchJob?.SubmitterName,
                batchJob?.SubmitterId,
                batchJob?.ArtifactId,
                batchJob?.JobType,
                batchJob?.Result,
                batchJob?.SchedulerInfo,
                batchJob?.PluginInfo,
                batchJob?.ErrorInfo,
                batchJob?.Tags,
                batchJob?.Id,
                batchJob?.AppId,
                batchJob?.AppInfo,
                batchJob?.State,
                batchJob?.Log)
        {
            this.LivyInfo = batchJob?.LivyInfo != null ? new PSLivyBatchStateInformation(batchJob?.LivyInfo) : null;
        }

        /// <summary>
        /// </summary>
        public PSLivyBatchStateInformation LivyInfo { get; set; }
    }
}
