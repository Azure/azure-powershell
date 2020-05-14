namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Object to define the number of days after last modification.</summary>
    public partial class DateAfterModification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModificationInternal
    {

        /// <summary>Backing field for <see cref="DaysAfterModificationGreaterThan" /> property.</summary>
        private float _daysAfterModificationGreaterThan;

        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public float DaysAfterModificationGreaterThan { get => this._daysAfterModificationGreaterThan; set => this._daysAfterModificationGreaterThan = value; }

        /// <summary>Creates an new <see cref="DateAfterModification" /> instance.</summary>
        public DateAfterModification()
        {

        }
    }
    /// Object to define the number of days after last modification.
    public partial interface IDateAfterModification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating the age in days after last modification</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after last modification",
        SerializedName = @"daysAfterModificationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DaysAfterModificationGreaterThan { get; set; }

    }
    /// Object to define the number of days after last modification.
    internal partial interface IDateAfterModificationInternal

    {
        /// <summary>Value indicating the age in days after last modification</summary>
        float DaysAfterModificationGreaterThan { get; set; }

    }
}