namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the load balancer.</summary>
    public partial class LoadBalancerPropertiesFormat
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerPropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerPropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerPropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new LoadBalancerPropertiesFormat(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="LoadBalancerPropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal LoadBalancerPropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_backendAddressPool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("backendAddressPools"), out var __jsonBackendAddressPools) ? If( __jsonBackendAddressPools as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BackendAddressPool.FromJson(__u) )) ))() : null : BackendAddressPool;}
            {_frontendIPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("frontendIPConfigurations"), out var __jsonFrontendIPConfigurations) ? If( __jsonFrontendIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.FrontendIPConfiguration.FromJson(__p) )) ))() : null : FrontendIPConfiguration;}
            {_inboundNatPool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("inboundNatPools"), out var __jsonInboundNatPools) ? If( __jsonInboundNatPools as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPool) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatPool.FromJson(__k) )) ))() : null : InboundNatPool;}
            {_inboundNatRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("inboundNatRules"), out var __jsonInboundNatRules) ? If( __jsonInboundNatRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatRule.FromJson(__f) )) ))() : null : InboundNatRule;}
            {_loadBalancingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("loadBalancingRules"), out var __jsonLoadBalancingRules) ? If( __jsonLoadBalancingRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRule) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.LoadBalancingRule.FromJson(__a) )) ))() : null : LoadBalancingRule;}
            {_outboundNatRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("outboundNatRules"), out var __jsonOutboundNatRules) ? If( __jsonOutboundNatRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IOutboundNatRule) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.OutboundNatRule.FromJson(___v) )) ))() : null : OutboundNatRule;}
            {_probe = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("probes"), out var __jsonProbes) ? If( __jsonProbes as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Probe.FromJson(___q) )) ))() : null : Probe;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_resourceGuid = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("resourceGuid"), out var __jsonResourceGuid) ? (string)__jsonResourceGuid : (string)ResourceGuid;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="LoadBalancerPropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="LoadBalancerPropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (null != this._backendAddressPool)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __x in this._backendAddressPool )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("backendAddressPools",__w);
            }
            if (null != this._frontendIPConfiguration)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __s in this._frontendIPConfiguration )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("frontendIPConfigurations",__r);
            }
            if (null != this._inboundNatPool)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __n in this._inboundNatPool )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("inboundNatPools",__m);
            }
            if (null != this._inboundNatRule)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __i in this._inboundNatRule )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("inboundNatRules",__h);
            }
            if (null != this._loadBalancingRule)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __d in this._loadBalancingRule )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("loadBalancingRules",__c);
            }
            if (null != this._outboundNatRule)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___y in this._outboundNatRule )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("outboundNatRules",___x);
            }
            if (null != this._probe)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___t in this._probe )
                {
                    AddIf(___t?.ToJson(null, serializationMode) ,___s.Add);
                }
                container.Add("probes",___s);
            }
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != (((object)this._resourceGuid)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._resourceGuid.ToString()) : null, "resourceGuid" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}