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
using System.Xml;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSUsageMetric
    {
        public PSUsageMetric()
        {
        }

        public PSUsageMetric(UsageMetric metric)
        {
            if (metric == null)
            {
                throw new ArgumentNullException("metric");
            }

            if (metric.Name != null)
            {
                this.Id = metric.Name.Value;
                this.Name = metric.Name.LocalizedValue;
            }

            this.CurrentValue = metric.CurrentValue;
            this.Limit = metric.Limit;
            this.NextResetTime = metric.NextResetTime;
            this.Unit = metric.Unit;
            this.QuotaPeriod = !string.IsNullOrWhiteSpace(metric.QuotaPeriod) ? XmlConvert.ToTimeSpan(metric.QuotaPeriod) : TimeSpan.Zero;
        }

        public double CurrentValue { get; set; }

        public double Limit { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime? NextResetTime { get; set; }

        public TimeSpan QuotaPeriod { get; set; }

        public string Unit { get; set; }
    }
}