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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql Database security Management Cmdlets
    /// </summary>
    public abstract class SqlDatabaseAuditingCmdletBase : AzureSqlDatabaseCmdletBase<AuditingPolicyModel, SqlAuditAdapter>
    {
        public virtual AuditType AuditType { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override AuditingPolicyModel GetEntity()
        {
            if (AuditType == AuditType.NotSet)
            {
                AuditType = AuditType.Blob;
                var blobPolicy = GetEntityHelper();

                // If the user has blob auditing on on the resource we return that policy no matter what is his table auditing policy
                if ((blobPolicy != null) && (blobPolicy.AuditState == AuditStateType.Enabled))
                {
                    return blobPolicy;
                }

                // The user don't have blob auditing policy on
                AuditType = AuditType.Table;
                var tablePolicy = GetEntityHelper();
                return tablePolicy;
            }

            // The user has selected specific audit type
            var policy = GetEntityHelper();
            return policy;
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
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override AuditingPolicyModel PersistChanges(AuditingPolicyModel model)
        {
            if (AuditType == AuditType.Table)
            {
                ModelAdapter.SetDatabaseAuditingPolicy(model as DatabaseAuditingPolicyModel, clientRequestId,
                    DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix));
            }
            if (AuditType == AuditType.Blob)
            {
                ModelAdapter.SetDatabaseAuditingPolicy(model as DatabaseBlobAuditingPolicyModel, clientRequestId,
                    DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix));
            }
            return null;
        }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecord()
        {
            SqlDatabaseServerAuditingCmdletBase.PrintDeprecationMessageForAuditingCmdlets(this);
            base.ProcessRecord();
        }

        private AuditingPolicyModel GetEntityHelper()
        {
            if (AuditType == AuditType.Table)
            {
                DatabaseAuditingPolicyModel model;
                ModelAdapter.GetDatabaseAuditingPolicy(ResourceGroupName, ServerName, DatabaseName, clientRequestId, out model);
                return model;
            }

            if (AuditType == AuditType.Blob)
            {
                DatabaseBlobAuditingPolicyModel blobModel;
                ModelAdapter.GetDatabaseAuditingPolicy(ResourceGroupName, ServerName, DatabaseName, clientRequestId, out blobModel);
                return blobModel;
            }

            return null;
        }
    }
}
