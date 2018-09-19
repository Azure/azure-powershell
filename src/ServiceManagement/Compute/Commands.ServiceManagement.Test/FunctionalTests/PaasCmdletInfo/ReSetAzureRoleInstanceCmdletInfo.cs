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
    public class ResetAzureRoleInstanceCmdletInfo : CmdletsInfo
    {
        public ResetAzureRoleInstanceCmdletInfo(string serviceName, string instanceName, string slot, bool reboot = false, bool reimage = false)
        {
            cmdletName = Utilities.ResetAzureRoleInstanceCmdletName;
            cmdletParams.Add(new CmdletParam("ServiceName", serviceName));
            cmdletParams.Add(new CmdletParam("InstanceName", instanceName));
            cmdletParams.Add(new CmdletParam("Slot", slot));
            if (reboot)
                cmdletParams.Add(new CmdletParam("Reboot"));
            if (reimage)
                cmdletParams.Add(new CmdletParam("Reimage"));
        }
    }
}
