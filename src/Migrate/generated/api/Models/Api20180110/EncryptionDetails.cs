namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Encryption details for the fabric.</summary>
    public partial class EncryptionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal
    {

        /// <summary>Backing field for <see cref="KekCertExpiryDate" /> property.</summary>
        private global::System.DateTime? _kekCertExpiryDate;

        /// <summary>The key encryption key certificate expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? KekCertExpiryDate { get => this._kekCertExpiryDate; set => this._kekCertExpiryDate = value; }

        /// <summary>Backing field for <see cref="KekCertThumbprint" /> property.</summary>
        private string _kekCertThumbprint;

        /// <summary>The key encryption key certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KekCertThumbprint { get => this._kekCertThumbprint; set => this._kekCertThumbprint = value; }

        /// <summary>Backing field for <see cref="KekState" /> property.</summary>
        private string _kekState;

        /// <summary>The key encryption key state for the Vmm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KekState { get => this._kekState; set => this._kekState = value; }

        /// <summary>Creates an new <see cref="EncryptionDetails" /> instance.</summary>
        public EncryptionDetails()
        {

        }
    }
    /// Encryption details for the fabric.
    public partial interface IEncryptionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The key encryption key certificate expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key certificate expiry date.",
        SerializedName = @"kekCertExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? KekCertExpiryDate { get; set; }
        /// <summary>The key encryption key certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key certificate thumbprint.",
        SerializedName = @"kekCertThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string KekCertThumbprint { get; set; }
        /// <summary>The key encryption key state for the Vmm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key state for the Vmm.",
        SerializedName = @"kekState",
        PossibleTypes = new [] { typeof(string) })]
        string KekState { get; set; }

    }
    /// Encryption details for the fabric.
    internal partial interface IEncryptionDetailsInternal

    {
        /// <summary>The key encryption key certificate expiry date.</summary>
        global::System.DateTime? KekCertExpiryDate { get; set; }
        /// <summary>The key encryption key certificate thumbprint.</summary>
        string KekCertThumbprint { get; set; }
        /// <summary>The key encryption key state for the Vmm.</summary>
        string KekState { get; set; }

    }
}