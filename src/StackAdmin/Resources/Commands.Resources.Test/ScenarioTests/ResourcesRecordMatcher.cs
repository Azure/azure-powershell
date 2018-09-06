using System.Collections.Generic;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ResourcesRecordMatcher : PermissiveRecordMatcherWithApiExclusion
    {
        public ResourcesRecordMatcher(bool ignoreResourcesClient, Dictionary<string, string> providers) : base(ignoreResourcesClient, providers)
        {
        }

        public ResourcesRecordMatcher(bool ignoreResourcesClient, Dictionary<string, string> providers, Dictionary<string, string> userAgents)
            : base(ignoreResourcesClient, providers, userAgents)
        {
        }

        private const string RetryAfterHeader = "Retry-After";
        private static readonly List<string> RetryAfterValue = new List<string> {"0"};

        public override string GetMatchingKey(RecordEntry recordEntry)
        {
            if (recordEntry.ResponseHeaders.ContainsKey(RetryAfterHeader))
            {
                recordEntry.ResponseHeaders.Remove(RetryAfterHeader);
            }
            recordEntry.ResponseHeaders.Add(RetryAfterHeader, RetryAfterValue);
            return base.GetMatchingKey(recordEntry);
        }
    }
}
