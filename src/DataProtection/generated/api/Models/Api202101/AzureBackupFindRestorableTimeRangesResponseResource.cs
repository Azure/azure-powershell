namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>List Restore Ranges Response</summary>
    public partial class AzureBackupFindRestorableTimeRangesResponseResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResource __dppResource = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppResource();

        /// <summary>Resource Id represents the complete path to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Id; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponse Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupFindRestorableTimeRangesResponse()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Type = value; }

        /// <summary>Resource name associated with the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseInternal)Property).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseInternal)Property).ObjectType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponse _property;

        /// <summary>AzureBackupFindRestorableTimeRangesResponseResource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponse Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupFindRestorableTimeRangesResponse()); set => this._property = value; }

        /// <summary>Returns the Restore Ranges available on the Backup Instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestorableTimeRange[] RestorableTimeRange { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseInternal)Property).RestorableTimeRange; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponseInternal)Property).RestorableTimeRange = value ?? null /* arrayOf */; }

        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).SystemData; }

        /// <summary>
        /// Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Type; }

        /// <summary>
        /// Creates an new <see cref="AzureBackupFindRestorableTimeRangesResponseResource" /> instance.
        /// </summary>
        public AzureBackupFindRestorableTimeRangesResponseResource()
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
            await eventListener.AssertNotNull(nameof(__dppResource), __dppResource);
            await eventListener.AssertObjectIsValid(nameof(__dppResource), __dppResource);
        }
    }
    /// List Restore Ranges Response
    public partial interface IAzureBackupFindRestorableTimeRangesResponseResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResource
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Returns the Restore Ranges available on the Backup Instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Returns the Restore Ranges available on the Backup Instance.",
        SerializedName = @"restorableTimeRanges",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestorableTimeRange) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestorableTimeRange[] RestorableTimeRange { get; set; }

    }
    /// List Restore Ranges Response
    internal partial interface IAzureBackupFindRestorableTimeRangesResponseResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal
    {
        string ObjectType { get; set; }
        /// <summary>AzureBackupFindRestorableTimeRangesResponseResource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupFindRestorableTimeRangesResponse Property { get; set; }
        /// <summary>Returns the Restore Ranges available on the Backup Instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestorableTimeRange[] RestorableTimeRange { get; set; }

    }
}