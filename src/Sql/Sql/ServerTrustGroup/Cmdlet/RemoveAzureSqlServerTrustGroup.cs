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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	/// <summary>
	/// Cmdlet to remove a Azure Sql Server Trust Group.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTrustGroup", SupportsShouldProcess = true, DefaultParameterSetName = "Default"), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	public class RemoveAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
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
			HelpMessage = "The location of the Server Trust Group to remove.")]
		[LocationCompleter("Microsoft.Sql/locations/serverTrustGroups")]
		[ValidateNotNullOrEmpty]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the name of the ServerTrustGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 2,
			HelpMessage = "The name of Server Trust Group to remove.")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Defines whether it is ok to skip the requesting of rule removal confirmation.
		/// </summary>
		[Parameter(HelpMessage = "Skip confirmation message for performing the action.")]
		public SwitchParameter Force { get; set; }

		/// <summary>
		/// Defines whether the cmdlets will output the model object at the end of its execution.
		/// </summary>
		[Parameter(Mandatory = false,
		HelpMessage = "Defines whether to return the removed Server Trust Group")]
		public SwitchParameter PassThru { get; set; }

		/// <summary>
		/// Returns true if the model object that was constructed by this cmdlet should be written out.
		/// </summary>
		protected override bool WriteResult() { return PassThru.IsPresent; }

		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			return new List<AzureSqlServerTrustGroupModel>() {
				ModelAdapter.GetServerTrustGroup(this.ResourceGroupName, this.Location, this.Name),
			};
		}

		/// <summary>
		/// No user input to apply to model.
		/// </summary>
		/// <param name="model">Model retrieved from service</param>
		/// <returns>The model that was passed in</returns>
		protected override IEnumerable<AzureSqlServerTrustGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerTrustGroupModel> model)
		{
			return model;
		}

		/// <summary>
		/// Persist deletion.
		/// </summary>
		/// <param name="entity">The output of apply user input to model</param>
		/// <returns>The input entity</returns>
		protected override IEnumerable<AzureSqlServerTrustGroupModel> PersistChanges(IEnumerable<AzureSqlServerTrustGroupModel> entity)
		{
			ModelAdapter.DeleteServerTrustGroup(this.ResourceGroupName, this.Location, this.Name);
			return entity;
		}

		public override void ExecuteCmdlet()
		{
			if (!Force.IsPresent && !ShouldProcess(
				string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerTrustGroupDescription, this.Name, this.Location),
				string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerTrustGroupWarning, this.Name, this.Location),
				Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
			{
				return;
			}

			base.ExecuteCmdlet();
		}
	}
}
