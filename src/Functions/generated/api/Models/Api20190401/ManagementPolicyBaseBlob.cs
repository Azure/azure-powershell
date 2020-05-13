namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Management policy action for base blob.</summary>
    public partial class ManagementPolicyBaseBlob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal
    {

        /// <summary>Backing field for <see cref="Delete" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification _delete;

        /// <summary>The function to delete the blob</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Delete { get => (this._delete = this._delete ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModification()); set => this._delete = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal)Delete).DaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal)Delete).DaysAfterModificationGreaterThan = value; }

        /// <summary>Internal Acessors for Delete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal.Delete { get => (this._delete = this._delete ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModification()); set { {_delete = value;} } }

        /// <summary>Internal Acessors for TierToArchive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal.TierToArchive { get => (this._tierToArchive = this._tierToArchive ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModification()); set { {_tierToArchive = value;} } }

        /// <summary>Internal Acessors for TierToCool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal.TierToCool { get => (this._tierToCool = this._tierToCool ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModification()); set { {_tierToCool = value;} } }

        /// <summary>Backing field for <see cref="TierToArchive" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification _tierToArchive;

        /// <summary>
        /// The function to tier blobs to archive storage. Support blobs currently at Hot or Cool tier
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification TierToArchive { get => (this._tierToArchive = this._tierToArchive ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModification()); set => this._tierToArchive = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToArchiveDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal)TierToArchive).DaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal)TierToArchive).DaysAfterModificationGreaterThan = value; }

        /// <summary>Backing field for <see cref="TierToCool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification _tierToCool;

        /// <summary>The function to tier blobs to cool storage. Support blobs currently at Hot tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification TierToCool { get => (this._tierToCool = this._tierToCool ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModification()); set => this._tierToCool = value; }

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float TierToCoolDaysAfterModificationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal)TierToCool).DaysAfterModificationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal)TierToCool).DaysAfterModificationGreaterThan = value; }

        /// <summary>Creates an new <see cref="ManagementPolicyBaseBlob" /> instance.</summary>
        public ManagementPolicyBaseBlob()
        {

        }
    }
    /// Management policy action for base blob.
    public partial interface IManagementPolicyBaseBlob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
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
    /// Management policy action for base blob.
    internal partial interface IManagementPolicyBaseBlobInternal

    {
        /// <summary>The function to delete the blob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification Delete { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float DeleteDaysAfterModificationGreaterThan { get; set; }
        /// <summary>
        /// The function to tier blobs to archive storage. Support blobs currently at Hot or Cool tier
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification TierToArchive { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToArchiveDaysAfterModificationGreaterThan { get; set; }
        /// <summary>The function to tier blobs to cool storage. Support blobs currently at Hot tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification TierToCool { get; set; }
        /// <summary>Value indicating the age in days after last modification</summary>
        float TierToCoolDaysAfterModificationGreaterThan { get; set; }

    }
}