namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>ExpressRouteCircuit resource</summary>
    public partial class ExpressRouteCircuit :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuit,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Resource();

        /// <summary>Allow classic operations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2, Label = @"Classic Operations Allowed")]
        public bool? AllowClassicOperations { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).AllowClassicOperation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).AllowClassicOperation = value; }

        /// <summary>The list of authorizations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] Authorization { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).Authorization; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).Authorization = value; }

        /// <summary>The CircuitProvisioningState state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Circuit Provisioning State")]
        public string CircuitProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).CircuitProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).CircuitProvisioningState = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; }

        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string GatewayManagerEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).GatewayManagerEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).GatewayManagerEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ServiceProviderProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitInternal.ServiceProviderProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderProperty = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; }

        /// <summary>The list of peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Peering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).Peering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).Peering = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormat _property;

        /// <summary>Properties of ExpressRouteCircuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 6, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>The ServiceKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string ServiceKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceKey = value; }

        /// <summary>The BandwidthInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public int? ServiceProviderBandwidthInMbps { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderPropertyBandwidthInMbps; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderPropertyBandwidthInMbps = value; }

        /// <summary>The serviceProviderName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 8, Label = @"Service Provider Name")]
        public string ServiceProviderName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderPropertyServiceProviderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderPropertyServiceProviderName = value; }

        /// <summary>The ServiceProviderNotes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 5, Label = @"Notes")]
        public string ServiceProviderNote { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderNote; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderNote = value; }

        /// <summary>The peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string ServiceProviderPeeringLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderPropertyPeeringLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderPropertyPeeringLocation = value; }

        /// <summary>
        /// The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned',
        /// and 'Deprovisioning'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Service Provider Provisioning State")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal)Property).ServiceProviderProvisioningState = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSku _sku;

        /// <summary>The SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitSku()); set => this._sku = value; }

        /// <summary>The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal)Sku).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal)Sku).Family = value; }

        /// <summary>The name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 7, Label = @"SKU Name")]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal)Sku).Name = value; }

        /// <summary>The tier of the SKU. Possible values are 'Standard' and 'Premium'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal)Sku).Tier = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuit" /> instance.</summary>
        public ExpressRouteCircuit()
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
    /// ExpressRouteCircuit resource
    public partial interface IExpressRouteCircuit :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource
    {
        /// <summary>Allow classic operations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allow classic operations",
        SerializedName = @"allowClassicOperations",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowClassicOperations { get; set; }
        /// <summary>The list of authorizations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of authorizations.",
        SerializedName = @"authorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] Authorization { get; set; }
        /// <summary>The CircuitProvisioningState state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CircuitProvisioningState state of the resource.",
        SerializedName = @"circuitProvisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitProvisioningState { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The GatewayManager Etag.",
        SerializedName = @"gatewayManagerEtag",
        PossibleTypes = new [] { typeof(string) })]
        string GatewayManagerEtag { get; set; }
        /// <summary>The list of peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The ServiceKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ServiceKey.",
        SerializedName = @"serviceKey",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceKey { get; set; }
        /// <summary>The BandwidthInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BandwidthInMbps.",
        SerializedName = @"bandwidthInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? ServiceProviderBandwidthInMbps { get; set; }
        /// <summary>The serviceProviderName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The serviceProviderName.",
        SerializedName = @"serviceProviderName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderName { get; set; }
        /// <summary>The ServiceProviderNotes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ServiceProviderNotes.",
        SerializedName = @"serviceProviderNotes",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderNote { get; set; }
        /// <summary>The peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peering location.",
        SerializedName = @"peeringLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderPeeringLocation { get; set; }
        /// <summary>
        /// The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned',
        /// and 'Deprovisioning'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned', and 'Deprovisioning'.",
        SerializedName = @"serviceProviderProvisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get; set; }
        /// <summary>The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? SkuFamily { get; set; }
        /// <summary>The name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>The tier of the SKU. Possible values are 'Standard' and 'Premium'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tier of the SKU. Possible values are 'Standard' and 'Premium'.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? SkuTier { get; set; }

    }
    /// ExpressRouteCircuit resource
    internal partial interface IExpressRouteCircuitInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal
    {
        /// <summary>Allow classic operations</summary>
        bool? AllowClassicOperations { get; set; }
        /// <summary>The list of authorizations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] Authorization { get; set; }
        /// <summary>The CircuitProvisioningState state of the resource.</summary>
        string CircuitProvisioningState { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The GatewayManager Etag.</summary>
        string GatewayManagerEtag { get; set; }
        /// <summary>The list of peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>Properties of ExpressRouteCircuit.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormat Property { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The ServiceKey.</summary>
        string ServiceKey { get; set; }
        /// <summary>The BandwidthInMbps.</summary>
        int? ServiceProviderBandwidthInMbps { get; set; }
        /// <summary>The serviceProviderName.</summary>
        string ServiceProviderName { get; set; }
        /// <summary>The ServiceProviderNotes.</summary>
        string ServiceProviderNote { get; set; }
        /// <summary>The peering location.</summary>
        string ServiceProviderPeeringLocation { get; set; }
        /// <summary>The ServiceProviderProperties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderProperties ServiceProviderProperty { get; set; }
        /// <summary>
        /// The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned',
        /// and 'Deprovisioning'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get; set; }
        /// <summary>The SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSku Sku { get; set; }
        /// <summary>The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? SkuFamily { get; set; }
        /// <summary>The name of the SKU.</summary>
        string SkuName { get; set; }
        /// <summary>The tier of the SKU. Possible values are 'Standard' and 'Premium'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? SkuTier { get; set; }

    }
}