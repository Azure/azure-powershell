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
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Update device config for an Azure StorSimple Virtual Device.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleVirtualDevice"), OutputType(typeof(DeviceDetails))]
    public class SetAzureStorSimpleVirtualDevice : StorSimpleCmdletBase
    {
        
        /// <summary>
        /// Friendly Name of the device to configure.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty] 
        public string DeviceName { get; set; }

        /// <summary>
        /// Service Encryption Key for the resource.
        /// </summary>
        [Parameter(Mandatory=true, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.SEK)]
        [ValidateNotNullOrEmpty]
        public string SecretKey { get; set; }

        /// <summary>
        /// Device administrator password
        /// </summary>
        [Parameter(Mandatory=true, Position=2, HelpMessage = StorSimpleCmdletHelpMessage.AdministratorPasswd)]
        [ValidateNotNullOrEmpty]
        public string AdministratorPassword { get; set; }

        /// <summary>
        /// Snapshot manager password
        /// </summary>
        [Parameter(Mandatory=true, Position=3, HelpMessage=StorSimpleCmdletHelpMessage.SnapshotManagerPasswd)]
        [ValidateNotNullOrEmpty]
        public string SnapshotManagerPassword { get; set; }

        /// <summary>
        /// TimeZone for the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.TimeZone, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public TimeZoneInfo TimeZone { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ValidateParams();
                
                // Make sure we have a device for supplied name and get its device id.
                var deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceId == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                }

                // Get the current device details. ( If we found id from the name, this call is bound to succeed)
                var deviceDetails = StorSimpleClient.GetDeviceDetails(deviceId);

                // The cik also needs to be sent to the service.
                string cik = EncryptionCmdLetHelper.RetrieveCIK(this, StorSimpleContext.ResourceId);

                // Update device details.
                var cryptoManager = new StorSimpleCryptoManager(StorSimpleClient);
                StorSimpleClient.UpdateVirtualDeviceDetails(deviceDetails, TimeZone, SecretKey, AdministratorPassword, SnapshotManagerPassword, cik, cryptoManager);
                
                // Make request with updated data
                WriteVerbose(string.Format(Resources.BeginningDeviceConfiguration, deviceDetails.DeviceProperties.FriendlyName));
                var taskStatusInfo = StorSimpleClient.UpdateDeviceDetails(deviceDetails);
                HandleSyncTaskResponse(taskStatusInfo, "Setup");
                if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                {
                    var updatedDetails = StorSimpleClient.GetDeviceDetails(deviceId);
                    WriteObject(updatedDetails);
                    WriteVerbose(string.Format(Resources.StorSimpleDeviceUpdatedSuccessfully, updatedDetails.DeviceProperties.FriendlyName, updatedDetails.DeviceProperties.DeviceId));
                }

            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void ValidateParams() {
            ValidateLength(AdministratorPassword, 8, 15, Resources.AdminPasswordLengthError);
            ValidateLength(SnapshotManagerPassword, 14, 15, Resources.SnapshotPasswordLengthError);
            ValidatePasswordComplexity(AdministratorPassword, "AdministratorPassword");
            ValidatePasswordComplexity(SnapshotManagerPassword, "SnapshotManagerPassword");
        }
    }
}

