namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>List Restore Ranges Request</summary>
    public partial class AzureBackupFindRestorableTimeRangesRequestResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequest"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequest __dppWorkerRequest = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppWorkerRequest();

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequest _content;

        /// <summary>AzureBackupFindRestorableTimeRangesRequestResource content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequest Content { get => (this._content = this._content ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupFindRestorableTimeRangesRequest()); set => this._content = value; }

        /// <summary>End time for the List Restore Ranges request</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ContentEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestInternal)Content).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestInternal)Content).EndTime = value ?? null; }

        /// <summary>Gets or sets the type of the source data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreSourceDataStoreType? ContentSourceDataStoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestInternal)Content).SourceDataStoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestInternal)Content).SourceDataStoreType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreSourceDataStoreType)""); }

        /// <summary>Start time for the List Restore Ranges request</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ContentStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestInternal)Content).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestInternal)Content).StartTime = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string CultureInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).CultureInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).CultureInfo = value ?? null; }

        /// <summary>
        /// Dictionary of <components·ikn5y4·schemas·dppworkerrequest·properties·headers·additionalproperties>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestHeaders Header { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).Header; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).Header = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string HttpMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).HttpMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).HttpMethod = value ?? null; }

        /// <summary>Internal Acessors for Content</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequest Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequestResourceInternal.Content { get => (this._content = this._content ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupFindRestorableTimeRangesRequest()); set { {_content = value;} } }

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters Parameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).Parameter = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string SubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).SubscriptionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).SubscriptionId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string[] SupportedGroupVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).SupportedGroupVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).SupportedGroupVersion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Uri { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).Uri; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal)__dppWorkerRequest).Uri = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="AzureBackupFindRestorableTimeRangesRequestResource" /> instance.
        /// </summary>
        public AzureBackupFindRestorableTimeRangesRequestResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dppWorkerRequest), __dppWorkerRequest);
            await eventListener.AssertObjectIsValid(nameof(__dppWorkerRequest), __dppWorkerRequest);
        }
    }
    /// List Restore Ranges Request
    public partial interface IAzureBackupFindRestorableTimeRangesRequestResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequest
    {
        /// <summary>End time for the List Restore Ranges request</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time for the List Restore Ranges request",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(string) })]
        string ContentEndTime { get; set; }
        /// <summary>Gets or sets the type of the source data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the type of the source data store.",
        SerializedName = @"sourceDataStoreType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreSourceDataStoreType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreSourceDataStoreType? ContentSourceDataStoreType { get; set; }
        /// <summary>Start time for the List Restore Ranges request</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time for the List Restore Ranges request",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string ContentStartTime { get; set; }

    }
    /// List Restore Ranges Request
    internal partial interface IAzureBackupFindRestorableTimeRangesRequestResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal
    {
        /// <summary>AzureBackupFindRestorableTimeRangesRequestResource content</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesRequest Content { get; set; }
        /// <summary>End time for the List Restore Ranges request</summary>
        string ContentEndTime { get; set; }
        /// <summary>Gets or sets the type of the source data store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreSourceDataStoreType? ContentSourceDataStoreType { get; set; }
        /// <summary>Start time for the List Restore Ranges request</summary>
        string ContentStartTime { get; set; }

    }
}