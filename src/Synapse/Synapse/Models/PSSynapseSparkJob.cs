using Azure.Analytics.Synapse.Spark.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkJob : PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkJob(SparkBatchJob batchJob) :
            base(batchJob?.Name,
                batchJob?.WorkspaceName,
                batchJob?.SparkPoolName,
                batchJob?.SubmitterName,
                batchJob?.SubmitterId,
                batchJob?.ArtifactId,
                batchJob?.JobType,
                batchJob?.Result.ToString(),
                batchJob?.Scheduler,
                batchJob?.Plugin,
                batchJob?.Errors,
                batchJob?.Tags.ToDictionary(kvp=>kvp.Key, kvp=>kvp.Value),
                batchJob?.Id,
                batchJob?.AppId,
                batchJob?.AppInfo,
                batchJob?.State,
                batchJob?.LogLines)
        {
            this.LivyInfo = batchJob?.LivyInfo != null ? new PSLivyBatchStateInformation(batchJob?.LivyInfo) : null;
        }

        /// <summary>
        /// </summary>
        public PSLivyBatchStateInformation LivyInfo { get; set; }
    }
}
