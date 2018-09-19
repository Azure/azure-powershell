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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using System.Net;
using System.Net.Sockets;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public IEnumerable<DeviceInfo> GetAllDevices()
        {
            return this.GetStorSimpleClient().Devices.List(this.GetCustomRequestHeaders());
        }

        public DeviceDetails GetDeviceDetails(string deviceId)
        {
            var deviceDetailsResponse = this.GetStorSimpleClient().DeviceDetails.Get(deviceId, this.GetCustomRequestHeaders());
            if (deviceDetailsResponse == null)
            {
                return null;
            }
            return deviceDetailsResponse.DeviceDetails;
        }

        /// <summary>
        /// Update device details for specified device given the specified data
        /// </summary>
        /// <param name="deviceDetails">Current device details for the device.</param>
        /// <param name="newName">New friendly name for the device. Null if its not to be changed</param>
        /// <param name="timeZone">New timeZone value for the device. Null if its not to be changed</param>
        /// <param name="secondaryDnsServer">New Secondary DNS Server address for the device. Null if its not to be changed</param>
        /// <param name="networkConfigs">An array or NetworkConfig objects for different interfaces. Null if its not to be changed</param>
        /// <returns></returns>
        public TaskStatusInfo UpdateDeviceDetails(DeviceDetails deviceDetails, string newName, TimeZoneInfo timeZone, IPAddress secondaryDnsServer, NetworkConfig[] networkConfigs)
        {
            // Update the object
            this.UpdateDeviceDetailsObject(deviceDetails, newName, timeZone, secondaryDnsServer, networkConfigs);
            // Copy stuff over from the DeviceDetails object into a new DeviceDetailsRequest object.
            var request = new DeviceDetailsRequest();
            MiscUtils.CopyProperties(deviceDetails, request);
            var taskStatusInfo = this.GetStorSimpleClient().DeviceDetails.UpdateDeviceDetails(request, this.GetCustomRequestHeaders());
            return taskStatusInfo;
        }

        /// <summary>
        /// Update device details for a device by passing the updated details themselves.
        /// </summary>
        /// <param name="updatedDetails">The new state of DeviceDetails for the device.</param>
        /// <returns></returns>
        public TaskStatusInfo UpdateDeviceDetails(DeviceDetails updatedDetails)
        {
            var request = new DeviceDetailsRequest();
            MiscUtils.CopyProperties(updatedDetails, request);
            var taskStatusInfo = this.GetStorSimpleClient().DeviceDetails.UpdateDeviceDetails(request, this.GetCustomRequestHeaders());
            return taskStatusInfo;
        }

        public bool IsValidDeviceId(string deviceId)
        {
            if (string.IsNullOrWhiteSpace(deviceId)) throw new ArgumentNullException("deviceId");
            var deviceInfos = GetAllDevices();
            foreach (var deviceInfo in deviceInfos)
            {
                if (deviceInfo.DeviceId.Equals(deviceId, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public string GetDeviceId(string deviceToUse)
        {
            if (deviceToUse == null) throw new ArgumentNullException("deviceToUse");
            var deviceInfos = GetAllDevices();
            return (from deviceInfo in deviceInfos where deviceInfo.FriendlyName.Equals(deviceToUse, StringComparison.InvariantCultureIgnoreCase) select deviceInfo.DeviceId).FirstOrDefault();
        }

        public List<IscsiConnection> GetAllIscsiConnections(string deviceId)
        {
            var iscsiConnectionResponse =  GetStorSimpleClient().IscsiConnection.Get(deviceId, GetCustomRequestHeaders());
            if (iscsiConnectionResponse == null || iscsiConnectionResponse.IscsiConnections == null)
            {
                return null;
            }
            return iscsiConnectionResponse.IscsiConnections.ToList();
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

            // Make sure that the interface gets enabled as well
            netInterface.IsEnabled = true;
        }

        /// <summary>
        /// Modify the provided DeviceDetails object with the data provided
        /// </summary>
        /// <param name="details"></param>
        private void UpdateDeviceDetailsObject(DeviceDetails deviceDetails, string newName, TimeZoneInfo timeZone, IPAddress secondaryDnsServer, NetworkConfig[] networkConfigs)
        {
            // modify details for non-null data provided to cmdlet

            if (!string.IsNullOrEmpty(newName))
            {
                deviceDetails.DeviceProperties.FriendlyName = newName;
            }

            if (timeZone != null)
            {
                deviceDetails.TimeServer.TimeZone = timeZone.StandardName;
            }

            if (secondaryDnsServer != null)
            {
                var secondaryDnsString = secondaryDnsServer.ToString();
                var secondaryDnsType = secondaryDnsServer.AddressFamily;
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

            if (networkConfigs != null && networkConfigs.Count()  > 0)
            {
                foreach (var netConfig in networkConfigs)
                {
                    this.UpdateDeviceDetailsWithNetworkConfig(deviceDetails, netConfig);
                }
            }

            // There are a bunch of details that this cmdlet never edits and the service 
            // considers null values for them to mean that there have been no changes.
            deviceDetails.AlertNotification = null;
            deviceDetails.Chap = null;
            deviceDetails.RemoteMgmtSettingsInfo = null;
            deviceDetails.RemoteMinishellSecretInfo = null;
            deviceDetails.SecretEncryptionCertThumbprint = null;
            deviceDetails.Snapshot = null;
            deviceDetails.VirtualApplianceProperties = null;
            deviceDetails.WebProxy = null;
        }

        public void UpdateVirtualDeviceDetails(DeviceDetails details, TimeZoneInfo timeZone, string sek, string adminPasswd, string snapshotPasswd, string cik, StorSimpleCryptoManager cryptoManager)
        {
            if (timeZone != null)
            {
                details.TimeServer.TimeZone = timeZone.StandardName;
            }
            // encrypt supplied secret with the device public key
            var encryptedSecretKey = this.EncryptWithDevicePublicKey(details.DeviceProperties.DeviceId, sek);

            details.VirtualApplianceProperties.EncodedServiceEncryptionKey = encryptedSecretKey;

            // Also set the CIK before making the request - service needs it.
            var encryptedCik = this.EncryptWithDevicePublicKey(details.DeviceProperties.DeviceId, cik);
            details.VirtualApplianceProperties.EncodedChannelIntegrityKey = encryptedCik;

            // Set the admin password
            string encryptedAdminPasswd = null;
            cryptoManager.EncryptSecretWithRakPub(adminPasswd, out encryptedAdminPasswd);
            details.RemoteMinishellSecretInfo.MinishellSecret = encryptedAdminPasswd;

            // Set the snapshot manager password
            string encryptedSnapshotManagerPasswd = null;
            cryptoManager.EncryptSecretWithRakPub(snapshotPasswd, out encryptedSnapshotManagerPasswd);
            details.Snapshot.SnapshotSecret = encryptedSnapshotManagerPasswd;

            // Set the cert thumbprint for the key used.
            details.SecretEncryptionCertThumbprint = cryptoManager.GetSecretsEncryptionThumbprint();

            // mark everything that we dont intend to modify as null - indicating
            // to the service that there has been no change
            details.AlertNotification = null;
            details.Chap = null;
            details.DnsServer = null;
            details.NetInterfaceList = null;
            details.RemoteMgmtSettingsInfo = null;
            details.WebProxy = null;
        }
    }
}