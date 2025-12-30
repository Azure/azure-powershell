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

using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Server.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Deleted Server
    /// </summary>
    public class AzureSqlDeletedServerModel
    {
        /// <summary>
        /// Gets or sets the name of the deleted server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the deletion time of the server
        /// </summary>
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified domain name of the deleted server
        /// </summary>
        public string FullyQualifiedDomainName { get; set; }

        /// <summary>
        /// Gets or sets the server version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the deleted server
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the original resource ID of the server before deletion
        /// </summary>
        public string OriginalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group the server was in (extracted from OriginalId)
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the subscription id where the server was located (extracted from OriginalId)
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}