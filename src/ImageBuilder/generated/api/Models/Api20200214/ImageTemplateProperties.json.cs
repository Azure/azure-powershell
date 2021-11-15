namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes the properties of an image template</summary>
    public partial class ImageTemplateProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject json ? new ImageTemplateProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject into a new instance of <see cref="ImageTemplateProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ImageTemplateProperties(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_source = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject>("source"), out var __jsonSource) ? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSource.FromJson(__jsonSource) : Source;}
            {_provisioningError = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject>("provisioningError"), out var __jsonProvisioningError) ? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ProvisioningError.FromJson(__jsonProvisioningError) : ProvisioningError;}
            {_lastRunStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject>("lastRunStatus"), out var __jsonLastRunStatus) ? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateLastRunStatus.FromJson(__jsonLastRunStatus) : LastRunStatus;}
            {_vMProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject>("vmProfile"), out var __jsonVMProfile) ? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateVMProfile.FromJson(__jsonVMProfile) : VMProfile;}
            {_customize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray>("customize"), out var __jsonCustomize) ? If( __jsonCustomize as Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer) (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateCustomizer.FromJson(__u) )) ))() : null : Customize;}
            {_distribute = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray>("distribute"), out var __jsonDistribute) ? If( __jsonDistribute as Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor) (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateDistributor.FromJson(__p) )) ))() : null : Distribute;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_buildTimeoutInMinute = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNumber>("buildTimeoutInMinutes"), out var __jsonBuildTimeoutInMinutes) ? (int?)__jsonBuildTimeoutInMinutes : BuildTimeoutInMinute;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ImageTemplateProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ImageTemplateProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._source ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) this._source.ToJson(null,serializationMode) : null, "source" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._provisioningError ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) this._provisioningError.ToJson(null,serializationMode) : null, "provisioningError" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastRunStatus ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) this._lastRunStatus.ToJson(null,serializationMode) : null, "lastRunStatus" ,container.Add );
            }
            AddIf( null != this._vMProfile ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) this._vMProfile.ToJson(null,serializationMode) : null, "vmProfile" ,container.Add );
            if (null != this._customize)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.XNodeArray();
                foreach( var __x in this._customize )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("customize",__w);
            }
            if (null != this._distribute)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.XNodeArray();
                foreach( var __s in this._distribute )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("distribute",__r);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != this._buildTimeoutInMinute ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNumber((int)this._buildTimeoutInMinute) : null, "buildTimeoutInMinutes" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}