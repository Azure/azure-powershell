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

using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class SetAzureServiceDomainJoinExtensionCmdletInfo : CmdletsInfo
    {
        private enum DomainJoinExtensionParameterSetType
        {
            DomainName,
            WorkgroupName
        }

        //Constructor with parameters applicable to all ParameterSets
        private SetAzureServiceDomainJoinExtensionCmdletInfo(
            DomainJoinExtensionParameterSetType type,
            string value,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string version)
        {
            this.cmdletName = Utilities.SetAzureServiceDomainJoinExtension;

            this.cmdletParams.Add(new CmdletParam(type.ToString(), value));
            if (role != null)
            {
                this.cmdletParams.Add(new CmdletParam("Role", role));
            }
            if (!string.IsNullOrEmpty(slot))
            {
                this.cmdletParams.Add(new CmdletParam("Slot", slot));
            }
            if (!string.IsNullOrEmpty(serviceName))
            {
                this.cmdletParams.Add(new CmdletParam("ServiceName",serviceName));
            }
            if (!string.IsNullOrEmpty(thumbprintAlgorithm))
            {
                this.cmdletParams.Add(new CmdletParam("ThumbprintAlgorithm", thumbprintAlgorithm));
            }
            if (restart)
            {
                this.cmdletParams.Add(new CmdletParam("Restart"));
            }
            if (credential != null)
            {
                this.cmdletParams.Add(new CmdletParam("Credential", credential));
            }
            this.cmdletParams.Add(new CmdletParam("Version", version));
        }

        //constructors for each parameter set

        //BasicDomainParameterSet
        private SetAzureServiceDomainJoinExtensionCmdletInfo(
            string domainName,
            PSCredential unjoinDomainCredential,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string oUPath,
            string version)
            : this(DomainJoinExtensionParameterSetType.DomainName, domainName, role, slot, serviceName, thumbprintAlgorithm, restart, credential, version)
        {
            if (unjoinDomainCredential != null)
            {
                this.cmdletParams.Add(new CmdletParam("UnjoinDomainCredential", unjoinDomainCredential));
            }
            if (!string.IsNullOrEmpty(oUPath))
            {
                this.cmdletParams.Add(new CmdletParam("OUPath",oUPath));
            }
        }

        //DomainJoinParameterSet with X509Certificate2 Certificate
        public SetAzureServiceDomainJoinExtensionCmdletInfo(
            string domainName,
            X509Certificate2 x509Certificate,
            JoinOptions? options,
            PSCredential unjoinDomainCredential,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string oUPath,
            string version)
            : this(domainName, unjoinDomainCredential, role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version)
        {
            if (x509Certificate != null)
            {
                this.cmdletParams.Add(new CmdletParam("X509Certificate", x509Certificate));
            }
            if (options.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("Options", options.Value));
            }
        }

        //DomainJoinParameterSet with X509Certificate2 Certificate and Join Option number
        public SetAzureServiceDomainJoinExtensionCmdletInfo(
            string domainName,
            X509Certificate2 x509Certificate,
            uint? joinOption,
            PSCredential unjoinDomainCredential,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string oUPath,
            string version)
            : this(domainName, unjoinDomainCredential, role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version)
        {
            if (x509Certificate != null)
            {
                this.cmdletParams.Add(new CmdletParam("X509Certificate", x509Certificate));
            }
            if (joinOption.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("JoinOption", joinOption.Value));
            }
        }

        //DomainJoinParameterSet with certificate thumbprint
        public SetAzureServiceDomainJoinExtensionCmdletInfo(
            string domainName,
            string certificateThumbprint,
            JoinOptions? options,
            PSCredential unjoinDomainCredential,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string oUPath,
            string version)
            : this(domainName, unjoinDomainCredential, role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version)
        {
            if (!string.IsNullOrEmpty(certificateThumbprint))
            {
                this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", certificateThumbprint));
            }
            if (options.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("Options", options.Value));
            }
        }

        //DomainJoinParameterSet with certificate thumbprint and Join Option number
        public SetAzureServiceDomainJoinExtensionCmdletInfo(
            string domainName,
            string certificateThumbprint,
            uint? joinOption,
            PSCredential unjoinDomainCredential,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string oUPath,
            string version)
            : this(domainName, unjoinDomainCredential, role, slot, serviceName, thumbprintAlgorithm, restart, credential, oUPath, version)
        {
            if (!string.IsNullOrEmpty(certificateThumbprint))
            {
                this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", certificateThumbprint));
            }
            if (joinOption.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("JoinOption", joinOption.Value));
            }
        }

        // WorkgroupParameterSet
        public SetAzureServiceDomainJoinExtensionCmdletInfo(
            string workGroupName,
            X509Certificate2 x509Certificate,
            string[] role,
            string slot,
            string serviceName,
            bool restart,
            string thumbprintAlgorithm,
            PSCredential credential,
            string version)
            : this(DomainJoinExtensionParameterSetType.WorkgroupName, workGroupName, role, slot, serviceName, thumbprintAlgorithm, restart, credential, version)
        {
            if (x509Certificate != null)
            {
                this.cmdletParams.Add(new CmdletParam("X509Certificate", x509Certificate));
            }
        }

        // WorkgroupThumbprintParameterSet
        public SetAzureServiceDomainJoinExtensionCmdletInfo(
            string workGroupName,
            string certificateThumbprint,
            string[] role,
            string slot,
            string serviceName,
            string thumbprintAlgorithm,
            bool restart,
            PSCredential credential,
            string version)
            : this(DomainJoinExtensionParameterSetType.WorkgroupName, workGroupName, role, slot, serviceName, thumbprintAlgorithm, restart, credential, version)
        {
            if (!string.IsNullOrEmpty(certificateThumbprint))
            {
                this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", certificateThumbprint));
            }
        }
    }
}
