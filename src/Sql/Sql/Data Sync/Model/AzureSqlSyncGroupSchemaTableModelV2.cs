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
using Microsoft.Azure.Management.Sql.DataSyncV2.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a the table of a sync group schema
    /// </summary>
    public class AzureSqlSyncGroupSchemaTableModelV2
    {
        /// <summary>
        /// Columns in the table
        /// </summary>
        public IList<AzureSqlSyncGroupSchemaColumnModelV2> Columns { get; set; }

        /// <summary>
        /// The quoted table name
        /// </summary>
        public string QuotedName { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncGroupSchemaTableModel
        /// </summary>
        public AzureSqlSyncGroupSchemaTableModelV2()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncGroupSchemaTableModel
        /// </summary>
        /// <param name="table">sync group schema table</param>
        public AzureSqlSyncGroupSchemaTableModelV2(SyncGroupSchemaTable table)
        {
            if (table != null && table.Columns != null)
            {
                Columns = new List<AzureSqlSyncGroupSchemaColumnModelV2>();
                foreach (var column in table.Columns)
                {
                    Columns.Add(new AzureSqlSyncGroupSchemaColumnModelV2(column));
                }
            }
            QuotedName = table != null ? table.QuotedName : null;
        }

        /// <summary>
        /// Convert AzureSqlSyncGroupSchemaTableModel to SyncGroupSchemaTable
        /// </summary>
        /// <returns>The result SyncGroupSchemaTable</returns>
        public SyncGroupSchemaTable ToSyncGroupSchemaTable()
        {
            List<SyncGroupSchemaTableColumn> syncGroupSchemaColumns = null;
            if (Columns != null)
            {
                syncGroupSchemaColumns = new List<SyncGroupSchemaTableColumn>();
                foreach (var column in Columns)
                {
                    syncGroupSchemaColumns.Add(column.ToSyncGroupSchemaColumn());
                }
            }
            return new SyncGroupSchemaTable()
            {
                Columns = syncGroupSchemaColumns,
                QuotedName = this.QuotedName
            };
        }
    }
}
