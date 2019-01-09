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
using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a the full schema of member database of a sync member
    /// </summary>
    public class AzureSqlSyncFullSchemaModel
    {
        /// <summary>
        /// Tables in the database
        /// </summary>
        public IList<AzureSqlSyncFullSchemaTableModel> Tables { get; set; }

        /// <summary>
        /// Last Update time of this schema
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncFullSchemaModel
        /// </summary>
        public AzureSqlSyncFullSchemaModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncFullSchemaModel
        /// </summary>
        /// <param name="schema">sync full schema</param>
        public AzureSqlSyncFullSchemaModel(SyncFullSchema schema)
        {
            if (schema != null)
            {
                if (schema.Tables != null)
                {
                    Tables = new List<AzureSqlSyncFullSchemaTableModel>();
                    foreach (var table in schema.Tables)
                    {
                        Tables.Add(new AzureSqlSyncFullSchemaTableModel(table));
                    }
                }
                LastUpdateTime = schema.LastUpdateTime;
            }
        }
    }
}
