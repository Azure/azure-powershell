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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synaspe.Models
{
    /// <summary>
    /// The base class for all Azure Sql pool management cmdlets
    /// </summary>
    public abstract class AzureSynapseSqlPoolManagementCmdletBase<M, A> : AzureSynapseSqlManagementCmdletBase<M, A>
    {
        /// <summary>
        /// Gets or sets the name of the workspace to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public virtual string WorkspaceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the pool to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(ResourceTypes.SqlPool, nameof(ResourceGroupName), nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public virtual string SqlPoolName { get; set; }
    }
}
