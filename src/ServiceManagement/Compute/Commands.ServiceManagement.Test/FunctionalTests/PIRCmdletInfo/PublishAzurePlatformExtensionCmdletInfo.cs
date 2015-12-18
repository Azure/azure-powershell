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

using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;
using System;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PIRCmdletInfo
{
    public class PublishAzurePlatformExtensionCmdletInfo : CmdletsInfo
    {
        public PublishAzurePlatformExtensionCmdletInfo(
            string extensionName, string publisher, string version, string hr,
            Uri media, string label, string description, string company,
            ExtensionCertificateConfig certConfig, ExtensionEndpointConfigSet epConfig, ExtensionLocalResourceConfigSet lrConfig,
            DateTime publishDate, string publicSchema, string privateSchema, string sample,
            string eula,  Uri privacyUri, Uri homepage, string os, string regions,
            bool blockRole, bool disallowUpgrade, bool xmlExtension, bool force)
        {
            this.cmdletName = Utilities.PublishAzurePlatformExtensionCmdletName;

            this.cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            this.cmdletParams.Add(new CmdletParam("Publisher", publisher));
            this.cmdletParams.Add(new CmdletParam("Version", version));

            this.cmdletParams.Add(new CmdletParam("HostingResources", hr));
            this.cmdletParams.Add(new CmdletParam("MediaLink", media));
            this.cmdletParams.Add(new CmdletParam("Label", label));
            this.cmdletParams.Add(new CmdletParam("Description", description));
             this.cmdletParams.Add(new CmdletParam("CompanyName", company));

            if (certConfig != null)
            {
                this.cmdletParams.Add(new CmdletParam("CertificateConfig", certConfig));
            }

            if (epConfig != null)
            {
                this.cmdletParams.Add(new CmdletParam("EndpointConfig", epConfig));
            }

            if (lrConfig != null)
            {
                this.cmdletParams.Add(new CmdletParam("LocalResourceConfig", lrConfig));
            }

            this.cmdletParams.Add(new CmdletParam("PublishedDate", publishDate));

            if (!string.IsNullOrEmpty(publicSchema))
            {
                this.cmdletParams.Add(new CmdletParam("PublicConfigurationSchema", publicSchema));
            }
            if (!string.IsNullOrEmpty(privateSchema))
            {
                this.cmdletParams.Add(new CmdletParam("PrivateConfigurationSchema", privateSchema));
            }
            if (!string.IsNullOrEmpty(sample))
            {
                this.cmdletParams.Add(new CmdletParam("SampleConfig", sample));
            }

            if (!string.IsNullOrEmpty(eula))
            {
                this.cmdletParams.Add(new CmdletParam("Eula", eula));
            }
            if (privacyUri != null)
            {
                this.cmdletParams.Add(new CmdletParam("PrivacyUri", privacyUri));
            }
            if (homepage != null)
            {
                this.cmdletParams.Add(new CmdletParam("HomepageUri", homepage));
            }
            if (!string.IsNullOrEmpty(os))
            {
                 this.cmdletParams.Add(new CmdletParam("SupportedOS", os));
            }
            if (!string.IsNullOrEmpty(regions))
            {
                this.cmdletParams.Add(new CmdletParam("Regions", regions));
            }

            if (blockRole)
            {
                this.cmdletParams.Add(new CmdletParam("BlockRoleUponFailure"));
            }

            if (disallowUpgrade)
            {
                this.cmdletParams.Add(new CmdletParam("DisallowMajorVersionUpgrade"));
            }

            if (xmlExtension)
            {
                this.cmdletParams.Add(new CmdletParam("XmlExtension"));
            }

            if (force)
            {
                this.cmdletParams.Add(new CmdletParam("Force"));
            }
        }
    }
}
