namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Represents a Configuration.</summary>
    public partial class Configuration :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.ProxyResource();

        /// <summary>Allowed values of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string AllowedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).AllowedValue; }

        /// <summary>Data type of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string DataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).DataType; }

        /// <summary>Default value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string DefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).DefaultValue; }

        /// <summary>Description of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Description; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for AllowedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationInternal.AllowedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).AllowedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).AllowedValue = value; }

        /// <summary>Internal Acessors for DataType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationInternal.DataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).DataType; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).DataType = value; }

        /// <summary>Internal Acessors for DefaultValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationInternal.DefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).DefaultValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).DefaultValue = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ConfigurationProperties()); set { {_property = value;} } }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationProperties _property;

        /// <summary>The properties of a configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ConfigurationProperties()); set => this._property = value; }

        /// <summary>Source of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Source = value; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IResourceInternal)__proxyResource).Type; }

        /// <summary>Value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.FormatTable(Index = 1)]
        public string Value { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationPropertiesInternal)Property).Value = value; }

        /// <summary>Creates an new <see cref="Configuration" /> instance.</summary>
        public Configuration()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Represents a Configuration.
    public partial interface IConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IProxyResource
    {
        /// <summary>Allowed values of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Allowed values of the configuration.",
        SerializedName = @"allowedValues",
        PossibleTypes = new [] { typeof(string) })]
        string AllowedValue { get;  }
        /// <summary>Data type of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Data type of the configuration.",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        string DataType { get;  }
        /// <summary>Default value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Default value of the configuration.",
        SerializedName = @"defaultValue",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultValue { get;  }
        /// <summary>Description of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the configuration.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Source of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source of the configuration.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }
        /// <summary>Value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value of the configuration.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Represents a Configuration.
    internal partial interface IConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api10.IProxyResourceInternal
    {
        /// <summary>Allowed values of the configuration.</summary>
        string AllowedValue { get; set; }
        /// <summary>Data type of the configuration.</summary>
        string DataType { get; set; }
        /// <summary>Default value of the configuration.</summary>
        string DefaultValue { get; set; }
        /// <summary>Description of the configuration.</summary>
        string Description { get; set; }
        /// <summary>The properties of a configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IConfigurationProperties Property { get; set; }
        /// <summary>Source of the configuration.</summary>
        string Source { get; set; }
        /// <summary>Value of the configuration.</summary>
        string Value { get; set; }

    }
}