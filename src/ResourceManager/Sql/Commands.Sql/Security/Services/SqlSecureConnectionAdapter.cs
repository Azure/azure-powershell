﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// The SqlSecureConnectionClient class is responsible for transforming the data that was received form the endpoints to the cmdlets model of auditing policy and vice versa
    /// </summary>
    public class SqlSecureConnectionAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private AzureSubscription Subscription { get; set; }
        
        /// <summary>
        /// The end points communicator used by this adapter
        /// </summary>
        private SecureConnectionEndpointsCommunicator Communicator { get; set; }
       
        /// <summary>
        /// The Azure profile used by this adapter
        /// </summary>
        public AzureProfile Profile { get; set; }

        public SqlSecureConnectionAdapter(AzureProfile profile , AzureSubscription subscription)
        {
            Profile = profile;
            Subscription = subscription;
            Communicator = new SecureConnectionEndpointsCommunicator(profile, subscription);
        }

        /// <summary>
        /// Provides the cmdlet model representation of a specific database secure connection policy
        /// </summary>
        public DatabaseSecureConnectionPolicyModel GetDatabaseSecureConnectionPolicy(string resourceGroup, string serverName, string databaseName, string requestId)
        {
            DatabaseSecureConnectionPolicy policy = Communicator.GetDatabaseSecureConnectionPolicy(resourceGroup, serverName, databaseName, requestId);
            DatabaseSecureConnectionPolicyModel dbPolicyModel = ModelizeDatabaseSecureConnectionPolicy(policy);
            dbPolicyModel.ResourceGroupName = resourceGroup;
            dbPolicyModel.ServerName = serverName;
            dbPolicyModel.DatabaseName = databaseName;
            return dbPolicyModel;
        }

        /// <summary>
        /// Transforms a secure connection policy object to its cmdlet model representation
        /// </summary>
        private DatabaseSecureConnectionPolicyModel ModelizeDatabaseSecureConnectionPolicy(DatabaseSecureConnectionPolicy policy)
        {
            DatabaseSecureConnectionPolicyModel dbPolicyModel = new DatabaseSecureConnectionPolicyModel();
            DatabaseSecureConnectionPolicyProperties properties = policy.Properties;
            dbPolicyModel.ProxyDnsName = properties.ProxyDnsName;
            dbPolicyModel.ProxyPort = properties.ProxyPort;
            dbPolicyModel.SecureConnectionState = properties.SecurityEnabledAccess == SecurityConstants.SecureConnectionEndpoint.Required ? SecureConnectionStateType.Required : SecureConnectionStateType.Optional;
            return dbPolicyModel;
        }

        /// <summary>
        /// Sets the secure connection policy of a specific database based on the information provided by the model object
        /// </summary>
        public void SetDatabaseSecureConnectionPolicy(DatabaseSecureConnectionPolicyModel model, String clientId)
        {
            DatabaseSecureConnectionPolicyCreateOrUpdateParameters parameters = PolicizeDatabaseSecureConnectionModel(model);
            Communicator.SetDatabaseSecureConnectionPolicy(model.ResourceGroupName, model.ServerName, model.DatabaseName, clientId, parameters);
        }

        /// <summary>
        /// Takes the cmdlets model object and transform it to the policy as expected by the endpoint
        /// </summary>
        /// <param name="model">The Secure Connection Policy model object</param>
        /// <returns>The communication model object</returns>
        private DatabaseSecureConnectionPolicyCreateOrUpdateParameters PolicizeDatabaseSecureConnectionModel(DatabaseSecureConnectionPolicyModel model)
        {
            DatabaseSecureConnectionPolicyCreateOrUpdateParameters updateParameters = new DatabaseSecureConnectionPolicyCreateOrUpdateParameters();
            DatabaseSecureConnectionPolicyCreateOrUpdateProperties properties = new DatabaseSecureConnectionPolicyCreateOrUpdateProperties();
            updateParameters.Properties = properties;
            properties.SecurityEnabledAccess = model.SecureConnectionState == SecureConnectionStateType.Required ? SecurityConstants.SecureConnectionEndpoint.Required : SecurityConstants.SecureConnectionEndpoint.Optional;
            return updateParameters;
        }
    }
}