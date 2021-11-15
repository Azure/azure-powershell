namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>
    /// Properties of RedisEnterprise clusters, as opposed to general resource properties like location, tags
    /// </summary>
    public partial class ClusterProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject into a new instance of <see cref="ClusterProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ClusterProperties(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_minimumTlsVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString>("minimumTlsVersion"), out var __jsonMinimumTlsVersion) ? (string)__jsonMinimumTlsVersion : (string)MinimumTlsVersion;}
            {_hostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString>("hostName"), out var __jsonHostName) ? (string)__jsonHostName : (string)HostName;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_resourceState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString>("resourceState"), out var __jsonResourceState) ? (string)__jsonResourceState : (string)ResourceState;}
            {_redisVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString>("redisVersion"), out var __jsonRedisVersion) ? (string)__jsonRedisVersion : (string)RedisVersion;}
            {_privateEndpointConnection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonArray>("privateEndpointConnections"), out var __jsonPrivateEndpointConnections) ? If( __jsonPrivateEndpointConnections as Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateEndpointConnection[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateEndpointConnection) (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.PrivateEndpointConnection.FromJson(__u) )) ))() : null : PrivateEndpointConnection;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IClusterProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IClusterProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IClusterProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject json ? new ClusterProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ClusterProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ClusterProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._minimumTlsVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString(this._minimumTlsVersion.ToString()) : null, "minimumTlsVersion" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._hostName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString(this._hostName.ToString()) : null, "hostName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._resourceState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString(this._resourceState.ToString()) : null, "resourceState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._redisVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonString(this._redisVersion.ToString()) : null, "redisVersion" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._privateEndpointConnection)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.XNodeArray();
                    foreach( var __x in this._privateEndpointConnection )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("privateEndpointConnections",__w);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}