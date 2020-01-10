namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ApplicationGatewayBackendHealth API service call.</summary>
    public partial class ApplicationGatewayBackendHealth :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealth,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthInternal
    {

        /// <summary>Backing field for <see cref="BackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool[] _backendAddressPool;

        /// <summary>A list of ApplicationGatewayBackendHealthPool resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool[] BackendAddressPool { get => this._backendAddressPool; set => this._backendAddressPool = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayBackendHealth" /> instance.</summary>
        public ApplicationGatewayBackendHealth()
        {

        }
    }
    /// Response for ApplicationGatewayBackendHealth API service call.
    public partial interface IApplicationGatewayBackendHealth :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of ApplicationGatewayBackendHealthPool resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of ApplicationGatewayBackendHealthPool resources.",
        SerializedName = @"backendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool[] BackendAddressPool { get; set; }

    }
    /// Response for ApplicationGatewayBackendHealth API service call.
    internal partial interface IApplicationGatewayBackendHealthInternal

    {
        /// <summary>A list of ApplicationGatewayBackendHealthPool resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool[] BackendAddressPool { get; set; }

    }
}