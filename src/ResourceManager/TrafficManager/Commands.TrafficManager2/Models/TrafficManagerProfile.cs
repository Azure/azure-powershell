﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Commands.TrafficManager.Utilities;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TrafficManagerProfile
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string RelativeDnsName { get; set; }

        public uint Ttl { get; set; }

        public string ProfileStatus { get; set; }

        public string TrafficRoutingMethod { get; set; }

        public string MonitorProtocol { get; set; }

        public uint MonitorPort { get; set; }

        public string MonitorPath { get; set; }

        public int? MonitorIntervalInSeconds { get; set; }

        public int? MonitorTimeoutInSeconds { get; set; }

        public int? MonitorToleratedNumberOfFailures { get; set; }

        public long? MaxReturn { get; set; }

        public List<TrafficManagerEndpoint> Endpoints { get; set; }

        public List<TrafficManagerCustomHeader> CustomHeaders { get; set; }

        public List<TrafficManagerExpectedStatusCodeRange> ExpectedStatusCodeRanges { get; set; }

        public Hashtable Tags { get; set; }

        public Profile ToSDKProfile()
        {
            var tags = TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true);

            var profile = new Profile(
                this.Id,
                this.Name,
                Constants.ProfileType,
                tags,
                TrafficManagerClient.ProfileResourceLocation)
            {
                ProfileStatus = this.ProfileStatus,
                TrafficRoutingMethod = this.TrafficRoutingMethod,
                MaxReturn = this.MaxReturn,
                DnsConfig = new DnsConfig
                {
                    RelativeName = this.RelativeDnsName,
                    Ttl = this.Ttl
                },
                MonitorConfig = new MonitorConfig
                {
                    Protocol = this.MonitorProtocol,
                    Port = this.MonitorPort,
                    Path = this.MonitorPath,
                    IntervalInSeconds = this.MonitorIntervalInSeconds,
                    TimeoutInSeconds = this.MonitorTimeoutInSeconds,
                    ToleratedNumberOfFailures = this.MonitorToleratedNumberOfFailures,
                    CustomHeaders = this.CustomHeaders?.Select(
                        customHeader => customHeader.ToSDKMonitorConfigCustomHeadersItem()).ToList(),
                    ExpectedStatusCodeRanges = this.ExpectedStatusCodeRanges?.Select(
                        expectedStatusCodeRange => expectedStatusCodeRange.ToSDKMonitorConfigStatusCodeRangesItem()).ToList()
                }
            };

            if (this.Endpoints != null && this.Endpoints.Any())
            {
                profile.Endpoints = this.Endpoints.Select(endpoint => endpoint.ToSDKEndpoint()).ToList();
            }

            return profile;
        }
    }
}
