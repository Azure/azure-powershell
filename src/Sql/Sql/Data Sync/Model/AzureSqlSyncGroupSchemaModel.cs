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
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a the schema of a sync group
    /// </summary>
    public class AzureSqlSyncGroupSchemaModel
    {
        /// <summary>
        /// Tables in the database
        /// </summary>
        public IList<AzureSqlSyncGroupSchemaTableModel> Tables { get; set; }

        /// <summary>
        /// Master sync member name
        /// </summary>
        public string MasterSyncMemberName { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncGroupSchemaModel
        /// </summary>
        public AzureSqlSyncGroupSchemaModel()
        {

        }

        public AzureSqlSyncGroupSchemaModel(SyncGroupSchema schema)
        {
            if(schema.Tables != null){
                Tables = new List<AzureSqlSyncGroupSchemaTableModel>();
                foreach(var table in schema.Tables){
                    Tables.Add(new AzureSqlSyncGroupSchemaTableModel(table));
                }
            }
            MasterSyncMemberName = schema.MasterSyncMemberName;
        }

        /// <summary>
        /// Convert AzureSqlSyncGroupSchemaModel to SyncGroupSchema
        /// </summary>
        /// <returns>The result SyncGroupSchema</returns>
        public SyncGroupSchema ToSyncGroupSchema()
        {
            List<SyncGroupSchemaTable> syncGroupSchemaTable = null;
            if (this.Tables != null)
            {
                syncGroupSchemaTable = new List<SyncGroupSchemaTable>();
                foreach (var table in this.Tables)
                {
                    syncGroupSchemaTable.Add(table.ToSyncGroupSchemaTable());
                }
            }
            return new SyncGroupSchema()
            {
                MasterSyncMemberName = this.MasterSyncMemberName,
                Tables = syncGroupSchemaTable
            };
        }
    }
}
