namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the subnet.</summary>
    public partial class SubnetPropertiesFormat
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new SubnetPropertiesFormat(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="SubnetPropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SubnetPropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_natGateway = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("natGateway"), out var __jsonNatGateway) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource.FromJson(__jsonNatGateway) : NatGateway;}
            {_nsg = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("networkSecurityGroup"), out var __jsonNetworkSecurityGroup) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroup.FromJson(__jsonNetworkSecurityGroup) : Nsg;}
            {_routeTable = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("routeTable"), out var __jsonRouteTable) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RouteTable.FromJson(__jsonRouteTable) : RouteTable;}
            {_addressPrefix = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("addressPrefix"), out var __jsonAddressPrefix) ? (string)__jsonAddressPrefix : (string)AddressPrefix;}
            {_addressPrefixes = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("addressPrefixes"), out var __jsonAddressPrefixes) ? If( __jsonAddressPrefixes as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AddressPrefixes;}
            {_delegation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("delegations"), out var __jsonDelegations) ? If( __jsonDelegations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Delegation.FromJson(__p) )) ))() : null : Delegation;}
            {_interfaceEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("interfaceEndpoints"), out var __jsonInterfaceEndpoints) ? If( __jsonInterfaceEndpoints as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InterfaceEndpoint.FromJson(__k) )) ))() : null : InterfaceEndpoint;}
            {_iPConfigurationProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("ipConfigurationProfiles"), out var __jsonIPConfigurationProfiles) ? If( __jsonIPConfigurationProfiles as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPConfigurationProfile.FromJson(__f) )) ))() : null : IPConfigurationProfile;}
            {_iPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("ipConfigurations"), out var __jsonIPConfigurations) ? If( __jsonIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPConfiguration.FromJson(__a) )) ))() : null : IPConfiguration;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_purpose = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("purpose"), out var __jsonPurpose) ? (string)__jsonPurpose : (string)Purpose;}
            {_resourceNavigationLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("resourceNavigationLinks"), out var __jsonResourceNavigationLinks) ? If( __jsonResourceNavigationLinks as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceNavigationLink.FromJson(___v) )) ))() : null : ResourceNavigationLink;}
            {_serviceAssociationLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("serviceAssociationLinks"), out var __jsonServiceAssociationLinks) ? If( __jsonServiceAssociationLinks as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ServiceAssociationLink.FromJson(___q) )) ))() : null : ServiceAssociationLink;}
            {_serviceEndpointPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("serviceEndpointPolicies"), out var __jsonServiceEndpointPolicies) ? If( __jsonServiceEndpointPolicies as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ServiceEndpointPolicy.FromJson(___l) )) ))() : null : ServiceEndpointPolicy;}
            {_serviceEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("serviceEndpoints"), out var __jsonServiceEndpoints) ? If( __jsonServiceEndpoints as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var ___h) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___h, (___g)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ServiceEndpointPropertiesFormat.FromJson(___g) )) ))() : null : ServiceEndpoint;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SubnetPropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SubnetPropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._natGateway ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._natGateway.ToJson(null,serializationMode) : null, "natGateway" ,container.Add );
            AddIf( null != this._nsg ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._nsg.ToJson(null,serializationMode) : null, "networkSecurityGroup" ,container.Add );
            AddIf( null != this._routeTable ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._routeTable.ToJson(null,serializationMode) : null, "routeTable" ,container.Add );
            AddIf( null != (((object)this._addressPrefix)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._addressPrefix.ToString()) : null, "addressPrefix" ,container.Add );
            if (null != this._addressPrefixes)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __x in this._addressPrefixes )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("addressPrefixes",__w);
            }
            if (null != this._delegation)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __s in this._delegation )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("delegations",__r);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._interfaceEndpoint)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __n in this._interfaceEndpoint )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("interfaceEndpoints",__m);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._iPConfigurationProfile)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __i in this._iPConfigurationProfile )
                    {
                        AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                    }
                    container.Add("ipConfigurationProfiles",__h);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._iPConfiguration)
                {
                    var __c = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __d in this._iPConfiguration )
                    {
                        AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                    }
                    container.Add("ipConfigurations",__c);
                }
            }
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._purpose)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._purpose.ToString()) : null, "purpose" ,container.Add );
            }
            if (null != this._resourceNavigationLink)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___y in this._resourceNavigationLink )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("resourceNavigationLinks",___x);
            }
            if (null != this._serviceAssociationLink)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___t in this._serviceAssociationLink )
                {
                    AddIf(___t?.ToJson(null, serializationMode) ,___s.Add);
                }
                container.Add("serviceAssociationLinks",___s);
            }
            if (null != this._serviceEndpointPolicy)
            {
                var ___n = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___o in this._serviceEndpointPolicy )
                {
                    AddIf(___o?.ToJson(null, serializationMode) ,___n.Add);
                }
                container.Add("serviceEndpointPolicies",___n);
            }
            if (null != this._serviceEndpoint)
            {
                var ___i = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var ___j in this._serviceEndpoint )
                {
                    AddIf(___j?.ToJson(null, serializationMode) ,___i.Add);
                }
                container.Add("serviceEndpoints",___i);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}