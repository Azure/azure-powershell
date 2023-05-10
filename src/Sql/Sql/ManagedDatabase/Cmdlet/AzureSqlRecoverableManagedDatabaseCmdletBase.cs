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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Services;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    public abstract class AzureSqlRecoverableManagedDatabaseCmdletBase<TModel> : AzureSqlCmdletBase<TModel, AzureSqlRecoverableManagedDatabaseAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the managed instance to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the instance.")]
        [ValidateNotNullOrEmpty]
        public virtual string InstanceName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlRecoverableManagedDatabaseAdapter InitModelAdapter()
        {
            return new AzureSqlRecoverableManagedDatabaseAdapter(DefaultProfile.DefaultContext);
        }
    }
}
