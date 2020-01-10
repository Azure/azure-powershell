namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for P2SVpnServerConfiguration</summary>
    public partial class P2SVpnServerConfigurationProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigurationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new P2SVpnServerConfigurationProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="P2SVpnServerConfigurationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal P2SVpnServerConfigurationProperties(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_etag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("etag"), out var __jsonEtag) ? (string)__jsonEtag : (string)Etag;}
            {_p2SVpnGateway = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("p2SVpnGateways"), out var __jsonP2SVpnGateways) ? If( __jsonP2SVpnGateways as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource.FromJson(__u) )) ))() : null : P2SVpnGateway;}
            {_p2SVpnServerConfigRadiusClientRootCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("p2SVpnServerConfigRadiusClientRootCertificates"), out var __jsonP2SVpnServerConfigRadiusClientRootCertificates) ? If( __jsonP2SVpnServerConfigRadiusClientRootCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnServerConfigRadiusClientRootCertificate.FromJson(__p) )) ))() : null : P2SVpnServerConfigRadiusClientRootCertificate;}
            {_p2SVpnServerConfigRadiusServerRootCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("p2SVpnServerConfigRadiusServerRootCertificates"), out var __jsonP2SVpnServerConfigRadiusServerRootCertificates) ? If( __jsonP2SVpnServerConfigRadiusServerRootCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnServerConfigRadiusServerRootCertificate.FromJson(__k) )) ))() : null : P2SVpnServerConfigRadiusServerRootCertificate;}
            {_p2SVpnServerConfigVpnClientRevokedCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("p2SVpnServerConfigVpnClientRevokedCertificates"), out var __jsonP2SVpnServerConfigVpnClientRevokedCertificates) ? If( __jsonP2SVpnServerConfigVpnClientRevokedCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnServerConfigVpnClientRevokedCertificate.FromJson(__f) )) ))() : null : P2SVpnServerConfigVpnClientRevokedCertificate;}
            {_p2SVpnServerConfigVpnClientRootCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("p2SVpnServerConfigVpnClientRootCertificates"), out var __jsonP2SVpnServerConfigVpnClientRootCertificates) ? If( __jsonP2SVpnServerConfigVpnClientRootCertificates as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnServerConfigVpnClientRootCertificate.FromJson(__a) )) ))() : null : P2SVpnServerConfigVpnClientRootCertificate;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_radiusServerAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("radiusServerAddress"), out var __jsonRadiusServerAddress) ? (string)__jsonRadiusServerAddress : (string)RadiusServerAddress;}
            {_radiusServerSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("radiusServerSecret"), out var __jsonRadiusServerSecret) ? (string)__jsonRadiusServerSecret : (string)RadiusServerSecret;}
            {_vpnClientIpsecPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("vpnClientIpsecPolicies"), out var __jsonVpnClientIpsecPolicies) ? If( __jsonVpnClientIpsecPolicies as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicy.FromJson(___v) )) ))() : null : VpnClientIpsecPolicy;}
            {_vpnProtocol = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("vpnProtocols"), out var __jsonVpnProtocols) ? If( __jsonVpnProtocols as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol) (___q is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString ___p ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol)(___p.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol)""))) ))() : null : VpnProtocol;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="P2SVpnServerConfigurationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="P2SVpnServerConfigurationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            AddIf( null != (((object)this._etag)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._etag.ToString()) : null, "etag" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._p2SVpnGateway)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __x in this._p2SVpnGateway )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("p2SVpnGateways",__w);
                }
            }
            if (null != this._p2SVpnServerConfigRadiusClientRootCertificate)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __s in this._p2SVpnServerConfigRadiusClientRootCertificate )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("p2SVpnServerConfigRadiusClientRootCertificates",__r);
            }
            if (null != this._p2SVpnServerConfigRadiusServerRootCertificate)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __n in this._p2SVpnServerConfigRadiusServerRootCertificate )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("p2SVpnServerConfigRadiusServerRootCertificates",__m);
            }
            if (null != this._p2SVpnServerConfigVpnClientRevokedCertificate)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __i in this._p2SVpnServerConfigVpnClientRevokedCertificate )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("p2SVpnServerConfigVpnClientRevokedCertificates",__h);
            }
            if (null != this._p2SVpnServerConfigVpnClientRootCertificate)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __d in this._p2SVpnServerConfigVpnClientRootCertificate )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("p2SVpnServerConfigVpnClientRootCertificates",__c);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._radiusServerAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._radiusServerAddress.ToString()) : null, "radiusServerAddress" ,container.Add );
            AddIf( null != (((object)this._radiusServerSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._radiusServerSecret.ToString()) : null, "radiusServerSecret" ,container.Add );
            if (null != this._vpnClientIpsecPolicy)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___y in this._vpnClientIpsecPolicy )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("vpnClientIpsecPolicies",___x);
            }
            if (null != this._vpnProtocol)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___t in this._vpnProtocol )
                {
                    AddIf(null != (((object)___t)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(___t.ToString()) : null ,___s.Add);
                }
                container.Add("vpnProtocols",___s);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}