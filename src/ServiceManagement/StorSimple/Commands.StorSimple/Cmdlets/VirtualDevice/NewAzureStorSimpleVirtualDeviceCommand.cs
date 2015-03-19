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
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleVirtualDevice"), OutputType(typeof(string))]
    public class NewAzureStorSimpleVirtualDeviceCommand : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VirtualDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.CreateNewStorageAccount)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VirtualDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.UseExistingStorageAccount)]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string VirtualDeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VirtualNetworkName, ParameterSetName = StorSimpleCmdletParameterSet.CreateNewStorageAccount)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VirtualNetworkName, ParameterSetName = StorSimpleCmdletParameterSet.UseExistingStorageAccount)]
        [Alias("VNetName")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.SubNetName, ParameterSetName = StorSimpleCmdletParameterSet.CreateNewStorageAccount)]
        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.SubNetName, ParameterSetName = StorSimpleCmdletParameterSet.UseExistingStorageAccount)]
        [ValidateNotNullOrEmpty]
        public string SubNetName { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountNameForVirtualDevice, ParameterSetName = StorSimpleCmdletParameterSet.CreateNewStorageAccount)]
        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.StorageAccountNameForVirtualDevice, ParameterSetName = StorSimpleCmdletParameterSet.UseExistingStorageAccount)]
        public string StorageAccountName { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.CreateNewStorageAccount, ParameterSetName = StorSimpleCmdletParameterSet.CreateNewStorageAccount)]
        public SwitchParameter CreateNewStorageAccount { get; set; }
        
        public override void ExecuteCmdlet()
        {
            try
            {
                var applianceProvisiongInfo = new VirtualDeviceProvisioningInfo()
                {
                    SubscriptionId = Profile.Context.Subscription.Id.ToString(),
                    DeviceName = VirtualDeviceName,
                    ReturnWorkflowId = true,
                    VirtualNetworkName = VirtualNetworkName,
                    SubNetName = SubNetName,
                    CreateNewStorageAccount = CreateNewStorageAccount.IsPresent,
                    StorageAccountName = StorageAccountName
                };

                var deviceJobResponse = StorSimpleClient.CreateVirtualDevice(applianceProvisiongInfo);

                HandleDeviceJobResponse(deviceJobResponse, "create");
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }

}