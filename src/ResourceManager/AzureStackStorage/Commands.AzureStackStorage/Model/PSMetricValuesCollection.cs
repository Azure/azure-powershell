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


using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System.Collections.Generic;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    /// Wraps around a list of PSMetricValue objects to display them with indentation
    /// </summary>
    internal class PSMetricValuesCollection
    {
        private IList<MetricValue> metricValues;

        /// <summary>
        /// Initializes a new instance of the PSMetricValuesCollection class
        /// </summary>
        /// <param name="metricValues">The list of metric values</param>
        public PSMetricValuesCollection(IList<MetricValue> metricValues)
        {
            this.metricValues = metricValues;
        }

        /// <summary>
        /// A string representation of the list Dimension objects including indentation
        /// </summary>
        /// <returns>A string representation of the list of Dimension objects including indentation</returns>
        public override string ToString()
        {
            return this.metricValues.ToString(indentationTabs: 1);
        }
    }
}
