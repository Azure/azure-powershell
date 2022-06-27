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
    /// Represents a the column of a sync group schema table
    /// </summary>
    public class AzureSqlSyncGroupSchemaColumnModel
    {
        /// <summary>
        /// The quoted table name
        /// </summary>
        public string QuotedName { get; set; }

        /// <summary>
        /// Gets or sets data size.
        /// </summary>
        public string DataSize { get; set; }

        /// <summary>
        /// Gets or sets data type
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncGroupSchemaColumnModel
        /// </summary>
        public AzureSqlSyncGroupSchemaColumnModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncGroupSchemaColumnModel
        /// </summary>
        /// <param name="column">sync group schema column</param>
        public AzureSqlSyncGroupSchemaColumnModel(SyncGroupSchemaTableColumn column)
        {
            QuotedName = column != null ? column.QuotedName : null;
            DataSize = column != null ? column.DataSize : null;
            DataType = column != null ? column.DataType : null;
        }

        public SyncGroupSchemaTableColumn ToSyncGroupSchemaColumn()
        {
            return new SyncGroupSchemaTableColumn
            {
                DataSize = this.DataSize,
                DataType = this.DataType,
                QuotedName = this.QuotedName
            };
        }
    }
}
