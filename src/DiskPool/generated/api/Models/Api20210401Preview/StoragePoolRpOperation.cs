namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Description of a StoragePool RP Operation</summary>
    public partial class StoragePoolRpOperation :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperation,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperationInternal
    {

        /// <summary>Backing field for <see cref="ActionType" /> property.</summary>
        private string _actionType;

        /// <summary>Indicates the action type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string ActionType { get => this._actionType; set => this._actionType = value; }

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplay _display;

        /// <summary>Additional metadata about RP operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.StoragePoolOperationDisplay()); set => this._display = value; }

        /// <summary>
        /// Localized friendly description for the operation, as it should be shown to the user.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Description = value ; }

        /// <summary>Localized friendly name for the operation, as it should be shown to the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Operation = value ; }

        /// <summary>Localized friendly form of the resource provider name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Provider = value ; }

        /// <summary>Localized friendly form of the resource type related to this action/operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplayInternal)Display).Resource = value ; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool _isDataAction;

        /// <summary>Indicates whether the operation applies to data-plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public bool IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.StoragePoolOperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the operation being performed on this particular object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Creates an new <see cref="StoragePoolRpOperation" /> instance.</summary>
        public StoragePoolRpOperation()
        {

        }
    }
    /// Description of a StoragePool RP Operation
    public partial interface IStoragePoolRpOperation :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>Indicates the action type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the action type.",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(string) })]
        string ActionType { get; set; }
        /// <summary>
        /// Localized friendly description for the operation, as it should be shown to the user.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Localized friendly description for the operation, as it should be shown to the user.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly name for the operation, as it should be shown to the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Localized friendly name for the operation, as it should be shown to the user.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Localized friendly form of the resource provider name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Localized friendly form of the resource provider name.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Localized friendly form of the resource type related to this action/operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Localized friendly form of the resource type related to this action/operation.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation applies to data-plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicates whether the operation applies to data-plane.",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsDataAction { get; set; }
        /// <summary>The name of the operation being performed on this particular object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the operation being performed on this particular object",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX.",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }

    }
    /// Description of a StoragePool RP Operation
    internal partial interface IStoragePoolRpOperationInternal

    {
        /// <summary>Indicates the action type.</summary>
        string ActionType { get; set; }
        /// <summary>Additional metadata about RP operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationDisplay Display { get; set; }
        /// <summary>
        /// Localized friendly description for the operation, as it should be shown to the user.
        /// </summary>
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly name for the operation, as it should be shown to the user.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Localized friendly form of the resource provider name.</summary>
        string DisplayProvider { get; set; }
        /// <summary>Localized friendly form of the resource type related to this action/operation.</summary>
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation applies to data-plane.</summary>
        bool IsDataAction { get; set; }
        /// <summary>The name of the operation being performed on this particular object</summary>
        string Name { get; set; }
        /// <summary>
        /// The intended executor of the operation; governs the display of the operation in the RBAC UX and the audit logs UX.
        /// </summary>
        string Origin { get; set; }

    }
}