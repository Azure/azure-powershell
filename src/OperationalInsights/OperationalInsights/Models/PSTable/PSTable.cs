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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Management.Automation;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSTable : OperationalInsightsParametersBase
    {
        public string TableName { get; set; }

        public string ResourceId { set; get; }

        public int? RetentionInDays { get; set; }

        public int? TotalRetentionInDays { get; set; }

        public string Plan { get; set; }

        public string Description { get; set; }

        public Schema Schema { get; set; }

        public string ProvisioningState { get; set; }

        public PSTable()
        {

        }

        /// <summary>
        /// Creates a PS Table object that is same as response contract
        /// </summary>
        /// <param name="table"></param>
        public PSTable(Table table, string resourceGroupName, string workspaceName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.TableName = table.Name;
            this.ResourceId = table.Id;
            this.ProvisioningState = table.ProvisioningState;
            this.RetentionInDays = table.RetentionInDays;
            this.TotalRetentionInDays = table.TotalRetentionInDays;
            this.Plan = table.Plan;
            this.Schema = table.Schema;
            this.Description = table.Schema?.Description;
        }

        public PSTable(
            string resourceGroupName,
            string workspaceName,
            string tableName,
            string id,
            int? retentionInDays,
            int? totalRetentionInDays,
            string plan,
            string description,
            Hashtable columns
            )
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.TableName = tableName;
            this.ResourceId = id;
            this.RetentionInDays = retentionInDays;
            this.TotalRetentionInDays = totalRetentionInDays;
            this.Plan = plan;
            this.Description = description;

            IList<Column> cols = new List<Column>();
            foreach (DictionaryEntry entry in columns)
            {
                if (string.IsNullOrEmpty((string)entry.Key) || string.IsNullOrEmpty((string)entry.Value))
                {
                    throw new PSArgumentException($"Invalid values passed as Columns, please use: {Constants.ColumnsExample}.");
                }

                cols.Add(new Column(name: (string)entry.Key, type: (string)entry.Value));
            }

            this.Schema = new Schema(columns: cols);
        }

        /// <summary>
        /// Creates a Table object for create or update flow
        /// </summary>
        /// <returns>The payload for Create or Update table</returns>
        public virtual Table ToTableProperties()
        {
            return new Table(
                name: this.TableName,
                plan: this.Plan,
                retentionInDays: this.RetentionInDays,
                totalRetentionInDays: this.TotalRetentionInDays,
                schema: new Schema(name: this.TableName, description: this.Description, columns: this.Schema.Columns));
        }

    }
}
