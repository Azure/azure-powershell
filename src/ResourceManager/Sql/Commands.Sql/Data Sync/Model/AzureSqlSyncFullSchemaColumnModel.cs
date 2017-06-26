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
    public class AzureSqlSyncFullSchemaColumnModel
    {
        /// <summary>
        /// Gets or sets data size.
        /// </summary>
        public string DataSize { get; set; }

        /// <summary>
        /// Gets or sets data type
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets error id
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has error
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is primary key 
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets quoted name
        /// </summary>
        public string QuotedName { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncFullSchemaColumnModel
        /// </summary>
        public AzureSqlSyncFullSchemaColumnModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncFullSchemaColumnModel
        /// </summary>
        /// <param name="column">data sync full schema column</param>
        public AzureSqlSyncFullSchemaColumnModel(SyncFullSchemaColumn column)
        {
            if (column != null)
            {
                DataSize = column.DataSize.ToString();
                DataType = column.DataType;
                ErrorId = column.ErrorId;
                HasError = column.HasError;
                IsPrimaryKey = column.IsPrimaryKey;
                Name = column.Name;
                QuotedName = column.QuotedName;
            }
        }
    }
}
