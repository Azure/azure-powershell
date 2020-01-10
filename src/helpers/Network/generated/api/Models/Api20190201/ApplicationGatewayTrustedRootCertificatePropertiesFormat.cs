namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Trusted Root certificates properties of an application gateway.</summary>
    public partial class ApplicationGatewayTrustedRootCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificatePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificatePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private string _data;

        /// <summary>Certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Data { get => this._data; set => this._data = value; }

        /// <summary>Backing field for <see cref="KeyVaultSecretId" /> property.</summary>
        private string _keyVaultSecretId;

        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string KeyVaultSecretId { get => this._keyVaultSecretId; set => this._keyVaultSecretId = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayTrustedRootCertificatePropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayTrustedRootCertificatePropertiesFormat()
        {

        }
    }
    /// Trusted Root certificates properties of an application gateway.
    public partial interface IApplicationGatewayTrustedRootCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Certificate public data.",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(string) })]
        string Data { get; set; }
        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.",
        SerializedName = @"keyVaultSecretId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultSecretId { get; set; }
        /// <summary>
        /// Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Trusted Root certificates properties of an application gateway.
    internal partial interface IApplicationGatewayTrustedRootCertificatePropertiesFormatInternal

    {
        /// <summary>Certificate public data.</summary>
        string Data { get; set; }
        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        string KeyVaultSecretId { get; set; }
        /// <summary>
        /// Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}