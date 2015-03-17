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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extensions.Common
{
    public class SetAzureVMExtensionCmdletInfo: CmdletsInfo
    {
        public SetAzureVMExtensionCmdletInfo(IPersistentVM vm, string extensionName, string publisher, string version, string referenceName = null,
            string publicConfiguration = null, string privateConfiguration = null, string publicConfigKey = null, string privateConfigKey = null,
            string publicConfigPath = null,string privateConfigPath =  null, bool disable = false, bool forceUpdate = false)
        {
            cmdletName = Utilities.SetAzureVMExtensionCmdletName;
            cmdletParams.Add(new CmdletParam("VM", vm));
            cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            cmdletParams.Add(new CmdletParam("Publisher", publisher));
            cmdletParams.Add(new CmdletParam("Version", version));

            if (!string.IsNullOrEmpty(referenceName))
            {
                cmdletParams.Add(new CmdletParam("ReferenceName", referenceName));
            }
            if (!string.IsNullOrEmpty(publicConfiguration))
            {
                cmdletParams.Add(new CmdletParam("PublicConfiguration", publicConfiguration));
            }
            if (!string.IsNullOrEmpty(privateConfiguration))
            {
                cmdletParams.Add(new CmdletParam("PrivateConfiguration", privateConfiguration));
            }
            if (disable)
            {
                cmdletParams.Add(new CmdletParam("Disable"));
            }
            if (!string.IsNullOrEmpty(publicConfigPath))
            {
                cmdletParams.Add(new CmdletParam("PublicConfigPath", publicConfigPath));
            }
            if (!string.IsNullOrEmpty(privateConfigPath))
            {
                cmdletParams.Add(new CmdletParam("PrivateConfigPath", privateConfigPath));
            }
            if (!string.IsNullOrEmpty(publicConfigKey))
            {
                cmdletParams.Add(new CmdletParam("PublicConfigKey", publicConfigKey));
            }
            if (!string.IsNullOrEmpty(publicConfigKey))
            {
                cmdletParams.Add(new CmdletParam("PrivateConfigKey", privateConfigKey));
            }
            if (forceUpdate)
            {
                cmdletParams.Add(new CmdletParam("ForceUpdate"));
            }
        }
    }
}
