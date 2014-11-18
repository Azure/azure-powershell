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
    public class MetricDefinition
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public string PrimaryAggregationType { get; set; }

        [DataMember]
        public List<MetricAvailabilily> MetricAvailabilities { get; set; }

        public MetricDefinition()
        {
            MetricAvailabilities = new List<MetricAvailabilily>();
        }

        public MetricDefinition(string name, string unit, string primaryAggregationType)
            : this()
        {
            Name = name;
            Unit = unit;
            PrimaryAggregationType = primaryAggregationType;
        }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class MetricAvailabilily
    {

        [DataMember]
        public TimeSpan TimeGrain { get; set; }

        [DataMember]
        public TimeSpan Retention { get; set; }

        public MetricAvailabilily()
        {
        }

        public MetricAvailabilily(TimeSpan timeGrain, TimeSpan retention)
        {
            TimeGrain = timeGrain;
            Retention = retention;
        }
    }

    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class MetricDefinitions : List<MetricDefinition>
    {

        public MetricDefinitions()
        {
        }

        public MetricDefinitions(List<MetricDefinition> metricDefinitions)
            : base(metricDefinitions)
        {
        }
    }

}
