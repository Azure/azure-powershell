namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The blob service properties for soft delete.</summary>
    public partial class DeleteRetentionPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicyInternal
    {

        /// <summary>Backing field for <see cref="Day" /> property.</summary>
        private int? _day;

        /// <summary>
        /// Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Day { get => this._day; set => this._day = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>Indicates whether DeleteRetentionPolicy is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Creates an new <see cref="DeleteRetentionPolicy" /> instance.</summary>
        public DeleteRetentionPolicy()
        {

        }
    }
    /// The blob service properties for soft delete.
    public partial interface IDeleteRetentionPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum value can be 365.",
        SerializedName = @"days",
        PossibleTypes = new [] { typeof(int) })]
        int? Day { get; set; }
        /// <summary>Indicates whether DeleteRetentionPolicy is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether DeleteRetentionPolicy is enabled for the Blob service.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }

    }
    /// The blob service properties for soft delete.
    internal partial interface IDeleteRetentionPolicyInternal

    {
        /// <summary>
        /// Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        int? Day { get; set; }
        /// <summary>Indicates whether DeleteRetentionPolicy is enabled for the Blob service.</summary>
        bool? Enabled { get; set; }

    }
}