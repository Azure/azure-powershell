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

using Microsoft.Azure.Management.DataFactories;
using Microsoft.DataTransfer.Gateway.Encryption;
using System;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual string OnPremisesEncryptString(SecureString value,
            string resourceGroupName,
            string dataFactoryName,
            string gatewayName,
            PSCredential credential,
            string type,
            string nonCredentialValue,
            string authenticationType,
            string serverName, string databaseName)
        {
            LinkedServiceType linkedServiceType = type == null ? LinkedServiceType.OnPremisesSqlLinkedService : GetLinkedServiceType(type);

            if (linkedServiceType == LinkedServiceType.OnPremisesSqlLinkedService && linkedServiceType == LinkedServiceType.OnPremisesOracleLinkedService
                && linkedServiceType == LinkedServiceType.OnPremisesFileSystemLinkedService && (value == null || value.Length == 0))
            {
                throw new ArgumentNullException("value");
            }

            AuthenticationType authType = authenticationType == null ? AuthenticationType.None : (AuthenticationType)Enum.Parse(typeof(AuthenticationType), authenticationType, true);

            var response = DataPipelineManagementClient.Gateways.RetrieveConnectionInfo(resourceGroupName, dataFactoryName, gatewayName);
            var gatewayEncryptionInfos = new[]
                {
                    new GatewayEncryptionInfo
                        {
                            ServiceToken = response.ConnectionInfo.ServiceToken,
                            IdentityCertThumbprint = response.ConnectionInfo.IdentityCertThumbprint,
                            HostServiceUri = response.ConnectionInfo.HostServiceUri,
                            InstanceVersionString = response.ConnectionInfo.Version
                        }
                };

            string userName = credential != null ? credential.UserName : null;
            SecureString password = credential != null ? credential.Password : null;
            UserInputConnectionString connectionString = new UserInputConnectionString(value, nonCredentialValue, userName, password, linkedServiceType, authType, serverName, databaseName);
            return GatewayEncryptionClient.Encrypt(connectionString, gatewayEncryptionInfos);
        }

        internal static LinkedServiceType GetLinkedServiceType(string typeName)
        {
            LinkedServiceType result;
            if (!Enum.TryParse<LinkedServiceType>(typeName, true, out result))
            {
                // Treat any non-existing type as a generic data source type for encryption
                return LinkedServiceType.Unknown;
            }

            return result;
        }
    }
}
