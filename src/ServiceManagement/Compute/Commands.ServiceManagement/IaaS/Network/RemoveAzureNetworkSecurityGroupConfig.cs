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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Remove, NetworkSecurityGroupConfig), OutputType(typeof(IPersistentVM))]
    public class RemoveAzureNetworkSecurityGroupConfigCommand : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "The Network Security Group Name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkSecurityGroupName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var networkConfiguration = GetNetworkConfiguration();
            if (networkConfiguration == null)
            {
                throw new ArgumentOutOfRangeException(Resources.NetworkConfigurationNotFoundOnPersistentVM);
            }

            if (string.IsNullOrEmpty(this.NetworkSecurityGroupName))
            {
                networkConfiguration.NetworkSecurityGroup = null;
            }
            else if (this.NetworkSecurityGroupName.Equals(networkConfiguration.NetworkSecurityGroup))
            {
                networkConfiguration.NetworkSecurityGroup = null;
            }
            else
            {
                // the specified Network Security Group is not directly associated with this VM
                WriteErrorWithTimestamp(
                    string.Format(
                        Resources.CannotRemoveNetworkSecurityGroupBecauseNotDirectlyAssociatedwithVm,
                        NetworkSecurityGroupName,
                        VM.GetInstance().RoleName));
            }

            WriteObject(VM, true);
        }
    }
}
