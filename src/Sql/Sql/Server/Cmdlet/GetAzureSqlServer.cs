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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServer cmdlet
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServer", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlServerModel))]
    public class GetAzureSqlServer : AzureSqlServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database server name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ServerName { get; set; }
        
        /// <summary>
        /// Gets a server from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlServerModel> GetEntity()
        {
            ICollection<AzureSqlServerModel> results = null;

            if (ShouldGetByName(ResourceGroupName, ServerName))
            {
                results = new List<AzureSqlServerModel>();
                results.Add(ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName));
            }
            else if (ShouldListByResourceGroup(ResourceGroupName, ServerName))
            {
                results = ModelAdapter.ListServersByResourceGroup(this.ResourceGroupName);
            }
            else
            {
                results = ModelAdapter.ListServers();
            }

            return TopLevelWildcardFilter(ResourceGroupName, ServerName, results);
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerModel> PersistChanges(IEnumerable<AzureSqlServerModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlServerModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerModel> model)
        {
            return model;
        }
    }
}
