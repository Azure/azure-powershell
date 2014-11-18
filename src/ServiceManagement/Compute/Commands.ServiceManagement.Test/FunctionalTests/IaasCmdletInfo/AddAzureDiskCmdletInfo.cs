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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class AddAzureDiskCmdletInfo : CmdletsInfo
    {
        public AddAzureDiskCmdletInfo(string diskName, string mediaLocation, string label, string os)
        {
            cmdletName = Utilities.AddAzureDiskCmdletName;
            
            this.cmdletParams.Add(new CmdletParam("DiskName", diskName));
            this.cmdletParams.Add(new CmdletParam("MediaLocation", mediaLocation));
            
            if (label != null)
            {
                this.cmdletParams.Add(new CmdletParam("Label", label));
            }

            if (os != null)
            {
                this.cmdletParams.Add(new CmdletParam("OS", os));
            }
        }
    }
}
