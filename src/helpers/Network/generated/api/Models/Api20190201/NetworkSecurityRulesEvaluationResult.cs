namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Network security rules evaluation result.</summary>
    public partial class NetworkSecurityRulesEvaluationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResultInternal
    {

        /// <summary>Backing field for <see cref="DestinationMatched" /> property.</summary>
        private bool? _destinationMatched;

        /// <summary>Value indicating whether destination is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? DestinationMatched { get => this._destinationMatched; set => this._destinationMatched = value; }

        /// <summary>Backing field for <see cref="DestinationPortMatched" /> property.</summary>
        private bool? _destinationPortMatched;

        /// <summary>Value indicating whether destination port is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? DestinationPortMatched { get => this._destinationPortMatched; set => this._destinationPortMatched = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ProtocolMatched" /> property.</summary>
        private bool? _protocolMatched;

        /// <summary>Value indicating whether protocol is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? ProtocolMatched { get => this._protocolMatched; set => this._protocolMatched = value; }

        /// <summary>Backing field for <see cref="SourceMatched" /> property.</summary>
        private bool? _sourceMatched;

        /// <summary>Value indicating whether source is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? SourceMatched { get => this._sourceMatched; set => this._sourceMatched = value; }

        /// <summary>Backing field for <see cref="SourcePortMatched" /> property.</summary>
        private bool? _sourcePortMatched;

        /// <summary>Value indicating whether source port is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? SourcePortMatched { get => this._sourcePortMatched; set => this._sourcePortMatched = value; }

        /// <summary>Creates an new <see cref="NetworkSecurityRulesEvaluationResult" /> instance.</summary>
        public NetworkSecurityRulesEvaluationResult()
        {

        }
    }
    /// Network security rules evaluation result.
    public partial interface INetworkSecurityRulesEvaluationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating whether destination is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value indicating whether destination is matched.",
        SerializedName = @"destinationMatched",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DestinationMatched { get; set; }
        /// <summary>Value indicating whether destination port is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value indicating whether destination port is matched.",
        SerializedName = @"destinationPortMatched",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DestinationPortMatched { get; set; }
        /// <summary>Name of the network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the network security rule.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Value indicating whether protocol is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value indicating whether protocol is matched.",
        SerializedName = @"protocolMatched",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ProtocolMatched { get; set; }
        /// <summary>Value indicating whether source is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value indicating whether source is matched.",
        SerializedName = @"sourceMatched",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SourceMatched { get; set; }
        /// <summary>Value indicating whether source port is matched.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value indicating whether source port is matched.",
        SerializedName = @"sourcePortMatched",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SourcePortMatched { get; set; }

    }
    /// Network security rules evaluation result.
    internal partial interface INetworkSecurityRulesEvaluationResultInternal

    {
        /// <summary>Value indicating whether destination is matched.</summary>
        bool? DestinationMatched { get; set; }
        /// <summary>Value indicating whether destination port is matched.</summary>
        bool? DestinationPortMatched { get; set; }
        /// <summary>Name of the network security rule.</summary>
        string Name { get; set; }
        /// <summary>Value indicating whether protocol is matched.</summary>
        bool? ProtocolMatched { get; set; }
        /// <summary>Value indicating whether source is matched.</summary>
        bool? SourceMatched { get; set; }
        /// <summary>Value indicating whether source port is matched.</summary>
        bool? SourcePortMatched { get; set; }

    }
}