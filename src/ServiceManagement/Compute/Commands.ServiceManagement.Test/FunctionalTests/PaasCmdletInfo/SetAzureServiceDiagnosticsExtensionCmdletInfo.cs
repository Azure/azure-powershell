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
using Microsoft.WindowsAzure.Commands.Common.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class SetAzureServiceDiagnosticsExtensionCmdletInfo : CmdletsInfo
    {

        public SetAzureServiceDiagnosticsExtensionCmdletInfo(string service, AzureStorageContext storageContext, string config, string[] roles, string slot)
        {
            this.cmdletName = Utilities.SetAzureServiceDiagnosticsExtensionCmdletName;
            this.cmdletParams.Add(new CmdletParam("ServiceName", service));
            this.cmdletParams.Add(new CmdletParam("StorageContext", storageContext));
            this.cmdletParams.Add(new CmdletParam("Slot", slot));
            if (roles != null)
            {
                this.cmdletParams.Add(new CmdletParam("Role", roles));
            }            
            if (config != null)
            {
                this.cmdletParams.Add(new CmdletParam("DiagnosticsConfigurationPath", config));
            }
        }

        public SetAzureServiceDiagnosticsExtensionCmdletInfo(string service, AzureStorageContext storageContext, X509Certificate2 cert, string config, string[] roles, string slot)
            : this(service, storageContext, config, roles, slot)
        {
            this.cmdletParams.Add(new CmdletParam("X509Certificate", cert));
        }

        public SetAzureServiceDiagnosticsExtensionCmdletInfo(string service, AzureStorageContext storageContext, string thumbprint, string algorithm, string config, string[] roles, string slot)
            : this(service, storageContext, config, roles, slot)
        {
            this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", thumbprint));
            if (!string.IsNullOrEmpty(algorithm))
            {
                this.cmdletParams.Add(new CmdletParam("ThumbprintAlgorithm", algorithm));
            }
        }
    }
}
