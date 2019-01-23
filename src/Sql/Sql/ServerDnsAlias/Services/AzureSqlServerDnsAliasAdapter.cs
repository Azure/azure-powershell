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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.ServerDnsAlias.Model;
using Microsoft.Azure.Commands.Sql.ServerDnsAlias.Services;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.ServerDnsAlias.Services
{
	/// <summary>
	/// Adapter for server dns alias operations
	/// </summary>
	public class AzureSqlServerDnsAliasAdapter
	{
		/// <summary>
		/// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
		/// </summary>
		private AzureSqlServerDnsAliasCommunicator Communicator { get; set; }

		/// <summary>
		/// Gets or sets the Azure profile
		/// </summary>
		public IAzureContext Context { get; set; }

		public AzureSqlServerDnsAliasAdapter(IAzureContext context)
		{
			Context = context;
			Communicator = new AzureSqlServerDnsAliasCommunicator(Context);
		}

		/// <summary>
		/// Gets a server dns alias
		/// </summary>
		public AzureSqlServerDnsAliasModel GetServerDnsAlias(string resourceGroup, string serverName, string serverDnsAliasName)
		{
			var resp = Communicator.Get(resourceGroup, serverName, serverDnsAliasName);
			return CreateServerDnsAliasModelFromResponse(resourceGroup, serverName, resp);
		}

		/// <summary>
		/// Lists server dns aliases on server
		/// </summary>
		public List<AzureSqlServerDnsAliasModel> ListServerDnsAliases(string resourceGroup, string serverName)
		{
			var resp = Communicator.List(resourceGroup, serverName);
			return resp.Select(s =>
			{
				return CreateServerDnsAliasModelFromResponse(resourceGroup, serverName, s);
			}).ToList();
		}

		/// <summary>
		/// Upsert server dns alias
		/// </summary>
		public AzureSqlServerDnsAliasModel UpsertServerDnsAlias(AzureSqlServerDnsAliasModel model)
		{
			var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.DnsAliasName);

			return CreateServerDnsAliasModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
		}

		/// <summary>
		/// Removes a server dns alias
		/// </summary>
		public void RemoveServerDnsAlias(string resourceGroup, string serverName, string serverDNSAliasName)
		{
			Communicator.Remove(resourceGroup, serverName, serverDNSAliasName);
		}

		/// <summary>
		/// Acquire server dns alias from one server and points it to another
		/// </summary>
		public AzureSqlServerDnsAliasModel AcquireServerDnsAlias(string resourceGroup, string serverName, string serverDNSAliasName, ServerDnsAliasAcquisition parameters)
		{
			Communicator.Acquire(resourceGroup, serverName, serverDNSAliasName, parameters);

			return null;
		}

		/// <summary>
		/// Create server dns alias model from response
		/// </summary>
		/// <param name="resourceGroup">Resource group</param>
		/// <param name="serverName">Server name</param>
		/// <param name="resp">Response</param>
		/// <returns></returns>
		private static AzureSqlServerDnsAliasModel CreateServerDnsAliasModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ServerDnsAlias resp)
		{
			AzureSqlServerDnsAliasModel serverDnsAliasModel = new AzureSqlServerDnsAliasModel();

			serverDnsAliasModel.Id = resp.Id;
			serverDnsAliasModel.ResourceGroupName = resourceGroup;
			serverDnsAliasModel.ServerName = serverName;
			serverDnsAliasModel.DnsAliasName = resp.Name;

			return serverDnsAliasModel;
		}
	}
}
