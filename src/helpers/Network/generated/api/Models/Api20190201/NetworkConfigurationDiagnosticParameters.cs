namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters to get network configuration diagnostic.</summary>
    public partial class NetworkConfigurationDiagnosticParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticParametersInternal
    {

        /// <summary>Backing field for <see cref="Profile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile[] _profile;

        /// <summary>List of network configuration diagnostic profiles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile[] Profile { get => this._profile; set => this._profile = value; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>
        /// The ID of the target resource to perform network configuration diagnostic. Valid options are VM, NetworkInterface, VMSS/NetworkInterface
        /// and Application Gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Backing field for <see cref="VerbosityLevel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VerbosityLevel? _verbosityLevel;

        /// <summary>Verbosity level. Accepted values are 'Normal', 'Minimum', 'Full'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VerbosityLevel? VerbosityLevel { get => this._verbosityLevel; set => this._verbosityLevel = value; }

        /// <summary>
        /// Creates an new <see cref="NetworkConfigurationDiagnosticParameters" /> instance.
        /// </summary>
        public NetworkConfigurationDiagnosticParameters()
        {

        }
    }
    /// Parameters to get network configuration diagnostic.
    public partial interface INetworkConfigurationDiagnosticParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of network configuration diagnostic profiles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of network configuration diagnostic profiles.",
        SerializedName = @"profiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile[] Profile { get; set; }
        /// <summary>
        /// The ID of the target resource to perform network configuration diagnostic. Valid options are VM, NetworkInterface, VMSS/NetworkInterface
        /// and Application Gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the target resource to perform network configuration diagnostic. Valid options are VM, NetworkInterface, VMSS/NetworkInterface and Application Gateway.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }
        /// <summary>Verbosity level. Accepted values are 'Normal', 'Minimum', 'Full'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Verbosity level. Accepted values are 'Normal', 'Minimum', 'Full'.",
        SerializedName = @"verbosityLevel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VerbosityLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VerbosityLevel? VerbosityLevel { get; set; }

    }
    /// Parameters to get network configuration diagnostic.
    internal partial interface INetworkConfigurationDiagnosticParametersInternal

    {
        /// <summary>List of network configuration diagnostic profiles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile[] Profile { get; set; }
        /// <summary>
        /// The ID of the target resource to perform network configuration diagnostic. Valid options are VM, NetworkInterface, VMSS/NetworkInterface
        /// and Application Gateway.
        /// </summary>
        string TargetResourceId { get; set; }
        /// <summary>Verbosity level. Accepted values are 'Normal', 'Minimum', 'Full'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VerbosityLevel? VerbosityLevel { get; set; }

    }
}