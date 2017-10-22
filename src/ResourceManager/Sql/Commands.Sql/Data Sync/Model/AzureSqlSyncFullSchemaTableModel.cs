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
    public class AzureSqlSyncFullSchemaTableModel
    {
        /// <summary>
        /// Columns in the database table
        /// </summary>
        public IList<AzureSqlSyncFullSchemaColumnModel> Columns { get; set; }

        /// <summary>
        /// Gets or sets error id
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has error
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets quoted name
        /// </summary>
        public string QuotedName { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncFullSchemaTableModel
        /// </summary>
        public AzureSqlSyncFullSchemaTableModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncFullSchemaTableModel
        /// </summary>
        /// <param name="table">Sync full schema table</param>
        public AzureSqlSyncFullSchemaTableModel(SyncFullSchemaTable table)
        {
            if (table != null)
            {
                if (table.Columns != null)
                {
                    Columns = new List<AzureSqlSyncFullSchemaColumnModel>();
                    foreach (var column in table.Columns)
                    {
                        Columns.Add(new AzureSqlSyncFullSchemaColumnModel(column));
                    }
                }
                ErrorId = table.ErrorId;
                HasError = table.HasError;
                Name = table.Name;
                QuotedName = table.QuotedName;
            }
        }
    }
}
