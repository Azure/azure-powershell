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

using System;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.DataTransfer.Gateway.Encryption;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public const int GatewayMajorVersionWithIRSupport = 3;

        public virtual string IntegrationRuntimeEncryptCredential(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            string linkedServiceJson)
        {

            var response = DataFactoryManagementClient.IntegrationRuntimes.GetConnectionInfo(resourceGroupName, dataFactoryName, integrationRuntimeName);
            var irVerStr = response.Version;
            var irVer = new Version(irVerStr);
            //Private preview customers can use 2.x gateways for this feature, below code change gateway version of 2.x to 3.0  to pass version check by gateway.
            if (irVer.Major < GatewayMajorVersionWithIRSupport)
            {
                irVer = new Version(GatewayMajorVersionWithIRSupport, 0);
                irVerStr = irVer.ToString();
            }
            var encryptionInfos = new[]
                {
                    new GatewayEncryptionInfo
                    {
                        HostServiceUri = new Uri(response.HostServiceUri),
                        IdentityCertThumbprint = response.IdentityCertThumbprint,
                        PublicKey = response.PublicKey,
                        ServiceToken = response.ServiceToken,
                        InstanceVersionString = irVerStr
                    }
                };
            return GatewayEncryptionClient.Encrypt(linkedServiceJson, encryptionInfos);
        }
    }
}
