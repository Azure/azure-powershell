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
using Microsoft.Azure.Commands.Sql.ServiceObjective.Adapter;
using Microsoft.Azure.Commands.Sql.ServiceObjective.Model;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ServiceObjective.Cmdlet
{
    public abstract class AzureSqlServerServiceObjectiveCmdletBase
        : AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlServerServiceObjectiveModel>, AzureSqlServerServiceObjectiveAdapter>
    {
        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The service objective adapter</returns>
        protected override AzureSqlServerServiceObjectiveAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlServerServiceObjectiveAdapter(DefaultProfile.Context);
        }
    }
}
