namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Properties for Disk Pool create or update request.</summary>
    public partial class DiskPoolCreateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolCreateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolCreatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdditionalCapability" /> property.</summary>
        private string[] _additionalCapability;

        /// <summary>List of additional capabilities for a Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string[] AdditionalCapability { get => this._additionalCapability; set => this._additionalCapability = value; }

        /// <summary>Backing field for <see cref="AvailabilityZone" /> property.</summary>
        private string[] _availabilityZone;

        /// <summary>Logical zone for Disk Pool resource; example: ["1"].</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string[] AvailabilityZone { get => this._availabilityZone; set => this._availabilityZone = value; }

        /// <summary>Backing field for <see cref="Disk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] _disk;

        /// <summary>List of Azure Managed Disks to attach to a Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] Disk { get => this._disk; set => this._disk = value; }

        /// <summary>Backing field for <see cref="SubnetId" /> property.</summary>
        private string _subnetId;

        /// <summary>Azure Resource ID of a Subnet for the Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string SubnetId { get => this._subnetId; set => this._subnetId = value; }

        /// <summary>Creates an new <see cref="DiskPoolCreateProperties" /> instance.</summary>
        public DiskPoolCreateProperties()
        {

        }
    }
    /// Properties for Disk Pool create or update request.
    public partial interface IDiskPoolCreateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>List of additional capabilities for a Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of additional capabilities for a Disk Pool.",
        SerializedName = @"additionalCapabilities",
        PossibleTypes = new [] { typeof(string) })]
        string[] AdditionalCapability { get; set; }
        /// <summary>Logical zone for Disk Pool resource; example: ["1"].</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Logical zone for Disk Pool resource; example: [""1""].",
        SerializedName = @"availabilityZones",
        PossibleTypes = new [] { typeof(string) })]
        string[] AvailabilityZone { get; set; }
        /// <summary>List of Azure Managed Disks to attach to a Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Azure Managed Disks to attach to a Disk Pool.",
        SerializedName = @"disks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] Disk { get; set; }
        /// <summary>Azure Resource ID of a Subnet for the Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Azure Resource ID of a Subnet for the Disk Pool.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    /// Properties for Disk Pool create or update request.
    internal partial interface IDiskPoolCreatePropertiesInternal

    {
        /// <summary>List of additional capabilities for a Disk Pool.</summary>
        string[] AdditionalCapability { get; set; }
        /// <summary>Logical zone for Disk Pool resource; example: ["1"].</summary>
        string[] AvailabilityZone { get; set; }
        /// <summary>List of Azure Managed Disks to attach to a Disk Pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] Disk { get; set; }
        /// <summary>Azure Resource ID of a Subnet for the Disk Pool.</summary>
        string SubnetId { get; set; }

    }
}