namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Network Security Group resource.</summary>
    public partial class NetworkSecurityGroupPropertiesFormat
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new NetworkSecurityGroupPropertiesFormat(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="NetworkSecurityGroupPropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal NetworkSecurityGroupPropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_defaultSecurityRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("defaultSecurityRules"), out var __jsonDefaultSecurityRules) ? If( __jsonDefaultSecurityRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRule.FromJson(__u) )) ))() : null : DefaultSecurityRule;}
            {_networkInterface = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("networkInterfaces"), out var __jsonNetworkInterfaces) ? If( __jsonNetworkInterfaces as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterface.FromJson(__p) )) ))() : null : NetworkInterface;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_resourceGuid = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("resourceGuid"), out var __jsonResourceGuid) ? (string)__jsonResourceGuid : (string)ResourceGuid;}
            {_securityRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("securityRules"), out var __jsonSecurityRules) ? If( __jsonSecurityRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRule.FromJson(__k) )) ))() : null : SecurityRule;}
            {_subnet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("subnets"), out var __jsonSubnets) ? If( __jsonSubnets as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Subnet.FromJson(__f) )) ))() : null : Subnet;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="NetworkSecurityGroupPropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NetworkSecurityGroupPropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
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
            if (null != this._defaultSecurityRule)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __x in this._defaultSecurityRule )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("defaultSecurityRules",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._networkInterface)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __s in this._networkInterface )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("networkInterfaces",__r);
                }
            }
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != (((object)this._resourceGuid)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._resourceGuid.ToString()) : null, "resourceGuid" ,container.Add );
            if (null != this._securityRule)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __n in this._securityRule )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("securityRules",__m);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._subnet)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __i in this._subnet )
                    {
                        AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                    }
                    container.Add("subnets",__h);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}