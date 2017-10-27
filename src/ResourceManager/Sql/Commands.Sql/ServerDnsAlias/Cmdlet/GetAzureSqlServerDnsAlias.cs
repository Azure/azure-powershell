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

using Microsoft.Azure.Commands.Sql.ServerDnsAlias.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDnsAlias.Cmdlet
{
	/// <summary>
	/// Defines the Get-AzureRmSqlServerDnsAlias cmdlet
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "AzureRmSqlServerDnsAlias", SupportsShouldProcess = true)]
	[OutputType(typeof(Model.AzureSqlServerDnsAliasModel))]
	public class GetAzureSqlServerDNSAlias : AzureSqlServerDnsAliasCmdletBase
	{
		/// <summary>
		/// Gets or sets the name of the Azure Sql Server DNS Alias
		/// </summary>
		[Parameter(Mandatory = false,
			HelpMessage = "The Azure Sql Server DNS Alias name.")]
		[Alias("DnsAliasName")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets a Server DNS Alias from the service.
		/// </summary>
		/// <returns>A single Server DNS Alias</returns>
		protected override IEnumerable<AzureSqlServerDnsAliasModel> GetEntity()
		{
			ICollection<AzureSqlServerDnsAliasModel> results = null;

			if (this.MyInvocation.BoundParameters.ContainsKey("Name"))
			{
				results = new List<AzureSqlServerDnsAliasModel>();
				results.Add(ModelAdapter.GetServerDnsAlias(this.ResourceGroupName, this.ServerName, this.Name));
			}
			else
			{
				results = ModelAdapter.ListServerDnsAliases(this.ResourceGroupName, this.ServerName);
			}

			return results;
		}

		/// <summary>
		/// No changes, thus nothing to persist.
		/// </summary>
		/// <param name="entity">The entity retrieved</param>
		/// <returns>The unchanged entity</returns>
		protected override IEnumerable<AzureSqlServerDnsAliasModel> PersistChanges(IEnumerable<AzureSqlServerDnsAliasModel> entity)
		{
			return entity;
		}

		/// <summary>
		/// No user input to apply to model.
		/// </summary>
		/// <param name="model">The model to modify</param>
		/// <returns>The input model</returns>
		protected override IEnumerable<AzureSqlServerDnsAliasModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerDnsAliasModel> model)
		{
			return model;
		}
	}
}
