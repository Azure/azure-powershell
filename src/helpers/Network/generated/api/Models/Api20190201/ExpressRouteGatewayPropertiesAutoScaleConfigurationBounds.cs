namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Minimum and maximum number of scale units to deploy.</summary>
    public partial class ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal
    {

        /// <summary>Backing field for <see cref="Max" /> property.</summary>
        private int? _max;

        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Max { get => this._max; set => this._max = value; }

        /// <summary>Backing field for <see cref="Min" /> property.</summary>
        private int? _min;

        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Min { get => this._min; set => this._min = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds" /> instance.
        /// </summary>
        public ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds()
        {

        }
    }
    /// Minimum and maximum number of scale units to deploy.
    public partial interface IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of scale units deployed for ExpressRoute gateway.",
        SerializedName = @"max",
        PossibleTypes = new [] { typeof(int) })]
        int? Max { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of scale units deployed for ExpressRoute gateway.",
        SerializedName = @"min",
        PossibleTypes = new [] { typeof(int) })]
        int? Min { get; set; }

    }
    /// Minimum and maximum number of scale units to deploy.
    internal partial interface IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal

    {
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        int? Max { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        int? Min { get; set; }

    }
}