namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Results of network configuration diagnostic on the target resource.</summary>
    public partial class NetworkConfigurationDiagnosticResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResponseInternal
    {

        /// <summary>Internal Acessors for Result</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResponseInternal.Result { get => this._result; set { {_result = value;} } }

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult[] _result;

        /// <summary>List of network configuration diagnostic results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult[] Result { get => this._result; }

        /// <summary>Creates an new <see cref="NetworkConfigurationDiagnosticResponse" /> instance.</summary>
        public NetworkConfigurationDiagnosticResponse()
        {

        }
    }
    /// Results of network configuration diagnostic on the target resource.
    public partial interface INetworkConfigurationDiagnosticResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of network configuration diagnostic results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of network configuration diagnostic results.",
        SerializedName = @"results",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult[] Result { get;  }

    }
    /// Results of network configuration diagnostic on the target resource.
    internal partial interface INetworkConfigurationDiagnosticResponseInternal

    {
        /// <summary>List of network configuration diagnostic results.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult[] Result { get; set; }

    }
}