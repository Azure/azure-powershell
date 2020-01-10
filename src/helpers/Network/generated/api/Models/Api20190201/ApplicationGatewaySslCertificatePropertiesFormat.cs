namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of SSL certificates of an application gateway.</summary>
    public partial class ApplicationGatewaySslCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificatePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificatePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private string _data;

        /// <summary>Base-64 encoded pfx certificate. Only applicable in PUT Request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Data { get => this._data; set => this._data = value; }

        /// <summary>Backing field for <see cref="KeyVaultSecretId" /> property.</summary>
        private string _keyVaultSecretId;

        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string KeyVaultSecretId { get => this._keyVaultSecretId; set => this._keyVaultSecretId = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Password for the pfx file specified in data. Only applicable in PUT request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="PublicCertData" /> property.</summary>
        private string _publicCertData;

        /// <summary>
        /// Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PublicCertData { get => this._publicCertData; set => this._publicCertData = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewaySslCertificatePropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewaySslCertificatePropertiesFormat()
        {

        }
    }
    /// Properties of SSL certificates of an application gateway.
    public partial interface IApplicationGatewaySslCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Base-64 encoded pfx certificate. Only applicable in PUT Request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base-64 encoded pfx certificate. Only applicable in PUT Request.",
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
        /// <summary>Password for the pfx file specified in data. Only applicable in PUT request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password for the pfx file specified in data. Only applicable in PUT request.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>
        /// Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>
        /// Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.",
        SerializedName = @"publicCertData",
        PossibleTypes = new [] { typeof(string) })]
        string PublicCertData { get; set; }

    }
    /// Properties of SSL certificates of an application gateway.
    internal partial interface IApplicationGatewaySslCertificatePropertiesFormatInternal

    {
        /// <summary>Base-64 encoded pfx certificate. Only applicable in PUT Request.</summary>
        string Data { get; set; }
        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        string KeyVaultSecretId { get; set; }
        /// <summary>Password for the pfx file specified in data. Only applicable in PUT request.</summary>
        string Password { get; set; }
        /// <summary>
        /// Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
        /// </summary>
        string PublicCertData { get; set; }

    }
}