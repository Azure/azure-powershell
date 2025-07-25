// ----------------------------------------------------------------------------------
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
using System.Linq;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class CreatePSDataExportParameters : OperationalInsightsParametersBase
    {
        public CreatePSDataExportParameters(string resourceGroupName, string workspaceName, string dataExportName, List<string> tableNames, string destinationResourceId, string eventHubName, bool? enable)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.DataExportName = dataExportName;
            this.TableNames = this.RemoveWhitespace(tableNames);
            this.DestinationResourceId = destinationResourceId;
            this.EventHubName = eventHubName;
            this.Enable = enable;
        }

        /// <summary>
        /// splits by comma and removes leading and trailing whitespaces  
        /// </summary>
        /// <param name="tableNames">list of table names</param>
        /// <returns>A list of table names without empty spaces</returns>
        private List<string> RemoveWhitespace(List<string> tableNames)
        {
            List<string> allTableNames = new List<string>();
            foreach (var tableName in tableNames)
            {
                allTableNames = tableName.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).Union(allTableNames).ToList();
            }

            return allTableNames;
        }

        public string DataExportName { get; set; }
        public List<string> TableNames { get; set; }
        public string DestinationResourceId { get; set; }
        public string EventHubName { get; set; }
        public bool? Enable { get; set; }
    }
}
