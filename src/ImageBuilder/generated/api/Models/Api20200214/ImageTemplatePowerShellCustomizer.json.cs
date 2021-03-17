namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Runs the specified PowerShell on the VM (Windows). Corresponds to Packer powershell provisioner. Exactly one of 'scriptUri'
    /// or 'inline' can be specified.
    /// </summary>
    public partial class ImageTemplatePowerShellCustomizer
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePowerShellCustomizer.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePowerShellCustomizer.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePowerShellCustomizer FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject json ? new ImageTemplatePowerShellCustomizer(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject into a new instance of <see cref="ImageTemplatePowerShellCustomizer" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ImageTemplatePowerShellCustomizer(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __imageTemplateCustomizer = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateCustomizer(json);
            {_scriptUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString>("scriptUri"), out var __jsonScriptUri) ? (string)__jsonScriptUri : (string)ScriptUri;}
            {_sha256Checksum = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString>("sha256Checksum"), out var __jsonSha256Checksum) ? (string)__jsonSha256Checksum : (string)Sha256Checksum;}
            {_inline = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray>("inline"), out var __jsonInline) ? If( __jsonInline as Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : Inline;}
            {_runElevated = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonBoolean>("runElevated"), out var __jsonRunElevated) ? (bool?)__jsonRunElevated : RunElevated;}
            {_runAsSystem = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonBoolean>("runAsSystem"), out var __jsonRunAsSystem) ? (bool?)__jsonRunAsSystem : RunAsSystem;}
            {_validExitCode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray>("validExitCodes"), out var __jsonValidExitCodes) ? If( __jsonValidExitCodes as Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<int[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(int) (__p is Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNumber __o ? (int)__o : default(int))) ))() : null : ValidExitCode;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ImageTemplatePowerShellCustomizer" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ImageTemplatePowerShellCustomizer" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode" />.
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
            __imageTemplateCustomizer?.ToJson(container, serializationMode);
            AddIf( null != (((object)this._scriptUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString(this._scriptUri.ToString()) : null, "scriptUri" ,container.Add );
            AddIf( null != (((object)this._sha256Checksum)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString(this._sha256Checksum.ToString()) : null, "sha256Checksum" ,container.Add );
            if (null != this._inline)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.XNodeArray();
                foreach( var __x in this._inline )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("inline",__w);
            }
            AddIf( null != this._runElevated ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonBoolean((bool)this._runElevated) : null, "runElevated" ,container.Add );
            AddIf( null != this._runAsSystem ? (Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonBoolean((bool)this._runAsSystem) : null, "runAsSystem" ,container.Add );
            if (null != this._validExitCode)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.XNodeArray();
                foreach( var __s in this._validExitCode )
                {
                    AddIf((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Json.JsonNumber(__s) ,__r.Add);
                }
                container.Add("validExitCodes",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}