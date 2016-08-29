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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// The base class for all SQL server auditing Management Cmdlets
    /// </summary>
    public abstract class SqlDatabaseServerAuditingCmdletBase : AzureSqlCmdletBase<AuditingPolicyModel, SqlAuditAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        public virtual AuditType AuditType { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override AuditingPolicyModel GetEntity()
        {
            if (AuditType == AuditType.Table)
            {
                ServerAuditingPolicyModel model;
                ModelAdapter.GetServerAuditingPolicy(ResourceGroupName, ServerName, this.clientRequestId, out model);
                return model;
            }
            ServerBlobAuditingPolicyModel blobModel;
            ModelAdapter.GetServerAuditingPolicy(ResourceGroupName, ServerName, this.clientRequestId, out blobModel);
            return blobModel;
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlAuditAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new SqlAuditAdapter(DefaultProfile.Context);
        }

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="baseModel">The model object with the data to be sent to the REST endpoints</param>
        protected override AuditingPolicyModel PersistChanges(AuditingPolicyModel baseModel)
        {
            if (AuditType == AuditType.Table)
            {
                ModelAdapter.SetServerAuditingPolicy(baseModel as ServerAuditingPolicyModel, clientRequestId, 
                    DefaultContext.Environment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix]);
            }
            if (AuditType == AuditType.Blob)
            {
                ModelAdapter.SetServerAuditingPolicy(baseModel as ServerBlobAuditingPolicyModel, clientRequestId,
                    DefaultContext.Environment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix]);
            }
            return null;
        }
    }
}