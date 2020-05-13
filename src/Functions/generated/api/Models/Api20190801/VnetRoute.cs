namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Virtual Network route contract used to pass routing information for a Virtual Network.
    /// </summary>
    public partial class VnetRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string EndAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal)Property).EndAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal)Property).EndAddress = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteProperties _property;

        /// <summary>VnetRoute resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteProperties()); set => this._property = value; }

        /// <summary>
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? RouteType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal)Property).RouteType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal)Property).RouteType = value; }

        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be
        /// specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string StartAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal)Property).StartAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoutePropertiesInternal)Property).StartAddress = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }

        /// <summary>Creates an new <see cref="VnetRoute" /> instance.</summary>
        public VnetRoute()
        {

        }
    }
    /// Virtual Network route contract used to pass routing information for a Virtual Network.
    public partial interface IVnetRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.",
        SerializedName = @"endAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EndAddress { get; set; }
        /// <summary>
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of route this is:
        DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        INHERITED - Routes inherited from the real Virtual Network routes
        STATIC - Static route set on the app only

        These values will be used for syncing an app's routes with those from a Virtual Network.",
        SerializedName = @"routeType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? RouteType { get; set; }
        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be
        /// specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The starting address for this route. This may also include a CIDR notation, in which case the end address must not be specified.",
        SerializedName = @"startAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StartAddress { get; set; }

    }
    /// Virtual Network route contract used to pass routing information for a Virtual Network.
    internal partial interface IVnetRouteInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>
        /// The ending address for this route. If the start address is specified in CIDR notation, this must be omitted.
        /// </summary>
        string EndAddress { get; set; }
        /// <summary>VnetRoute resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRouteProperties Property { get; set; }
        /// <summary>
        /// The type of route this is:
        /// DEFAULT - By default, every app has routes to the local address ranges specified by RFC1918
        /// INHERITED - Routes inherited from the real Virtual Network routes
        /// STATIC - Static route set on the app only
        /// These values will be used for syncing an app's routes with those from a Virtual Network.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RouteType? RouteType { get; set; }
        /// <summary>
        /// The starting address for this route. This may also include a CIDR notation, in which case the end address must not be
        /// specified.
        /// </summary>
        string StartAddress { get; set; }

    }
}