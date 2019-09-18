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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Services;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Cmdlet
{
    public abstract class InstancePoolCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlInstancePoolModel>, AzureSqlInstancePoolAdapter>
    {
        /// <summary>
        /// Initializes the instance pool model adapter.
        /// </summary>
        /// <returns>The instance pool adapter</returns>
        protected override AzureSqlInstancePoolAdapter InitModelAdapter()
        {
            return new AzureSqlInstancePoolAdapter(DefaultContext);
        }
    }
}
