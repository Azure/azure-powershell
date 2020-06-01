namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A service that allows server-side encryption to be used.</summary>
    public partial class EncryptionService :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServiceInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="LastEnabledTime" /> property.</summary>
        private global::System.DateTime? _lastEnabledTime;

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastEnabledTime { get => this._lastEnabledTime; }

        /// <summary>Internal Acessors for LastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServiceInternal.LastEnabledTime { get => this._lastEnabledTime; set { {_lastEnabledTime = value;} } }

        /// <summary>Creates an new <see cref="EncryptionService" /> instance.</summary>
        public EncryptionService()
        {

        }
    }
    /// A service that allows server-side encryption to be used.
    public partial interface IEncryptionService :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastEnabledTime { get;  }

    }
    /// A service that allows server-side encryption to be used.
    internal partial interface IEncryptionServiceInternal

    {
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? LastEnabledTime { get; set; }

    }
}