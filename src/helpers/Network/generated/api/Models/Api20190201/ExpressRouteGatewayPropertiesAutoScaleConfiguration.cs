namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Configuration for auto scaling.</summary>
    public partial class ExpressRouteGatewayPropertiesAutoScaleConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Bound" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds _bound;

        /// <summary>Minimum and maximum number of scale units to deploy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds Bound { get => (this._bound = this._bound ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds()); set => this._bound = value; }

        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BoundMax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)Bound).Max; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)Bound).Max = value; }

        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BoundMin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)Bound).Min; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsInternal)Bound).Min = value; }

        /// <summary>Internal Acessors for Bound</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal.Bound { get => (this._bound = this._bound ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfigurationBounds()); set { {_bound = value;} } }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteGatewayPropertiesAutoScaleConfiguration" /> instance.
        /// </summary>
        public ExpressRouteGatewayPropertiesAutoScaleConfiguration()
        {

        }
    }
    /// Configuration for auto scaling.
    public partial interface IExpressRouteGatewayPropertiesAutoScaleConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of scale units deployed for ExpressRoute gateway.",
        SerializedName = @"max",
        PossibleTypes = new [] { typeof(int) })]
        int? BoundMax { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of scale units deployed for ExpressRoute gateway.",
        SerializedName = @"min",
        PossibleTypes = new [] { typeof(int) })]
        int? BoundMin { get; set; }

    }
    /// Configuration for auto scaling.
    internal partial interface IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal

    {
        /// <summary>Minimum and maximum number of scale units to deploy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds Bound { get; set; }
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        int? BoundMax { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        int? BoundMin { get; set; }

    }
}