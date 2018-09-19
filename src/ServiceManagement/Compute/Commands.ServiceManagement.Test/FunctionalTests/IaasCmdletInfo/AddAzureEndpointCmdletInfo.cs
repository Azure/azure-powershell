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
    public class AddAzureEndpointCmdletInfo : CmdletsInfo
    {
        public AddAzureEndpointCmdletInfo(AzureEndPointConfigInfo endPointConfig)
        {
            this.cmdletName = Utilities.AddAzureEndpointCmdletName;
              
            this.cmdletParams.Add(new CmdletParam("Name", endPointConfig.EndpointName));
            this.cmdletParams.Add(new CmdletParam("LocalPort", endPointConfig.EndpointLocalPort));
            if (endPointConfig.EndpointPublicPort.HasValue)
            {
                this.cmdletParams.Add(new CmdletParam("PublicPort", endPointConfig.EndpointPublicPort));
            }
            if (endPointConfig.Acl != null)
            {
                this.cmdletParams.Add(new CmdletParam("ACL", endPointConfig.Acl));
            }
            this.cmdletParams.Add(new CmdletParam("Protocol", endPointConfig.EndpointProtocol.ToString()));
            this.cmdletParams.Add(new CmdletParam("VM", endPointConfig.Vm));

            if (endPointConfig.ParamSet == AzureEndPointConfigInfo.ParameterSet.DefaultProbe)
            {
                this.cmdletParams.Add(new CmdletParam("LBSetName", endPointConfig.LBSetName));
                this.cmdletParams.Add(new CmdletParam("DefaultProbe"));
            }
            if (endPointConfig.ParamSet == AzureEndPointConfigInfo.ParameterSet.LoadBalancedNoProbe)
            {
                this.cmdletParams.Add(new CmdletParam("LBSetName", endPointConfig.LBSetName));
                this.cmdletParams.Add(new CmdletParam("NoProbe"));
            }
            else if (endPointConfig.ParamSet == AzureEndPointConfigInfo.ParameterSet.CustomProbe)
            {
                this.cmdletParams.Add(new CmdletParam("LBSetName", endPointConfig.LBSetName));
                this.cmdletParams.Add(new CmdletParam("ProbePort", endPointConfig.ProbePort));
                this.cmdletParams.Add(new CmdletParam("ProbeProtocol", endPointConfig.ProbeProtocol.ToString()));
                if ("http" == endPointConfig.ProbeProtocol.ToString())
                {
                    this.cmdletParams.Add(new CmdletParam("ProbePath", endPointConfig.ProbePath));
                }

                if (endPointConfig.ProbeInterval.HasValue)
                {
                    this.cmdletParams.Add(new CmdletParam("ProbeIntervalInSeconds", endPointConfig.ProbeInterval));
                }

                if (endPointConfig.ProbeTimeout.HasValue)
                {
                    this.cmdletParams.Add(new CmdletParam("ProbeTimeoutInSeconds", endPointConfig.ProbeTimeout));
                }
            }

            if (endPointConfig.DirectServerReturn)
            {
                this.cmdletParams.Add(new CmdletParam("DirectServerReturn", endPointConfig.DirectServerReturn));
            }
            if (!string.IsNullOrEmpty(endPointConfig.InternalLoadBalancerName))
            {
                this.cmdletParams.Add(new CmdletParam("InternalLoadBalancerName", endPointConfig.InternalLoadBalancerName));
            }
            if (! string.IsNullOrEmpty(endPointConfig.LoadBalancerDistribution))
            {
                this.cmdletParams.Add(new CmdletParam("LoadBalancerDistribution", endPointConfig.LoadBalancerDistribution));
            }
            if (!string.IsNullOrEmpty(endPointConfig.VirtualIPName))
            {
                this.cmdletParams.Add(new CmdletParam("VirtualIPName", endPointConfig.VirtualIPName));
            }
        }

        public AddAzureEndpointCmdletInfo()
        {
            this.cmdletName = Utilities.AddAzureEndpointCmdletName;
        }
    }
}
