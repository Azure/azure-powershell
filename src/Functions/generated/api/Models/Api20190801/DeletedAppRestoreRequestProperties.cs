namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DeletedAppRestoreRequest resource specific properties</summary>
    public partial class DeletedAppRestoreRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DeletedSiteId" /> property.</summary>
        private string _deletedSiteId;

        /// <summary>
        /// ARM resource ID of the deleted app. Example:
        /// /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DeletedSiteId { get => this._deletedSiteId; set => this._deletedSiteId = value; }

        /// <summary>Backing field for <see cref="RecoverConfiguration" /> property.</summary>
        private bool? _recoverConfiguration;

        /// <summary>If true, deleted site configuration, in addition to content, will be restored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? RecoverConfiguration { get => this._recoverConfiguration; set => this._recoverConfiguration = value; }

        /// <summary>Backing field for <see cref="SnapshotTime" /> property.</summary>
        private string _snapshotTime;

        /// <summary>
        /// Point in time to restore the deleted app from, formatted as a DateTime string.
        /// If unspecified, default value is the time that the app was deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SnapshotTime { get => this._snapshotTime; set => this._snapshotTime = value; }

        /// <summary>Backing field for <see cref="UseDrSecondary" /> property.</summary>
        private bool? _useDrSecondary;

        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? UseDrSecondary { get => this._useDrSecondary; set => this._useDrSecondary = value; }

        /// <summary>Creates an new <see cref="DeletedAppRestoreRequestProperties" /> instance.</summary>
        public DeletedAppRestoreRequestProperties()
        {

        }
    }
    /// DeletedAppRestoreRequest resource specific properties
    public partial interface IDeletedAppRestoreRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// ARM resource ID of the deleted app. Example:
        /// /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM resource ID of the deleted app. Example:
        /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}",
        SerializedName = @"deletedSiteId",
        PossibleTypes = new [] { typeof(string) })]
        string DeletedSiteId { get; set; }
        /// <summary>If true, deleted site configuration, in addition to content, will be restored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If true, deleted site configuration, in addition to content, will be restored.",
        SerializedName = @"recoverConfiguration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RecoverConfiguration { get; set; }
        /// <summary>
        /// Point in time to restore the deleted app from, formatted as a DateTime string.
        /// If unspecified, default value is the time that the app was deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Point in time to restore the deleted app from, formatted as a DateTime string.
        If unspecified, default value is the time that the app was deleted.",
        SerializedName = @"snapshotTime",
        PossibleTypes = new [] { typeof(string) })]
        string SnapshotTime { get; set; }
        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If true, the snapshot is retrieved from DRSecondary endpoint.",
        SerializedName = @"useDRSecondary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UseDrSecondary { get; set; }

    }
    /// DeletedAppRestoreRequest resource specific properties
    internal partial interface IDeletedAppRestoreRequestPropertiesInternal

    {
        /// <summary>
        /// ARM resource ID of the deleted app. Example:
        /// /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// </summary>
        string DeletedSiteId { get; set; }
        /// <summary>If true, deleted site configuration, in addition to content, will be restored.</summary>
        bool? RecoverConfiguration { get; set; }
        /// <summary>
        /// Point in time to restore the deleted app from, formatted as a DateTime string.
        /// If unspecified, default value is the time that the app was deleted.
        /// </summary>
        string SnapshotTime { get; set; }
        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        bool? UseDrSecondary { get; set; }

    }
}