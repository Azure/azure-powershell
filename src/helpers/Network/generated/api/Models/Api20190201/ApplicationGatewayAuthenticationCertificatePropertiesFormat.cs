namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Authentication certificates properties of an application gateway.</summary>
    public partial class ApplicationGatewayAuthenticationCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificatePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private string _data;

        /// <summary>Certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Data { get => this._data; set => this._data = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayAuthenticationCertificatePropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayAuthenticationCertificatePropertiesFormat()
        {

        }
    }
    /// Authentication certificates properties of an application gateway.
    public partial interface IApplicationGatewayAuthenticationCertificatePropertiesFormat :
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
        /// Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Authentication certificates properties of an application gateway.
    internal partial interface IApplicationGatewayAuthenticationCertificatePropertiesFormatInternal

    {
        /// <summary>Certificate public data.</summary>
        string Data { get; set; }
        /// <summary>
        /// Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}