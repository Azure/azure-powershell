namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines NIC IP configuration properties.</summary>
    public partial class NicIPConfigurationResourceSettings
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INicIPConfigurationResourceSettings.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INicIPConfigurationResourceSettings.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INicIPConfigurationResourceSettings FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json ? new NicIPConfigurationResourceSettings(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject into a new instance of <see cref="NicIPConfigurationResourceSettings" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal NicIPConfigurationResourceSettings(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_subnet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject>("subnet"), out var __jsonSubnet) ? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ProxyResourceReference.FromJson(__jsonSubnet) : Subnet;}
            {_publicIP = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject>("publicIp"), out var __jsonPublicIP) ? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.AzureResourceReference.FromJson(__jsonPublicIP) : PublicIP;}
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_privateIPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString>("privateIpAddress"), out var __jsonPrivateIPAddress) ? (string)__jsonPrivateIPAddress : (string)PrivateIPAddress;}
            {_privateIPAllocationMethod = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString>("privateIpAllocationMethod"), out var __jsonPrivateIPAllocationMethod) ? (string)__jsonPrivateIPAllocationMethod : (string)PrivateIPAllocationMethod;}
            {_primary = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonBoolean>("primary"), out var __jsonPrimary) ? (bool?)__jsonPrimary : Primary;}
            {_loadBalancerBackendAddressPool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray>("loadBalancerBackendAddressPools"), out var __jsonLoadBalancerBackendAddressPools) ? If( __jsonLoadBalancerBackendAddressPools as Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference) (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ProxyResourceReference.FromJson(__u) )) ))() : null : LoadBalancerBackendAddressPool;}
            {_loadBalancerNatRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray>("loadBalancerNatRules"), out var __jsonLoadBalancerNatRules) ? If( __jsonLoadBalancerNatRules as Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference) (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ProxyResourceReference.FromJson(__p) )) ))() : null : LoadBalancerNatRule;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="NicIPConfigurationResourceSettings" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NicIPConfigurationResourceSettings" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._subnet ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) this._subnet.ToJson(null,serializationMode) : null, "subnet" ,container.Add );
            AddIf( null != this._publicIP ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) this._publicIP.ToJson(null,serializationMode) : null, "publicIp" ,container.Add );
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            AddIf( null != (((object)this._privateIPAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(this._privateIPAddress.ToString()) : null, "privateIpAddress" ,container.Add );
            AddIf( null != (((object)this._privateIPAllocationMethod)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonString(this._privateIPAllocationMethod.ToString()) : null, "privateIpAllocationMethod" ,container.Add );
            AddIf( null != this._primary ? (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonBoolean((bool)this._primary) : null, "primary" ,container.Add );
            if (null != this._loadBalancerBackendAddressPool)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.XNodeArray();
                foreach( var __x in this._loadBalancerBackendAddressPool )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("loadBalancerBackendAddressPools",__w);
            }
            if (null != this._loadBalancerNatRule)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.XNodeArray();
                foreach( var __s in this._loadBalancerNatRule )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("loadBalancerNatRules",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}