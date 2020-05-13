namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set.
    /// </summary>
    public partial class ManagementPolicyDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction _action;

        /// <summary>An object that defines the action set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyAction()); set => this._action = value; }

        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterCreationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).DeleteDaysAfterCreationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).DeleteDaysAfterCreationGreaterThan = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).DeleteDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).DeleteDaysAfterModificationGreaterThan = value; }

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter _filter;

        /// <summary>An object that defines the filter set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyFilter()); set => this._filter = value; }

        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] FilterBlobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilterInternal)Filter).BlobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilterInternal)Filter).BlobType = value; }

        /// <summary>An array of strings for prefixes to be match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] FilterPrefixMatch { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilterInternal)Filter).PrefixMatch; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilterInternal)Filter).PrefixMatch = value; }

        /// <summary>Internal Acessors for Action</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyAction()); set { {_action = value;} } }

        /// <summary>Internal Acessors for ActionBaseBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.ActionBaseBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlob = value; }

        /// <summary>Internal Acessors for ActionSnapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.ActionSnapshot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).Snapshot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).Snapshot = value; }

        /// <summary>Internal Acessors for BaseBlobDelete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.BaseBlobDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlobDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlobDelete = value; }

        /// <summary>Internal Acessors for BaseBlobTierToArchive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.BaseBlobTierToArchive { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlobTierToArchive; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlobTierToArchive = value; }

        /// <summary>Internal Acessors for BaseBlobTierToCool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.BaseBlobTierToCool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlobTierToCool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).BaseBlobTierToCool = value; }

        /// <summary>Internal Acessors for Filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyFilter()); set { {_filter = value;} } }

        /// <summary>Internal Acessors for SnapshotDelete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyDefinitionInternal.SnapshotDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).SnapshotDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).SnapshotDelete = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToArchiveDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).TierToArchiveDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).TierToArchiveDaysAfterModificationGreaterThan = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToCoolDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).TierToCoolDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)Action).TierToCoolDaysAfterModificationGreaterThan = value; }

        /// <summary>Creates an new <see cref="ManagementPolicyDefinition" /> instance.</summary>
        public ManagementPolicyDefinition()
        {

        }
    }
    /// An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set.
    public partial interface IManagementPolicyDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after creation",
        SerializedName = @"daysAfterCreationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DeleteDaysAfterCreationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DeleteDaysAfterModificationGreaterThan { get; set; }
        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"An array of predefined enum values. Only blockBlob is supported.",
        SerializedName = @"blobTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] FilterBlobType { get; set; }
        /// <summary>An array of strings for prefixes to be match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of strings for prefixes to be match.",
        SerializedName = @"prefixMatch",
        PossibleTypes = new [] { typeof(string) })]
        string[] FilterPrefixMatch { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float TierToArchiveDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float TierToCoolDaysAfterModificationGreaterThan { get; set; }

    }
    /// An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set.
    internal partial interface IManagementPolicyDefinitionInternal

    {
        /// <summary>An object that defines the action set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction Action { get; set; }
        /// <summary>The management policy action for base blob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob ActionBaseBlob { get; set; }
        /// <summary>The management policy action for snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot ActionSnapshot { get; set; }
        /// <summary>The function to delete the blob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification BaseBlobDelete { get; set; }
        /// <summary>
        /// The function to tier blobs to archive storage. Support blobs currently at Hot or Cool tier
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification BaseBlobTierToArchive { get; set; }
        /// <summary>The function to tier blobs to cool storage. Support blobs currently at Hot tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification BaseBlobTierToCool { get; set; }
        /// <summary>Value indicating the age in days after creation</summary>
        float DeleteDaysAfterCreationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float DeleteDaysAfterModificationGreaterThan { get; set; }
        /// <summary>An object that defines the filter set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyFilter Filter { get; set; }
        /// <summary>An array of predefined enum values. Only blockBlob is supported.</summary>
        string[] FilterBlobType { get; set; }
        /// <summary>An array of strings for prefixes to be match.</summary>
        string[] FilterPrefixMatch { get; set; }
        /// <summary>The function to delete the blob snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation SnapshotDelete { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToArchiveDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToCoolDaysAfterModificationGreaterThan { get; set; }

    }
}