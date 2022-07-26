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
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Services
{
    /// <summary>
    /// Adapter for Azure SQL Server Active Directory administrator operations
    /// </summary>
    public class AzureSqlServerActiveDirectoryOnlyAuthenticationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlServerActiveDirectoryOnlyAuthenticationCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerActiveDirectoryOnlyAuthenticationCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Azure SQL Server Active Directory administrator adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerActiveDirectoryOnlyAuthenticationAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerActiveDirectoryOnlyAuthenticationCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure SQL Server Active Directory only authentication by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server that contains the Azure Active Directory only authentication</param>
        /// <returns>The Azure Sql ServerActiveDirectoryAdministrator object</returns>
        internal AzureSqlServerActiveDirectoryOnlyAuthenticationModel GetServerActiveDirectoryOnlyAuthentication(string resourceGroupName, string serverName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName);
            return CreateServerActiveDirectoryOnlyAuthenticationModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure SQL Server Active Directory only authentications.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server that contains the Azure Active Directory only authentication</param>
        /// <returns>A list of Azure SQL Server Active Directory only authentication objects</returns>
        internal ICollection<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> ListServerActiveDirectoryOnlyAuthentications(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);

            return resp.Select((activeDirectoryOnlyAuth) =>
            {
                return CreateServerActiveDirectoryOnlyAuthenticationModelFromResponse(resourceGroupName, serverName, activeDirectoryOnlyAuth);
            }).ToList();
        }

        /// <summary>
        /// Enable\Disable Azure Active Directory only authentication on a Azure SQL Server
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        /// <param name="model"></param>
        /// <returns>The upserted Azure SQL Server Active Directory administrator</returns>
        internal AzureSqlServerActiveDirectoryOnlyAuthenticationModel UpsertAzureADOnlyAuthenticaion(string resourceGroup, string serverName, AzureSqlServerActiveDirectoryOnlyAuthenticationModel model)
        {
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, new ServerAzureADOnlyAuthentication(model.AzureADOnlyAuthentication));

            return CreateServerActiveDirectoryOnlyAuthenticationModelFromResponse(resourceGroup, serverName, resp);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        /// <param name="serverAzureADOnlyAuthentication"></param>
        /// <returns>The converted model</returns>
        public static AzureSqlServerActiveDirectoryOnlyAuthenticationModel CreateServerActiveDirectoryOnlyAuthenticationModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ServerAzureADOnlyAuthentication serverAzureADOnlyAuthentication)
        {
            if (serverAzureADOnlyAuthentication != null)
            {
                AzureSqlServerActiveDirectoryOnlyAuthenticationModel model = new AzureSqlServerActiveDirectoryOnlyAuthenticationModel();

                model.ResourceGroupName = resourceGroup;
                model.ServerName = serverName;
                model.AzureADOnlyAuthentication = serverAzureADOnlyAuthentication.AzureADOnlyAuthentication;
                return model;
            }

            return null;
        }      
    }
}
