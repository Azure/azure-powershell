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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    /// <summary>
    /// Represents an Azure Sql Managed Database
    /// </summary>
    public abstract class AzureSqlManagedDatabaseBaseModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the managed database
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the earliest restore date
        /// </summary>
        public DateTime? EarliestRestorePoint { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the managed database
        /// </summary>
        public string Id { get; set; }
    }
}
