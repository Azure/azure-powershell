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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionArmCommunicator
    {
        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Databases TransparentDataEncryption
        /// </summary>
        /// <param name="context">Azure context</param>
        public AzureSqlDatabaseTransparentDataEncryptionArmCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        internal void AddAzureRmSqlServerTransparentDataEncryptionCertificate(string resourceGroupName, string serverName, string privateBlob, string password)
        {
            TdeCertificate tdeCertificate = new TdeCertificate(privateBlob:privateBlob, certPassword:password);
            GetCurrentSqlClient().TdeCertificates.Create(resourceGroupName, serverName, tdeCertificate);
        }

        internal void AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate(string resourceGroupName, string managedInstanceName, string privateBlob, string password)
        {
            TdeCertificate tdeCertificate = new TdeCertificate(privateBlob:privateBlob, certPassword: password);
            GetCurrentSqlClient().ManagedInstanceTdeCertificates.Create(resourceGroupName, managedInstanceName, tdeCertificate);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient() =>
            // Get the SQL management client for the current subscription
            AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
    }
}
