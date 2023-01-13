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
// --------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx.Recorder;

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
