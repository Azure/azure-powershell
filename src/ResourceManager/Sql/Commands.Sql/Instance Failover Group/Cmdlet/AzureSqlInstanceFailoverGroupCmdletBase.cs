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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model;
using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Services;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    public abstract class AzureSqlInstanceFailoverGroupCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlInstanceFailoverGroupModel>, AzureSqlInstanceFailoverGroupAdapter>
    {
        /// <summary>
        /// Initializes the Azure Sql Instance Failover Group Adapter
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        protected override AzureSqlInstanceFailoverGroupAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlInstanceFailoverGroupAdapter(DefaultProfile.DefaultContext);
        }
    }
}
