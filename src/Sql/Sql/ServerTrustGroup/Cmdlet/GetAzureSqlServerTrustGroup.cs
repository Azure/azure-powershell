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

using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{

	[Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServerTrustGroup"), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	class GetAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
	{
		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			Position = 1,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			Position = 2,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			Position = 3,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string InstanceName { get; set; }

		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			ICollection<AzureSqlServerTrustGroupModel> entities = null;

			if(MyInvocation.BoundParameters.ContainsKey("InstanceName"))
			{
				entities = new List<AzureSqlServerTrustGroupModel>();
				entities.Add(ModelAdapter.GetServerTrustGroup(this.ResourceGroupName, this.Location, this.Name));
			}

			return entities;
		}
	}
}
