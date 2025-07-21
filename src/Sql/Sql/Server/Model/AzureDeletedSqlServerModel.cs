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
using System.Security;

namespace Microsoft.Azure.Commands.Sql.Server.Model
{
    /// <summary>
    /// Represents the core properties of a deleted Azure Sql Server
    /// </summary>
    public class AzureDeletedSqlServerModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group the server is in
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the location the server is in
        /// </summary>
        public string Location { get; set; }
    }
}
