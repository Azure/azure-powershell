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
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter
{
    /// <summary>
    /// Adapter for firewall operations
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionArmAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseTransparentDataEncryptionArmCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Transparent Data Encryption adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseTransparentDataEncryptionArmAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseTransparentDataEncryptionArmCommunicator(Context);
        }

        internal void AddAzureRmSqlServerTransparentDataEncryptionCertificate(AzureRmSqlServerTransparentDataEncryptionCertificateModel azureRmSqlServerTransparentDataEncryptionCertificateModel)
        {
            string resourceGroupName = azureRmSqlServerTransparentDataEncryptionCertificateModel.ResourceGroupName;
            string serverName = azureRmSqlServerTransparentDataEncryptionCertificateModel.ServerName;
            string privateBlob = azureRmSqlServerTransparentDataEncryptionCertificateModel.PrivateBlob.ConvertToString();
            string password = azureRmSqlServerTransparentDataEncryptionCertificateModel.Password.ConvertToString();

            Communicator.AddAzureRmSqlServerTransparentDataEncryptionCertificate(
                resourceGroupName,
                serverName,
                privateBlob,
                password);
        }

        internal void AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate(AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel)
        {
            string resourceGroupName = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.ResourceGroupName;
            string managedInstanceName = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.ManagedInstanceName;
            string privateBlob = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.PrivateBlob.ConvertToString();
            string password = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.Password.ConvertToString();

            Communicator.AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate(
                resourceGroupName,
                managedInstanceName,
                privateBlob,
                password);
        }
    }
}
