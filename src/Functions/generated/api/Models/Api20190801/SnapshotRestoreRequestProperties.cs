namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SnapshotRestoreRequest resource specific properties</summary>
    public partial class SnapshotRestoreRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="IgnoreConflictingHostName" /> property.</summary>
        private bool? _ignoreConflictingHostName;

        /// <summary>
        /// If true, custom hostname conflicts will be ignored when recovering to a target web app.
        /// This setting is only necessary when RecoverConfiguration is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IgnoreConflictingHostName { get => this._ignoreConflictingHostName; set => this._ignoreConflictingHostName = value; }

        /// <summary>Internal Acessors for RecoverySource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal.RecoverySource { get => (this._recoverySource = this._recoverySource ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRecoverySource()); set { {_recoverySource = value;} } }

        /// <summary>Backing field for <see cref="Overwrite" /> property.</summary>
        private bool _overwrite;

        /// <summary>
        /// If <code>true</code> the restore operation can overwrite source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool Overwrite { get => this._overwrite; set => this._overwrite = value; }

        /// <summary>Backing field for <see cref="RecoverConfiguration" /> property.</summary>
        private bool? _recoverConfiguration;

        /// <summary>If true, site configuration, in addition to content, will be reverted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? RecoverConfiguration { get => this._recoverConfiguration; set => this._recoverConfiguration = value; }

        /// <summary>Backing field for <see cref="RecoverySource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource _recoverySource;

        /// <summary>
        /// Optional. Specifies the web app that snapshot contents will be retrieved from.
        /// If empty, the targeted web app will be used as the source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource RecoverySource { get => (this._recoverySource = this._recoverySource ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRecoverySource()); set => this._recoverySource = value; }

        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RecoverySourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySourceInternal)RecoverySource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySourceInternal)RecoverySource).Id = value; }

        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RecoverySourceLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySourceInternal)RecoverySource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySourceInternal)RecoverySource).Location = value; }

        /// <summary>Backing field for <see cref="SnapshotTime" /> property.</summary>
        private string _snapshotTime;

        /// <summary>
        /// Point in time in which the app restore should be done, formatted as a DateTime string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SnapshotTime { get => this._snapshotTime; set => this._snapshotTime = value; }

        /// <summary>Backing field for <see cref="UseDrSecondary" /> property.</summary>
        private bool? _useDrSecondary;

        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? UseDrSecondary { get => this._useDrSecondary; set => this._useDrSecondary = value; }

        /// <summary>Creates an new <see cref="SnapshotRestoreRequestProperties" /> instance.</summary>
        public SnapshotRestoreRequestProperties()
        {

        }
    }
    /// SnapshotRestoreRequest resource specific properties
    public partial interface ISnapshotRestoreRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If true, custom hostname conflicts will be ignored when recovering to a target web app.
        /// This setting is only necessary when RecoverConfiguration is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If true, custom hostname conflicts will be ignored when recovering to a target web app.
        This setting is only necessary when RecoverConfiguration is enabled.",
        SerializedName = @"ignoreConflictingHostNames",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreConflictingHostName { get; set; }
        /// <summary>
        /// If <code>true</code> the restore operation can overwrite source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"If <code>true</code> the restore operation can overwrite source app; otherwise, <code>false</code>.",
        SerializedName = @"overwrite",
        PossibleTypes = new [] { typeof(bool) })]
        bool Overwrite { get; set; }
        /// <summary>If true, site configuration, in addition to content, will be reverted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If true, site configuration, in addition to content, will be reverted.",
        SerializedName = @"recoverConfiguration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RecoverConfiguration { get; set; }
        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM resource ID of the source app.
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RecoverySourceId { get; set; }
        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string RecoverySourceLocation { get; set; }
        /// <summary>
        /// Point in time in which the app restore should be done, formatted as a DateTime string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Point in time in which the app restore should be done, formatted as a DateTime string.",
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
    /// SnapshotRestoreRequest resource specific properties
    internal partial interface ISnapshotRestoreRequestPropertiesInternal

    {
        /// <summary>
        /// If true, custom hostname conflicts will be ignored when recovering to a target web app.
        /// This setting is only necessary when RecoverConfiguration is enabled.
        /// </summary>
        bool? IgnoreConflictingHostName { get; set; }
        /// <summary>
        /// If <code>true</code> the restore operation can overwrite source app; otherwise, <code>false</code>.
        /// </summary>
        bool Overwrite { get; set; }
        /// <summary>If true, site configuration, in addition to content, will be reverted.</summary>
        bool? RecoverConfiguration { get; set; }
        /// <summary>
        /// Optional. Specifies the web app that snapshot contents will be retrieved from.
        /// If empty, the targeted web app will be used as the source.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource RecoverySource { get; set; }
        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        string RecoverySourceId { get; set; }
        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        string RecoverySourceLocation { get; set; }
        /// <summary>
        /// Point in time in which the app restore should be done, formatted as a DateTime string.
        /// </summary>
        string SnapshotTime { get; set; }
        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        bool? UseDrSecondary { get; set; }

    }
}