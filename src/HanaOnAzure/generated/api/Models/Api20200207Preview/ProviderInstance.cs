namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>A provider instance associated with a SAP monitor.</summary>
    public partial class ProviderInstance :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ProxyResource();

        /// <summary>The Azure Resource Manager resource ID for the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Id; }

        /// <summary>A JSON string containing metadata of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).Metadata = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ProviderInstanceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>The name of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Name; }

        /// <summary>The type of provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string PropertiesType { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).Type = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceProperties _property;

        /// <summary>Provider Instance properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ProviderInstanceProperties()); set => this._property = value; }

        /// <summary>A JSON string containing the properties of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string ProviderInstanceProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).Property = value; }

        /// <summary>State of provisioning of the provider instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstancePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The resource type of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="ProviderInstance" /> instance.</summary>
        public ProviderInstance()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// A provider instance associated with a SAP monitor.
    public partial interface IProviderInstance :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IProxyResource
    {
        /// <summary>A JSON string containing metadata of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A JSON string containing metadata of the provider instance.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(string) })]
        string Metadata { get; set; }
        /// <summary>The type of provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of provider instance.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesType { get; set; }
        /// <summary>A JSON string containing the properties of the provider instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A JSON string containing the properties of the provider instance.",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderInstanceProperty { get; set; }
        /// <summary>State of provisioning of the provider instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of provisioning of the provider instance",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get;  }

    }
    /// A provider instance associated with a SAP monitor.
    internal partial interface IProviderInstanceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IProxyResourceInternal
    {
        /// <summary>A JSON string containing metadata of the provider instance.</summary>
        string Metadata { get; set; }
        /// <summary>The type of provider instance.</summary>
        string PropertiesType { get; set; }
        /// <summary>Provider Instance properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstanceProperties Property { get; set; }
        /// <summary>A JSON string containing the properties of the provider instance.</summary>
        string ProviderInstanceProperty { get; set; }
        /// <summary>State of provisioning of the provider instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get; set; }

    }
}