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
    public class RemoveAzurePlatformExtensionEndpointCmdletInfo : CmdletsInfo
    {
        public RemoveAzurePlatformExtensionEndpointCmdletInfo(ExtensionEndpointConfigSet epConfig, string endpointName, string endpointKind)
        {
            this.cmdletName = Utilities.RemoveAzurePlatformExtensionEndpointCmdletName;

            this.cmdletParams.Add(new CmdletParam("EndpointConfig", epConfig));

            if (endpointKind.Equals("Input"))
            {
                this.cmdletParams.Add(new CmdletParam("InputEndpointName", endpointName));
            }
            else if (endpointKind.Equals("Internal"))
            {
                this.cmdletParams.Add(new CmdletParam("InternalEndpointName", endpointName));
            }
            else if (endpointKind.Equals("InstanceInput"))
            {
                this.cmdletParams.Add(new CmdletParam("InstanceInputEndpointName", endpointName));
            }
        }
    }
}
