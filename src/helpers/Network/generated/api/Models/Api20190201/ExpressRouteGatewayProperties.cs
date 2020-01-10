namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>ExpressRoute gateway resource properties.</summary>
    public partial class ExpressRouteGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AutoScaleConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration _autoScaleConfiguration;

        /// <summary>Configuration for auto scaling.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration AutoScaleConfiguration { get => (this._autoScaleConfiguration = this._autoScaleConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfiguration()); set => this._autoScaleConfiguration = value; }

        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BoundMax { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal)AutoScaleConfiguration).BoundMax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal)AutoScaleConfiguration).BoundMax = value; }

        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BoundMin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal)AutoScaleConfiguration).BoundMin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal)AutoScaleConfiguration).BoundMin = value; }

        /// <summary>Backing field for <see cref="ExpressRouteConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] _expressRouteConnection;

        /// <summary>List of ExpressRoute connections to the ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] ExpressRouteConnection { get => this._expressRouteConnection; }

        /// <summary>Internal Acessors for AutoScaleConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal.AutoScaleConfiguration { get => (this._autoScaleConfiguration = this._autoScaleConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayPropertiesAutoScaleConfiguration()); set { {_autoScaleConfiguration = value;} } }

        /// <summary>Internal Acessors for AutoScaleConfigurationBound</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal.AutoScaleConfigurationBound { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal)AutoScaleConfiguration).Bound; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationInternal)AutoScaleConfiguration).Bound = value; }

        /// <summary>Internal Acessors for ExpressRouteConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal.ExpressRouteConnection { get => this._expressRouteConnection; set { {_expressRouteConnection = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal.VirtualHub { get => (this._virtualHub = this._virtualHub ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubId()); set { {_virtualHub = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="VirtualHub" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId _virtualHub;

        /// <summary>The Virtual Hub where the ExpressRoute gateway is or will be deployed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId VirtualHub { get => (this._virtualHub = this._virtualHub ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubId()); set => this._virtualHub = value; }

        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubIdInternal)VirtualHub).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubIdInternal)VirtualHub).Id = value; }

        /// <summary>Creates an new <see cref="ExpressRouteGatewayProperties" /> instance.</summary>
        public ExpressRouteGatewayProperties()
        {

        }
    }
    /// ExpressRoute gateway resource properties.
    public partial interface IExpressRouteGatewayProperties :
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
        /// <summary>List of ExpressRoute connections to the ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of ExpressRoute connections to the ExpressRoute gateway.",
        SerializedName = @"expressRouteConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] ExpressRouteConnection { get;  }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and the ExpressRoute gateway resource reside in the same subscription.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualHubId { get; set; }

    }
    /// ExpressRoute gateway resource properties.
    internal partial interface IExpressRouteGatewayPropertiesInternal

    {
        /// <summary>Configuration for auto scaling.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration AutoScaleConfiguration { get; set; }
        /// <summary>Minimum and maximum number of scale units to deploy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds AutoScaleConfigurationBound { get; set; }
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        int? BoundMax { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        int? BoundMin { get; set; }
        /// <summary>List of ExpressRoute connections to the ExpressRoute gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] ExpressRouteConnection { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The Virtual Hub where the ExpressRoute gateway is or will be deployed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId VirtualHub { get; set; }
        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        string VirtualHubId { get; set; }

    }
}