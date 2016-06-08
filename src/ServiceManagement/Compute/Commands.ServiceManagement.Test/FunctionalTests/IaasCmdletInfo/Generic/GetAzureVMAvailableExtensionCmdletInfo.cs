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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo.Extensions.Common
{
    public class GetAzureVMAvailableExtensionCmdletInfo: CmdletsInfo
    {
        
        private GetAzureVMAvailableExtensionCmdletInfo()
        {
            cmdletName = Utilities.GetAzureVMAvailableExtensionCmdletName;
        }

        //ListLatestExtensionsParamSet -> ExtensionName,Publisher,
        public GetAzureVMAvailableExtensionCmdletInfo(string extensionName = null, string publisher = null)
            :this()
        {
            
            if (!string.IsNullOrEmpty(extensionName))
            {
                cmdletParams.Add(new CmdletParam("ExtensionName", extensionName));
            }
            if (!string.IsNullOrEmpty(publisher))
            {
                cmdletParams.Add(new CmdletParam("Publisher", publisher));
            } 
        }

        //ListAllVersionsParamSetName -> ExtensionName,Publisher,AllVersions
        public GetAzureVMAvailableExtensionCmdletInfo(string extensionName, string publisher, bool allVersions)
            : this(extensionName, publisher)
        {
            if (allVersions)
            {
                cmdletParams.Add(new CmdletParam("AllVersions"));
            }
        }

        //ListSingleVersionParamSetName -> ExtensionName,Publisher,Version
        public GetAzureVMAvailableExtensionCmdletInfo(string extensionName, string publisher, string version)
            : this(extensionName, publisher)
        {
            if (!string.IsNullOrEmpty(publisher))
            {
                cmdletParams.Add(new CmdletParam("Version", version));
            }
        }
    }
}
