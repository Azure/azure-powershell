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
using Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryOnlyAuthentication.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryOnlyAuthentication.Services
{
    /// <summary>
    /// Adapter for Azure SQL Managed Instance Active Directory only authentication operations
    /// </summary>
    public class AzureSqlInstanceActiveDirectoryOnlyAuthenticationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlInstanceActiveDirectoryOnlyAuthenticationCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlInstanceActiveDirectoryOnlyAuthenticationCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Azure SQL Managed Instance Active Directory only authentication administrator adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlInstanceActiveDirectoryOnlyAuthenticationAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlInstanceActiveDirectoryOnlyAuthenticationCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure SQL Managed Instance Active Directory only authentication by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="InstanceName">The name of the Azure SQL Server that contains the Azure Active Directory only authentication</param>
        /// <returns>The Azure Sql ServerActiveDirectoryAdministrator object</returns>
        internal AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel GetInstanceActiveDirectoryOnlyAuthentication(string resourceGroupName, string InstanceName)
        {
            var resp = Communicator.Get(resourceGroupName, InstanceName);
            return CreateInstanceActiveDirectoryOnlyAuthenticationModelFromResponse(resourceGroupName, InstanceName, resp);
        }

        /// <summary>
        /// Gets a list of Azure SQL Managed Instance Active Directory only authentications.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="InstanceName">The name of the Azure SQL Server that contains the Azure Active Directory only authentication</param>
        /// <returns>A list of Azure SQL Server Active Directory only authentication objects</returns>
        internal ICollection<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> ListInstanceActiveDirectoryOnlyAuthentications(string resourceGroupName, string InstanceName)
        {
            var resp = Communicator.List(resourceGroupName, InstanceName);

            return resp.Select((activeDirectoryOnlyAuth) =>
            {
                return CreateInstanceActiveDirectoryOnlyAuthenticationModelFromResponse(resourceGroupName, InstanceName, activeDirectoryOnlyAuth);
            }).ToList();
        }

        /// <summary>
        /// Enable\Disable Azure Active Directory only authentication on a Azure SQL Managed Instance
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="InstanceName">The name of the Azure Sql Managed Instance</param>
        /// <param name="model"></param>
        /// <returns>The upserted Azure SQL Managed Insance AD Only Authentication</returns>
        internal AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel UpsertAzureADOnlyAuthenticaion(string resourceGroup, string InstanceName, AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel model)
        {
            var resp = Communicator.CreateOrUpdate(resourceGroup, InstanceName, new ManagedInstanceAzureADOnlyAuthentication(model.AzureADOnlyAuthentication));

            return CreateInstanceActiveDirectoryOnlyAuthenticationModelFromResponse(resourceGroup, InstanceName, resp);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the instance is in</param>
        /// <param name="InstanceName">The name of the Azure Sql Managed Instance</param>
        /// <param name="serverAzureADOnlyAuthentication"></param>
        /// <returns>The converted model</returns>
        public static AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel CreateInstanceActiveDirectoryOnlyAuthenticationModelFromResponse(string resourceGroup, string InstanceName, Management.Sql.Models.ManagedInstanceAzureADOnlyAuthentication serverAzureADOnlyAuthentication)
        {
            if (serverAzureADOnlyAuthentication != null)
            {
                AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel model = new AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel();

                model.ResourceGroupName = resourceGroup;
                model.InstanceName = InstanceName;
                model.AzureADOnlyAuthentication = serverAzureADOnlyAuthentication.AzureADOnlyAuthentication;
                return model;
            }

            return null;
        }      
    }
}
