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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    public abstract class AzureSqlInstanceFailoverGroupCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlInstanceFailoverGroupModel>, AzureSqlInstanceFailoverGroupAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the local region to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Local Region from which to retrieve the Instance Failover Group.")]
        [LocationCompleter("Microsoft.Sql/locations/instanceFailoverGroups")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        /// <summary>
        /// Initializes the Azure Sql Instance Failover Group Adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlInstanceFailoverGroupAdapter InitModelAdapter()
        {
            return new AzureSqlInstanceFailoverGroupAdapter(DefaultProfile.DefaultContext);
        }
    }
}
