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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSearchMetadata
    {
        public PSSearchMetadata()
        {
        }

        public PSSearchMetadata(SearchMetadata metadata)
        {
            if (metadata != null)
            {
                this.ResultType = metadata.ResultType;
                this.Top = metadata.Top;
                this.Total = metadata.Total;
                this.Id = metadata.Id;
                List<PSCoreSummary> summaryList = new List<PSCoreSummary>();
                if (metadata.CoreSummaries != null)
                {
                    for (int i = 0; i < metadata.CoreSummaries.Count; i++)
                    {
                        summaryList.Add(new PSCoreSummary(metadata.CoreSummaries[i]));
                    }
                }
                this.CoreSummaries = summaryList;
                this.Status = metadata.Status;
                this.StartTime = metadata.StartTime;
                this.LastUpdated = metadata.LastUpdated;
                this.ETag = metadata.ETag;
                List<PSSearchSort> sortList = new List<PSSearchSort>();
                if (metadata.Sort != null)
                {
                    for (int j = 0; j < metadata.Sort.Count; j++)
                    {
                        sortList.Add(new PSSearchSort(metadata.Sort[j]));
                    }
                }
                this.Sort = sortList;
                this.RequestTime = metadata.RequestTime;
                this.AggregatedValueField = metadata.AggregatedValueField;
                this.AggregatedGroupingFields = metadata.AggregatedGroupingFields;
                this.Sum = metadata.Sum;
                this.Max = metadata.Max;
                this.Schema = new PSMetadataSchema(metadata.Schema);
            }
        }
        public string ResultType { get; set; }
        public long? Total { get; set; }
        public long? Top { get; set; }
        public Guid? Id { get; set; }
        public IEnumerable<object> CoreResponses { get; set; }
        public List<PSCoreSummary> CoreSummaries { get; set; }
        public string Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string ETag { get; set; }
        public List<PSSearchSort> Sort { get; set; }
        public long? RequestTime { get; set; }
        public string AggregatedValueField { get; set; }
        public string AggregatedGroupingFields { get; set; }
        public long? Sum { get; set; }
        public long? Max { get; set; }
        public PSMetadataSchema Schema { get; set; }
    }
}
