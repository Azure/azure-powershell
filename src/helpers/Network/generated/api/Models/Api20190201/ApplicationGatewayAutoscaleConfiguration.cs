namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Application Gateway autoscale configuration.</summary>
    public partial class ApplicationGatewayAutoscaleConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAutoscaleConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAutoscaleConfigurationInternal
    {

        /// <summary>Backing field for <see cref="MaxCapacity" /> property.</summary>
        private int? _maxCapacity;

        /// <summary>Upper bound on number of Application Gateway capacity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MaxCapacity { get => this._maxCapacity; set => this._maxCapacity = value; }

        /// <summary>Backing field for <see cref="MinCapacity" /> property.</summary>
        private int _minCapacity;

        /// <summary>Lower bound on number of Application Gateway capacity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int MinCapacity { get => this._minCapacity; set => this._minCapacity = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayAutoscaleConfiguration" /> instance.
        /// </summary>
        public ApplicationGatewayAutoscaleConfiguration()
        {

        }
    }
    /// Application Gateway autoscale configuration.
    public partial interface IApplicationGatewayAutoscaleConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Upper bound on number of Application Gateway capacity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Upper bound on number of Application Gateway capacity",
        SerializedName = @"maxCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxCapacity { get; set; }
        /// <summary>Lower bound on number of Application Gateway capacity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Lower bound on number of Application Gateway capacity",
        SerializedName = @"minCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int MinCapacity { get; set; }

    }
    /// Application Gateway autoscale configuration.
    internal partial interface IApplicationGatewayAutoscaleConfigurationInternal

    {
        /// <summary>Upper bound on number of Application Gateway capacity</summary>
        int? MaxCapacity { get; set; }
        /// <summary>Lower bound on number of Application Gateway capacity</summary>
        int MinCapacity { get; set; }

    }
}