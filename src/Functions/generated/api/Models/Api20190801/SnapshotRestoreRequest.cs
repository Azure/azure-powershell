namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Details about app recovery operation.</summary>
    public partial class SnapshotRestoreRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// If true, custom hostname conflicts will be ignored when recovering to a target web app.
        /// This setting is only necessary when RecoverConfiguration is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IgnoreConflictingHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).IgnoreConflictingHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).IgnoreConflictingHostName = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequestProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RecoverySource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal.RecoverySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverySource = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>
        /// If <code>true</code> the restore operation can overwrite source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool Overwrite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).Overwrite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).Overwrite = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties _property;

        /// <summary>SnapshotRestoreRequest resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequestProperties()); set => this._property = value; }

        /// <summary>If true, site configuration, in addition to content, will be reverted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? RecoverConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverConfiguration = value; }

        /// <summary>
        /// ARM resource ID of the source app.
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RecoverySourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverySourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverySourceId = value; }

        /// <summary>Geographical location of the source web app, e.g. SouthEastAsia, SouthCentralUS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RecoverySourceLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverySourceLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).RecoverySourceLocation = value; }

        /// <summary>
        /// Point in time in which the app restore should be done, formatted as a DateTime string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SnapshotTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).SnapshotTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).SnapshotTime = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? UseDrSecondary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).UseDrSecondary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestPropertiesInternal)Property).UseDrSecondary = value; }

        /// <summary>Creates an new <see cref="SnapshotRestoreRequest" /> instance.</summary>
        public SnapshotRestoreRequest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Details about app recovery operation.
    public partial interface ISnapshotRestoreRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Details about app recovery operation.
    internal partial interface ISnapshotRestoreRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>SnapshotRestoreRequest resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties Property { get; set; }
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