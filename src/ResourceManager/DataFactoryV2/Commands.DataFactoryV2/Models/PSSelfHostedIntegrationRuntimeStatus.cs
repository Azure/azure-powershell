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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSSelfHostedIntegrationRuntimeStatus : PSSelfHostedIntegrationRuntime
    {
        private readonly SelfHostedIntegrationRuntimeStatus _status;
        private readonly JsonSerializerSettings _deserializerSettings;

        public PSSelfHostedIntegrationRuntimeStatus(
            IntegrationRuntimeResource integrationRuntime,
            SelfHostedIntegrationRuntimeStatus status,
            string resourceGroupName,
            string factoryName,
            JsonSerializerSettings deserializerSettings)
            : base(integrationRuntime, resourceGroupName, factoryName)
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
