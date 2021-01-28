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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	[Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTrustGroup", SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	public class RemoveAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
	{
		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			Position = 1,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[LocationCompleter("Microsoft.Sql/locations/serverTrustGroups")]
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


		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			return new List<AzureSqlServerTrustGroupModel>() {
				ModelAdapter.GetServerTrustGroup(this.ResourceGroupName, this.Location, this.Name),
			};
		}

		/// <summary>
		/// No user input to apply to model
		/// </summary>
		/// <param name="model">Model retrieved from service</param>
		/// <returns>The model that was passed in</returns>
		protected override IEnumerable<AzureSqlServerTrustGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerTrustGroupModel> model)
		{
			return model;
		}

		/// <summary>
		/// Persist deletion
		/// </summary>
		/// <param name="entity">The output of apply user input to model</param>
		/// <returns>The input entity</returns>
		protected override IEnumerable<AzureSqlServerTrustGroupModel> PersistChanges(IEnumerable<AzureSqlServerTrustGroupModel> entity)
		{
			ModelAdapter.DeleteServerTrustGroup(this.ResourceGroupName, this.Location, this.Name);
			return entity;
		}
	}
}
