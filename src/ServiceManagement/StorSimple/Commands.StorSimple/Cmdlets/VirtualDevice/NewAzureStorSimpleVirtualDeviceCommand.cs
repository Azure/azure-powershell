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
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.VirtualDevice
{
    /// <summary>

    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleVirtualDevice")]
    public class NewAzureStorSimpleVirtualDeviceCommand : StorSimpleCmdletBase, IDynamicParameters
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VirtualDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        public string VirtualDeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VirtualNetworkName, , ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        public string VirtualNetworkName { get; set; }
        
        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.SubNetName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        public string SubNetName { get; set; }
        
        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountNameForVirtualDevice, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        public string StorageAccountName { get; set; }
        
        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.CreateNewStorageAccount, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        public SwitchParameter CreateNewStorageAccount { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var applianceProvisiongInfo = new VirtualApplianceProvisioningInfo()
                {
                    SubscriptionId = CurrentContext.Subscription.Id.ToString(),
                    DeviceName = VirtualDeviceName,
                    ReturnWorkflowId = true,
                    VirtualNetworkName = VirtualNetworkName,
                    SubNetName = SubNetName,
                    StorageAccountName = StorageAccountName,
                    CreateNewStorageAccount = CreateNewStorageAccount.IsPresent
                };

                var deviceJobResponse = StorSimpleClient.CreateVirtualDevice(applianceProvisiongInfo);

                HandleDeviceJobResponse(deviceJobResponse, "add");
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        public object GetDynamicParameters()
        {
            throw new NotImplementedException();
        }
    }

}