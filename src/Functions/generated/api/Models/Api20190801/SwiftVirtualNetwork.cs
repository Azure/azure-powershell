namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.
    /// </summary>
    public partial class SwiftVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetwork,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkInternal,
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
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SwiftVirtualNetworkProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkProperties _property;

        /// <summary>SwiftVirtualNetwork resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SwiftVirtualNetworkProperties()); set => this._property = value; }

        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation
        /// to Microsoft.Web/serverFarms defined first.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SubnetResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkPropertiesInternal)Property).SubnetResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkPropertiesInternal)Property).SubnetResourceId = value; }

        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? SwiftSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkPropertiesInternal)Property).SwiftSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkPropertiesInternal)Property).SwiftSupported = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="SwiftVirtualNetwork" /> instance.</summary>
        public SwiftVirtualNetwork()
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
    /// Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.
    public partial interface ISwiftVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation
        /// to Microsoft.Web/serverFarms defined first.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation to Microsoft.Web/serverFarms defined first.",
        SerializedName = @"subnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetResourceId { get; set; }
        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag that specifies if the scale unit this Web App is on supports Swift integration.",
        SerializedName = @"swiftSupported",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SwiftSupported { get; set; }

    }
    /// Swift Virtual Network Contract. This is used to enable the new Swift way of doing virtual network integration.
    internal partial interface ISwiftVirtualNetworkInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>SwiftVirtualNetwork resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISwiftVirtualNetworkProperties Property { get; set; }
        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation
        /// to Microsoft.Web/serverFarms defined first.
        /// </summary>
        string SubnetResourceId { get; set; }
        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        bool? SwiftSupported { get; set; }

    }
}