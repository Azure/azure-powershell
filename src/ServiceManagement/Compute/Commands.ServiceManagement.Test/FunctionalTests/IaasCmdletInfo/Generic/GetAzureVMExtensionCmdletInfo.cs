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
    public class GetAzureVMExtensionCmdletInfo : CmdletsInfo
    {
        public GetAzureVMExtensionCmdletInfo(IPersistentVM vm,string extensionName=null, string publisher=null, string version = null, string referenceName = null,
            string publicConfiguration = null, string privateConfiguration = null, bool disable= false)
        {
            cmdletName = Utilities.GetAzureVMExtensionCmdletName;
            cmdletParams.Add(new CmdletParam("VM", vm));
            if (!string.IsNullOrEmpty(extensionName))
            {
                cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            }
            if (!string.IsNullOrEmpty(publisher))
            {
                cmdletParams.Add(new CmdletParam("Publisher", publisher));
            }
            if (!string.IsNullOrEmpty(version))
            {
                cmdletParams.Add(new CmdletParam("Version", version));
            }
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
        }
    }
}
