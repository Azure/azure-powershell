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

namespace Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Model
{
    /// <summary>
    /// Represents a recommended elastic pool metric
    /// </summary>
    public class AzureSqlElasticPoolRecommendationMetricModel
    {
        /// <summary>
        /// Gets or sets the time of metric.
        /// </summary>
        public DateTime DateTime { get; set; }
        
        /// <summary>
        /// Gets or sets the DTU.
        /// </summary>
        public double Dtu { get; set; }

        /// <summary>
        /// Gets or sets size in gigabytes.
        /// </summary>
        public double SizeGB { get; set; }
    }
}
