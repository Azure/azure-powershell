// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Configuration (also known as server parameter).</summary>
    public partial class Configuration :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ProxyResource();

        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 3, Width = 20)]
        public string AllowedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).AllowedValue; }

        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 1, Width = 15)]
        public string DataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DataType; }

        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 4, Width = 20)]
        public string DefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DefaultValue; }

        /// <summary>Description of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 6, Width = 50)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Description; }

        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string DocumentationLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DocumentationLink; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public bool? IsConfigPendingRestart { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsConfigPendingRestart; }

        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public bool? IsDynamicConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsDynamicConfig; }

        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public bool? IsReadOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsReadOnly; }

        /// <summary>Internal Acessors for AllowedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.AllowedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).AllowedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).AllowedValue = value ?? null; }

        /// <summary>Internal Acessors for DataType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.DataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DataType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DataType = value ?? null; }

        /// <summary>Internal Acessors for DefaultValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.DefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DefaultValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DefaultValue = value ?? null; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>Internal Acessors for DocumentationLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.DocumentationLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DocumentationLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DocumentationLink = value ?? null; }

        /// <summary>Internal Acessors for IsConfigPendingRestart</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.IsConfigPendingRestart { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsConfigPendingRestart; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsConfigPendingRestart = value ?? default(bool); }

        /// <summary>Internal Acessors for IsDynamicConfig</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.IsDynamicConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsDynamicConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsDynamicConfig = value ?? default(bool); }

        /// <summary>Internal Acessors for IsReadOnly</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.IsReadOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsReadOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsReadOnly = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationInternal.Unit { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Unit; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Unit = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 0, Width = 35)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties _property;

        /// <summary>Properties of a configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationProperties()); set => this._property = value; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 5, Width = 15)]
        public string Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Source = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.DoNotFormat]
        public string Unit { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Unit; }

        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.FormatTable(Index = 2, Width = 20)]
        public string Value { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Value = value ?? null; }

        /// <summary>Creates an new <see cref="Configuration" /> instance.</summary>
        public Configuration()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Configuration (also known as server parameter).
    public partial interface IConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResource
    {
        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Allowed values of the configuration (also known as server parameter).",
        SerializedName = @"allowedValues",
        PossibleTypes = new [] { typeof(string) })]
        string AllowedValue { get;  }
        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Data type of the configuration (also known as server parameter).",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Boolean", "Numeric", "Integer", "Enumeration", "String", "Set")]
        string DataType { get;  }
        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Value assigned by default to the configuration (also known as server parameter).",
        SerializedName = @"defaultValue",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultValue { get;  }
        /// <summary>Description of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Description of the configuration (also known as server parameter).",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Link pointing to the documentation of the configuration (also known as server parameter).",
        SerializedName = @"documentationLink",
        PossibleTypes = new [] { typeof(string) })]
        string DocumentationLink { get;  }
        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for it to take effect.",
        SerializedName = @"isConfigPendingRestart",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsConfigPendingRestart { get;  }
        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters do not require a server restart after changing the value assigned to them, for the change to take effect.",
        SerializedName = @"isDynamicConfig",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDynamicConfig { get;  }
        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).",
        SerializedName = @"isReadOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsReadOnly { get;  }
        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable configuration.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }
        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Units in which the configuration (also known as server parameter) value is expressed.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }
        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable configuration.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Configuration (also known as server parameter).
    internal partial interface IConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IProxyResourceInternal
    {
        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        string AllowedValue { get; set; }
        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Boolean", "Numeric", "Integer", "Enumeration", "String", "Set")]
        string DataType { get; set; }
        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        string DefaultValue { get; set; }
        /// <summary>Description of the configuration (also known as server parameter).</summary>
        string Description { get; set; }
        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        string DocumentationLink { get; set; }
        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        bool? IsConfigPendingRestart { get; set; }
        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        bool? IsDynamicConfig { get; set; }
        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        bool? IsReadOnly { get; set; }
        /// <summary>Properties of a configuration (also known as server parameter).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties Property { get; set; }
        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        string Source { get; set; }
        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        string Unit { get; set; }
        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        string Value { get; set; }

    }
}