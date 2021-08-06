namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The init container definition properties.</summary>
    public partial class InitContainerPropertiesDefinition
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json ? new InitContainerPropertiesDefinition(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject into a new instance of <see cref="InitContainerPropertiesDefinition" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal InitContainerPropertiesDefinition(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_instanceView = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("instanceView"), out var __jsonInstanceView) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerPropertiesDefinitionInstanceView.FromJson(__jsonInstanceView) : InstanceView;}
            {_image = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("image"), out var __jsonImage) ? (string)__jsonImage : (string)Image;}
            {_command = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("command"), out var __jsonCommand) ? If( __jsonCommand as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : Command;}
            {_environmentVariable = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("environmentVariables"), out var __jsonEnvironmentVariables) ? If( __jsonEnvironmentVariables as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EnvironmentVariable.FromJson(__p) )) ))() : null : EnvironmentVariable;}
            {_volumeMount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("volumeMounts"), out var __jsonVolumeMounts) ? If( __jsonVolumeMounts as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.VolumeMount.FromJson(__k) )) ))() : null : VolumeMount;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="InitContainerPropertiesDefinition" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="InitContainerPropertiesDefinition" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._instanceView ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._instanceView.ToJson(null,serializationMode) : null, "instanceView" ,container.Add );
            }
            AddIf( null != (((object)this._image)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._image.ToString()) : null, "image" ,container.Add );
            if (null != this._command)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __x in this._command )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("command",__w);
            }
            if (null != this._environmentVariable)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __s in this._environmentVariable )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("environmentVariables",__r);
            }
            if (null != this._volumeMount)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __n in this._volumeMount )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("volumeMounts",__m);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}