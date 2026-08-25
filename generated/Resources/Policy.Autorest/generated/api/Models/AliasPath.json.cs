// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The type of the paths for alias.</summary>
    public partial class AliasPath
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject into a new instance of <see cref="AliasPath" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AliasPath(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_pattern = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("pattern"), out var __jsonPattern) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPattern.FromJson(__jsonPattern) : _pattern;}
            {_metadata = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("metadata"), out var __jsonMetadata) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadata.FromJson(__jsonMetadata) : _metadata;}
            {_path = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("path"), out var __jsonPath) ? (string)__jsonPath : (string)_path;}
            {_apiVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray>("apiVersions"), out var __jsonApiVersions) ? If( __jsonApiVersions as Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _apiVersion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json ? new AliasPath(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AliasPath" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AliasPath" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._pattern ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._pattern.ToJson(null,serializationMode) : null, "pattern" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._metadata ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._metadata.ToJson(null,serializationMode) : null, "metadata" ,container.Add );
            }
            AddIf( null != (((object)this._path)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._path.ToString()) : null, "path" ,container.Add );
            if (null != this._apiVersion)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.XNodeArray();
                foreach( var __x in this._apiVersion )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("apiVersions",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}