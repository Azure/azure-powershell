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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Net.Sockets;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Update device config for an Azure StorSimple Device.
    /// 
    /// If the device is being configured for the first time, then some of the
    /// arguments will be mandatory - TimeZone, PrimaryDnsServer, Config for Data0
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleDeviceDetails"), OutputType(typeof(DeviceDetails))]
    public class SetAzureStorSimpleDeviceDetails : StorSimpleCmdletBase
    {
        /// <summary>
        /// Device Id of the device to configure.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceId)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Guid DeviceId
        {
            get { return this.deviceid; }
            set { this.deviceid = value; }
        }
        private System.Guid deviceid;

        /// <summary>
        /// Friendly Name of the device to configure.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName
        {
            get { return this.devicename; }
            set { this.devicename = value; }
        }
        private string devicename;

        /// <summary>
        /// New friendly name for the device.
        /// </summary>
        [Parameter(Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageNewDeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string NewName
        {
            get { return this.newName; }
            set { this.newName = value; }
        }
        private string newName;

        /// <summary>
        /// The following is the definition of the input parameter "TimeZone".       
        /// TimeZone for the device.
        /// </summary>
        [Parameter(Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageTimeZone)]
        [ValidateNotNullOrEmptyAttribute]
        public System.TimeZone TimeZone
        {
            get { return this.timezone; }
            set { this.timezone = value; }
        }
        private System.TimeZone timezone;

        /// <summary>
        /// Primary DNS server for the device.
        /// </summary>
        [Parameter(Position = 3, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessagePrimaryDnsServer)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress PrimaryDnsServer
        {
            get { return this.primarydnsserver; }
            set { this.primarydnsserver = value; }
        }
        private System.Net.IPAddress primarydnsserver;

        /// <summary>
        /// Secondary DNS server for the device.
        /// </summary>
        [Parameter(Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageSecondaryDnsServer)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress SecondaryDnsServer
        {
            get { return this.secondarydnsserver; }
            set { this.secondarydnsserver = value; }
        }
        private System.Net.IPAddress secondarydnsserver;

        /// <summary>
        /// A collection of network configs for interfaces on the device.
        /// </summary>
        [Parameter(Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageStorSimpleNetworkConfig)]
        [ValidateNotNullOrEmptyAttribute]
        public PSObject[] StorSimpleNetworkConfig
        {
            get { return this.storsimplenetworkconfig; }
            set { this.storsimplenetworkconfig = value; }
        }
        private PSObject[] storsimplenetworkconfig;

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
                var deviceDetails = StorSimpleClient.GetDeviceDetails(DeviceId.ToString());
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

                if (!this.ValidateNetworkConfigs(deviceDetails))
                {
                    return;
                }

                // Update device details.
                this.UpdateDeviceDetails(deviceDetails);
                
                // Make request with updated data
                WriteVerbose("About to run a task to configure the device for the first time!");
                var taskStatusInfo = StorSimpleClient.UpdateDeviceDetails(deviceDetails);
                HandleSyncTaskResponse(taskStatusInfo, "Setup");
                if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                {
                    var updatedDetails = StorSimpleClient.GetDeviceDetails(DeviceId.ToString());
                    WriteObject(updatedDetails);
                }

            }
            catch (Exception exception)
            {
            }
        }

        /// <summary>
        /// Validate that all network configs are valid.
        /// 
        /// Its mandatory to provide either (IPv4 Address and netmask) or IPv6 orefix for an interface that
        /// is being enabled. ( Was previously disabled and is now being configured)
        /// </summary>
        /// <returns></returns>
        private bool ValidateNetworkConfigs(DeviceDetails details)
        {
            if(StorSimpleNetworkConfig == null){
                return true;
            }
            foreach(var netConfigObj in StorSimpleNetworkConfig){
                var config = (NetworkConfig)netConfigObj.BaseObject;
                // get corresponding netInterface in device details.
                var netInterface = details.NetInterfaceList.FirstOrDefault(x => x.InterfaceId == config.InterfaceAlias);
                // If its being enabled and its not Data0, it must have IP Address info
                if (netInterface == null || (netInterface.InterfaceId!=NetInterfaceId.Data0 && !netInterface.IsEnabled))
                {
                    // If its not an enabled interface either IPv6(prefix) or IPv4(address and mask) must be provided.
                    if ((config.IPv4Address == null || config.IPv4Netmask == null) && config.IPv6Prefix == null)
                    {
                        WriteVerbose(string.Format(Resources.IPAddressesNotProvidedForNetInterfaceBeingEnabled, StorSimpleContext.ResourceName, DeviceId));
                        WriteObject(null);
                        return false;
                    }
                }
            }
            return true;
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
            var data0 = StorSimpleNetworkConfig.FirstOrDefault(x => ((NetworkConfig)x.BaseObject).InterfaceAlias == NetInterfaceId.Data0);
            if (data0 == null || ((NetworkConfig)data0.BaseObject).Controller0IPv4Address == null)
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

            if (this.timezone != null)
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
                    UpdateDeviceDetailsWithNetworkConfig(deviceDetails, (NetworkConfig)netConfig.BaseObject);
                }
            }
        }

        /// <summary>
        /// Update the specified DeviceDetails object with given network config data
        /// </summary>
        /// <param name="details">DeviceDetails object to be updated</param>
        /// <param name="netConfig">network config object to pick new details from</param>
        internal void UpdateDeviceDetailsWithNetworkConfig(DeviceDetails details, NetworkConfig netConfig)
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

            if (netConfig.IsIscsiEnabled != null)
            {
                netInterface.IsIScsiEnabled = (bool)netConfig.IsIscsiEnabled;
            }
            if (netConfig.IsCloudEnabled != null)
            {
                netInterface.IsCloudEnabled = (bool)netConfig.IsCloudEnabled;
            }
            
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
                DeviceId = new Guid(deviceId);
            }
            return true;
        }
    }
}

