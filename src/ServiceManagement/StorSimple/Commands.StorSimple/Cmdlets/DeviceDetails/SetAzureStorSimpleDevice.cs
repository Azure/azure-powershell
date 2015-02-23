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
using Hyak.Common;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;

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
        [Parameter(Mandatory = false, Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.TimeZone)]
        [ValidateNotNullOrEmpty] 
        public TimeZoneInfo TimeZone { get; set; }

        /// <summary>
        /// Primary DNS server for the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage = StorSimpleCmdletHelpMessage.PrimaryDnsServer)]
        [ValidateNotNullOrEmpty]
        public IPAddress PrimaryDnsServer { get; set; }
        
        /// <summary>
        /// Secondary DNS server for the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.SecondaryDnsServer)]
        [ValidateNotNullOrEmpty]
        public IPAddress SecondaryDnsServer { get; set; }
        
        /// <summary>
        /// A collection of network configs for interfaces on the device.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.StorSimpleNetworkConfig)]
        [ValidateNotNullOrEmpty]
        public NetworkConfig[] StorSimpleNetworkConfig { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                // Make sure params were supplied appropriately.
                if (!ProcessParameters())
                {
                    return;
                }

                // Get the current device details.
                var deviceDetails = StorSimpleClient.GetDeviceDetails(DeviceId);

                if (deviceDetails == null)
                {
                    WriteVerbose(string.Format(Resources.NoDeviceFoundWithGivenIdInResourceMessage, StorSimpleContext.ResourceName, DeviceId));
                    WriteObject(null);
                    return;
                }

                // If the device is being configured for the first time, validate that mandatory params 
                // for first setup have been provided
                if (!this.IsDeviceConfigurationCompleteForDevice(deviceDetails) && !ValidParamsForFirstDeviceConfiguration())
                {
                    WriteVerbose(Resources.MandatoryParamsMissingForInitialDeviceConfiguration);
                    WriteObject(null);
                    return;
                }

                if (!this.ValidateNetworkConfigs(deviceDetails, StorSimpleNetworkConfig))
                {
                    return;
                }

                
                WriteVerbose(string.Format(Resources.BeginningDeviceConfiguration, deviceDetails.DeviceProperties.FriendlyName));

                // Update device details.
                this.UpdateDeviceDetails(deviceDetails);

                // Make request with updated data
                var taskStatusInfo = StorSimpleClient.UpdateDeviceDetails(deviceDetails);
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

        /// <summary>
        /// Update the specified DeviceDetails object with given network config data
        /// </summary>
        /// <param name="details">DeviceDetails object to be updated</param>
        /// <param name="netConfig">network config object to pick new details from</param>
        private void UpdateDeviceDetailsWithNetworkConfig(DeviceDetails details, NetworkConfig netConfig)
        {
            // See if deviceDetails already has an object for the interface for which network config has been provided.
            // If not, then a new object is to be provided.
            var netInterface = details.NetInterfaceList.FirstOrDefault(x => x.InterfaceId == netConfig.InterfaceAlias);
            if (netInterface == null)
            {
                netInterface = new NetInterface
                {
                    NicIPv4Settings = new NicIPv4(),
                    NicIPv6Settings = new NicIPv6()
                };
                details.NetInterfaceList.Add(netInterface);
            }

            netInterface.IsIScsiEnabled = netConfig.IsIscsiEnabled.HasValue ? netConfig.IsIscsiEnabled.Value : netInterface.IsIScsiEnabled;

            netInterface.IsCloudEnabled = netConfig.IsCloudEnabled.HasValue ? netConfig.IsCloudEnabled.Value : netInterface.IsCloudEnabled;

            if (netConfig.InterfaceAlias == NetInterfaceId.Data0)
            {   // Other interfaces are not supposed to have controller IPs
                if (netConfig.Controller0IPv4Address != null)
                {
                    netInterface.NicIPv4Settings.Controller0IPv4Address = netConfig.Controller0IPv4Address.ToString();
                }
                if (netConfig.Controller1IPv4Address != null)
                {
                    netInterface.NicIPv4Settings.Controller1IPv4Address = netConfig.Controller1IPv4Address.ToString();
                }
            }
            if (netConfig.IPv4Gateway != null)
            {
                netInterface.NicIPv4Settings.IPv4Gateway = netConfig.IPv4Gateway.ToString();
            }
            if (netConfig.IPv4Address != null)
            {
                netInterface.NicIPv4Settings.IPv4Address = netConfig.IPv4Address.ToString();
            }
            if (netConfig.IPv4Netmask != null)
            {
                netInterface.NicIPv4Settings.IPv4Netmask = netConfig.IPv4Netmask.ToString();
            }
            if (netConfig.IPv6Prefix != null)
            {
                netInterface.NicIPv6Settings.IPv6Prefix = netConfig.IPv6Prefix.ToString();
            }
            if (netConfig.IPv6Gateway != null)
            {
                netInterface.NicIPv6Settings.IPv6Gateway = netConfig.IPv6Gateway.ToString();
            }
        }

        /// <summary>
        /// Modify the provided DeviceDetails object with the data provided to the commandlet.
        /// </summary>
        /// <param name="details"></param>
        private void UpdateDeviceDetails(DeviceDetails deviceDetails){
            // modify details for non-null data provided to cmdlet

            if (!string.IsNullOrEmpty(this.NewName))
            {
                deviceDetails.DeviceProperties.FriendlyName = this.NewName;
            }

            if (this.TimeZone != null)
            {
                deviceDetails.TimeServer.TimeZone = this.TimeZone.StandardName;
            }
            if (this.PrimaryDnsServer != null)
            {
                var primaryDnsString = this.PrimaryDnsServer.ToString();
                var primaryDnsType = this.PrimaryDnsServer.AddressFamily;
                if (primaryDnsType == AddressFamily.InterNetwork)   // IPv4
                {
                    deviceDetails.DnsServer.PrimaryIPv4 = primaryDnsString;
                }
                else if (primaryDnsType == AddressFamily.InterNetworkV6)
                {
                    deviceDetails.DnsServer.PrimaryIPv6 = primaryDnsString;
                }
            }
            if (this.SecondaryDnsServer != null)
            {
                var secondaryDnsString = this.SecondaryDnsServer.ToString();
                var secondaryDnsType = this.SecondaryDnsServer.AddressFamily;
                if (secondaryDnsType == AddressFamily.InterNetwork)   // IPv4
                {
                    deviceDetails.DnsServer.SecondaryIPv4.Clear();
                    deviceDetails.DnsServer.SecondaryIPv4.Add(secondaryDnsString);
                }
                else if (secondaryDnsType == AddressFamily.InterNetworkV6)
                {
                    deviceDetails.DnsServer.SecondaryIPv6.Clear();
                    deviceDetails.DnsServer.SecondaryIPv6.Add(secondaryDnsString);
                }
            }

            if (this.StorSimpleNetworkConfig != null)
            {
                foreach (var netConfig in this.StorSimpleNetworkConfig)
                {
                    UpdateDeviceDetailsWithNetworkConfig(deviceDetails, netConfig);
                }
            }

            // There are a bunch of details that this cmdlet never edits and the service considers null
            // values there to mean that there have been no changes.
            deviceDetails.AlertNotification = null;
            deviceDetails.Chap = null;
            deviceDetails.RemoteMgmtSettingsInfo = null;
            deviceDetails.RemoteMinishellSecretInfo = null;
            deviceDetails.SecretEncryptionCertThumbprint = null;
            deviceDetails.Snapshot = null;
            deviceDetails.VirtualApplianceProperties = null;
            deviceDetails.WebProxy = null;
        }

        /// <summary>
        /// Validate that all mandatory data for the first Device Configuration has been provided.
        /// </summary>
        /// <returns>bool indicating whether all mandatory data is there or not.</returns>
        private bool ValidParamsForFirstDeviceConfiguration()
        {
            if (StorSimpleNetworkConfig == null)
            {
                return false;
            }
            // Make sure network config for Data0 has been provided with atleast Controller0 IP Address
            var data0 = StorSimpleNetworkConfig.FirstOrDefault(x => x.InterfaceAlias == NetInterfaceId.Data0);
            if (data0 == null || data0.Controller0IPv4Address == null)
            {
                return false;
            }
            // Timezone and Primary Dns Server are also mandatory
            if (TimeZone == null || PrimaryDnsServer == null)
            {
                return false;
            }
            return true;
        }

        private bool ProcessParameters()
        {
            // Make sure that the DeviceId property has the appropriate value irrespective of the parameter set
            if (ParameterSetName == StorSimpleCmdletParameterSet.IdentifyByName)
            {
                var deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceId == null)
                {
                    WriteVerbose(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                    WriteObject(null);
                    return false;
                }
                DeviceId = deviceId;
            }
            return true;
        }
    }
}

