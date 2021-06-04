namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceType
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json ? new ResourceType(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject into a new instance of <see cref="ResourceType" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ResourceType(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_identityManagement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("identityManagement"), out var __jsonIdentityManagement) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IdentityManagement.FromJson(__jsonIdentityManagement) : IdentityManagement;}
            {_featuresRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("featuresRule"), out var __jsonFeaturesRule) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRule.FromJson(__jsonFeaturesRule) : FeaturesRule;}
            {_requestHeaderOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("requestHeaderOptions"), out var __jsonRequestHeaderOptions) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptions.FromJson(__jsonRequestHeaderOptions) : RequestHeaderOption;}
            {_templateDeploymentPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("templateDeploymentPolicy"), out var __jsonTemplateDeploymentPolicy) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TemplateDeploymentPolicy.FromJson(__jsonTemplateDeploymentPolicy) : TemplateDeploymentPolicy;}
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_routingType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("routingType"), out var __jsonRoutingType) ? (string)__jsonRoutingType : (string)RoutingType;}
            {_resourceValidation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("resourceValidation"), out var __jsonResourceValidation) ? (string)__jsonResourceValidation : (string)ResourceValidation;}
            {_allowedUnauthorizedAction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("allowedUnauthorizedActions"), out var __jsonAllowedUnauthorizedActions) ? If( __jsonAllowedUnauthorizedActions as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AllowedUnauthorizedAction;}
            {_authorizationActionMapping = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("authorizationActionMappings"), out var __jsonAuthorizationActionMappings) ? If( __jsonAuthorizationActionMappings as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.AuthorizationActionMapping.FromJson(__p) )) ))() : null : AuthorizationActionMapping;}
            {_linkedAccessCheck = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("linkedAccessChecks"), out var __jsonLinkedAccessChecks) ? If( __jsonLinkedAccessChecks as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LinkedAccessCheck.FromJson(__k) )) ))() : null : LinkedAccessCheck;}
            {_defaultApiVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("defaultApiVersion"), out var __jsonDefaultApiVersion) ? (string)__jsonDefaultApiVersion : (string)DefaultApiVersion;}
            {_loggingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("loggingRules"), out var __jsonLoggingRules) ? If( __jsonLoggingRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LoggingRule.FromJson(__f) )) ))() : null : LoggingRule;}
            {_throttlingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("throttlingRules"), out var __jsonThrottlingRules) ? If( __jsonThrottlingRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThrottlingRule.FromJson(__a) )) ))() : null : ThrottlingRule;}
            {_endpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("endpoints"), out var __jsonEndpoints) ? If( __jsonEndpoints as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderEndpoint.FromJson(___v) )) ))() : null : Endpoint;}
            {_marketplaceType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("marketplaceType"), out var __jsonMarketplaceType) ? (string)__jsonMarketplaceType : (string)MarketplaceType;}
            {_metadata = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject>("metadata"), out var __jsonMetadata) ? Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any.FromJson(__jsonMetadata) : Metadata;}
            {_requiredFeature = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("requiredFeatures"), out var __jsonRequiredFeatures) ? If( __jsonRequiredFeatures as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(string) (___q is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString ___p ? (string)(___p.ToString()) : null)) ))() : null : RequiredFeature;}
            {_subscriptionStateRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("subscriptionStateRules"), out var __jsonSubscriptionStateRules) ? If( __jsonSubscriptionStateRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SubscriptionStateRule.FromJson(___l) )) ))() : null : SubscriptionStateRule;}
            {_serviceTreeInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("serviceTreeInfos"), out var __jsonServiceTreeInfos) ? If( __jsonServiceTreeInfos as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___h) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___h, (___g)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ServiceTreeInfo.FromJson(___g) )) ))() : null : ServiceTreeInfo;}
            {_skuLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("skuLink"), out var __jsonSkuLink) ? (string)__jsonSkuLink : (string)SkuLink;}
            {_disallowedActionVerb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("disallowedActionVerbs"), out var __jsonDisallowedActionVerbs) ? If( __jsonDisallowedActionVerbs as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ___c) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___c, (___b)=>(string) (___b is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString ___a ? (string)(___a.ToString()) : null)) ))() : null : DisallowedActionVerb;}
            {_extendedLocation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("extendedLocations"), out var __jsonExtendedLocations) ? If( __jsonExtendedLocations as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ____x) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____x, (____w)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ExtendedLocationOptions.FromJson(____w) )) ))() : null : ExtendedLocation;}
            {_linkedOperationRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray>("linkedOperationRules"), out var __jsonLinkedOperationRules) ? If( __jsonLinkedOperationRules as Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonArray, out var ____s) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____s, (____r)=>(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule) (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LinkedOperationRule.FromJson(____r) )) ))() : null : LinkedOperationRule;}
            {_resourceDeletionPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("resourceDeletionPolicy"), out var __jsonResourceDeletionPolicy) ? (string)__jsonResourceDeletionPolicy : (string)ResourceDeletionPolicy;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ResourceType" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ResourceType" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._identityManagement ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._identityManagement.ToJson(null,serializationMode) : null, "identityManagement" ,container.Add );
            AddIf( null != this._featuresRule ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._featuresRule.ToJson(null,serializationMode) : null, "featuresRule" ,container.Add );
            AddIf( null != this._requestHeaderOption ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._requestHeaderOption.ToJson(null,serializationMode) : null, "requestHeaderOptions" ,container.Add );
            AddIf( null != this._templateDeploymentPolicy ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._templateDeploymentPolicy.ToJson(null,serializationMode) : null, "templateDeploymentPolicy" ,container.Add );
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            AddIf( null != (((object)this._routingType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._routingType.ToString()) : null, "routingType" ,container.Add );
            AddIf( null != (((object)this._resourceValidation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._resourceValidation.ToString()) : null, "resourceValidation" ,container.Add );
            if (null != this._allowedUnauthorizedAction)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __x in this._allowedUnauthorizedAction )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("allowedUnauthorizedActions",__w);
            }
            if (null != this._authorizationActionMapping)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __s in this._authorizationActionMapping )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("authorizationActionMappings",__r);
            }
            if (null != this._linkedAccessCheck)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __n in this._linkedAccessCheck )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("linkedAccessChecks",__m);
            }
            AddIf( null != (((object)this._defaultApiVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._defaultApiVersion.ToString()) : null, "defaultApiVersion" ,container.Add );
            if (null != this._loggingRule)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __i in this._loggingRule )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("loggingRules",__h);
            }
            if (null != this._throttlingRule)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var __d in this._throttlingRule )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("throttlingRules",__c);
            }
            if (null != this._endpoint)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___y in this._endpoint )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("endpoints",___x);
            }
            AddIf( null != (((object)this._marketplaceType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._marketplaceType.ToString()) : null, "marketplaceType" ,container.Add );
            AddIf( null != this._metadata ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) this._metadata.ToJson(null,serializationMode) : null, "metadata" ,container.Add );
            if (null != this._requiredFeature)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___t in this._requiredFeature )
                {
                    AddIf(null != (((object)___t)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(___t.ToString()) : null ,___s.Add);
                }
                container.Add("requiredFeatures",___s);
            }
            if (null != this._subscriptionStateRule)
            {
                var ___n = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___o in this._subscriptionStateRule )
                {
                    AddIf(___o?.ToJson(null, serializationMode) ,___n.Add);
                }
                container.Add("subscriptionStateRules",___n);
            }
            if (null != this._serviceTreeInfo)
            {
                var ___i = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___j in this._serviceTreeInfo )
                {
                    AddIf(___j?.ToJson(null, serializationMode) ,___i.Add);
                }
                container.Add("serviceTreeInfos",___i);
            }
            AddIf( null != (((object)this._skuLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._skuLink.ToString()) : null, "skuLink" ,container.Add );
            if (null != this._disallowedActionVerb)
            {
                var ___d = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ___e in this._disallowedActionVerb )
                {
                    AddIf(null != (((object)___e)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(___e.ToString()) : null ,___d.Add);
                }
                container.Add("disallowedActionVerbs",___d);
            }
            if (null != this._extendedLocation)
            {
                var ____y = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ____z in this._extendedLocation )
                {
                    AddIf(____z?.ToJson(null, serializationMode) ,____y.Add);
                }
                container.Add("extendedLocations",____y);
            }
            if (null != this._linkedOperationRule)
            {
                var ____t = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.XNodeArray();
                foreach( var ____u in this._linkedOperationRule )
                {
                    AddIf(____u?.ToJson(null, serializationMode) ,____t.Add);
                }
                container.Add("linkedOperationRules",____t);
            }
            AddIf( null != (((object)this._resourceDeletionPolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._resourceDeletionPolicy.ToString()) : null, "resourceDeletionPolicy" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}