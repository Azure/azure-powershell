// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The data policy manifest.</summary>
    public partial class DataPolicyManifest :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifest,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ProxyResource();

        /// <summary>The effect definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> Effect { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).Effect; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).Effect = value ?? null /* arrayOf */; }

        /// <summary>The non-alias field accessor values that can be used in the policy rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> FieldValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).FieldValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).FieldValue = value ?? null /* arrayOf */; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>A value indicating whether policy mode is allowed only in built-in definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public bool? IsBuiltInOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).IsBuiltInOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).IsBuiltInOnly = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataPolicyManifestProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResourceFunction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestInternal.ResourceFunction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceFunction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceFunction = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>The list of namespaces for the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> Namespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).Namespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).Namespace = value ?? null /* arrayOf */; }

        /// <summary>The policy mode of the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).PolicyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).PolicyMode = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataPolicyManifestProperties()); set => this._property = value; }

        /// <summary>An array of data manifest custom resource definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> ResourceFunctionCustom { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceFunctionCustom; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceFunctionCustom = value ?? null /* arrayOf */; }

        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> ResourceFunctionStandard { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceFunctionStandard; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceFunctionStandard = value ?? null /* arrayOf */; }

        /// <summary>An array of resource type aliases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> ResourceTypeAlias { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceTypeAlias; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)Property).ResourceTypeAlias = value ?? null /* arrayOf */; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="DataPolicyManifest" /> instance.</summary>
        public DataPolicyManifest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// The data policy manifest.
    public partial interface IDataPolicyManifest :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource
    {
        /// <summary>The effect definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The effect definition.",
        SerializedName = @"effects",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> Effect { get; set; }
        /// <summary>The non-alias field accessor values that can be used in the policy rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The non-alias field accessor values that can be used in the policy rule.",
        SerializedName = @"fieldValues",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> FieldValue { get; set; }
        /// <summary>A value indicating whether policy mode is allowed only in built-in definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A value indicating whether policy mode is allowed only in built-in definitions.",
        SerializedName = @"isBuiltInOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsBuiltInOnly { get; set; }
        /// <summary>The list of namespaces for the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of namespaces for the data policy manifest.",
        SerializedName = @"namespaces",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Namespace { get; set; }
        /// <summary>The policy mode of the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy mode of the data policy manifest.",
        SerializedName = @"policyMode",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyMode { get; set; }
        /// <summary>An array of data manifest custom resource definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of data manifest custom resource definitions.",
        SerializedName = @"custom",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> ResourceFunctionCustom { get; set; }
        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The standard resource functions (subscription and/or resourceGroup).",
        SerializedName = @"standard",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ResourceFunctionStandard { get; set; }
        /// <summary>An array of resource type aliases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of resource type aliases.",
        SerializedName = @"resourceTypeAliases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> ResourceTypeAlias { get; set; }

    }
    /// The data policy manifest.
    internal partial interface IDataPolicyManifestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResourceInternal
    {
        /// <summary>The effect definition.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> Effect { get; set; }
        /// <summary>The non-alias field accessor values that can be used in the policy rule.</summary>
        System.Collections.Generic.List<string> FieldValue { get; set; }
        /// <summary>A value indicating whether policy mode is allowed only in built-in definitions.</summary>
        bool? IsBuiltInOnly { get; set; }
        /// <summary>The list of namespaces for the data policy manifest.</summary>
        System.Collections.Generic.List<string> Namespace { get; set; }
        /// <summary>The policy mode of the data policy manifest.</summary>
        string PolicyMode { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties Property { get; set; }
        /// <summary>The resource functions definition specified in the data manifest.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition ResourceFunction { get; set; }
        /// <summary>An array of data manifest custom resource definitions.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> ResourceFunctionCustom { get; set; }
        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        System.Collections.Generic.List<string> ResourceFunctionStandard { get; set; }
        /// <summary>An array of resource type aliases.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> ResourceTypeAlias { get; set; }

    }
}