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

using Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Compute;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Network;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Network.Models;
using System.Linq;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common
{
    internal class IpUtils
    {
        #region Fields
        private NetworkClient _networkClient;
        private ComputeClient _computeClient;
        private IAzureContext _context;
        #endregion

        public IpUtils(IAzureContext context)
        {
            _context = context;
        }

        #region Properties
        private NetworkClient NetworkClient
        {
            get
            {
                if (_networkClient == null)
                {
                    _networkClient = new NetworkClient(_context);
                }
                return _networkClient;
            }

            set { _networkClient = value; }
        }

        private ComputeClient ComputeClient
        {
            get
            {
                if (_computeClient == null)
                {
                    _computeClient = new ComputeClient(_context);
                }
                return _computeClient;
            }

            set { _computeClient = value; }
        }

        private IVirtualMachinesOperations VirtualMachineClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachines;
            }
        }

        private INetworkInterfacesOperations NetworkInterfacesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.NetworkInterfaces;
            }
        }

        private IPublicIPAddressesOperations PublicIPAddressesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.PublicIPAddresses;
            }
        }

        #endregion

        #region Internal Methods
        /// <summary>
        /// Get an IP address for the target machine.
        /// If the user selected "-UsePrivateIP" this method will return the first private IP it finds.
        /// Otherwise, the function will look for a public ip, and if fails to find that, return a private ip.
        /// </summary>
        /// <param name="vmName">Virtual Machine Name</param>
        /// <param name="rgName">Resource Group Name</param>
        /// <param name="usePrivateIp">Get a Private IP for the VM.</param>
        /// <param name="message">Hint message when public IP is not available</param>
        /// <returns>string containing the ip address</returns>
        public string GetIpAddress(
            string vmName, 
            string rgName,
            bool usePrivateIp,
            out string message)
        {
            string _firstPrivateIp = null;
            string _firstPublicIp = null;
            message = "";

            var result = this.VirtualMachineClient.GetWithHttpMessagesAsync(
                rgName, vmName).GetAwaiter().GetResult();
            VirtualMachine vm = result.Body;

            foreach (var nicReference in vm.NetworkProfile.NetworkInterfaces)
            {
                ResourceIdentifier parsedNicId = new ResourceIdentifier(nicReference.Id);
                NetworkInterface nic;

                try
                {
                    nic = this.NetworkInterfacesClient.GetWithHttpMessagesAsync(
                        parsedNicId.ResourceGroupName, parsedNicId.ResourceName)
                        .GetAwaiter().GetResult().Body;
                }
                catch (CloudException)
                {
                    continue;
                }

                if (_firstPrivateIp == null) { _firstPrivateIp = GetFirstPrivateIp(nic); }
                if (usePrivateIp && _firstPrivateIp != null) { return _firstPrivateIp; }
                if (!usePrivateIp && _firstPublicIp == null) { _firstPublicIp = GetFirstPublicIp(nic); }
                if (!usePrivateIp && _firstPublicIp != null) { return _firstPublicIp; }
            }

            if (!usePrivateIp && _firstPrivateIp != null) 
            {
                message = $"Unable to find public IP. Attempting to connect to private ip {_firstPrivateIp}";
                return _firstPrivateIp;
            }

            return null;
        }

        #endregion

        #region Private Methods
        private string GetFirstPrivateIp(NetworkInterface nic)
        {
            var privateIp = nic.IpConfigurations
            .Where(ipconfig => !string.IsNullOrEmpty(ipconfig.PrivateIPAddress))
            .Select(ipconfig => ipconfig.PrivateIPAddress);          

            if (privateIp.Count() > 0)
            {
                return privateIp.First();
            }

            return null;
        }
        
        private string GetFirstPublicIp(NetworkInterface nic)
        {
            var publicIps = nic.IpConfigurations
                .Where(ipconfig => ipconfig.PublicIPAddress != null)
                .Select(ipconfig => ipconfig.PublicIPAddress);

            PublicIPAddress ipAddress;

            foreach (var ip in publicIps)
            {
                ResourceIdentifier parsedIpId = new ResourceIdentifier(ip.Id);

                try
                {
                    ipAddress = this.PublicIPAddressesClient.GetWithHttpMessagesAsync(
                    parsedIpId.ResourceGroupName, parsedIpId.ResourceName)
                    .GetAwaiter().GetResult().Body;
                }
                catch (CloudException)
                {
                    continue;
                }

                var publicIpAddress = ipAddress.IpAddress;

                if (!string.IsNullOrEmpty(publicIpAddress))
                {
                    return publicIpAddress;
                }
            }

            return null;
        }

        #endregion
    }
}
