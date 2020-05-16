namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Details about restoring a deleted app.</summary>
    public partial class DeletedAppRestoreRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// ARM resource ID of the deleted app. Example:
        /// /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DeletedSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).DeletedSiteId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).DeletedSiteId = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedAppRestoreRequestProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestProperties _property;

        /// <summary>DeletedAppRestoreRequest resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedAppRestoreRequestProperties()); set => this._property = value; }

        /// <summary>If true, deleted site configuration, in addition to content, will be restored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? RecoverConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).RecoverConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).RecoverConfiguration = value; }

        /// <summary>
        /// Point in time to restore the deleted app from, formatted as a DateTime string.
        /// If unspecified, default value is the time that the app was deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SnapshotTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).SnapshotTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).SnapshotTime = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>If true, the snapshot is retrieved from DRSecondary endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? UseDrSecondary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).UseDrSecondary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestPropertiesInternal)Property).UseDrSecondary = value; }

        /// <summary>Creates an new <see cref="DeletedAppRestoreRequest" /> instance.</summary>
        public DeletedAppRestoreRequest()
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
    /// Details about restoring a deleted app.
    public partial interface IDeletedAppRestoreRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Details about restoring a deleted app.
    internal partial interface IDeletedAppRestoreRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>
        /// ARM resource ID of the deleted app. Example:
        /// /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// </summary>
        string DeletedSiteId { get; set; }
        /// <summary>DeletedAppRestoreRequest resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedAppRestoreRequestProperties Property { get; set; }
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