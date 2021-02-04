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
using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	/// <summary>
	/// Cmdlet to retrieve a Azure Sql Server Trust Group.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTrustGroup"), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	public class GetAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
	{
		/// <summary>
		/// Gets or sets the location of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 1,
			ParameterSetName = "Default",
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[Parameter(Mandatory = true,
			Position = 1,
			ParameterSetName = "ListByLocationSet",
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[LocationCompleter("Microsoft.Sql/locations/serverTrustGroups")]
		[ValidateNotNullOrEmpty]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the resource id of the ServerTrustGroup.
		/// </summary>
		[Parameter(ParameterSetName = "ResourceIdSet",
			Mandatory = true,
			Position = 0,
			ValueFromPipelineByPropertyName = true,
			HelpMessage = "The resource id of instance to use")]
		[ValidateNotNullOrEmpty]
		public string ResourceId { get; set; }

		/// <summary>
		/// Gets or sets the name of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 2,
			ParameterSetName = "Default",
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the instance to use for retrieving ServerTrustGroups.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 3,
			ParameterSetName = "ListByInstanceSet",
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string InstanceName { get; set; }

		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			ICollection<AzureSqlServerTrustGroupModel> entities = null;

			if (string.Equals(this.ParameterSetName, "ResourceIdSet", System.StringComparison.OrdinalIgnoreCase))
			{
				var resourceInfo = new ResourceIdentifier(ResourceId);
				entities = new List<AzureSqlServerTrustGroupModel>();
				entities.Add(ModelAdapter.GetServerTrustGroup(resourceInfo.ResourceGroupName, resourceInfo.ParentResource.Split('/')[1], resourceInfo.ResourceName));
			}
			else if (MyInvocation.BoundParameters.ContainsKey("InstanceName"))
			{
				entities = ModelAdapter.ListServerTrustGrousByInstance(this.ResourceGroupName, this.InstanceName);
			}
			else if(!MyInvocation.BoundParameters.ContainsKey("Name") && MyInvocation.BoundParameters.ContainsKey("Location"))
			{
				entities = ModelAdapter.ListServerTrustGrousByLocation(this.ResourceGroupName, this.Location);
			}
			else
			{
				entities = new List<AzureSqlServerTrustGroupModel>();
				entities.Add(ModelAdapter.GetServerTrustGroup(this.ResourceGroupName, this.Location, this.Name));
			}

			return entities;
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerTrustGroupModel> model)
		{
			return model;
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> PersistChanges(IEnumerable<AzureSqlServerTrustGroupModel> entity)
		{
			return entity;
		}
	}
}
