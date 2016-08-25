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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.SecureConnection.Model;
using Microsoft.Azure.Commands.Sql.SecureConnection.Services;

namespace Microsoft.Azure.Commands.Sql.SecureConnection.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql Database security management cmdlets
    /// </summary>
    public abstract class SqlDatabaseSecureConnectionCmdletBase : AzureSqlDatabaseCmdletBase<DatabaseSecureConnectionPolicyModel, SqlSecureConnectionAdapter>
    {
        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override DatabaseSecureConnectionPolicyModel GetEntity()
        {
            return ModelAdapter.GetDatabaseSecureConnectionPolicy(ResourceGroupName, ServerName, DatabaseName, clientRequestId);
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlSecureConnectionAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new SqlSecureConnectionAdapter(DefaultProfile.Context);
        }
    }
}