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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.Server.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    public abstract class AzureSqlDeletedServerCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlDeletedServerModel>, AzureSqlDeletedServerAdapter>
    {
        /// <summary>
        /// Override ResourceGroupName to make it non-mandatory for deleted servers
        /// Deleted servers are retrieved by location, not by resource group
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group. Not required for deleted server operations.")]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Initializes the model adapter
        /// </summary>
        /// <returns>The deleted server adapter</returns>
        protected override AzureSqlDeletedServerAdapter InitModelAdapter()
        {
            return new AzureSqlDeletedServerAdapter(DefaultContext);
        }
    }
}