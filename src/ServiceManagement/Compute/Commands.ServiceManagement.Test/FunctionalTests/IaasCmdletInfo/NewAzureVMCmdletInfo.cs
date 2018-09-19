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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class NewAzureVMCmdletInfo : CmdletsInfo
    {

        public NewAzureVMCmdletInfo(string serviceName, PersistentVM[] vMs, string vnetName, DnsServer[] dnsSettings,
            string serviceLabel, string serviceDescription, string deploymentLabel, string deploymentName, string location, string affinityGroup, string rsvIPName,InternalLoadBalancerConfig internalLoadBalancerConfig, bool waitForBoot)
        {
            this.cmdletName = Utilities.NewAzureVMCmdletName;

            this.cmdletParams.Add(new CmdletParam("ServiceName", serviceName));
            this.cmdletParams.Add(new CmdletParam("VMs", vMs));

            if (!string.IsNullOrEmpty(vnetName))
            {
                this.cmdletParams.Add(new CmdletParam("VNetName", vnetName));
            }
            if (dnsSettings != null)
            {
                this.cmdletParams.Add(new CmdletParam("DnsSettings", dnsSettings));
            }
            if (!string.IsNullOrEmpty(affinityGroup))
            {
                this.cmdletParams.Add(new CmdletParam("AffinityGroup", affinityGroup));
            }
            if (!string.IsNullOrEmpty(serviceLabel))
            {
                this.cmdletParams.Add(new CmdletParam("ServiceLabel", serviceLabel));
            }
            if (!string.IsNullOrEmpty(serviceDescription))
            {
                this.cmdletParams.Add(new CmdletParam("ServiceDescription", serviceDescription));
            }
            if (!string.IsNullOrEmpty(deploymentLabel))
            {
                this.cmdletParams.Add(new CmdletParam("DeploymentLabel", deploymentLabel));
            }
            if (!string.IsNullOrEmpty(deploymentName))
            {
                this.cmdletParams.Add(new CmdletParam("DeploymentName", deploymentName));
            }
            if (!string.IsNullOrEmpty(location))
            {
                this.cmdletParams.Add(new CmdletParam("Location", location));
            }
            if (!string.IsNullOrEmpty(rsvIPName))
            {
                this.cmdletParams.Add(new CmdletParam("ReservedIPName", rsvIPName));
            }
            if (waitForBoot)
            {
                this.cmdletParams.Add(new CmdletParam("WaitForBoot", waitForBoot));
            }
            if (internalLoadBalancerConfig != null)
            {
                this.cmdletParams.Add(new CmdletParam("InternalLoadBalancerConfig", internalLoadBalancerConfig));
            }
        }
    }
}
