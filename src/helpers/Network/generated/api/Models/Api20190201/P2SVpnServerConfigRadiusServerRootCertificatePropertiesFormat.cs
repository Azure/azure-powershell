namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of Radius Server root certificate of P2SVpnServerConfiguration.</summary>
    public partial class P2SVpnServerConfigRadiusServerRootCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificatePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificatePropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificatePropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the P2SVpnServerConfiguration Radius Server root certificate resource. Possible values are:
        /// 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicCertData" /> property.</summary>
        private string _publicCertData;

        /// <summary>The certificate public data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PublicCertData { get => this._publicCertData; set => this._publicCertData = value; }

        /// <summary>
        /// Creates an new <see cref="P2SVpnServerConfigRadiusServerRootCertificatePropertiesFormat" /> instance.
        /// </summary>
        public P2SVpnServerConfigRadiusServerRootCertificatePropertiesFormat()
        {

        }
    }
    /// Properties of Radius Server root certificate of P2SVpnServerConfiguration.
    public partial interface IP2SVpnServerConfigRadiusServerRootCertificatePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The provisioning state of the P2SVpnServerConfiguration Radius Server root certificate resource. Possible values are:
        /// 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the P2SVpnServerConfiguration Radius Server root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
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
    /// Properties of Radius Server root certificate of P2SVpnServerConfiguration.
    internal partial interface IP2SVpnServerConfigRadiusServerRootCertificatePropertiesFormatInternal

    {
        /// <summary>
        /// The provisioning state of the P2SVpnServerConfiguration Radius Server root certificate resource. Possible values are:
        /// 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The certificate public data.</summary>
        string PublicCertData { get; set; }

    }
}