// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy set definition.</summary>
    public partial class PolicySetDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ProxyResource();

        /// <summary>The policy set definition description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>The display name of the policy set definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 2)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).DisplayName = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>
        /// The policy set definition metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionProperties Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicySetDefinitionProperties()); set { {_property = value;} } }

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
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>
        /// The policy set definition parameters that can be used in policy definition references.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesParameters ParameterRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Parameter = value ?? null /* model class */; }

        /// <summary>An array of policy definition references.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReference> PolicyDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).PolicyDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).PolicyDefinition = value ?? null /* arrayOf */; }

        /// <summary>
        /// The metadata describing groups of policy definition references within the policy set definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionGroup> PolicyDefinitionGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).PolicyDefinitionGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).PolicyDefinitionGroup = value ?? null /* arrayOf */; }

        /// <summary>
        /// The type of policy set definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 1)]
        public string PolicyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).PolicyType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).PolicyType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionProperties _property;

        /// <summary>The policy set definition properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicySetDefinitionProperties()); set => this._property = value; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>The policy set definition version in #.#.# format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Version = value ?? null; }

        /// <summary>A list of available versions for this policy set definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<string> Versions { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Versions; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Versions = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="PolicySetDefinition" /> instance.</summary>
        public PolicySetDefinition()
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
    /// The policy set definition.
    public partial interface IPolicySetDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource
    {
        /// <summary>The policy set definition description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name of the policy set definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display name of the policy set definition.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// The policy set definition metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get; set; }
        /// <summary>
        /// The policy set definition parameters that can be used in policy definition references.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition parameters that can be used in policy definition references.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesParameters ParameterRaw { get; set; }
        /// <summary>An array of policy definition references.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of policy definition references.",
        SerializedName = @"policyDefinitions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReference) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReference> PolicyDefinition { get; set; }
        /// <summary>
        /// The metadata describing groups of policy definition references within the policy set definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The metadata describing groups of policy definition references within the policy set definition.",
        SerializedName = @"policyDefinitionGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionGroup) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionGroup> PolicyDefinitionGroup { get; set; }
        /// <summary>
        /// The type of policy set definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of policy set definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.",
        SerializedName = @"policyType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "BuiltIn", "Custom", "Static")]
        string PolicyType { get; set; }
        /// <summary>The policy set definition version in #.#.# format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition version in #.#.# format.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }
        /// <summary>A list of available versions for this policy set definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A list of available versions for this policy set definition.",
        SerializedName = @"versions",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Versions { get; set; }

    }
    /// The policy set definition.
    internal partial interface IPolicySetDefinitionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResourceInternal
    {
        /// <summary>The policy set definition description.</summary>
        string Description { get; set; }
        /// <summary>The display name of the policy set definition.</summary>
        string DisplayName { get; set; }
        /// <summary>
        /// The policy set definition metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get; set; }
        /// <summary>
        /// The policy set definition parameters that can be used in policy definition references.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesParameters ParameterRaw { get; set; }
        /// <summary>An array of policy definition references.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReference> PolicyDefinition { get; set; }
        /// <summary>
        /// The metadata describing groups of policy definition references within the policy set definition.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionGroup> PolicyDefinitionGroup { get; set; }
        /// <summary>
        /// The type of policy set definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "BuiltIn", "Custom", "Static")]
        string PolicyType { get; set; }
        /// <summary>The policy set definition properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionProperties Property { get; set; }
        /// <summary>The policy set definition version in #.#.# format.</summary>
        string Version { get; set; }
        /// <summary>A list of available versions for this policy set definition.</summary>
        System.Collections.Generic.List<string> Versions { get; set; }

    }
}