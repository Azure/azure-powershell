namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Response properties for iSCSI Target operations.</summary>
    public partial class IscsiTargetProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTargetProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject json ? new IscsiTargetProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject into a new instance of <see cref="IscsiTargetProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal IscsiTargetProperties(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_aclMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString>("aclMode"), out var __jsonAclMode) ? (string)__jsonAclMode : (string)AclMode;}
            {_staticAcls = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonArray>("staticAcls"), out var __jsonStaticAcls) ? If( __jsonStaticAcls as Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl) (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Acl.FromJson(__u) )) ))() : null : StaticAcls;}
            {_lun = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonArray>("luns"), out var __jsonLuns) ? If( __jsonLuns as Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun) (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IscsiLun.FromJson(__p) )) ))() : null : Lun;}
            {_targetIqn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString>("targetIqn"), out var __jsonTargetIqn) ? (string)__jsonTargetIqn : (string)TargetIqn;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_endpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonArray>("endpoints"), out var __jsonEndpoints) ? If( __jsonEndpoints as Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : Endpoint;}
            {_port = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNumber>("port"), out var __jsonPort) ? (int?)__jsonPort : Port;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="IscsiTargetProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="IscsiTargetProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._aclMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString(this._aclMode.ToString()) : null, "aclMode" ,container.Add );
            if (null != this._staticAcls)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.XNodeArray();
                foreach( var __x in this._staticAcls )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("staticAcls",__w);
            }
            if (null != this._lun)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.XNodeArray();
                foreach( var __s in this._lun )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("luns",__r);
            }
            AddIf( null != (((object)this._targetIqn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString(this._targetIqn.ToString()) : null, "targetIqn" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            if (null != this._endpoint)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.XNodeArray();
                foreach( var __n in this._endpoint )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("endpoints",__m);
            }
            AddIf( null != this._port ? (Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Json.JsonNumber((int)this._port) : null, "port" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}