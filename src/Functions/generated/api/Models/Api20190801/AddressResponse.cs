namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes main public IP address and any extra virtual IPs.</summary>
    public partial class AddressResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string InternalIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).InternalIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).InternalIPAddress = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AddressResponseProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>IP addresses appearing on outbound connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] OutboundIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).OutboundIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).OutboundIPAddress = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseProperties _property;

        /// <summary>AddressResponse resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AddressResponseProperties()); set => this._property = value; }

        /// <summary>Main public virtual IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ServiceIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).ServiceIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).ServiceIPAddress = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Additional virtual IPs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).VipMapping; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponsePropertiesInternal)Property).VipMapping = value; }

        /// <summary>Creates an new <see cref="AddressResponse" /> instance.</summary>
        public AddressResponse()
        {

        }

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
    }
    /// Describes main public IP address and any extra virtual IPs.
    public partial interface IAddressResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>
        /// Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.",
        SerializedName = @"internalIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string InternalIPAddress { get; set; }
        /// <summary>IP addresses appearing on outbound connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP addresses appearing on outbound connections.",
        SerializedName = @"outboundIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] OutboundIPAddress { get; set; }
        /// <summary>Main public virtual IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Main public virtual IP.",
        SerializedName = @"serviceIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceIPAddress { get; set; }
        /// <summary>Additional virtual IPs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional virtual IPs.",
        SerializedName = @"vipMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get; set; }

    }
    /// Describes main public IP address and any extra virtual IPs.
    internal partial interface IAddressResponseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>
        /// Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode.
        /// </summary>
        string InternalIPAddress { get; set; }
        /// <summary>IP addresses appearing on outbound connections.</summary>
        string[] OutboundIPAddress { get; set; }
        /// <summary>AddressResponse resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAddressResponseProperties Property { get; set; }
        /// <summary>Main public virtual IP.</summary>
        string ServiceIPAddress { get; set; }
        /// <summary>Additional virtual IPs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get; set; }

    }
}