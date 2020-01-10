namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the application gateway.</summary>
    public partial class ApplicationGatewayPropertiesFormat
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="ApplicationGatewayPropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ApplicationGatewayPropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_autoscaleConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("autoscaleConfiguration"), out var __jsonAutoscaleConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayAutoscaleConfiguration.FromJson(__jsonAutoscaleConfiguration) : AutoscaleConfiguration;}
            {_firewallPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("firewallPolicy"), out var __jsonFirewallPolicy) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource.FromJson(__jsonFirewallPolicy) : FirewallPolicy;}
            {_sku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("sku"), out var __jsonSku) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewaySku.FromJson(__jsonSku) : Sku;}
            {_sslPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("sslPolicy"), out var __jsonSslPolicy) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewaySslPolicy.FromJson(__jsonSslPolicy) : SslPolicy;}
            {_wafConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("webApplicationFirewallConfiguration"), out var __jsonWebApplicationFirewallConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayWebApplicationFirewallConfiguration.FromJson(__jsonWebApplicationFirewallConfiguration) : WafConfiguration;}
            {_authenticationCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("authenticationCertificates"), out var __jsonAuthenticationCertificates) ? If( __jsonAuthenticationCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAuthenticationCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayAuthenticationCertificate.FromJson(__u) )) ))() : null : AuthenticationCertificate;}
            {_backendAddressPool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("backendAddressPools"), out var __jsonBackendAddressPools) ? If( __jsonBackendAddressPools as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayBackendAddressPool.FromJson(__p) )) ))() : null : BackendAddressPool;}
            {_backendHttpSettingsCollection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("backendHttpSettingsCollection"), out var __jsonBackendHttpSettingsCollection) ? If( __jsonBackendHttpSettingsCollection as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayBackendHttpSettings.FromJson(__k) )) ))() : null : BackendHttpSettingsCollection;}
            {_customErrorConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("customErrorConfigurations"), out var __jsonCustomErrorConfigurations) ? If( __jsonCustomErrorConfigurations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayCustomError.FromJson(__f) )) ))() : null : CustomErrorConfiguration;}
            {_enableFips = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean>("enableFips"), out var __jsonEnableFips) ? (bool?)__jsonEnableFips : EnableFips;}
            {_enableHttp2 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean>("enableHttp2"), out var __jsonEnableHttp2) ? (bool?)__jsonEnableHttp2 : EnableHttp2;}
            {_frontendIPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("frontendIPConfigurations"), out var __jsonFrontendIPConfigurations) ? If( __jsonFrontendIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendIPConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayFrontendIPConfiguration.FromJson(__a) )) ))() : null : FrontendIPConfiguration;}
            {_frontendPort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("frontendPorts"), out var __jsonFrontendPorts) ? If( __jsonFrontendPorts as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendPort[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFrontendPort) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayFrontendPort.FromJson(___v) )) ))() : null : FrontendPort;}
            {_gatewayIPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("gatewayIPConfigurations"), out var __jsonGatewayIPConfigurations) ? If( __jsonGatewayIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayIPConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayIPConfiguration.FromJson(___q) )) ))() : null : GatewayIPConfiguration;}
            {_httpListener = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("httpListeners"), out var __jsonHttpListeners) ? If( __jsonHttpListeners as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHttpListener[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHttpListener) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayHttpListener.FromJson(___l) )) ))() : null : HttpListener;}
            {_operationalState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("operationalState"), out var __jsonOperationalState) ? (string)__jsonOperationalState : (string)OperationalState;}
            {_probe = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("probes"), out var __jsonProbes) ? If( __jsonProbes as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___h) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbe[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___h, (___g)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbe) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbe.FromJson(___g) )) ))() : null : Probe;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_redirectConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("redirectConfigurations"), out var __jsonRedirectConfigurations) ? If( __jsonRedirectConfigurations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___c) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___c, (___b)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRedirectConfiguration.FromJson(___b) )) ))() : null : RedirectConfiguration;}
            {_requestRoutingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("requestRoutingRules"), out var __jsonRequestRoutingRules) ? If( __jsonRequestRoutingRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ____x) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRequestRoutingRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____x, (____w)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRequestRoutingRule) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRequestRoutingRule.FromJson(____w) )) ))() : null : RequestRoutingRule;}
            {_resourceGuid = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("resourceGuid"), out var __jsonResourceGuid) ? (string)__jsonResourceGuid : (string)ResourceGuid;}
            {_rewriteRuleSet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("rewriteRuleSets"), out var __jsonRewriteRuleSets) ? If( __jsonRewriteRuleSets as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ____s) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSet[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____s, (____r)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSet) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRewriteRuleSet.FromJson(____r) )) ))() : null : RewriteRuleSet;}
            {_sslCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("sslCertificates"), out var __jsonSslCertificates) ? If( __jsonSslCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ____n) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____n, (____m)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewaySslCertificate.FromJson(____m) )) ))() : null : SslCertificate;}
            {_trustedRootCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("trustedRootCertificates"), out var __jsonTrustedRootCertificates) ? If( __jsonTrustedRootCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ____i) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____i, (____h)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayTrustedRootCertificate.FromJson(____h) )) ))() : null : TrustedRootCertificate;}
            {_urlPathMap = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("urlPathMaps"), out var __jsonUrlPathMaps) ? If( __jsonUrlPathMaps as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ____d) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____d, (____c)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayUrlPathMap.FromJson(____c) )) ))() : null : UrlPathMap;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayPropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new ApplicationGatewayPropertiesFormat(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ApplicationGatewayPropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ApplicationGatewayPropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._autoscaleConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._autoscaleConfiguration.ToJson(null,serializationMode) : null, "autoscaleConfiguration" ,container.Add );
            AddIf( null != this._firewallPolicy ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._firewallPolicy.ToJson(null,serializationMode) : null, "firewallPolicy" ,container.Add );
            AddIf( null != this._sku ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._sku.ToJson(null,serializationMode) : null, "sku" ,container.Add );
            AddIf( null != this._sslPolicy ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._sslPolicy.ToJson(null,serializationMode) : null, "sslPolicy" ,container.Add );
            AddIf( null != this._wafConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._wafConfiguration.ToJson(null,serializationMode) : null, "webApplicationFirewallConfiguration" ,container.Add );
            if (null != this._authenticationCertificate)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __x in this._authenticationCertificate )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("authenticationCertificates",__w);
            }
            if (null != this._backendAddressPool)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __s in this._backendAddressPool )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("backendAddressPools",__r);
            }
            if (null != this._backendHttpSettingsCollection)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __n in this._backendHttpSettingsCollection )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("backendHttpSettingsCollection",__m);
            }
            if (null != this._customErrorConfiguration)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __i in this._customErrorConfiguration )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("customErrorConfigurations",__h);
            }
            AddIf( null != this._enableFips ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean((bool)this._enableFips) : null, "enableFips" ,container.Add );
            AddIf( null != this._enableHttp2 ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean((bool)this._enableHttp2) : null, "enableHttp2" ,container.Add );
            if (null != this._frontendIPConfiguration)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __d in this._frontendIPConfiguration )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("frontendIPConfigurations",__c);
            }
            if (null != this._frontendPort)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___y in this._frontendPort )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("frontendPorts",___x);
            }
            if (null != this._gatewayIPConfiguration)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___t in this._gatewayIPConfiguration )
                {
                    AddIf(___t?.ToJson(null, serializationMode) ,___s.Add);
                }
                container.Add("gatewayIPConfigurations",___s);
            }
            if (null != this._httpListener)
            {
                var ___n = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___o in this._httpListener )
                {
                    AddIf(___o?.ToJson(null, serializationMode) ,___n.Add);
                }
                container.Add("httpListeners",___n);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._operationalState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._operationalState.ToString()) : null, "operationalState" ,container.Add );
            }
            if (null != this._probe)
            {
                var ___i = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___j in this._probe )
                {
                    AddIf(___j?.ToJson(null, serializationMode) ,___i.Add);
                }
                container.Add("probes",___i);
            }
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            if (null != this._redirectConfiguration)
            {
                var ___d = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___e in this._redirectConfiguration )
                {
                    AddIf(___e?.ToJson(null, serializationMode) ,___d.Add);
                }
                container.Add("redirectConfigurations",___d);
            }
            if (null != this._requestRoutingRule)
            {
                var ____y = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ____z in this._requestRoutingRule )
                {
                    AddIf(____z?.ToJson(null, serializationMode) ,____y.Add);
                }
                container.Add("requestRoutingRules",____y);
            }
            AddIf( null != (((object)this._resourceGuid)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._resourceGuid.ToString()) : null, "resourceGuid" ,container.Add );
            if (null != this._rewriteRuleSet)
            {
                var ____t = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ____u in this._rewriteRuleSet )
                {
                    AddIf(____u?.ToJson(null, serializationMode) ,____t.Add);
                }
                container.Add("rewriteRuleSets",____t);
            }
            if (null != this._sslCertificate)
            {
                var ____o = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ____p in this._sslCertificate )
                {
                    AddIf(____p?.ToJson(null, serializationMode) ,____o.Add);
                }
                container.Add("sslCertificates",____o);
            }
            if (null != this._trustedRootCertificate)
            {
                var ____j = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ____k in this._trustedRootCertificate )
                {
                    AddIf(____k?.ToJson(null, serializationMode) ,____j.Add);
                }
                container.Add("trustedRootCertificates",____j);
            }
            if (null != this._urlPathMap)
            {
                var ____e = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ____f in this._urlPathMap )
                {
                    AddIf(____f?.ToJson(null, serializationMode) ,____e.Add);
                }
                container.Add("urlPathMaps",____e);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}