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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.ServerDnsAlias.Cmdlet
{
	[Cmdlet(VerbsCommon.Remove, "AzureRmSqlServerDnsAlias", SupportsShouldProcess = true)]
	[OutputType(typeof(Model.AzureSqlServerDnsAliasModel))]
	public class RemoveAzureSqlServerDNSAlias : AzureSqlServerDnsAliasCmdletBase
	{
		protected const string RemoveByNameAndResourceGroupParameterSet =
			"Remove a Server Dns Alias from cmdlet input parameters";

		protected const string RemoveByInputObjectParameterSet =
			"Remove a Server Dns Alias from AzureSqlServerDnsAliasModel instance definition";

		protected const string RemoveByResourceIdParameterSet =
			"Remove a Server Dns Alias from an Azure resource id";

		/// <summary>
		/// Gets or sets the name of the server dns alias to remove
		/// </summary>
		[Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
			Mandatory = true,
			HelpMessage = "Azure Sql Server Dns Alias name")]
		[Alias("DnsAliasName")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the Azure Sql Server to use
		/// </summary>
		[Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
			Mandatory = true,
			HelpMessage = "The Azure Sql Server name.")]
		[ValidateNotNullOrEmpty]
		public override string ServerName { get; set; }

		/// <summary>
		/// Gets or sets the name of the resource group to use.
		/// </summary>
		[Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
			Mandatory = true,
			Position = 0,
			HelpMessage = "The name of the resource group.")]
		[ValidateNotNullOrEmpty]
		public override string ResourceGroupName { get; set; }

		/// <summary>
		/// Server Dns Alias object to remove
		/// </summary>
		[Parameter(ParameterSetName = RemoveByInputObjectParameterSet,
			Mandatory = true,
			ValueFromPipeline = true,
			HelpMessage = "The Server Dns Alias object to remove")]
		[ValidateNotNullOrEmpty]
		public Model.AzureSqlServerDnsAliasModel InputObject { get; set; }

		/// <summary>
		/// Gets or sets the resource id of the server dns alias
		/// </summary>
		[Parameter(ParameterSetName = RemoveByResourceIdParameterSet,
			Mandatory = true,
			ValueFromPipelineByPropertyName = true,
			HelpMessage = "The resource id of Server Dns Alias object to remove")]
		[ValidateNotNullOrEmpty]
		public string ResourceId { get; set; }

		/// <summary>
		/// Defines whether it is ok to skip the requesting of rule removal confirmation
		/// </summary>
		[Parameter(HelpMessage = "Skip confirmation message for performing the action")]
		public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> GetEntity()
		{
			return new List<Model.AzureSqlServerDnsAliasModel>()
			{
				ModelAdapter.GetServerDnsAlias(this.ResourceGroupName, this.ServerName, this.Name)
			};
		}

		/// <summary>
		/// Apply user input.  Here nothing to apply
		/// </summary>
		/// <param name="model">The result of GetEntity</param>
		/// <returns>The input model</returns>
		protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerDnsAliasModel> model)
		{
			return model;
		}

		/// <summary>
		/// Deletes server dns alias
		/// </summary>
		protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> PersistChanges(IEnumerable<Model.AzureSqlServerDnsAliasModel> entity)
		{
			ModelAdapter.RemoveServerDnsAlias(this.ResourceGroupName, this.ServerName, this.Name);
			return entity;
		}

		/// <summary>
		/// Entry point for the cmdlet
		/// </summary>
		public override void ExecuteCmdlet()
		{
			if (ShouldProcess(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerDnsAliasDescription, this.Name),
 string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerDnsAliasWarning, this.Name),
 Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
			{
				if (Force || ShouldContinue(string.Format(CultureInfo.InvariantCulture,
						Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerDnsAliasWarning, this.Name),
					Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
				{
					if (string.Equals(this.ParameterSetName, RemoveByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
					{
						var resourceInfo = new ResourceIdentifier(InputObject.Id);
						ResourceGroupName = resourceInfo.ResourceGroupName;

						var serverResourceInfo = new ResourceIdentifier(resourceInfo.ParentResource);
						ServerName = serverResourceInfo.ResourceName;

						Name = resourceInfo.ResourceName;
					}
					else if (string.Equals(this.ParameterSetName, RemoveByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
					{
						var resourceInfo = new ResourceIdentifier(ResourceId);
						ResourceGroupName = resourceInfo.ResourceGroupName;

						var serverResourceInfo = new ResourceIdentifier(resourceInfo.ParentResource);
						ServerName = serverResourceInfo.ResourceName;

						Name = resourceInfo.ResourceName;
					}

					base.ExecuteCmdlet();
				}
			}
		}
	}
}
