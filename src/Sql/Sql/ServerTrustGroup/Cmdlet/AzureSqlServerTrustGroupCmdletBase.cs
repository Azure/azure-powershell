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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Services;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	public abstract class AzureSqlServerTrustGroupCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlServerTrustGroupModel>, AzureSqlServerTrustGroupAdapter>
	{
        /// <summary>
        /// Initializes the Azure Sql Server Trust Group Adapter.
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlServerTrustGroupAdapter InitModelAdapter()
		{
			return new AzureSqlServerTrustGroupAdapter(DefaultProfile.DefaultContext);
		}
    }
}
