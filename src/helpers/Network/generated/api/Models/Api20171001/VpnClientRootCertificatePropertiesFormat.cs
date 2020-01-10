namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of SSL certificates of application gateway</summary>
    public partial class VpnClientRootCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificatePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificatePropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificatePropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the VPN client root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicCertData" /> property.</summary>
        private string _publicCertData;

        /// <summary>The certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PublicCertData { get => this._publicCertData; set => this._publicCertData = value; }

        /// <summary>
        /// Creates an new <see cref="VpnClientRootCertificatePropertiesFormat" /> instance.
        /// </summary>
        public VpnClientRootCertificatePropertiesFormat()
        {

        }
    }
    /// Properties of SSL certificates of application gateway
    public partial interface IVpnClientRootCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The provisioning state of the VPN client root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the VPN client root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The certificate public data.",
        SerializedName = @"publicCertData",
        PossibleTypes = new [] { typeof(string) })]
        string PublicCertData { get; set; }

    }
    /// Properties of SSL certificates of application gateway
    internal partial interface IVpnClientRootCertificatePropertiesFormatInternal

    {
        /// <summary>
        /// The provisioning state of the VPN client root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The certificate public data.</summary>
        string PublicCertData { get; set; }

    }
}