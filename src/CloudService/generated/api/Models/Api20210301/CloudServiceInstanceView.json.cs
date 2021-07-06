namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>InstanceView of CloudService as a whole</summary>
    public partial class CloudServiceInstanceView
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject into a new instance of <see cref="CloudServiceInstanceView" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal CloudServiceInstanceView(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_roleInstance = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject>("roleInstance"), out var __jsonRoleInstance) ? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceViewStatusesSummary.FromJson(__jsonRoleInstance) : RoleInstance;}
            {_sdkVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonString>("sdkVersion"), out var __jsonSdkVersion) ? (string)__jsonSdkVersion : (string)SdkVersion;}
            {_privateId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray>("privateIds"), out var __jsonPrivateIds) ? If( __jsonPrivateIds as Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : PrivateId;}
            {_statuses = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray>("statuses"), out var __jsonStatuses) ? If( __jsonStatuses as Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus) (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceInstanceViewStatus.FromJson(__p) )) ))() : null : Statuses;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceView.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceView.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceView FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject json ? new CloudServiceInstanceView(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="CloudServiceInstanceView" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="CloudServiceInstanceView" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._roleInstance ? (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode) this._roleInstance.ToJson(null,serializationMode) : null, "roleInstance" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._sdkVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonString(this._sdkVersion.ToString()) : null, "sdkVersion" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._privateId)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.XNodeArray();
                    foreach( var __x in this._privateId )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("privateIds",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._statuses)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.XNodeArray();
                    foreach( var __s in this._statuses )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("statuses",__r);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}