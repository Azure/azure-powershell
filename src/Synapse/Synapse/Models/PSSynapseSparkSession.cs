using Azure.Analytics.Synapse.Spark.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkSession : PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkSession(SparkSession session) : this(null, session)
        {
        }

        public PSSynapseSparkSession(string language, SparkSession session) :
            base(session?.Name,
                session?.WorkspaceName,
                session?.SparkPoolName,
                session?.SubmitterName,
                session?.SubmitterId,
                session?.ArtifactId,
                session?.JobType,
                session?.Result.ToString(),
                session?.Scheduler,
                session?.Plugin,
                session?.Errors,
                session?.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                session?.Id,
                session?.AppId,
                session?.AppInfo,
                session?.State,
                session?.LogLines)
        {
            this.Language = language;
            this.LivyInfo = session?.LivyInfo != null ? new PSLivySessionStateInformation(session?.LivyInfo) : null;
        }

        /// <summary>
        /// </summary>
        public PSLivySessionStateInformation LivyInfo { get; set; }

        public string Language { get; set; }
    }
}
