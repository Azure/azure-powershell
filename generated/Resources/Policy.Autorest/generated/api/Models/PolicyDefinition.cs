// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy definition.</summary>
    public partial class PolicyDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ProxyResource();

        /// <summary>The policy definition description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>The display name of the policy definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 2)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).DisplayName = value ?? null; }

        /// <summary>The details of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny EndpointSettingDetailRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).EndpointSettingDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).EndpointSettingDetail = value ?? null /* model class */; }

        /// <summary>The kind of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string EndpointSettingKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).EndpointSettingKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).EndpointSettingKind = value ?? null; }

        /// <summary>
        /// What to do when evaluating an enforcement policy that requires an external evaluation and the token is missing. Possible
        /// values are Audit and Deny and language expressions are supported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string ExternalEvaluationEnforcementSettingMissingTokenAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingMissingTokenAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingMissingTokenAction = value ?? null; }

        /// <summary>
        /// The lifespan of the endpoint invocation result after which it's no longer valid. Value is expected to follow the ISO 8601
        /// duration format and language expressions are supported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string ExternalEvaluationEnforcementSettingResultLifespan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingResultLifespan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingResultLifespan = value ?? null; }

        /// <summary>
        /// An array of the role definition Ids the assignment's MSI will need in order to invoke the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<string> ExternalEvaluationEnforcementSettingRoleDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingRoleDefinitionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingRoleDefinitionId = value ?? null /* arrayOf */; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>
        /// The policy definition metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ExternalEvaluationEnforcementSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEnforcementSettings Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionInternal.ExternalEvaluationEnforcementSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSetting = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ExternalEvaluationEnforcementSettingEndpointSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointSettings Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionInternal.ExternalEvaluationEnforcementSettingEndpointSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingEndpointSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).ExternalEvaluationEnforcementSettingEndpointSetting = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionProperties Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyDefinitionProperties()); set { {_property = value;} } }

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

        /// <summary>
        /// The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Mode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Mode = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>
        /// The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesParameters ParameterRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Parameter = value ?? null /* model class */; }

        /// <summary>The policy rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny PolicyRuleRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).PolicyRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).PolicyRule = value ?? null /* model class */; }

        /// <summary>
        /// The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 1)]
        public string PolicyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).PolicyType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).PolicyType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionProperties _property;

        /// <summary>The policy definition properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyDefinitionProperties()); set => this._property = value; }

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

        /// <summary>The policy definition version in #.#.# format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Version = value ?? null; }

        /// <summary>A list of available versions for this policy definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<string> Versions { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Versions; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Versions = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="PolicyDefinition" /> instance.</summary>
        public PolicyDefinition()
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
    /// The policy definition.
    public partial interface IPolicyDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResource
    {
        /// <summary>The policy definition description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name of the policy definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display name of the policy definition.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>The details of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The details of the endpoint.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny EndpointSettingDetailRaw { get; set; }
        /// <summary>The kind of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The kind of the endpoint.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointSettingKind { get; set; }
        /// <summary>
        /// What to do when evaluating an enforcement policy that requires an external evaluation and the token is missing. Possible
        /// values are Audit and Deny and language expressions are supported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"What to do when evaluating an enforcement policy that requires an external evaluation and the token is missing. Possible values are Audit and Deny and language expressions are supported.",
        SerializedName = @"missingTokenAction",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalEvaluationEnforcementSettingMissingTokenAction { get; set; }
        /// <summary>
        /// The lifespan of the endpoint invocation result after which it's no longer valid. Value is expected to follow the ISO 8601
        /// duration format and language expressions are supported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The lifespan of the endpoint invocation result after which it's no longer valid. Value is expected to follow the ISO 8601 duration format and language expressions are supported.",
        SerializedName = @"resultLifespan",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalEvaluationEnforcementSettingResultLifespan { get; set; }
        /// <summary>
        /// An array of the role definition Ids the assignment's MSI will need in order to invoke the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of the role definition Ids the assignment's MSI will need in order to invoke the endpoint.",
        SerializedName = @"roleDefinitionIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ExternalEvaluationEnforcementSettingRoleDefinitionId { get; set; }
        /// <summary>
        /// The policy definition metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get; set; }
        /// <summary>
        /// The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        string Mode { get; set; }
        /// <summary>
        /// The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The parameter definitions for parameters used in the policy rule. The keys are the parameter names.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesParameters ParameterRaw { get; set; }
        /// <summary>The policy rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy rule.",
        SerializedName = @"policyRule",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny PolicyRuleRaw { get; set; }
        /// <summary>
        /// The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.",
        SerializedName = @"policyType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "BuiltIn", "Custom", "Static")]
        string PolicyType { get; set; }
        /// <summary>The policy definition version in #.#.# format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition version in #.#.# format.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }
        /// <summary>A list of available versions for this policy definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A list of available versions for this policy definition.",
        SerializedName = @"versions",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Versions { get; set; }

    }
    /// The policy definition.
    internal partial interface IPolicyDefinitionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IProxyResourceInternal
    {
        /// <summary>The policy definition description.</summary>
        string Description { get; set; }
        /// <summary>The display name of the policy definition.</summary>
        string DisplayName { get; set; }
        /// <summary>The details of the endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny EndpointSettingDetailRaw { get; set; }
        /// <summary>The kind of the endpoint.</summary>
        string EndpointSettingKind { get; set; }
        /// <summary>
        /// The details of the source of external evaluation results required by the policy during enforcement evaluation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEnforcementSettings ExternalEvaluationEnforcementSetting { get; set; }
        /// <summary>The settings of an external endpoint providing evaluation results.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointSettings ExternalEvaluationEnforcementSettingEndpointSetting { get; set; }
        /// <summary>
        /// What to do when evaluating an enforcement policy that requires an external evaluation and the token is missing. Possible
        /// values are Audit and Deny and language expressions are supported.
        /// </summary>
        string ExternalEvaluationEnforcementSettingMissingTokenAction { get; set; }
        /// <summary>
        /// The lifespan of the endpoint invocation result after which it's no longer valid. Value is expected to follow the ISO 8601
        /// duration format and language expressions are supported.
        /// </summary>
        string ExternalEvaluationEnforcementSettingResultLifespan { get; set; }
        /// <summary>
        /// An array of the role definition Ids the assignment's MSI will need in order to invoke the endpoint.
        /// </summary>
        System.Collections.Generic.List<string> ExternalEvaluationEnforcementSettingRoleDefinitionId { get; set; }
        /// <summary>
        /// The policy definition metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get; set; }
        /// <summary>
        /// The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data.
        /// </summary>
        string Mode { get; set; }
        /// <summary>
        /// The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesParameters ParameterRaw { get; set; }
        /// <summary>The policy rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny PolicyRuleRaw { get; set; }
        /// <summary>
        /// The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "BuiltIn", "Custom", "Static")]
        string PolicyType { get; set; }
        /// <summary>The policy definition properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionProperties Property { get; set; }
        /// <summary>The policy definition version in #.#.# format.</summary>
        string Version { get; set; }
        /// <summary>A list of available versions for this policy definition.</summary>
        System.Collections.Generic.List<string> Versions { get; set; }

    }
}