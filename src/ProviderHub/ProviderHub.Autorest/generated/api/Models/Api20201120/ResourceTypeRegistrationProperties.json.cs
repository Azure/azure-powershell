namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceTypeRegistrationProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistrationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json ? new ResourceTypeRegistrationProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject into a new instance of <see cref="ResourceTypeRegistrationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ResourceTypeRegistrationProperties(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_extensionOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("extensionOptions"), out var __jsonExtensionOptions) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeExtensionOptions.FromJson(__jsonExtensionOptions) : ExtensionOption;}
            {_featuresRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("featuresRule"), out var __jsonFeaturesRule) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule.FromJson(__jsonFeaturesRule) : FeaturesRule;}
            {_subscriptionLifecycleNotificationSpecification = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("subscriptionLifecycleNotificationSpecifications"), out var __jsonSubscriptionLifecycleNotificationSpecifications) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SubscriptionLifecycleNotificationSpecifications.FromJson(__jsonSubscriptionLifecycleNotificationSpecifications) : SubscriptionLifecycleNotificationSpecification;}
            {_identityManagement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("identityManagement"), out var __jsonIdentityManagement) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagementProperties.FromJson(__jsonIdentityManagement) : IdentityManagement;}
            {_checkNameAvailabilitySpecification = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("checkNameAvailabilitySpecifications"), out var __jsonCheckNameAvailabilitySpecifications) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CheckNameAvailabilitySpecifications.FromJson(__jsonCheckNameAvailabilitySpecifications) : CheckNameAvailabilitySpecification;}
            {_requestHeaderOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("requestHeaderOptions"), out var __jsonRequestHeaderOptions) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions.FromJson(__jsonRequestHeaderOptions) : RequestHeaderOption;}
            {_templateDeploymentOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("templateDeploymentOptions"), out var __jsonTemplateDeploymentOptions) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentOptions.FromJson(__jsonTemplateDeploymentOptions) : TemplateDeploymentOption;}
            {_resourceMovePolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("resourceMovePolicy"), out var __jsonResourceMovePolicy) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceMovePolicy.FromJson(__jsonResourceMovePolicy) : ResourceMovePolicy;}
            {_routingType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("routingType"), out var __jsonRoutingType) ? (string)__jsonRoutingType : (string)RoutingType;}
            {_regionality = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("regionality"), out var __jsonRegionality) ? (string)__jsonRegionality : (string)Regionality;}
            {_endpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("endpoints"), out var __jsonEndpoints) ? If( __jsonEndpoints as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeEndpoint.FromJson(__u) )) ))() : null : Endpoint;}
            {_marketplaceType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("marketplaceType"), out var __jsonMarketplaceType) ? (string)__jsonMarketplaceType : (string)MarketplaceType;}
            {_swaggerSpecification = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("swaggerSpecifications"), out var __jsonSwaggerSpecifications) ? If( __jsonSwaggerSpecifications as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SwaggerSpecification.FromJson(__p) )) ))() : null : SwaggerSpecification;}
            {_allowedUnauthorizedAction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("allowedUnauthorizedActions"), out var __jsonAllowedUnauthorizedActions) ? If( __jsonAllowedUnauthorizedActions as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : AllowedUnauthorizedAction;}
            {_authorizationActionMapping = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("authorizationActionMappings"), out var __jsonAuthorizationActionMappings) ? If( __jsonAuthorizationActionMappings as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.AuthorizationActionMapping.FromJson(__f) )) ))() : null : AuthorizationActionMapping;}
            {_linkedAccessCheck = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("linkedAccessChecks"), out var __jsonLinkedAccessChecks) ? If( __jsonLinkedAccessChecks as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LinkedAccessCheck.FromJson(__a) )) ))() : null : LinkedAccessCheck;}
            {_defaultApiVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("defaultApiVersion"), out var __jsonDefaultApiVersion) ? (string)__jsonDefaultApiVersion : (string)DefaultApiVersion;}
            {_loggingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("loggingRules"), out var __jsonLoggingRules) ? If( __jsonLoggingRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LoggingRule.FromJson(___v) )) ))() : null : LoggingRule;}
            {_throttlingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("throttlingRules"), out var __jsonThrottlingRules) ? If( __jsonThrottlingRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThrottlingRule.FromJson(___q) )) ))() : null : ThrottlingRule;}
            {_requiredFeature = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("requiredFeatures"), out var __jsonRequiredFeatures) ? If( __jsonRequiredFeatures as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(string) (___l is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString ___k ? (string)(___k.ToString()) : null)) ))() : null : RequiredFeature;}
            {_enableAsyncOperation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonBoolean>("enableAsyncOperation"), out var __jsonEnableAsyncOperation) ? (bool?)__jsonEnableAsyncOperation : EnableAsyncOperation;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_enableThirdPartyS2S = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonBoolean>("enableThirdPartyS2S"), out var __jsonEnableThirdPartyS2S) ? (bool?)__jsonEnableThirdPartyS2S : EnableThirdPartyS2S;}
            {_isPureProxy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonBoolean>("isPureProxy"), out var __jsonIsPureProxy) ? (bool?)__jsonIsPureProxy : IsPureProxy;}
            {_disallowedActionVerb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("disallowedActionVerbs"), out var __jsonDisallowedActionVerbs) ? If( __jsonDisallowedActionVerbs as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___h) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___h, (___g)=>(string) (___g is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString ___f ? (string)(___f.ToString()) : null)) ))() : null : DisallowedActionVerb;}
            {_serviceTreeInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("serviceTreeInfos"), out var __jsonServiceTreeInfos) ? If( __jsonServiceTreeInfos as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___c) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___c, (___b)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ServiceTreeInfo.FromJson(___b) )) ))() : null : ServiceTreeInfo;}
            {_subscriptionStateRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("subscriptionStateRules"), out var __jsonSubscriptionStateRules) ? If( __jsonSubscriptionStateRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ____x) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____x, (____w)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SubscriptionStateRule.FromJson(____w) )) ))() : null : SubscriptionStateRule;}
            {_extendedLocation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("extendedLocations"), out var __jsonExtendedLocations) ? If( __jsonExtendedLocations as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ____s) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____s, (____r)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ExtendedLocationOptions.FromJson(____r) )) ))() : null : ExtendedLocation;}
            {_resourceDeletionPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("resourceDeletionPolicy"), out var __jsonResourceDeletionPolicy) ? (string)__jsonResourceDeletionPolicy : (string)ResourceDeletionPolicy;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ResourceTypeRegistrationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ResourceTypeRegistrationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._extensionOption ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._extensionOption.ToJson(null,serializationMode) : null, "extensionOptions" ,container.Add );
            AddIf( null != this._featuresRule ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._featuresRule.ToJson(null,serializationMode) : null, "featuresRule" ,container.Add );
            AddIf( null != this._subscriptionLifecycleNotificationSpecification ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._subscriptionLifecycleNotificationSpecification.ToJson(null,serializationMode) : null, "subscriptionLifecycleNotificationSpecifications" ,container.Add );
            AddIf( null != this._identityManagement ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._identityManagement.ToJson(null,serializationMode) : null, "identityManagement" ,container.Add );
            AddIf( null != this._checkNameAvailabilitySpecification ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._checkNameAvailabilitySpecification.ToJson(null,serializationMode) : null, "checkNameAvailabilitySpecifications" ,container.Add );
            AddIf( null != this._requestHeaderOption ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._requestHeaderOption.ToJson(null,serializationMode) : null, "requestHeaderOptions" ,container.Add );
            AddIf( null != this._templateDeploymentOption ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._templateDeploymentOption.ToJson(null,serializationMode) : null, "templateDeploymentOptions" ,container.Add );
            AddIf( null != this._resourceMovePolicy ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._resourceMovePolicy.ToJson(null,serializationMode) : null, "resourceMovePolicy" ,container.Add );
            AddIf( null != (((object)this._routingType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._routingType.ToString()) : null, "routingType" ,container.Add );
            AddIf( null != (((object)this._regionality)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._regionality.ToString()) : null, "regionality" ,container.Add );
            if (null != this._endpoint)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __x in this._endpoint )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("endpoints",__w);
            }
            AddIf( null != (((object)this._marketplaceType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._marketplaceType.ToString()) : null, "marketplaceType" ,container.Add );
            if (null != this._swaggerSpecification)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __s in this._swaggerSpecification )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("swaggerSpecifications",__r);
            }
            if (null != this._allowedUnauthorizedAction)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __n in this._allowedUnauthorizedAction )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("allowedUnauthorizedActions",__m);
            }
            if (null != this._authorizationActionMapping)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __i in this._authorizationActionMapping )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("authorizationActionMappings",__h);
            }
            if (null != this._linkedAccessCheck)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __d in this._linkedAccessCheck )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("linkedAccessChecks",__c);
            }
            AddIf( null != (((object)this._defaultApiVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._defaultApiVersion.ToString()) : null, "defaultApiVersion" ,container.Add );
            if (null != this._loggingRule)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___y in this._loggingRule )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("loggingRules",___x);
            }
            if (null != this._throttlingRule)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___t in this._throttlingRule )
                {
                    AddIf(___t?.ToJson(null, serializationMode) ,___s.Add);
                }
                container.Add("throttlingRules",___s);
            }
            if (null != this._requiredFeature)
            {
                var ___n = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___o in this._requiredFeature )
                {
                    AddIf(null != (((object)___o)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(___o.ToString()) : null ,___n.Add);
                }
                container.Add("requiredFeatures",___n);
            }
            AddIf( null != this._enableAsyncOperation ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonBoolean((bool)this._enableAsyncOperation) : null, "enableAsyncOperation" ,container.Add );
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != this._enableThirdPartyS2S ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonBoolean((bool)this._enableThirdPartyS2S) : null, "enableThirdPartyS2S" ,container.Add );
            AddIf( null != this._isPureProxy ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonBoolean((bool)this._isPureProxy) : null, "isPureProxy" ,container.Add );
            if (null != this._disallowedActionVerb)
            {
                var ___i = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___j in this._disallowedActionVerb )
                {
                    AddIf(null != (((object)___j)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(___j.ToString()) : null ,___i.Add);
                }
                container.Add("disallowedActionVerbs",___i);
            }
            if (null != this._serviceTreeInfo)
            {
                var ___d = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___e in this._serviceTreeInfo )
                {
                    AddIf(___e?.ToJson(null, serializationMode) ,___d.Add);
                }
                container.Add("serviceTreeInfos",___d);
            }
            if (null != this._subscriptionStateRule)
            {
                var ____y = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ____z in this._subscriptionStateRule )
                {
                    AddIf(____z?.ToJson(null, serializationMode) ,____y.Add);
                }
                container.Add("subscriptionStateRules",____y);
            }
            if (null != this._extendedLocation)
            {
                var ____t = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ____u in this._extendedLocation )
                {
                    AddIf(____u?.ToJson(null, serializationMode) ,____t.Add);
                }
                container.Add("extendedLocations",____t);
            }
            AddIf( null != (((object)this._resourceDeletionPolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._resourceDeletionPolicy.ToString()) : null, "resourceDeletionPolicy" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}