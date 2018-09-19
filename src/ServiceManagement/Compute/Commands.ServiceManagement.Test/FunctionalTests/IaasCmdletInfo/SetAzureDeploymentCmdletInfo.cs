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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class SetAzureDeploymentCmdletInfo : CmdletsInfo
    {

        private SetAzureDeploymentCmdletInfo(string serviceName, string slot)
        {
            this.cmdletName = Utilities.SetAzureDeploymentCmdletName;

            this.cmdletParams.Add(new CmdletParam("ServiceName", serviceName));
            this.cmdletParams.Add(new CmdletParam("Slot", slot));
        }

        public static SetAzureDeploymentCmdletInfo SetAzureDeploymentStatusCmdletInfo(string serviceName, string slot, string newStatus)
        {
            SetAzureDeploymentCmdletInfo result = new SetAzureDeploymentCmdletInfo(serviceName, slot);

            result.cmdletParams.Add(new CmdletParam("Status"));
            result.cmdletParams.Add(new CmdletParam("NewStatus", newStatus));

            return result;
        }


        public static SetAzureDeploymentCmdletInfo SetAzureDeploymentConfigCmdletInfo(string serviceName, string slot, string configPath, ExtensionConfigurationInput extConfig = null)
        {
            SetAzureDeploymentCmdletInfo result = new SetAzureDeploymentCmdletInfo(serviceName, slot);

            result.cmdletParams.Add(new CmdletParam("Config"));
            result.cmdletParams.Add(new CmdletParam("Configuration", configPath));

            if (extConfig != null)
            {
                result.cmdletParams.Add(new CmdletParam("ExtensionConfiguration", extConfig));
            }

            return result;
        }

        public static SetAzureDeploymentCmdletInfo SetAzureDeploymentUpgradeCmdletInfo(
            string serviceName, string slot, string mode, string packagePath, string configPath)
        {
            SetAzureDeploymentCmdletInfo result = new SetAzureDeploymentCmdletInfo(serviceName, slot);

            result.cmdletParams.Add(new CmdletParam("Upgrade"));

            result.cmdletParams.Add(new CmdletParam("Mode", mode));
            result.cmdletParams.Add(new CmdletParam("Package", packagePath));
            result.cmdletParams.Add(new CmdletParam("Configuration", configPath));

            return result;
        }

        public SetAzureDeploymentCmdletInfo(
            string option, 
            string serviceName, 
            string packagePath, 
            string configPath, 
            string newStatus, 
            string slot, 
            string mode, 
            string label, 
            string roleName, 
            bool force)
        {
            cmdletName = Utilities.SetAzureDeploymentCmdletName;

            switch (option)
            {
                case "config":
                    cmdletParams.Add(new CmdletParam("Config"));
                    break;
                case "status":
                    cmdletParams.Add(new CmdletParam("Status"));
                    break;
                case "upgrade":
                    cmdletParams.Add(new CmdletParam("Upgrade"));
                    break;
            }

            cmdletParams.Add(new CmdletParam("ServiceName", serviceName));

            if (!string.IsNullOrEmpty(packagePath))
            {
                cmdletParams.Add(new CmdletParam("Package", packagePath));
            }
            if (!string.IsNullOrEmpty(configPath))
            {
                cmdletParams.Add(new CmdletParam("Configuration", configPath));
            }
            if (!string.IsNullOrEmpty(mode))
            {
                cmdletParams.Add(new CmdletParam("Mode", mode));
            }
            if (!string.IsNullOrEmpty(newStatus))
            {
                cmdletParams.Add(new CmdletParam("NewStatus", newStatus));
            }
            if (!string.IsNullOrEmpty(slot))
            {
                cmdletParams.Add(new CmdletParam("Slot", slot));
            }
            if (!string.IsNullOrEmpty(label))
            {
                cmdletParams.Add(new CmdletParam("Label", label));
            }
            if (!string.IsNullOrEmpty(roleName))
            {
                cmdletParams.Add(new CmdletParam("RoleName", roleName));
            }
            if (force)
            {
                cmdletParams.Add(new CmdletParam("Force"));
            }
        }
    }
}
