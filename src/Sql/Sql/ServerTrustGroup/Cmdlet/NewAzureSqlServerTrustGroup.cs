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
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	/// <summary>
	/// Cmdlet to create a new Azure Sql Server Trust Group.
	/// </summary>
	[Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTrustGroup", DefaultParameterSetName = "GroupMemberObjectSet", SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	[Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTrustGroup")]
	public class NewAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
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
		/// Gets or sets the location of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 1,
			HelpMessage = "The location of the Server Trust Group to create.")]
		[LocationCompleter("Microsoft.Sql/locations/serverTrustGroups")]
		[ValidateNotNullOrEmpty]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the name of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 2,
			HelpMessage = "The name of the Server Trust Group to create.")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets group members of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			ParameterSetName = "GroupMemberObjectSet",
			Position = 3,
			HelpMessage = "Group members of the Server Trust Group to create.")]
		[ValidateNotNullOrEmpty]
		public List<ManagedInstance.Model.AzureSqlManagedInstanceModel> GroupMember { get; set; }

		/// <summary>
		/// Gets or sets group members of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			ParameterSetName = "GroupMemberResourceIdSet",
			Position = 3,
			HelpMessage = "Group members of the Server Trust Group to create.")]
		[ValidateNotNullOrEmpty]
		public List<string> GroupMemberResourceId { get; set; }

		/// <summary>
		/// Gets or sets the trust scope of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			HelpMessage = "The trust scope of the Server Trust Group to create.")]
		[ValidateNotNullOrEmpty]
		public List<String> TrustScope { get; set; }

		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			try
			{
				ModelAdapter.GetServerTrustGroup(this.ResourceGroupName, this.Location, this.Name);
			}
			catch (CloudException ex)
			{
				if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					return null;
				}

				throw;
			}

			return null;
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerTrustGroupModel> model)
		{
			bool objectSet = string.Equals(this.ParameterSetName, "GroupMemberObjectSet", System.StringComparison.OrdinalIgnoreCase);
			List<AzureSqlServerTrustGroupModel> newEntity = new List<AzureSqlServerTrustGroupModel>();
			newEntity.Add(new AzureSqlServerTrustGroupModel()
			{
				ResourceGroupName = this.ResourceGroupName,
				Location = this.Location,
				Name = this.Name,
				TrustScope = this.TrustScope,
				GroupMember = objectSet ? ProcessGroupMembers(this.GroupMember) : GroupMemberResourceId
			}); ;
			return newEntity;
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> PersistChanges(IEnumerable<AzureSqlServerTrustGroupModel> entity)
		{
			return new List<AzureSqlServerTrustGroupModel>()
			{
				ModelAdapter.CreateServerTrustGroup(entity.First())
			};
		}

		private List<string> ProcessGroupMembers(List<ManagedInstance.Model.AzureSqlManagedInstanceModel> groupMembers)
		{
			List<string> output = new List<string>();
			foreach(ManagedInstance.Model.AzureSqlManagedInstanceModel member in groupMembers)
			{
				output.Add(member.Id);
			}

			return output;
		}
	}
}
