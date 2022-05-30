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
using System.Linq;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSTable : OperationalInsightsParametersBase
    {
        public string TableName { get; set; }

        public string Id { set; get; }

        public int? RetentionInDays { get; set; }

        public int? TotalRetentionInDays { get; set; }

        public string Plan { get; set; }

        public string Description { get; set; }

        public IList<Column> Columns { get; set; }

        public PSTable()
        {

        }

        public PSTable(Table table)
        {
            this.TableName = table.Name;
            this.Id = table.Id;
            this.RetentionInDays = table.RetentionInDays;
            this.TotalRetentionInDays = table.TotalRetentionInDays;
            this.Plan = table.Plan;
            this.Description = table.Schema.Description;
            this.Columns = (List<Column>)table.Schema.Columns;// TODO dabenham check values are assertted corectly
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
            this.Id = id;
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

            this.Columns = cols;
        }

        /// <summary>
        /// Creates a Table object for create or update flow
        /// </summary>
        /// <returns>The payload for Create or Update table</returns>
        public virtual Table ToTableProperties()
        {
            return new Table(
                name: TableName,
                plan: Plan,
                retentionInDays: RetentionInDays,
                totalRetentionInDays: TotalRetentionInDays,
                schema: new Schema(description: Description, columns: Columns));
        }

    }
}
