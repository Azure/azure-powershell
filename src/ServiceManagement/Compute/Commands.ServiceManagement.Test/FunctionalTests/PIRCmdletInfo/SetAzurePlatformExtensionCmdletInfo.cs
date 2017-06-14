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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;
using System;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PIRCmdletInfo
{
    public class SetAzurePlatformExtensionCmdletInfo : CmdletsInfo
    {
        public SetAzurePlatformExtensionCmdletInfo(
            string extensionName, string publisher, string version,
            string label, string description, string company,
            string sample, string eula,  Uri privacyUri, Uri homepage, string extensionMode, string regions)
        {
            this.cmdletName = Utilities.PublishAzurePlatformExtensionCmdletName;

            this.cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            this.cmdletParams.Add(new CmdletParam("Publisher", publisher));
            this.cmdletParams.Add(new CmdletParam("Version", version));

            if (!string.IsNullOrEmpty(label))
            {
                this.cmdletParams.Add(new CmdletParam("Label", label));
            }
            if (!string.IsNullOrEmpty(description))
            {
                this.cmdletParams.Add(new CmdletParam("Description", description));
            }
            if (!string.IsNullOrEmpty(company))
            {
                this.cmdletParams.Add(new CmdletParam("CompanyName", company));
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
            if (!string.IsNullOrEmpty(regions))
            {
                this.cmdletParams.Add(new CmdletParam("Regions", regions));
            }
            if (!string.IsNullOrEmpty(extensionMode))
            {
                this.cmdletParams.Add(new CmdletParam("ExtensionMode", regions));
            }
        }
    }
}
