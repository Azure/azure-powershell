namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>LUN to expose the Azure Managed Disk.</summary>
    public partial class IscsiLun :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLunInternal
    {

        /// <summary>Backing field for <see cref="Lun" /> property.</summary>
        private int? _lun;

        /// <summary>Specifies the Logical Unit Number of the iSCSI LUN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public int? Lun { get => this._lun; }

        /// <summary>Backing field for <see cref="ManagedDiskAzureResourceId" /> property.</summary>
        private string _managedDiskAzureResourceId;

        /// <summary>Azure Resource ID of the Managed Disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string ManagedDiskAzureResourceId { get => this._managedDiskAzureResourceId; set => this._managedDiskAzureResourceId = value; }

        /// <summary>Internal Acessors for Lun</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLunInternal.Lun { get => this._lun; set { {_lun = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>User defined name for iSCSI LUN; example: "lun0"</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="IscsiLun" /> instance.</summary>
        public IscsiLun()
        {

        }
    }
    /// LUN to expose the Azure Managed Disk.
    public partial interface IIscsiLun :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the Logical Unit Number of the iSCSI LUN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Logical Unit Number of the iSCSI LUN.",
        SerializedName = @"lun",
        PossibleTypes = new [] { typeof(int) })]
        int? Lun { get;  }
        /// <summary>Azure Resource ID of the Managed Disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Azure Resource ID of the Managed Disk.",
        SerializedName = @"managedDiskAzureResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedDiskAzureResourceId { get; set; }
        /// <summary>User defined name for iSCSI LUN; example: "lun0"</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"User defined name for iSCSI LUN; example: ""lun0""",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// LUN to expose the Azure Managed Disk.
    internal partial interface IIscsiLunInternal

    {
        /// <summary>Specifies the Logical Unit Number of the iSCSI LUN.</summary>
        int? Lun { get; set; }
        /// <summary>Azure Resource ID of the Managed Disk.</summary>
        string ManagedDiskAzureResourceId { get; set; }
        /// <summary>User defined name for iSCSI LUN; example: "lun0"</summary>
        string Name { get; set; }

    }
}