using Microsoft.Azure.Management.Synapse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSelfHostedIntegrationRuntimeStatus : PSSelfHostedIntegrationRuntime
    {
        private readonly SelfHostedIntegrationRuntimeStatus _status;
        private readonly JsonSerializerSettings _deserializerSettings;

        public PSSelfHostedIntegrationRuntimeStatus(
            IntegrationRuntimeResource integrationRuntime,
            SelfHostedIntegrationRuntimeStatus status,
            string resourceGroupName,
            string workspaceName,
            JsonSerializerSettings deserializerSettings)
            : base(integrationRuntime, resourceGroupName, workspaceName)
        {
            _status = status;
            _deserializerSettings = deserializerSettings;
        }

        public string State => _status.State;

        public string Version => _status.Version;

        public DateTime? CreateTime => _status.CreateTime;

        public string AutoUpdate => _status.AutoUpdate;

        public DateTime? ScheduledUpdateDate => _status.ScheduledUpdateDate;

        public TimeSpan? UpdateDelayOffset => ConvertStringTimeSpan(_status.UpdateDelayOffset);

        public TimeSpan? LocalTimeZoneOffset => ConvertStringTimeSpan(_status.LocalTimeZoneOffset);

        public string InternalChannelEncryption => _status.InternalChannelEncryption;

        public IDictionary<string, string> Capabilities => _status.Capabilities;

        public IList<string> ServiceUrls => _status.ServiceUrls;

        public IList<SelfHostedIntegrationRuntimeNode> Nodes => _status.Nodes;

        public IList<LinkedIntegrationRuntime> Links => _status.Links;

        public DateTime? AutoUpdateETA => _status.AutoUpdateETA;

        public string LatestVersion => _status.LatestVersion;

        public string PushedVersion => _status.PushedVersion;

        public string TaskQueueId => _status.TaskQueueId;

        public string VersionStatus => _status.VersionStatus;

        private TimeSpan? ConvertStringTimeSpan(string ts)
        {
            if (string.IsNullOrWhiteSpace(ts))
            {
                return null;
            }

            try
            {
                var definition = new { timeSpan = TimeSpan.FromHours(1) };
                var value = JsonConvert.DeserializeAnonymousType($"{{'timeSpan': '{ts}'}}", definition, _deserializerSettings);
                return value.timeSpan;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
