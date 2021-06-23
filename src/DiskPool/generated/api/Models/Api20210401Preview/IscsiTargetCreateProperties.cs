namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Properties for iSCSI Target create or update request.</summary>
    public partial class IscsiTargetCreateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetCreatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AclMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode _aclMode;

        /// <summary>Mode for Target connectivity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode AclMode { get => this._aclMode; set => this._aclMode = value; }

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

        /// <summary>Backing field for <see cref="TargetIqn" /> property.</summary>
        private string _targetIqn;

        /// <summary>
        /// iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string TargetIqn { get => this._targetIqn; set => this._targetIqn = value; }

        /// <summary>Creates an new <see cref="IscsiTargetCreateProperties" /> instance.</summary>
        public IscsiTargetCreateProperties()
        {

        }
    }
    /// Properties for iSCSI Target create or update request.
    public partial interface IIscsiTargetCreateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>Mode for Target connectivity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Mode for Target connectivity.",
        SerializedName = @"aclMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode AclMode { get; set; }
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
        /// <summary>
        /// iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"iSCSI Target IQN (iSCSI Qualified Name); example: ""iqn.2005-03.org.iscsi:server"".",
        SerializedName = @"targetIqn",
        PossibleTypes = new [] { typeof(string) })]
        string TargetIqn { get; set; }

    }
    /// Properties for iSCSI Target create or update request.
    internal partial interface IIscsiTargetCreatePropertiesInternal

    {
        /// <summary>Mode for Target connectivity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.IscsiTargetAclMode AclMode { get; set; }
        /// <summary>List of LUNs to be exposed through iSCSI Target.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[] Lun { get; set; }
        /// <summary>Access Control List (ACL) for an iSCSI Target; defines LUN masking policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[] StaticAcls { get; set; }
        /// <summary>
        /// iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server".
        /// </summary>
        string TargetIqn { get; set; }

    }
}