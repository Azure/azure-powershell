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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Update device config for an Azure StorSimple Device.
    /// 
    /// If the device is being configured for the first time, then some of the
    /// arguments will be mandatory - TimeZone, PrimaryDnsServer, Config for Data0
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleDevice", DefaultParameterSetName=StorSimpleCmdletParameterSet.IdentifyByName), OutputType(typeof(DeviceDetails))]
    public class SetAzureStorSimpleDevice : StorSimpleCmdletBase
    {
                /// <summary>
        /// Device Id of the device to configure.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.DeviceId)]
        [ValidateNotNullOrEmpty] 
        public string DeviceId { get; set; }

        /// <summary>
        /// Friendly Name of the device to configure.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty] 
        public string DeviceName { get; set; }

        /// <summary>
        /// New friendly name for the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.NewDeviceName)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }
        
        /// <summary>
        /// TimeZone for the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.TimeZone, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty] 
        public TimeZoneInfo TimeZone { get; set; }

        /// <summary>
        /// Secondary DNS server for the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage = StorSimpleCmdletHelpMessage.SecondaryDnsServer)]
        [ValidateNotNullOrEmpty]
        public string SecondaryDnsServer { get; set; }
        
        /// <summary>
        /// A collection of network configs for interfaces on the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.StorSimpleNetworkConfig, ValueFromPipeline=true)]
        [ValidateNotNullOrEmpty]
        public NetworkConfig[] StorSimpleNetworkConfig { get; set; }

        private IPAddress secondaryDnsServer;

        public override void ExecuteCmdlet()
        {
            try
            {
                // Make sure params were supplied appropriately.
                ProcessParameters();

                // Get the current device details.
                var deviceDetails = StorSimpleClient.GetDeviceDetails(DeviceId);

                if (deviceDetails == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenIdInResourceMessage, StorSimpleContext.ResourceName, DeviceId));
                }

                // If the device is being configured for the first time, validate that mandatory params 
                // for first setup have been provided
                if (!deviceDetails.DeviceProperties.IsConfigUpdated && !ValidParamsForFirstDeviceConfiguration(StorSimpleNetworkConfig, TimeZone, SecondaryDnsServer))
                {
                    throw new ArgumentException(Resources.MandatoryParamsMissingForInitialDeviceConfiguration);
                }

                // Validate Network configs - this method throws an exception if any validation fails
                ValidateNetworkConfigs(deviceDetails, StorSimpleNetworkConfig);
                
                WriteVerbose(string.Format(Resources.BeginningDeviceConfiguration, deviceDetails.DeviceProperties.FriendlyName));

                // Update device details objects with the details provided to the cmdlet
                // and make request with updated data
                var taskStatusInfo = StorSimpleClient.UpdateDeviceDetails(deviceDetails, this.NewName, this.TimeZone, this.secondaryDnsServer, this.StorSimpleNetworkConfig);

                HandleSyncTaskResponse(taskStatusInfo, "Setup");
                if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                {
                    var updatedDetails = StorSimpleClient.GetDeviceDetails(DeviceId.ToString());
                    WriteObject(updatedDetails);
                    WriteVerbose(string.Format(Resources.StorSimpleDeviceUpdatedSuccessfully, updatedDetails.DeviceProperties.FriendlyName, updatedDetails.DeviceProperties.DeviceId));
                }

            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        private void ProcessParameters()
        {
            // Make sure that atleast one of the settings has been provided.
            // Its no use making a request when the user didnt specify any of
            // the settings.
            if (string.IsNullOrEmpty(NewName) && TimeZone == null &&
                string.IsNullOrEmpty(SecondaryDnsServer) &&
                (StorSimpleNetworkConfig == null || StorSimpleNetworkConfig.Count() < 1))
            {
                throw new ArgumentException(Resources.SetAzureStorSimpleDeviceNoSettingsProvided);
            }

            // Make sure that the DeviceId property has the appropriate value irrespective of the parameter set
            if (ParameterSetName == StorSimpleCmdletParameterSet.IdentifyByName)
            {
                var deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceId == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                }
                DeviceId = deviceId;
            }
            TrySetIPAddress(SecondaryDnsServer, out secondaryDnsServer, "SecondaryDnsServer");
        }
    }
}

