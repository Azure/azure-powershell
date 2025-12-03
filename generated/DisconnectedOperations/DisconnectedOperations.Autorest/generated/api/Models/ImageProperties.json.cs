// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The image properties</summary>
    public partial class ImageProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json ? new ImageProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject into a new instance of <see cref="ImageProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ImageProperties(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)_provisioningState;}
            {_releaseVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("releaseVersion"), out var __jsonReleaseVersion) ? (string)__jsonReleaseVersion : (string)_releaseVersion;}
            {_releaseDisplayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("releaseDisplayName"), out var __jsonReleaseDisplayName) ? (string)__jsonReleaseDisplayName : (string)_releaseDisplayName;}
            {_releaseNote = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("releaseNotes"), out var __jsonReleaseNotes) ? (string)__jsonReleaseNotes : (string)_releaseNote;}
            {_releaseDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("releaseDate"), out var __jsonReleaseDate) ? global::System.DateTime.TryParse((string)__jsonReleaseDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonReleaseDateValue) ? __jsonReleaseDateValue : _releaseDate : _releaseDate;}
            {_releaseType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("releaseType"), out var __jsonReleaseType) ? (string)__jsonReleaseType : (string)_releaseType;}
            {_compatibleVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonArray>("compatibleVersions"), out var __jsonCompatibleVersions) ? If( __jsonCompatibleVersions as Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _compatibleVersion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ImageProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ImageProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._releaseVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._releaseVersion.ToString()) : null, "releaseVersion" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._releaseDisplayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._releaseDisplayName.ToString()) : null, "releaseDisplayName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._releaseNote)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._releaseNote.ToString()) : null, "releaseNotes" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._releaseDate ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._releaseDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "releaseDate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._releaseType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._releaseType.ToString()) : null, "releaseType" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._compatibleVersion)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.XNodeArray();
                    foreach( var __x in this._compatibleVersion )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("compatibleVersions",__w);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}