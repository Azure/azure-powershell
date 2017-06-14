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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PIRCmdletInfo
{
    public class SetAzurePlatformExtensionEndpointCmdletInfo : CmdletsInfo
    {
        public SetAzurePlatformExtensionEndpointCmdletInfo(
            ExtensionEndpointConfigSet endpointConfig,
            string inputEndpoint, string internalEndpoint, string instanceInputlEndpoint,
            string protocol, int? port, string localPort, int? maxPort, int? minPort)
        {
            this.cmdletName = Utilities.SetAzurePlatformExtensionEndpointCmdletName;

            this.cmdletParams.Add(new CmdletParam("EndpointConfig", endpointConfig));

            if (!string.IsNullOrEmpty(inputEndpoint))
            {
                this.cmdletParams.Add(new CmdletParam("InputEndpointName", inputEndpoint));
            }

            if (!string.IsNullOrEmpty(internalEndpoint))
            {
                this.cmdletParams.Add(new CmdletParam("InternalEndpointName", internalEndpoint));
            }

            if (!string.IsNullOrEmpty(instanceInputlEndpoint))
            {
                this.cmdletParams.Add(new CmdletParam("InstanceInputEndpointName", instanceInputlEndpoint));
            }

            this.cmdletParams.Add(new CmdletParam("Protocol", protocol));

            if (port != null)
            {
                this.cmdletParams.Add(new CmdletParam("Port", port));
            }

            if (! string.IsNullOrEmpty(localPort))
            {
                this.cmdletParams.Add(new CmdletParam("LocalPort", localPort));
            }

            if (maxPort != null)
            {
                this.cmdletParams.Add(new CmdletParam("FixedPortMax", maxPort));
            }

            if (minPort != null)
            {
                this.cmdletParams.Add(new CmdletParam("FixedPortMin", minPort));
            }
        }
    }
}
