namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Vpn Client Parameters for package generation</summary>
    public partial class P2SVpnProfileParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnProfileParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnProfileParametersInternal
    {

        /// <summary>Backing field for <see cref="AuthenticationMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? _authenticationMethod;

        /// <summary>VPN client authentication method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? AuthenticationMethod { get => this._authenticationMethod; set => this._authenticationMethod = value; }

        /// <summary>Creates an new <see cref="P2SVpnProfileParameters" /> instance.</summary>
        public P2SVpnProfileParameters()
        {

        }
    }
    /// Vpn Client Parameters for package generation
    public partial interface IP2SVpnProfileParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>VPN client authentication method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VPN client authentication method.",
        SerializedName = @"authenticationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? AuthenticationMethod { get; set; }

    }
    /// Vpn Client Parameters for package generation
    internal partial interface IP2SVpnProfileParametersInternal

    {
        /// <summary>VPN client authentication method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? AuthenticationMethod { get; set; }

    }
}