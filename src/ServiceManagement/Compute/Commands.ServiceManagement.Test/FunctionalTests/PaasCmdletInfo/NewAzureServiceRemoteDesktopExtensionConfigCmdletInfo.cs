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
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo : CmdletsInfo
    {

        public NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo(PSCredential credential, DateTime? expiration, string[] roles, string version)
        {
            this.cmdletName = Utilities.NewAzureServiceRemoteDesktopExtensionConfigCmdletName;            
            this.cmdletParams.Add(new CmdletParam("Credential", credential));
            if (roles != null)
            {
                this.cmdletParams.Add(new CmdletParam("Role", roles));
            }
            if (expiration != null)
            {
                this.cmdletParams.Add(new CmdletParam("Expiration", expiration));
            }
            if (! string.IsNullOrEmpty(version))
            {
                this.cmdletParams.Add(new CmdletParam("Version", version));
            }
        }

        public NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo
            (PSCredential credential, X509Certificate2 cert, string algorithm, DateTime? expiration, string[] roles, string version)
            : this(credential, expiration, roles, version)
        {
            this.cmdletParams.Add(new CmdletParam("X509Certificate", cert));
            if (!string.IsNullOrEmpty(algorithm))
            {
                this.cmdletParams.Add(new CmdletParam("ThumbprintAlgorithm", algorithm));
            }
        }

        public NewAzureServiceRemoteDesktopExtensionConfigCmdletInfo
            (PSCredential credential, string thumbprint, string algorithm, DateTime? expiration, string[] roles, string version)
            : this(credential, expiration, roles, version)
        {
            this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", thumbprint));
            if (!string.IsNullOrEmpty(algorithm))
            {
                this.cmdletParams.Add(new CmdletParam("ThumbprintAlgorithm", algorithm));
            }
        }
    }
}
