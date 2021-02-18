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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
<<<<<<< HEAD
    /// Wrapps around the Metric and exposes a summary of the properties properties
=======
    /// Wraps around the Metric and exposes a summary of the property's properties
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    /// </summary>
    public class PSMetricNoDetails : PSMetric
    {
        /// <summary>
        /// Initializes a new instance of the PSMetric class.
        /// </summary>
        /// <param name="metric">The input Metric object</param>
        public PSMetricNoDetails(Metric metric)
            : base(metric)
        {
            this.Name = new PSLocalizableStringNoDetails(metric.Name);
        }
    }
}
