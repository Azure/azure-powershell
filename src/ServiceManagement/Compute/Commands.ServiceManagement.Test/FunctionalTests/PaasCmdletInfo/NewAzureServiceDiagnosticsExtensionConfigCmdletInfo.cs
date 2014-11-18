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
using System.Xml;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class NewAzureServiceDiagnosticsExtensionConfigCmdletInfo : CmdletsInfo
    {

        public NewAzureServiceDiagnosticsExtensionConfigCmdletInfo(string storage, XmlDocument config, string[] roles)
        {
            this.cmdletName = Utilities.NewAzureServiceDiagnosticsExtensionConfigCmdletName;

            this.cmdletParams.Add(new CmdletParam("StorageAccountName", storage));            
            if (roles != null)
            {
                this.cmdletParams.Add(new CmdletParam("Role", roles));
            }            
            if (config != null)
            {
                this.cmdletParams.Add(new CmdletParam("DiagnosticsConfiguration", config));
            }
        }

        public NewAzureServiceDiagnosticsExtensionConfigCmdletInfo(string storage, X509Certificate2 cert, XmlDocument config, string[] roles)
            : this(storage, config, roles)
        {
            this.cmdletParams.Add(new CmdletParam("X509Certificate", cert));
        }

        public NewAzureServiceDiagnosticsExtensionConfigCmdletInfo(string storage, string thumbprint, string algorithm, XmlDocument config, string[] roles)
            : this(storage, config, roles)
        {
            this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", thumbprint));
            if (!string.IsNullOrEmpty(algorithm))
            {
                this.cmdletParams.Add(new CmdletParam("ThumbprintAlgorithm", algorithm));
            }
        }
    }
}
