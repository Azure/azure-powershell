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

using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class SetAzureServiceExtensionCmdletInfo : CmdletsInfo
    {
        public SetAzureServiceExtensionCmdletInfo(string serviceName, string[] roles, string slot, string extensionName,
            string providerNamespace, string publicConfig, string privateConfig, string version)
        {
            this.cmdletName = Utilities.SetAzureServiceExtensionCmdletName;
            this.cmdletParams.Add(new CmdletParam("ServiceName", serviceName));
            if (!string.IsNullOrEmpty(slot))
            {
                this.cmdletParams.Add(new CmdletParam("Slot", slot));
            }
            if (roles != null)
            {
                this.cmdletParams.Add(new CmdletParam("Role", roles));
            }
            this.cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            this.cmdletParams.Add(new CmdletParam("ProviderNamespace", providerNamespace));
            this.cmdletParams.Add(new CmdletParam("PublicConfiguration", publicConfig));
            this.cmdletParams.Add(new CmdletParam("PrivateConfiguration", privateConfig));
            if (!string.IsNullOrEmpty(version))
            {
                this.cmdletParams.Add(new CmdletParam("Version", version));
            }
        }

        public SetAzureServiceExtensionCmdletInfo(string serviceName, X509Certificate2 cert, string[] roles, string slot,
            string extensionName, string providerNamespace, string publicConfig, string privateConfig, string version)
            : this(serviceName, roles, slot, extensionName, providerNamespace, publicConfig, privateConfig, version)
        {
            this.cmdletParams.Add(new CmdletParam("X509Certificate", cert));
        }

        public SetAzureServiceExtensionCmdletInfo(string serviceName, string thumbprint, string algorithm,
            string[] roles, string slot, string extensionName, string providerNamespace, string publicConfig,
            string privateConfig, string version)
            : this(serviceName, roles, slot, extensionName, providerNamespace, publicConfig, privateConfig, version)
        {
            this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", thumbprint));
            if (!string.IsNullOrEmpty(algorithm))
            {
                this.cmdletParams.Add(new CmdletParam("ThumbprintAlgorithm", algorithm));
            }
        }
    }
}
