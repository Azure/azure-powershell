namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Request payload for Update Disk Pool request.</summary>
    public partial class DiskPoolUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateInternal
    {

        /// <summary>List of Azure Managed Disks to attach to a Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] Disk { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdatePropertiesInternal)Property).Disk; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdatePropertiesInternal)Property).Disk = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.DiskPoolUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateProperties _property;

        /// <summary>Properties for Disk Pool update request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.DiskPoolUpdateProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.DiskPoolUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="DiskPoolUpdate" /> instance.</summary>
        public DiskPoolUpdate()
        {

        }
    }
    /// Request payload for Update Disk Pool request.
    public partial interface IDiskPoolUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>List of Azure Managed Disks to attach to a Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Azure Managed Disks to attach to a Disk Pool.",
        SerializedName = @"disks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] Disk { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTags Tag { get; set; }

    }
    /// Request payload for Update Disk Pool request.
    internal partial interface IDiskPoolUpdateInternal

    {
        /// <summary>List of Azure Managed Disks to attach to a Disk Pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDisk[] Disk { get; set; }
        /// <summary>Properties for Disk Pool update request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateProperties Property { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolUpdateTags Tag { get; set; }

    }
}