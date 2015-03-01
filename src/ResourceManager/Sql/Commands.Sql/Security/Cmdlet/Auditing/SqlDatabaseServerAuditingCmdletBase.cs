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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Security.Services;
using Microsoft.Azure.Common.Extensions.Models;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.Auditing
{
    /// <summary>
    /// The base class for all au Management Cmdlets
    /// </summary>
    public abstract class SqlDatabaseServerAuditingCmdletBase : SqlCmdletBase<ServerAuditingPolicyModel, SqlAuditAdapter>
    {

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override ServerAuditingPolicyModel GetModel()
        {
            return ModelAdapter.GetServerAuditingPolicy(ResourceGroupName, ServerName, this.clientRequestId);
        }

        protected override SqlAuditAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new SqlAuditAdapter(subscription);
        }

        protected override void SendModel(ServerAuditingPolicyModel model)
        {
            ModelAdapter.SetServerAuditingPolicy(model, clientRequestId);
        }
    }
}