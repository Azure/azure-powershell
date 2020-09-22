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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Model;
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Services;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Cmdlet
{
    public abstract class AzureSqlServerActiveDirectoryOnlyAuthenticationCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlServerActiveDirectoryOnlyAuthenticationModel>, AzureSqlServerActiveDirectoryOnlyAuthenticationAdapter>
    {
        protected const string UseInputObjectParameterSet = "UseInputObjectParameterSet";
        protected const string UseResourceGroupAndServerNameParameterSet = "UseResourceGroupAndServerNameParameterSet";
        protected const string UserResourceIdParameterSet = "UserResourceIdParameterSet";

        /// <summary>
        /// Server resource
        /// </summary>
        [Parameter(ParameterSetName = UseInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SQL server object to use.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlServerModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the instance
        /// </summary>
        [Parameter(ParameterSetName = UserResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of instance to use")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = UseResourceGroupAndServerNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the SQL Server to use.
        /// </summary>
        [Parameter(ParameterSetName = UseResourceGroupAndServerNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Server name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        protected string GetResourceGroupName()
        {
            if (string.Equals(this.ParameterSetName, UseInputObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                return InputObject.ResourceGroupName;
            }
            else if (string.Equals(this.ParameterSetName, UserResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                return resourceInfo.ResourceGroupName;
            }

            return ResourceGroupName;
        }

        protected string GetServerName()
        {
            if (string.Equals(this.ParameterSetName, UseInputObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                return InputObject.ServerName;
            }
            else if (string.Equals(this.ParameterSetName, UserResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                return resourceInfo.ResourceName;
            }

            return ServerName;
        }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlServerActiveDirectoryOnlyAuthenticationAdapter InitModelAdapter()
        {
            return new AzureSqlServerActiveDirectoryOnlyAuthenticationAdapter(DefaultProfile.DefaultContext);
        }
    }
}
