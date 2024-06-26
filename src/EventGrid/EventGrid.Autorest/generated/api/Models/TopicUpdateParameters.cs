// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Extensions;

    /// <summary>Properties of the Topic update</summary>
    public partial class TopicUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersInternal
    {

        /// <summary>The data residency boundary for the topic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string DataResidencyBoundary { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).DataResidencyBoundary; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).DataResidencyBoundary = value ?? null; }

        /// <summary>
        /// This boolean is used to enable or disable local auth. Default value is false. When the property is set to true, only AAD
        /// token will be used to authenticate if user is allowed to publish to the topic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public bool? DisableLocalAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).DisableLocalAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).DisableLocalAuth = value ?? default(bool); }

        /// <summary>
        /// A collection of inline event types for the resource. The inline event type keys are of type string which represents the
        /// name of the event.
        /// An example of a valid inline event name is "Contoso.OrderCreated".
        /// The inline event type values are of type InlineEventProperties and will contain additional information for every inline
        /// event type.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventTypeInfoInlineEventTypes EventTypeInfoInlineEventType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).EventTypeInfoInlineEventType; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).EventTypeInfoInlineEventType = value ?? null /* model class */; }

        /// <summary>The kind of event type used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string EventTypeInfoKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).EventTypeInfoKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).EventTypeInfoKind = value ?? null; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfo _identity;

        /// <summary>Topic resource identity information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfo Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IdentityInfo()); set => this._identity = value; }

        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).PrincipalId = value ?? null; }

        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).TenantId = value ?? null; }

        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).Type = value ?? null; }

        /// <summary>
        /// The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource
        /// ids in the form:
        /// '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// This property is currently not used and reserved for future usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>
        /// This can be used to restrict traffic from specific IPs instead of all IPs. Note: These are considered only if PublicNetworkAccess
        /// is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IInboundIPRule> InboundIPRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).InboundIPRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).InboundIPRule = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for EventTypeInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventTypeInfo Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersInternal.EventTypeInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).EventTypeInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).EventTypeInfo = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfo Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IdentityInfo()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterProperties Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.TopicUpdateParameterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceSku Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ResourceSku()); set { {_sku = value;} } }

        /// <summary>Minimum TLS version of the publisher allowed to publish to this domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string MinimumTlsVersionAllowed { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).MinimumTlsVersionAllowed; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).MinimumTlsVersionAllowed = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterProperties _property;

        /// <summary>Properties of the Topic resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.TopicUpdateParameterProperties()); set => this._property = value; }

        /// <summary>
        /// This determines if traffic is allowed over public network. By default it is enabled.
        /// You can further restrict to specific IPs by configuring <seealso cref="P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.TopicUpdateParameterProperties.InboundIpRules"
        /// />
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterPropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceSku _sku;

        /// <summary>The Sku pricing tier for the topic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ResourceSku()); set => this._sku = value; }

        /// <summary>The Sku name of the resource. The possible values are: Basic or Premium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceSkuInternal)Sku).Name = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersTags _tag;

        /// <summary>Tags of the Topic resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.TopicUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="TopicUpdateParameters" /> instance.</summary>
        public TopicUpdateParameters()
        {

        }
    }
    /// Properties of the Topic update
    public partial interface ITopicUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.IJsonSerializable
    {
        /// <summary>The data residency boundary for the topic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The data residency boundary for the topic.",
        SerializedName = @"dataResidencyBoundary",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("WithinGeopair", "WithinRegion")]
        string DataResidencyBoundary { get; set; }
        /// <summary>
        /// This boolean is used to enable or disable local auth. Default value is false. When the property is set to true, only AAD
        /// token will be used to authenticate if user is allowed to publish to the topic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This boolean is used to enable or disable local auth. Default value is false. When the property is set to true, only AAD token will be used to authenticate if user is allowed to publish to the topic.",
        SerializedName = @"disableLocalAuth",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableLocalAuth { get; set; }
        /// <summary>
        /// A collection of inline event types for the resource. The inline event type keys are of type string which represents the
        /// name of the event.
        /// An example of a valid inline event name is "Contoso.OrderCreated".
        /// The inline event type values are of type InlineEventProperties and will contain additional information for every inline
        /// event type.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A collection of inline event types for the resource. The inline event type keys are of type string which represents the name of the event.
        An example of a valid inline event name is ""Contoso.OrderCreated"".
        The inline event type values are of type InlineEventProperties and will contain additional information for every inline event type.",
        SerializedName = @"inlineEventTypes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventTypeInfoInlineEventTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventTypeInfoInlineEventTypes EventTypeInfoInlineEventType { get; set; }
        /// <summary>The kind of event type used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The kind of event type used.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("Inline")]
        string EventTypeInfoKind { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The principal ID of resource identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The tenant ID of resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities. The type 'None' will remove any identity.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource
        /// ids in the form:
        /// '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// This property is currently not used and reserved for future usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form:
        '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        This property is currently not used and reserved for future usage.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>
        /// This can be used to restrict traffic from specific IPs instead of all IPs. Note: These are considered only if PublicNetworkAccess
        /// is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This can be used to restrict traffic from specific IPs instead of all IPs. Note: These are considered only if PublicNetworkAccess is enabled.",
        SerializedName = @"inboundIpRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IInboundIPRule) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IInboundIPRule> InboundIPRule { get; set; }
        /// <summary>Minimum TLS version of the publisher allowed to publish to this domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Minimum TLS version of the publisher allowed to publish to this domain",
        SerializedName = @"minimumTlsVersionAllowed",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("1.0", "1.1", "1.2")]
        string MinimumTlsVersionAllowed { get; set; }
        /// <summary>
        /// This determines if traffic is allowed over public network. By default it is enabled.
        /// You can further restrict to specific IPs by configuring <seealso cref="P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.TopicUpdateParameterProperties.InboundIpRules"
        /// />
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This determines if traffic is allowed over public network. By default it is enabled.
        You can further restrict to specific IPs by configuring <seealso cref=""P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.TopicUpdateParameterProperties.InboundIpRules"" />",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>The Sku name of the resource. The possible values are: Basic or Premium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Sku name of the resource. The possible values are: Basic or Premium.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("Basic", "Premium")]
        string SkuName { get; set; }
        /// <summary>Tags of the Topic resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Tags of the Topic resource.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersTags Tag { get; set; }

    }
    /// Properties of the Topic update
    internal partial interface ITopicUpdateParametersInternal

    {
        /// <summary>The data residency boundary for the topic.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("WithinGeopair", "WithinRegion")]
        string DataResidencyBoundary { get; set; }
        /// <summary>
        /// This boolean is used to enable or disable local auth. Default value is false. When the property is set to true, only AAD
        /// token will be used to authenticate if user is allowed to publish to the topic.
        /// </summary>
        bool? DisableLocalAuth { get; set; }
        /// <summary>The eventTypeInfo for the topic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventTypeInfo EventTypeInfo { get; set; }
        /// <summary>
        /// A collection of inline event types for the resource. The inline event type keys are of type string which represents the
        /// name of the event.
        /// An example of a valid inline event name is "Contoso.OrderCreated".
        /// The inline event type values are of type InlineEventProperties and will contain additional information for every inline
        /// event type.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventTypeInfoInlineEventTypes EventTypeInfoInlineEventType { get; set; }
        /// <summary>The kind of event type used.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("Inline")]
        string EventTypeInfoKind { get; set; }
        /// <summary>Topic resource identity information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfo Identity { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identity.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource
        /// ids in the form:
        /// '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// This property is currently not used and reserved for future usage.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IIdentityInfoUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>
        /// This can be used to restrict traffic from specific IPs instead of all IPs. Note: These are considered only if PublicNetworkAccess
        /// is enabled.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IInboundIPRule> InboundIPRule { get; set; }
        /// <summary>Minimum TLS version of the publisher allowed to publish to this domain</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("1.0", "1.1", "1.2")]
        string MinimumTlsVersionAllowed { get; set; }
        /// <summary>Properties of the Topic resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParameterProperties Property { get; set; }
        /// <summary>
        /// This determines if traffic is allowed over public network. By default it is enabled.
        /// You can further restrict to specific IPs by configuring <seealso cref="P:Microsoft.Azure.Events.ResourceProvider.Common.Contracts.TopicUpdateParameterProperties.InboundIpRules"
        /// />
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>The Sku pricing tier for the topic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IResourceSku Sku { get; set; }
        /// <summary>The Sku name of the resource. The possible values are: Basic or Premium.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PSArgumentCompleterAttribute("Basic", "Premium")]
        string SkuName { get; set; }
        /// <summary>Tags of the Topic resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ITopicUpdateParametersTags Tag { get; set; }

    }
}