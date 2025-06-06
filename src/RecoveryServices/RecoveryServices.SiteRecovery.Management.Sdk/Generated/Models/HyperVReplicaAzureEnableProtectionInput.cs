// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// HyperVReplicaAzure specific enable protection input.
    /// </summary>
    [Newtonsoft.Json.JsonObject("HyperVReplicaAzure")]
    public partial class HyperVReplicaAzureEnableProtectionInput : EnableProtectionProviderSpecificInput
    {
        /// <summary>
        /// Initializes a new instance of the HyperVReplicaAzureEnableProtectionInput class.
        /// </summary>
        public HyperVReplicaAzureEnableProtectionInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HyperVReplicaAzureEnableProtectionInput class.
        /// </summary>

        /// <param name="hvHostVMId">The Hyper-V host VM Id.
        /// </param>

        /// <param name="vmName">The VM Name.
        /// </param>

        /// <param name="osType">The OS type associated with VM.
        /// </param>

        /// <param name="userSelectedOSName">The OS name selected by user.
        /// </param>

        /// <param name="vhdId">The OS disk VHD id associated with VM.
        /// </param>

        /// <param name="targetStorageAccountId">The storage account Id.
        /// </param>

        /// <param name="targetAzureNetworkId">The selected target Azure network Id.
        /// </param>

        /// <param name="targetAzureSubnetId">The selected target Azure subnet Id.
        /// </param>

        /// <param name="enableRdpOnTargetOption">The selected option to enable RDP\SSH on target vm after failover. String
        /// value of SrsDataContract.EnableRDPOnTargetOption enum.
        /// </param>

        /// <param name="targetAzureVMName">The target azure VM Name.
        /// </param>

        /// <param name="logStorageAccountId">The storage account to be used for logging during replication.
        /// </param>

        /// <param name="disksToInclude">The list of VHD Ids of disks to be protected.
        /// </param>

        /// <param name="targetAzureV1ResourceGroupId">The Id of the target resource group (for classic deployment) in which the
        /// failover VM is to be created.
        /// </param>

        /// <param name="targetAzureV2ResourceGroupId">The Id of the target resource group (for resource manager deployment) in
        /// which the failover VM is to be created.
        /// </param>

        /// <param name="useManagedDisks">A value indicating whether managed disks should be used during failover.
        /// </param>

        /// <param name="targetAvailabilitySetId">The target availability set ARM Id for resource manager deployment.
        /// </param>

        /// <param name="targetAvailabilityZone">The target availability zone.
        /// </param>

        /// <param name="licenseType">License type.
        /// Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;WindowsServer&#39;</param>

        /// <param name="sqlServerLicenseType">The SQL Server license type.
        /// Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;PAYG&#39;, &#39;AHUB&#39;</param>

        /// <param name="linuxLicenseType">The license type for Linux VM&#39;s.
        /// Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;LinuxServer&#39;</param>

        /// <param name="targetVMSecurityProfile">The target VM security profile.
        /// </param>

        /// <param name="targetVMSize">The target VM size.
        /// </param>

        /// <param name="targetProximityPlacementGroupId">The proximity placement group ARM Id.
        /// </param>

        /// <param name="useManagedDisksForReplication">A value indicating whether managed disks should be used during replication.
        /// </param>

        /// <param name="diskType">The disk type.
        /// Possible values include: &#39;Standard_LRS&#39;, &#39;Premium_LRS&#39;, &#39;StandardSSD_LRS&#39;,
        /// &#39;PremiumV2_LRS&#39;, &#39;UltraSSD_LRS&#39;, &#39;StandardSSD_ZRS&#39;, &#39;Premium_ZRS&#39;</param>

        /// <param name="disksToIncludeForManagedDisks">The disks to include list for managed disks.
        /// </param>

        /// <param name="diskEncryptionSetId">The DiskEncryptionSet ARM Id.
        /// </param>

        /// <param name="targetVMTags">The target VM tags.
        /// </param>

        /// <param name="seedManagedDiskTags">The tags for the seed managed disks.
        /// </param>

        /// <param name="targetManagedDiskTags">The tags for the target managed disks.
        /// </param>

        /// <param name="targetNicTags">The tags for the target NICs.
        /// </param>
        public HyperVReplicaAzureEnableProtectionInput(string hvHostVMId = default(string), string vmName = default(string), string osType = default(string), string userSelectedOSName = default(string), string vhdId = default(string), string targetStorageAccountId = default(string), string targetAzureNetworkId = default(string), string targetAzureSubnetId = default(string), string enableRdpOnTargetOption = default(string), string targetAzureVMName = default(string), string logStorageAccountId = default(string), System.Collections.Generic.IList<string> disksToInclude = default(System.Collections.Generic.IList<string>), string targetAzureV1ResourceGroupId = default(string), string targetAzureV2ResourceGroupId = default(string), string useManagedDisks = default(string), string targetAvailabilitySetId = default(string), string targetAvailabilityZone = default(string), string licenseType = default(string), string sqlServerLicenseType = default(string), string linuxLicenseType = default(string), SecurityProfileProperties targetVMSecurityProfile = default(SecurityProfileProperties), string targetVMSize = default(string), string targetProximityPlacementGroupId = default(string), string useManagedDisksForReplication = default(string), string diskType = default(string), System.Collections.Generic.IList<HyperVReplicaAzureDiskInputDetails> disksToIncludeForManagedDisks = default(System.Collections.Generic.IList<HyperVReplicaAzureDiskInputDetails>), string diskEncryptionSetId = default(string), System.Collections.Generic.IDictionary<string, string> targetVMTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> seedManagedDiskTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> targetManagedDiskTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> targetNicTags = default(System.Collections.Generic.IDictionary<string, string>))

        {
            this.HvHostVMId = hvHostVMId;
            this.VMName = vmName;
            this.OSType = osType;
            this.UserSelectedOSName = userSelectedOSName;
            this.VhdId = vhdId;
            this.TargetStorageAccountId = targetStorageAccountId;
            this.TargetAzureNetworkId = targetAzureNetworkId;
            this.TargetAzureSubnetId = targetAzureSubnetId;
            this.EnableRdpOnTargetOption = enableRdpOnTargetOption;
            this.TargetAzureVMName = targetAzureVMName;
            this.LogStorageAccountId = logStorageAccountId;
            this.DisksToInclude = disksToInclude;
            this.TargetAzureV1ResourceGroupId = targetAzureV1ResourceGroupId;
            this.TargetAzureV2ResourceGroupId = targetAzureV2ResourceGroupId;
            this.UseManagedDisks = useManagedDisks;
            this.TargetAvailabilitySetId = targetAvailabilitySetId;
            this.TargetAvailabilityZone = targetAvailabilityZone;
            this.LicenseType = licenseType;
            this.SqlServerLicenseType = sqlServerLicenseType;
            this.LinuxLicenseType = linuxLicenseType;
            this.TargetVMSecurityProfile = targetVMSecurityProfile;
            this.TargetVMSize = targetVMSize;
            this.TargetProximityPlacementGroupId = targetProximityPlacementGroupId;
            this.UseManagedDisksForReplication = useManagedDisksForReplication;
            this.DiskType = diskType;
            this.DisksToIncludeForManagedDisks = disksToIncludeForManagedDisks;
            this.DiskEncryptionSetId = diskEncryptionSetId;
            this.TargetVMTags = targetVMTags;
            this.SeedManagedDiskTags = seedManagedDiskTags;
            this.TargetManagedDiskTags = targetManagedDiskTags;
            this.TargetNicTags = targetNicTags;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the Hyper-V host VM Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "hvHostVmId")]
        public string HvHostVMId {get; set; }

        /// <summary>
        /// Gets or sets the VM Name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmName")]
        public string VMName {get; set; }

        /// <summary>
        /// Gets or sets the OS type associated with VM.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "osType")]
        public string OSType {get; set; }

        /// <summary>
        /// Gets or sets the OS name selected by user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "userSelectedOSName")]
        public string UserSelectedOSName {get; set; }

        /// <summary>
        /// Gets or sets the OS disk VHD id associated with VM.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vhdId")]
        public string VhdId {get; set; }

        /// <summary>
        /// Gets or sets the storage account Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetStorageAccountId")]
        public string TargetStorageAccountId {get; set; }

        /// <summary>
        /// Gets or sets the selected target Azure network Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAzureNetworkId")]
        public string TargetAzureNetworkId {get; set; }

        /// <summary>
        /// Gets or sets the selected target Azure subnet Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAzureSubnetId")]
        public string TargetAzureSubnetId {get; set; }

        /// <summary>
        /// Gets or sets the selected option to enable RDP\SSH on target vm after
        /// failover. String value of SrsDataContract.EnableRDPOnTargetOption enum.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableRdpOnTargetOption")]
        public string EnableRdpOnTargetOption {get; set; }

        /// <summary>
        /// Gets or sets the target azure VM Name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAzureVmName")]
        public string TargetAzureVMName {get; set; }

        /// <summary>
        /// Gets or sets the storage account to be used for logging during replication.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "logStorageAccountId")]
        public string LogStorageAccountId {get; set; }

        /// <summary>
        /// Gets or sets the list of VHD Ids of disks to be protected.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "disksToInclude")]
        public System.Collections.Generic.IList<string> DisksToInclude {get; set; }

        /// <summary>
        /// Gets or sets the Id of the target resource group (for classic deployment)
        /// in which the failover VM is to be created.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAzureV1ResourceGroupId")]
        public string TargetAzureV1ResourceGroupId {get; set; }

        /// <summary>
        /// Gets or sets the Id of the target resource group (for resource manager
        /// deployment) in which the failover VM is to be created.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAzureV2ResourceGroupId")]
        public string TargetAzureV2ResourceGroupId {get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether managed disks should be used during
        /// failover.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "useManagedDisks")]
        public string UseManagedDisks {get; set; }

        /// <summary>
        /// Gets or sets the target availability set ARM Id for resource manager
        /// deployment.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAvailabilitySetId")]
        public string TargetAvailabilitySetId {get; set; }

        /// <summary>
        /// Gets or sets the target availability zone.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAvailabilityZone")]
        public string TargetAvailabilityZone {get; set; }

        /// <summary>
        /// Gets or sets license type. Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;WindowsServer&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "licenseType")]
        public string LicenseType {get; set; }

        /// <summary>
        /// Gets or sets the SQL Server license type. Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;PAYG&#39;, &#39;AHUB&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sqlServerLicenseType")]
        public string SqlServerLicenseType {get; set; }

        /// <summary>
        /// Gets or sets the license type for Linux VM&#39;s. Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;LinuxServer&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "linuxLicenseType")]
        public string LinuxLicenseType {get; set; }

        /// <summary>
        /// Gets or sets the target VM security profile.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetVmSecurityProfile")]
        public SecurityProfileProperties TargetVMSecurityProfile {get; set; }

        /// <summary>
        /// Gets or sets the target VM size.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetVmSize")]
        public string TargetVMSize {get; set; }

        /// <summary>
        /// Gets or sets the proximity placement group ARM Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetProximityPlacementGroupId")]
        public string TargetProximityPlacementGroupId {get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether managed disks should be used during
        /// replication.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "useManagedDisksForReplication")]
        public string UseManagedDisksForReplication {get; set; }

        /// <summary>
        /// Gets or sets the disk type. Possible values include: &#39;Standard_LRS&#39;, &#39;Premium_LRS&#39;, &#39;StandardSSD_LRS&#39;, &#39;PremiumV2_LRS&#39;, &#39;UltraSSD_LRS&#39;, &#39;StandardSSD_ZRS&#39;, &#39;Premium_ZRS&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskType")]
        public string DiskType {get; set; }

        /// <summary>
        /// Gets or sets the disks to include list for managed disks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "disksToIncludeForManagedDisks")]
        public System.Collections.Generic.IList<HyperVReplicaAzureDiskInputDetails> DisksToIncludeForManagedDisks {get; set; }

        /// <summary>
        /// Gets or sets the DiskEncryptionSet ARM Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskEncryptionSetId")]
        public string DiskEncryptionSetId {get; set; }

        /// <summary>
        /// Gets or sets the target VM tags.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetVmTags")]
        public System.Collections.Generic.IDictionary<string, string> TargetVMTags {get; set; }

        /// <summary>
        /// Gets or sets the tags for the seed managed disks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seedManagedDiskTags")]
        public System.Collections.Generic.IDictionary<string, string> SeedManagedDiskTags {get; set; }

        /// <summary>
        /// Gets or sets the tags for the target managed disks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetManagedDiskTags")]
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags {get; set; }

        /// <summary>
        /// Gets or sets the tags for the target NICs.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetNicTags")]
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags {get; set; }
    }
}