namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Actions are applied to the filtered blobs when the execution condition is met.</summary>
    public partial class ManagementPolicyAction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal
    {

        /// <summary>Backing field for <see cref="BaseBlob" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob _baseBlob;

        /// <summary>The management policy action for base blob</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob BaseBlob { get => (this._baseBlob = this._baseBlob ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlob()); set => this._baseBlob = value; }

        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterCreationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShotInternal)Snapshot).DeleteDaysAfterCreationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShotInternal)Snapshot).DeleteDaysAfterCreationGreaterThan = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).DeleteDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).DeleteDaysAfterModificationGreaterThan = value; }

        /// <summary>Internal Acessors for BaseBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal.BaseBlob { get => (this._baseBlob = this._baseBlob ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlob()); set { {_baseBlob = value;} } }

        /// <summary>Internal Acessors for BaseBlobDelete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal.BaseBlobDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).Delete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).Delete = value; }

        /// <summary>Internal Acessors for BaseBlobTierToArchive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal.BaseBlobTierToArchive { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToArchive; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToArchive = value; }

        /// <summary>Internal Acessors for BaseBlobTierToCool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal.BaseBlobTierToCool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToCool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToCool = value; }

        /// <summary>Internal Acessors for Snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal.Snapshot { get => (this._snapshot = this._snapshot ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicySnapShot()); set { {_snapshot = value;} } }

        /// <summary>Internal Acessors for SnapshotDelete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal.SnapshotDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShotInternal)Snapshot).Delete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShotInternal)Snapshot).Delete = value; }

        /// <summary>Backing field for <see cref="Snapshot" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot _snapshot;

        /// <summary>The management policy action for snapshot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot Snapshot { get => (this._snapshot = this._snapshot ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicySnapShot()); set => this._snapshot = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToArchiveDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToArchiveDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToArchiveDaysAfterModificationGreaterThan = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToCoolDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToCoolDaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)BaseBlob).TierToCoolDaysAfterModificationGreaterThan = value; }

        /// <summary>Creates an new <see cref="ManagementPolicyAction" /> instance.</summary>
        public ManagementPolicyAction()
        {

        }
    }
    /// Actions are applied to the filtered blobs when the execution condition is met.
    public partial interface IManagementPolicyAction :
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
    /// Actions are applied to the filtered blobs when the execution condition is met.
    internal partial interface IManagementPolicyActionInternal

    {
        /// <summary>The management policy action for base blob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob BaseBlob { get; set; }
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
        /// <summary>The management policy action for snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot Snapshot { get; set; }
        /// <summary>The function to delete the blob snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation SnapshotDelete { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToArchiveDaysAfterModificationGreaterThan { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToCoolDaysAfterModificationGreaterThan { get; set; }

    }
}