namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>ExpressRoute gateway resource.</summary>
    public partial class ExpressRouteGateway :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGateway,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; }

        /// <summary>List of ExpressRoute connections to the ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] ExpressRouteConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).ExpressRouteConnection; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Max Scale Unit")]
        public int? MaximumScaleUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).BoundMax; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).BoundMax = value; }

        /// <summary>Internal Acessors for AutoScaleConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal.AutoScaleConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).AutoScaleConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).AutoScaleConfiguration = value; }

        /// <summary>Internal Acessors for AutoScaleConfigurationBound</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal.AutoScaleConfigurationBound { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).AutoScaleConfigurationBound; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).AutoScaleConfigurationBound = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for ExpressRouteConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal.ExpressRouteConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).ExpressRouteConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).ExpressRouteConnection = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubId Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayInternal.VirtualHub { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).VirtualHub; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).VirtualHub = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2, Label = @"Min Scale Unit")]
        public int? MinimumScaleUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).BoundMin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).BoundMin = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties _property;

        /// <summary>Properties of the express route gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteGatewayProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Provisioning State")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>
        /// The resource URI for the Virtual Hub where the ExpressRoute gateway is or will be deployed. The Virtual Hub resource and
        /// the ExpressRoute gateway resource reside in the same subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string VirtualHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).VirtualHubId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesInternal)Property).VirtualHubId = value; }

        /// <summary>Creates an new <see cref="ExpressRouteGateway" /> instance.</summary>
        public ExpressRouteGateway()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// ExpressRoute gateway resource.
    public partial interface IExpressRouteGateway :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>List of ExpressRoute connections to the ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of ExpressRoute connections to the ExpressRoute gateway.",
        SerializedName = @"expressRouteConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] ExpressRouteConnection { get;  }
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of scale units deployed for ExpressRoute gateway.",
        SerializedName = @"max",
        PossibleTypes = new [] { typeof(int) })]
        int? MaximumScaleUnit { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of scale units deployed for ExpressRoute gateway.",
        SerializedName = @"min",
        PossibleTypes = new [] { typeof(int) })]
        int? MinimumScaleUnit { get; set; }
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
    /// ExpressRoute gateway resource.
    internal partial interface IExpressRouteGatewayInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>Configuration for auto scaling.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfiguration AutoScaleConfiguration { get; set; }
        /// <summary>Minimum and maximum number of scale units to deploy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayPropertiesAutoScaleConfigurationBounds AutoScaleConfigurationBound { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>List of ExpressRoute connections to the ExpressRoute gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteConnection[] ExpressRouteConnection { get; set; }
        /// <summary>Maximum number of scale units deployed for ExpressRoute gateway.</summary>
        int? MaximumScaleUnit { get; set; }
        /// <summary>Minimum number of scale units deployed for ExpressRoute gateway.</summary>
        int? MinimumScaleUnit { get; set; }
        /// <summary>Properties of the express route gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteGatewayProperties Property { get; set; }
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