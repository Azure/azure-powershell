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

using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDnsAlias.Cmdlet
{
	/// <summary>
	/// Defines the New-AzureRmSqlServerDnsAlias cmdlet
	/// </summary>
	[Cmdlet(VerbsCommon.New, "AzureRmSqlServerDnsAlias", SupportsShouldProcess = true)]
	[OutputType(typeof(Model.AzureSqlServerDnsAliasModel))]
	public class NewAzureSqlServerDNSAlias : AzureSqlServerDnsAliasCmdletBase
	{
		/// <summary>
		/// Gets or sets the name of the Azure Sql Server Dns Alias
		/// </summary>
		[Parameter(Mandatory = true,
			HelpMessage = "The Azure Sql Server Dns Alias name.")]
		[Alias("DnsAliasName")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if the Server Dns Alias already exists for this server
        /// </summary>
        /// <returns>Null if the Server DNS Alias doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> GetEntity()
		{
			try
			{
				ModelAdapter.GetServerDnsAlias(this.ResourceGroupName, this.ServerName, this.Name);
			}
			catch (CloudException ex)
			{
				if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					// This is what we want - there is no server dns alias with this name
					return null;
				}

				// Unexpected error occured
				throw;
			}

			// The server dns alias already exists
			throw new PSArgumentException(
				string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerDnsAliasNameExists, this.Name), "ServerDNSAlias");
		}

		/// <summary>
		/// Generates the model from user input.
		/// </summary>
		/// <param name="model">This is null since the server dns alias doesn't exist yet</param>
		/// <returns>The generated model from user input</returns>
		protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerDnsAliasModel> model)
		{
			List<Model.AzureSqlServerDnsAliasModel> newEntity = new List<Model.AzureSqlServerDnsAliasModel>();
			newEntity.Add(new Model.AzureSqlServerDnsAliasModel()
			{
				ResourceGroupName = this.ResourceGroupName,
				ServerName = this.ServerName,
				DnsAliasName = this.Name
			});

			return newEntity;
		}

		/// <summary>
		/// Sends the changes to the service -> Creates the server dns alias
		/// </summary>
		/// <param name="entity">The server dns alias to create</param>
		/// <returns>The created server dns alias</returns>
		protected override IEnumerable<Model.AzureSqlServerDnsAliasModel> PersistChanges(IEnumerable<Model.AzureSqlServerDnsAliasModel> entity)
		{
			var resp = new List<Model.AzureSqlServerDnsAliasModel>()
			{
				ModelAdapter.UpsertServerDnsAlias(entity.First())
			};

			return resp;
		}
	}
}
