namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Management policy action for snapshot.</summary>
    public partial class ManagementPolicySnapShot :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShotInternal
    {

        /// <summary>Backing field for <see cref="Delete" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation _delete;

        /// <summary>The function to delete the blob snapshot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation Delete { get => (this._delete = this._delete ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterCreation()); set => this._delete = value; }

        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public float DeleteDaysAfterCreationGreaterThan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreationInternal)Delete).DaysAfterCreationGreaterThan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreationInternal)Delete).DaysAfterCreationGreaterThan = value; }

        /// <summary>Internal Acessors for Delete</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShotInternal.Delete { get => (this._delete = this._delete ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterCreation()); set { {_delete = value;} } }

        /// <summary>Creates an new <see cref="ManagementPolicySnapShot" /> instance.</summary>
        public ManagementPolicySnapShot()
        {

        }
    }
    /// Management policy action for snapshot.
    public partial interface IManagementPolicySnapShot :
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

    }
    /// Management policy action for snapshot.
    internal partial interface IManagementPolicySnapShotInternal

    {
        /// <summary>The function to delete the blob snapshot</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation Delete { get; set; }
        /// <summary>Value indicating the age in days after creation</summary>
        float DeleteDaysAfterCreationGreaterThan { get; set; }

    }
}