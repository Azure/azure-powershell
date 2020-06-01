namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Object to define the number of days after creation.</summary>
    public partial class DateAfterCreation :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreationInternal
    {

        /// <summary>Backing field for <see cref="DaysAfterCreationGreaterThan" /> property.</summary>
        private float _daysAfterCreationGreaterThan;

        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public float DaysAfterCreationGreaterThan { get => this._daysAfterCreationGreaterThan; set => this._daysAfterCreationGreaterThan = value; }

        /// <summary>Creates an new <see cref="DateAfterCreation" /> instance.</summary>
        public DateAfterCreation()
        {

        }
    }
    /// Object to define the number of days after creation.
    public partial interface IDateAfterCreation :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value indicating the age in days after creation",
        SerializedName = @"daysAfterCreationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DaysAfterCreationGreaterThan { get; set; }

    }
    /// Object to define the number of days after creation.
    internal partial interface IDateAfterCreationInternal

    {
        /// <summary>Value indicating the age in days after creation</summary>
        float DaysAfterCreationGreaterThan { get; set; }

    }
}