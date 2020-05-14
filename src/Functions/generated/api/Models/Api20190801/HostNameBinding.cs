namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A hostname binding object.</summary>
    public partial class HostNameBinding :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBinding,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Azure resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzureResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).AzureResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).AzureResourceName = value; }

        /// <summary>Azure resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).AzureResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).AzureResourceType = value; }

        /// <summary>Custom DNS record type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).CustomHostNameDnsRecordType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).CustomHostNameDnsRecordType = value; }

        /// <summary>Fully qualified ARM domain resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DomainId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).DomainId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).DomainId = value; }

        /// <summary>Hostname type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? HostNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).HostNameType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).HostNameType = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameBindingProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VirtualIP</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingInternal.VirtualIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).VirtualIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).VirtualIP = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties _property;

        /// <summary>HostNameBinding resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameBindingProperties()); set => this._property = value; }

        /// <summary>App Service app name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).SiteName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).SiteName = value; }

        /// <summary>SSL type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).SslState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).SslState = value; }

        /// <summary>SSL certificate thumbprint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).Thumbprint = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)Property).VirtualIP; }

        /// <summary>Creates an new <see cref="HostNameBinding" /> instance.</summary>
        public HostNameBinding()
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
    /// A hostname binding object.
    public partial interface IHostNameBinding :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Azure resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure resource name.",
        SerializedName = @"azureResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureResourceName { get; set; }
        /// <summary>Azure resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure resource type.",
        SerializedName = @"azureResourceType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get; set; }
        /// <summary>Custom DNS record type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom DNS record type.",
        SerializedName = @"customHostNameDnsRecordType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }
        /// <summary>Fully qualified ARM domain resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified ARM domain resource URI.",
        SerializedName = @"domainId",
        PossibleTypes = new [] { typeof(string) })]
        string DomainId { get; set; }
        /// <summary>Hostname type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hostname type.",
        SerializedName = @"hostNameType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? HostNameType { get; set; }
        /// <summary>App Service app name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service app name.",
        SerializedName = @"siteName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteName { get; set; }
        /// <summary>SSL type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL type",
        SerializedName = @"sslState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get; set; }
        /// <summary>SSL certificate thumbprint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL certificate thumbprint",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get; set; }
        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual IP address assigned to the hostname if IP based SSL is enabled.",
        SerializedName = @"virtualIP",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualIP { get;  }

    }
    /// A hostname binding object.
    internal partial interface IHostNameBindingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Azure resource name.</summary>
        string AzureResourceName { get; set; }
        /// <summary>Azure resource type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get; set; }
        /// <summary>Custom DNS record type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }
        /// <summary>Fully qualified ARM domain resource URI.</summary>
        string DomainId { get; set; }
        /// <summary>Hostname type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? HostNameType { get; set; }
        /// <summary>HostNameBinding resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties Property { get; set; }
        /// <summary>App Service app name.</summary>
        string SiteName { get; set; }
        /// <summary>SSL type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get; set; }
        /// <summary>SSL certificate thumbprint</summary>
        string Thumbprint { get; set; }
        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        string VirtualIP { get; set; }

    }
}