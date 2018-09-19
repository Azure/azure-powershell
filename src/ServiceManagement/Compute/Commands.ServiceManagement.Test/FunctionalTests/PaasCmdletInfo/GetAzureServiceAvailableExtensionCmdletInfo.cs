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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class GetAzureServiceAvailableExtensionCmdletInfo : CmdletsInfo
    {
        public GetAzureServiceAvailableExtensionCmdletInfo(string extensionName, string providerNamespace, string version, bool allVersion)
        {

            this.cmdletName = Utilities.GetAzureServiceAvailableExtensionCmdletName;

            if (!string.IsNullOrEmpty(extensionName))
            {
                this.cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            }
            if (!string.IsNullOrEmpty(providerNamespace))
            {
                this.cmdletParams.Add(new CmdletParam("ProviderNamespace", providerNamespace));
            }
            if (!string.IsNullOrEmpty(version))
            {
                this.cmdletParams.Add(new CmdletParam("Version", version));
            }
            if (allVersion)
            {
                this.cmdletParams.Add(new CmdletParam("AllVersions"));
            }
        }
    }
}
