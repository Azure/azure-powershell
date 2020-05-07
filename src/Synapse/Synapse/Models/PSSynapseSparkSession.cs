using Microsoft.Azure.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkSession : PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkSession(ExtendedLivySessionResponse session) : this(null, session)
        {
        }

        public PSSynapseSparkSession(string language, ExtendedLivySessionResponse session) :
            base(session?.Name,
                session?.WorkspaceName,
                session?.SparkPoolName,
                session?.SubmitterName,
                session?.SubmitterId,
                session?.ArtifactId,
                session?.JobType,
                session?.Result,
                session?.SchedulerInfo,
                session?.PluginInfo,
                session?.ErrorInfo,
                session?.Tags,
                session?.Id,
                session?.AppId,
                session?.AppInfo,
                session?.State,
                session?.Log)
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
