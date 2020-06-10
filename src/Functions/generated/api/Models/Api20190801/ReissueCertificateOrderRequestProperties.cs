namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ReissueCertificateOrderRequest resource specific properties</summary>
    public partial class ReissueCertificateOrderRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IReissueCertificateOrderRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Csr" /> property.</summary>
        private string _csr;

        /// <summary>Csr to be used for re-key operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Csr { get => this._csr; set => this._csr = value; }

        /// <summary>Backing field for <see cref="DelayExistingRevokeInHour" /> property.</summary>
        private int? _delayExistingRevokeInHour;

        /// <summary>
        /// Delay in hours to revoke existing certificate after the new certificate is issued.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? DelayExistingRevokeInHour { get => this._delayExistingRevokeInHour; set => this._delayExistingRevokeInHour = value; }

        /// <summary>Backing field for <see cref="IsPrivateKeyExternal" /> property.</summary>
        private bool? _isPrivateKeyExternal;

        /// <summary>
        /// Should we change the ASC type (from managed private key to external private key and vice versa).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsPrivateKeyExternal { get => this._isPrivateKeyExternal; set => this._isPrivateKeyExternal = value; }

        /// <summary>Backing field for <see cref="KeySize" /> property.</summary>
        private int? _keySize;

        /// <summary>Certificate Key Size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? KeySize { get => this._keySize; set => this._keySize = value; }

        /// <summary>
        /// Creates an new <see cref="ReissueCertificateOrderRequestProperties" /> instance.
        /// </summary>
        public ReissueCertificateOrderRequestProperties()
        {

        }
    }
    /// ReissueCertificateOrderRequest resource specific properties
    public partial interface IReissueCertificateOrderRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Csr to be used for re-key operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Csr to be used for re-key operation.",
        SerializedName = @"csr",
        PossibleTypes = new [] { typeof(string) })]
        string Csr { get; set; }
        /// <summary>
        /// Delay in hours to revoke existing certificate after the new certificate is issued.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Delay in hours to revoke existing certificate after the new certificate is issued.",
        SerializedName = @"delayExistingRevokeInHours",
        PossibleTypes = new [] { typeof(int) })]
        int? DelayExistingRevokeInHour { get; set; }
        /// <summary>
        /// Should we change the ASC type (from managed private key to external private key and vice versa).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Should we change the ASC type (from managed private key to external private key and vice versa).",
        SerializedName = @"isPrivateKeyExternal",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPrivateKeyExternal { get; set; }
        /// <summary>Certificate Key Size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Certificate Key Size.",
        SerializedName = @"keySize",
        PossibleTypes = new [] { typeof(int) })]
        int? KeySize { get; set; }

    }
    /// ReissueCertificateOrderRequest resource specific properties
    internal partial interface IReissueCertificateOrderRequestPropertiesInternal

    {
        /// <summary>Csr to be used for re-key operation.</summary>
        string Csr { get; set; }
        /// <summary>
        /// Delay in hours to revoke existing certificate after the new certificate is issued.
        /// </summary>
        int? DelayExistingRevokeInHour { get; set; }
        /// <summary>
        /// Should we change the ASC type (from managed private key to external private key and vice versa).
        /// </summary>
        bool? IsPrivateKeyExternal { get; set; }
        /// <summary>Certificate Key Size.</summary>
        int? KeySize { get; set; }

    }
}