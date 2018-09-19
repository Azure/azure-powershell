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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class MetricSet
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public string TimeGrain { get; set; }

        [DataMember]
        public string PrimaryAggregationType { get; set; }

        [DataMember]
        public List<MetricSample> Values { get; set; }

        public MetricSet()
        {
            Values = new List<MetricSample>();
        }

        public MetricSet(string name, string units, DateTime startTime, DateTime endTime, string timeGrain, string primaryAggregationType)
            : this()
        {
            Name = name;
            Unit = units;
            StartTime = startTime;
            EndTime = endTime;
            TimeGrain = timeGrain;
            PrimaryAggregationType = primaryAggregationType;
        }

    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class MetricSample
    {

        [DataMember]
        public DateTime TimeCreated { get; set; }

        [DataMember]
        public long? Total { get; set; }

        [DataMember]
        public long? Minimum { get; set; }

        [DataMember]
        public long? Maximum { get; set; }

        [DataMember]
        public long? Count { get; set; }

        [DataMember]
        public string InstanceName { get; set; }

        public MetricSample()
        {
        }

        public MetricSample(long total, DateTime timeCreated)
        {
            Total = total;
            TimeCreated = timeCreated;
            Count = 1;
        }

        public override string ToString()
        {
            return string.Format("Time:{0}, Total:{1}, Min:{2}, Max:{3}", TimeCreated, Total, Minimum, Maximum);
        }
    }

    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class MetricSets : List<MetricSet>
    {
        public MetricSets()
        {
        }

        public MetricSets(List<MetricSet> metricSets)
            : base(metricSets)
        {
        }
    }
}
