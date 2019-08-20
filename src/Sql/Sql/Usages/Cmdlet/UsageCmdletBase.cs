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

using Microsoft.Azure.Commands.Sql.Common;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Usages.Services;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Usages.Models;

namespace Microsoft.Azure.Commands.Sql.Usages.Cmdlet
{
    public abstract class UsageCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlUsageModel>, AzureSqlUsageAdapter>
    {
        /// <summary>
        /// Initializes the usage adapter.
        /// </summary>
        /// <returns>The usage adapter</returns>
        protected override AzureSqlUsageAdapter InitModelAdapter()
        {
            return new AzureSqlUsageAdapter(DefaultContext);
        }
    }
}
