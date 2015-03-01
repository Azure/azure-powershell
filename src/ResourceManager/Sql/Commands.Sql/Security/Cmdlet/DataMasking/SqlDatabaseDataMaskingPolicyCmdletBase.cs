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

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.DataMasking
{
    /// <summary>
    /// The base class for all Azure Sql Database security Management Cmdlets
    /// </summary>
    public abstract class SqlDatabaseDataMaskingPolicyCmdletBase : SqlDatabaseCmdletBase<DatabaseDataMaskingPolicyModel, SqlDataMaskingAdapter>
    {

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override DatabaseDataMaskingPolicyModel GetModel()
        {
            return ModelAdapter.GetDatabaseDataMaskingPolicy(ResourceGroupName, ServerName, DatabaseName, clientRequestId);
        }

        protected override SqlDataMaskingAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new SqlDataMaskingAdapter(subscription);
        }

        protected override void SendModel(DatabaseDataMaskingPolicyModel model)
        {
            ModelAdapter.SetDatabaseDataMaskingPolicy(model, clientRequestId);
        }
    }
}