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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Properties;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// The base class for Azure SQL server auditing settings Management Cmdlets
    /// </summary>
    public abstract class SqlServerAuditingSettingsCmdletBase : AzureSqlCmdletBase<ServerBlobAuditingSettingsModel, SqlAuditAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the SQL server to use.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override ServerBlobAuditingSettingsModel GetEntity()
        {
            ServerBlobAuditingSettingsModel model;
            ModelAdapter.GetServerBlobAuditingPolicyV2(ResourceGroupName, ServerName, out model);
            return model;
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlAuditAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new SqlAuditAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="baseModel">The model object with the data to be sent to the REST endpoints</param>
        protected override ServerBlobAuditingSettingsModel PersistChanges(ServerBlobAuditingSettingsModel baseModel)
        {
            if (Array.IndexOf(baseModel.AuditActionGroup, AuditActionGroups.AUDIT_CHANGE_GROUP) > -1)
            {
                // AUDIT_CHANGE_GROUP is not supported.
                WriteWarning(Resources.auditChangeGroupDeprecationMessage);

                // Remove it
                baseModel.AuditActionGroup = baseModel.AuditActionGroup.Where(v => v != AuditActionGroups.AUDIT_CHANGE_GROUP).ToArray();
            }

            ModelAdapter.SetServerAuditingPolicy(baseModel, DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix));
          
            return null;
        }
    }
}
