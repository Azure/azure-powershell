namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Load balancer probe resource.</summary>
    public partial class ProbePropertiesFormat
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbePropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new ProbePropertiesFormat(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="ProbePropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ProbePropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_intervalInSeconds = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("intervalInSeconds"), out var __jsonIntervalInSeconds) ? (int?)__jsonIntervalInSeconds : IntervalInSeconds;}
            {_loadBalancingRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("loadBalancingRules"), out var __jsonLoadBalancingRules) ? If( __jsonLoadBalancingRules as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource.FromJson(__u) )) ))() : null : LoadBalancingRule;}
            {_numberOfProbe = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("numberOfProbes"), out var __jsonNumberOfProbes) ? (int?)__jsonNumberOfProbes : NumberOfProbe;}
            {_port = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("port"), out var __jsonPort) ? (int)__jsonPort : Port;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_requestPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("requestPath"), out var __jsonRequestPath) ? (string)__jsonRequestPath : (string)RequestPath;}
            {_protocol = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("protocol"), out var __jsonProtocol) ? (string)__jsonProtocol : (string)Protocol;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ProbePropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ProbePropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._intervalInSeconds ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._intervalInSeconds) : null, "intervalInSeconds" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._loadBalancingRule)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                    foreach( var __x in this._loadBalancingRule )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("loadBalancingRules",__w);
                }
            }
            AddIf( null != this._numberOfProbe ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._numberOfProbe) : null, "numberOfProbes" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber(this._port), "port" ,container.Add );
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != (((object)this._requestPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._requestPath.ToString()) : null, "requestPath" ,container.Add );
            AddIf( null != (((object)this._protocol)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._protocol.ToString()) : null, "protocol" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}