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
    public class NewAzureServiceDomainJoinExtensionConfigCmdletInfo: CmdletsInfo
    {
        private NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
        {
            this.cmdletName = Utilities.NewAzureServiceDomainJoinExtensionConfig;

            if(role != null)
            {
                this.cmdletParams.Add(new CmdletParam("Role", role));
            }
            if(!string.IsNullOrEmpty(thumbprintAlgorithm))
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
        }

        // WorkgroupParameterSet
        public NewAzureServiceDomainJoinExtensionConfigCmdletInfo
            (string workGroupName, X509Certificate2 certificate,string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(role, thumbprintAlgorithm, restart, credential, version)
        {
            this.cmdletParams.Add(new CmdletParam("WorkGroupName", workGroupName));
            if (certificate != null)
            {
                this.cmdletParams.Add(new CmdletParam("X509Certificate", certificate));
            }
        }

        // WorkgroupThumbprintParameterSet
        public NewAzureServiceDomainJoinExtensionConfigCmdletInfo
            (string workGroupName, string certificateThumbprint, string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(role, thumbprintAlgorithm, restart, credential, version)
        {
            this.cmdletParams.Add(new CmdletParam("WorkGroupName", workGroupName));
            if (!string.IsNullOrEmpty(certificateThumbprint))
            {
                this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", certificateThumbprint));
            }
        }

        private NewAzureServiceDomainJoinExtensionConfigCmdletInfo
            (string domainName, string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(role, thumbprintAlgorithm, restart, credential, version)
        {
            this.cmdletParams.Add(new CmdletParam("DomainName", domainName));
            if (!string.IsNullOrEmpty(oUPath))
            {
                this.cmdletParams.Add(new CmdletParam("OUPath", oUPath));
            }
            if (unjoinDomainCredential != null)
            {
                this.cmdletParams.Add(new CmdletParam("UnjoinDomainCredential", unjoinDomainCredential));
            }
        }

        private NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string domainName, JoinOptions? options, string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(domainName, oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version)
        {
            if (options.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("Options", options.Value));
            }
        }

        private NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string domainName, uint? joinOption, string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(domainName, oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version)
        {
            if (joinOption.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("JoinOption", joinOption.Value));
            }
        }

        // DomainParameterSet
        public NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string domainName,X509Certificate2 x509Certificate,JoinOptions? options,  string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(domainName, options, oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version)
        {
            if (x509Certificate != null)
            {
                this.cmdletParams.Add(new CmdletParam("X509Certificate", x509Certificate));
            }
        }

        // DomainJoinOptionParameterSet
        public NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string domainName, X509Certificate2 x509Certificate, uint? joinOption, string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(domainName, joinOption, oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version)
        {
            if (x509Certificate != null)
            {
                this.cmdletParams.Add(new CmdletParam("X509Certificate", x509Certificate));
            }
        }

        // DomainThumbprintParameterSet
        public NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string domainName, string certificateThumbprint, JoinOptions? options, string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(domainName, options, oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version)
        {
            if (!string.IsNullOrEmpty(certificateThumbprint))
            {
                this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", certificateThumbprint));
            }
        }

        // DomainJoinOptionThumbprintParameterSet
        public NewAzureServiceDomainJoinExtensionConfigCmdletInfo(string domainName, string certificateThumbprint, uint? joinOption, string oUPath, PSCredential unjoinDomainCredential,
            string[] role, string thumbprintAlgorithm, bool restart, PSCredential credential, string version)
            : this(domainName, joinOption, oUPath, unjoinDomainCredential, role, thumbprintAlgorithm, restart, credential, version)
        {
            if (!string.IsNullOrEmpty(certificateThumbprint))
            {
                this.cmdletParams.Add(new CmdletParam("CertificateThumbprint", certificateThumbprint));
            }
        }
    }
}
