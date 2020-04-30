using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Synapse.Models;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkJobInformationBase()
        {
        }

        public PSSynapseSparkJobInformationBase(
            string name,
            string workspaceName,
            string sparkPoolName,
            string submitterName,
            string submitterId,
            string artifactId,
            string jobType,
            string result,
            SchedulerInformation schedulerInfo,
            SparkServicePluginInformation pluginInfo,
            IList<ErrorInformation> errorInfo,
            IDictionary<string, string> tags,
            int? id,
            string appId,
            IDictionary<string, string> appInfo,
            string state,
            IList<string> log)
        {
            this.Name = name;
            this.WorkspaceName = workspaceName;
            this.SparkPoolName = sparkPoolName;
            this.SubmitterName = submitterName;
            this.SubmitterId = submitterId;
            this.ArtifactId = artifactId;
            this.JobType = jobType;
            this.Result = result;
            this.SchedulerInfo = schedulerInfo != null ? new PSSchedulerInformation(schedulerInfo) : null;
            this.PluginInfo = pluginInfo != null ?new PSSparkServicePluginInformation(pluginInfo) : null;
            this.ErrorInfo = errorInfo;
            this.Tags = TagsConversionHelper.CreateTagHashtable(tags);
            this.Id = id;
            this.AppId = appId;
            this.AppInfo = appInfo;
            this.State = state;
            this.Log = log;
        }

        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string WorkspaceName { get; set; }

        /// <summary>
        /// </summary>
        public string SparkPoolName { get; set; }

        /// <summary>
        /// </summary>
        public string SubmitterName { get; set; }

        /// <summary>
        /// </summary>
        public string SubmitterId { get; set; }

        /// <summary>
        /// </summary>
        public string ArtifactId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'SparkBatch', 'SparkSession'
        /// </summary>
        public string JobType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Uncertain', 'Succeeded',
        /// 'Failed', 'Cancelled'
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// </summary>
        public PSSchedulerInformation SchedulerInfo { get; set; }

        /// <summary>
        /// </summary>
        public PSSparkServicePluginInformation PluginInfo { get; set; }

        /// <summary>
        /// </summary>
        public IList<ErrorInformation> ErrorInfo { get; set; }

        /// <summary>
        /// </summary>
        public Hashtable Tags { get; set; }

        public string TagsTable => ResourcesExtensions.ConstructTagsTable(Tags);

        /// <summary>
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// </summary>
        public IDictionary<string, string> AppInfo { get; set; }

        /// <summary>
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// </summary>
        public IList<string> Log { get; set; }
    }
}
