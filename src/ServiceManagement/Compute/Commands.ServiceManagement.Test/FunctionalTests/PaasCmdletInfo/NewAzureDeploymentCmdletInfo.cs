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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PaasCmdletInfo
{
    public class NewAzureDeploymentCmdletInfo : CmdletsInfo
    {
        public NewAzureDeploymentCmdletInfo(string serviceName, string packagePath, string configName, string slot,
            string label, string name, bool doNotStart, bool warning, ExtensionConfigurationInput config)
    {
        cmdletName = Utilities.NewAzureDeploymentCmdletName;

        cmdletParams.Add(new CmdletParam("ServiceName", serviceName));
        cmdletParams.Add(new CmdletParam("Package", packagePath));
        cmdletParams.Add(new CmdletParam("Configuration", configName));
        cmdletParams.Add(new CmdletParam("Slot", slot));

        if (label != null)
        {
            cmdletParams.Add(new CmdletParam("Label", label));
        }
        if (name != null)
        {
            cmdletParams.Add(new CmdletParam("Name", name));
        }
        if (doNotStart)
        {
            cmdletParams.Add(new CmdletParam("DoNotStart"));
        }
        if (warning)
        {
            cmdletParams.Add(new CmdletParam("TreatWarningsAsError"));
        }
        if (config != null)
        {
            cmdletParams.Add(new CmdletParam("ExtensionConfiguration", config));
        }
    }
    }
}
