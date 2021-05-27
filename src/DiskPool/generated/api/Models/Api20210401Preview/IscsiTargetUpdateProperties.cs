namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Properties for iSCSI Target update request.</summary>
    public partial class IscsiTargetUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Lun" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] _lun;

        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get => this._lun; set => this._lun = value; }

        /// <summary>Backing field for <see cref="StaticAcls" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] _staticAcls;

        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get => this._staticAcls; set => this._staticAcls = value; }

        /// <summary>Creates an new <see cref="IscsiTargetUpdateProperties" /> instance.</summary>
        public IscsiTargetUpdateProperties()
        {

        }
    }
    /// Properties for iSCSI Target update request.
    public partial interface IIscsiTargetUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of LUNs to be exposed through iSCSI Target.",
        SerializedName = @"luns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get; set; }
        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Access Control List (ACL) for an iSCSI Target; defines LUN masking policy",
        SerializedName = @"staticAcls",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get; set; }

    }
    /// Properties for iSCSI Target update request.
    internal partial interface IIscsiTargetUpdatePropertiesInternal

    {
        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get; set; }
        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get; set; }

    }
}