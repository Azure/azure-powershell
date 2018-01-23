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
using Microsoft.Azure.Commands.Sql.ServerDnsAlias.Services;
using Microsoft.Azure.Commands.Sql.ServerDnsAlias.Model;
using System.Collections.Generic;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.Sql.ServerDnsAlias.Cmdlet
{
	/// <summary>
	/// Defines the Set-AzureRmSqlServerDnsAlias cmdlet
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "AzureRmSqlServerDnsAlias",
		SupportsShouldProcess = true)]
	[OutputType(typeof(Model.AzureSqlServerDnsAliasModel))]
	public class SetAzureSqlServerDnsAlias : AzureSqlCmdletBase<IEnumerable<AzureSqlServerDnsAliasModel>, AzureSqlServerDnsAliasAdapter>
	{
		/// <summary>
		/// Template to generate the Server Dns Alias Id
		/// </summary>
		public static string ServerDnsAliasIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/dnsAliases/{3}";
		
		/// <summary>
		/// Gets or sets the name of the Azure Sql Server Dns Alias
		/// </summary>
		[Parameter(Mandatory = true,
			ValueFromPipelineByPropertyName = true,
			HelpMessage = "The Azure Sql Server Dns Alias name.")]
		[Alias("DnsAliasName")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the new server to which alias should point
		/// </summary>
		[Parameter(Mandatory = true,
			HelpMessage = "The name of Azure Sql Server to which alias should point.")]
		[ValidateNotNullOrEmpty]
		public string TargetServerName { get; set; }

		/// <summary>
		/// Gets or sets the name of the resource group to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 0,
			ValueFromPipelineByPropertyName = true,
			HelpMessage = "The name of the resource group of the target server.")]
		[Alias("TargetResourceGroupName")]
		[ValidateNotNullOrEmpty]
		public override string ResourceGroupName { get; set; }

		/// <summary>
		/// Gets or sets the name of the new server to which alias is currently pointing
		/// </summary>
		[Parameter(Mandatory = true,
			HelpMessage = "The name of Azure Sql Server to which alias is currently pointing.")]
		[ValidateNotNullOrEmpty]
		public string SourceServerName { get; set; }

		/// <summary>
		/// Gets or sets the name of the resource group of the old server
		/// </summary>
		[Parameter(Mandatory = true,
			HelpMessage = "The name of resource group of the source server.")]
		[ValidateNotNullOrEmpty]
		public string SourceServerResourceGroupName { get; set; }

		/// <summary>
		/// Gets or sets the name of the subscription id of the old server
		/// </summary>
		[Parameter(Mandatory = true,
			HelpMessage = "The subscription id of the source server")]
		[ValidateNotNullOrEmpty]
		public Guid SourceServerSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get entity method - nothing to return
        /// </summary>
        protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> GetEntity()
		{
			return new List<Model.AzureSqlServerDnsAliasModel>();
		}

		/// <summary>
		/// Apply user input to model - nothing to do
		/// </summary>
		protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerDnsAliasModel> model)
		{
			return model;
		}

		/// <summary>
		/// Persist changes - actually invoke acquire on alias to move it from one server to another
		/// </summary>
		protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> PersistChanges(IEnumerable<Model.AzureSqlServerDnsAliasModel> entity)
		{
			return new List<Model.AzureSqlServerDnsAliasModel>()
			{
				ModelAdapter.AcquireServerDnsAlias(
					this.ResourceGroupName,
					this.TargetServerName,
					this.Name,
					new Management.Sql.Models.ServerDnsAliasAcquisition(oldServerDnsAliasId: ConstructOldServerId()))
			};
		}

		/// <summary>
		/// Init model adapter
		/// </summary>
		protected override AzureSqlServerDnsAliasAdapter InitModelAdapter(IAzureSubscription subscription)
		{
			return new AzureSqlServerDnsAliasAdapter(DefaultProfile.DefaultContext);
		}

		/// <summary>
		/// Construct server dns alias id for purpose of acquire parameters
		/// </summary>
		/// <returns></returns>
		private string ConstructOldServerId()
		{
			return string.Format(ServerDnsAliasIdTemplate, this.SourceServerSubscriptionId, this.SourceServerResourceGroupName, this.SourceServerName, this.Name);
		}
	}
}
