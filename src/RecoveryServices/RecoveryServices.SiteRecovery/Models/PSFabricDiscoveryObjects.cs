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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Fabric Specific Virtual Machine Details for InMageRcm.
    /// </summary>
    public class ASRInMageRcmSpecificVMDetails : ASRFabricSpecificVMDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRInMageRcmSpecificVMDetails" /> class.
        /// </summary>
        /// <param name="properties">Fabric discovery machine properties.</param>
        public ASRInMageRcmSpecificVMDetails(VMwareMachineProperties properties)
        {
            this.BiosGuid = properties.BiosGuid;
            this.InstanceUuid = properties.InstanceUuid;
            this.PowerStatus = properties.PowerStatus;
            this.VCenterFQDN = properties.VCenterFQDN;
            this.VCenterId = properties.VCenterId;
            this.HostName = properties.HostName;
            this.HostVersion = properties.HostVersion;
            this.AllocatedMemoryInMB = properties.AllocatedMemoryInMB;
            this.NumberOfProcessorCore = properties.NumberOfProcessorCore;
            this.NetworkAdapters = properties.NetworkAdapters;
        }

        /// <summary>
        /// Gets or sets the BIOS guid of the machine.
        /// </summary>
        public string BiosGuid { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine instance UUID.
        /// </summary>
        public string InstanceUuid { get; set; }

        /// <summary>
        /// Gets or sets the power status.
        /// </summary>
        public string PowerStatus { get; set; }

        /// <summary>
        /// Gets or sets the VCenter FQDN.
        /// </summary>
        public string VCenterFQDN { get; set; }

        /// <summary>
        /// Gets or sets the VCenter ID.
        /// </summary>
        public string VCenterId { get; set; }

        /// <summary>
        /// Gets or sets the host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the host version.
        /// </summary>
        public string HostVersion { get; set; }

        /// <summary>
        /// Gets or sets allocated memory in MB.
        /// </summary>
        public double AllocatedMemoryInMB { get; set; }

        /// <summary>
        /// Gets or sets number of processor cores.
        /// </summary>
        public int NumberOfProcessorCore { get; set; }

        /// <summary>
        /// Gets or sets the list of network adapters attached to the virtual machine.
        /// </summary>
        public IList<VMwareNetworkAdapter> NetworkAdapters { get; set; }
    }

    #region Fabric discovery client contracts.

    /// <summary>
    /// RunAsAccount details.
    /// </summary>
    public class VMwareRunAsAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VMwareRunAsAccount" /> class.
        /// </summary>
        public VMwareRunAsAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VMwareRunAsAccount" /> class.
        /// </summary>
        /// <param name="id">RunAsAccount ARM Id.</param>
        /// <param name="name">RunAsAccount name.</param>
        /// <param name="type">Type of resource.</param>
        /// <param name="properties">RunAsAccount properties.</param>
        public VMwareRunAsAccount(
            string id = null,
            string name = null,
            string type = null,
            VMwareRunAsAccountProperties properties = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets the ARM Id of the run as account.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the run as account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of resource. Type = Microsoft.OffAzure/VMWareSites/RunAsAccounts.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the run as account properties.
        /// </summary>
        public VMwareRunAsAccountProperties Properties { get; set; }
    }

    /// <summary>
    /// RunAsAccount properties.
    /// </summary>
    public class VMwareRunAsAccountProperties
    {
        /// <summary>
        /// Gets or sets the display name of the run as account.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the credential type of the run as account.
        /// </summary>
        public string CredentialType { get; set; }
    }

    /// <summary>
    /// Discovered machine details.
    /// </summary>
    public class VMwareMachine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VMwareMachine" /> class.
        /// </summary>
        public VMwareMachine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VMwareMachine" /> class.
        /// </summary>
        /// <param name="id">Discovered machine ARM Id.</param>
        /// <param name="name">Discovered machine Name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="properties">Discovered machine properties.</param>
        public VMwareMachine(
            string id = null,
            string name = null,
            string type = null,
            VMwareMachineProperties properties = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets the ARM Id of the discovered machine.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the discovered machine.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of resource. Type = Microsoft.OffAzure/VMWareSites/Machines.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the discovered machine properties.
        /// </summary>
        public VMwareMachineProperties Properties { get; set; }
    }

    /// <summary>
    /// VMware machine properties.
    /// </summary>
    public class VMwareMachineProperties
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the BIOS guid of the machine.
        /// </summary>
        public string BiosGuid { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine instance UUID.
        /// </summary>
        public string InstanceUuid { get; set; }

        /// <summary>
        /// Gets or sets the power status.
        /// </summary>
        public string PowerStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the machine is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the VCenter FQDN.
        /// </summary>
        public string VCenterFQDN { get; set; }

        /// <summary>
        /// Gets or sets the VCenter ID.
        /// </summary>
        public string VCenterId { get; set; }

        /// <summary>
        /// Gets or sets the host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the host version.
        /// </summary>
        public string HostVersion { get; set; }

        /// <summary>
        /// Gets or sets allocated memory in MB.
        /// </summary>
        public double AllocatedMemoryInMB { get; set; }

        /// <summary>
        /// Gets or sets number of processor cores.
        /// </summary>
        public int NumberOfProcessorCore { get; set; }

        /// <summary>
        /// Gets or sets the operating system details.
        /// </summary>
        public OperatingSystem OperatingSystemDetails { get; set; }

        /// <summary>
        /// Gets or sets the list of disks attached to the virtual machine.
        /// </summary>
        public IList<VMwareDisk> Disks { get; set; }

        /// <summary>
        /// Gets or sets the list of network adapters attached to the virtual machine.
        /// </summary>
        public IList<VMwareNetworkAdapter> NetworkAdapters { get; set; }
    }

    /// <summary>
    /// VMware disk details.
    /// </summary>
    public class VMwareDisk
    {
        /// <summary>
        /// Gets or sets the disk size in bytes.
        /// </summary>
        public long MaxSizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the disk name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the disk identifier.
        /// </summary>
        public string Uuid { get; set; }
    }

    /// <summary>
    /// VMware NIC details.
    /// </summary>
    public class VMwareNetworkAdapter
    {
        /// <summary>
        /// Gets or sets the NIC label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the NIC Id.
        /// </summary>
        public string NicId { get; set; }

        /// <summary>
        /// Gets or sets the MAC address.
        /// </summary>
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets or sets the IP address list.
        /// </summary>
        public IList<string> IpAddressList { get; set; }

        /// <summary>
        /// Gets or sets the network name.
        /// </summary>
        public string NetworkName { get; set; }

        /// <summary>
        /// Gets or sets the IP address type.
        /// </summary>
        public string IpAddressType { get; set; }
    }

    /// <summary>
    /// Operating system details.
    /// </summary>
    public class OperatingSystem
    {
        /// <summary>
        /// Gets or sets the type of the operating system.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets the name of the operating system.
        /// </summary>
        public string OsName { get; set; }

        /// <summary>
        /// Gets or sets the version of the operating system.
        /// </summary>
        public string OsVersion { get; set; }
    }

    #endregion Fabric Discovery contracts.
}
