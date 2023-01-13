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

using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSAggregatedCounts
    {
        /// <summary>
        /// Gets the Content of the object
        /// </summary>
        public IList<AlertsSummaryGroupItem> Content { get; private set; }

        /// <summary>
        /// Initializes a new instance of the PSDictionaryElement class.
        /// </summary>
        /// <param name="content"></param>
        public PSAggregatedCounts(IList<AlertsSummaryGroupItem> content)
        {
            this.Content = content;
        }

        /// <summary>
        /// A string representation of the contained dictionary
        /// </summary>
        /// <returns>A string representation of the contained dictionary</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            if (this.Content != null && this.Content.Count > 0)
            {
                foreach (var item in this.Content)
                {
                    output.Append(string.Format("{0} - {1}", item.Name, item.Count));

                    if (!string.IsNullOrWhiteSpace(item.Groupedby))
                    {
                        output.Append(string.Format(" : Further grouped by {0}", item.Groupedby));

                        foreach (var aggregation in item.Values)
                        {
                            output.AppendLine();
                            output.Append(string.Format("{0} - {1}", aggregation.Name, aggregation.Count));
                        }

                        output.AppendLine();
                    }

                    output.AppendLine();
                }
            }

            return output.ToString();
        }
    }
}
