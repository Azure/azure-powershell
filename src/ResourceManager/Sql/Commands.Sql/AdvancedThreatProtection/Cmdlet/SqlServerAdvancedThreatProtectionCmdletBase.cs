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

using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using Microsoft.Azure.Commands.Sql.Server.Model;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql server Advanced Threat Protection Cmdlets
    /// </summary>
    public abstract class SqlServerAdvancedThreatProtectionCmdletBase : AzureSqlCmdletBase<ServerAdvancedThreatProtectionPolicyModel, SqlAdvancedThreatProtectionAdapter>
    {
        protected const string UseParentResourceParameterSet = "UseParentResourceParameterSet";
        protected const string UseResourceIdParameterSet = "UseResourceIdParameterSet";
        protected const string UseExplicitArgumentsParameterSet = "UseExplicitArgumentsParameterSet";

        /// <summary>
        /// Server resource
        /// </summary>
        [Parameter(ParameterSetName = UseParentResourceParameterSet,
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The server object to use with Advanced Threat Protection policy operation ")]
        [ValidateNotNullOrEmpty]
        public AzureSqlServerModel InputObject { get; set; }

        /// <summary>
        /// Advanced Threat Protection resource Id
        /// </summary>
        [Parameter(ParameterSetName = UseResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The resource id of a Advanced Threat Protection (e.g. /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/resourceGroups01/providers/Microsoft.Sql/servers/server01/advancedThreatProtection/default.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(ParameterSetName = UseExplicitArgumentsParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override ServerAdvancedThreatProtectionPolicyModel GetEntity()
        {
            string resourceGroupName = ResourceGroupName;
            string serverName = ServerName;

            if (string.Equals(this.ParameterSetName, UseParentResourceParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                resourceGroupName = InputObject.ResourceGroupName;
                serverName = InputObject.ServerName;
            }
            else if (string.Equals(this.ParameterSetName, UseResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                resourceGroupName = resourceInfo.ResourceGroupName;

                var serverResourceInfo = new ResourceIdentifier(resourceInfo.ParentResource);
                serverName = serverResourceInfo.ResourceName;
            }

            return new ServerAdvancedThreatProtectionPolicyModel()
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName
            };
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlAdvancedThreatProtectionAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new SqlAdvancedThreatProtectionAdapter(DefaultProfile.DefaultContext);
        }
    }
}
