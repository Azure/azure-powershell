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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class SetAzureLoadBalancedEndpointCmdletInfo : CmdletsInfo
    {
        public SetAzureLoadBalancedEndpointCmdletInfo()
        {
            this.cmdletName = Utilities.SetAzureLoadBalancedEndpointCmdletName;
        }

        public SetAzureLoadBalancedEndpointCmdletInfo(AzureEndPointConfigInfo endPointConfig, AzureEndPointConfigInfo.ParameterSet paramset)
        {
            this.cmdletName = Utilities.SetAzureLoadBalancedEndpointCmdletName;

            this.cmdletParams.Add(new CmdletParam("ServiceName", endPointConfig.ServiceName));
            this.cmdletParams.Add(new CmdletParam("LocalPort", endPointConfig.EndpointLocalPort));
            if (endPointConfig.EndpointPublicPort.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("PublicPort", endPointConfig.EndpointPublicPort));
            }
            this.cmdletParams.Add(new CmdletParam("Protocol", endPointConfig.EndpointProtocol.ToString()));
            this.cmdletParams.Add(new CmdletParam("LBSetName", endPointConfig.LBSetName));

            switch (paramset)
            {
                case AzureEndPointConfigInfo.ParameterSet.CustomProbe :
                    switch (endPointConfig.ProbeProtocol.ToString())
                    {
                        case "tcp":
                            this.cmdletParams.Add(new CmdletParam("ProbeProtocolTCP"));
                            break;
                        case "http":
                            this.cmdletParams.Add(new CmdletParam("ProbeProtocolHTTP"));
                            this.cmdletParams.Add(new CmdletParam("ProbePath", endPointConfig.ProbePath));
                            break;
                        default:
                            break;
                    }
                    break;

                case AzureEndPointConfigInfo.ParameterSet.DefaultProbe :
                case AzureEndPointConfigInfo.ParameterSet.LoadBalancedNoProbe :
                default :
                    break;
            }

            if (endPointConfig.Acl != null)
            {
                this.cmdletParams.Add(new CmdletParam("ACL", endPointConfig.Acl));
            }
            if (endPointConfig.DirectServerReturn)
            {
                this.cmdletParams.Add(new CmdletParam("DirectServerReturn", endPointConfig.DirectServerReturn));
            }
        }
    }
    
}
