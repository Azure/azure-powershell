// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>Icon files</summary>
    public partial class IconFileUris
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris FromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json ? new IconFileUris(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject into a new instance of <see cref="IconFileUris" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal IconFileUris(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_small = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("small"), out var __jsonSmall) ? (string)__jsonSmall : (string)_small;}
            {_medium = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("medium"), out var __jsonMedium) ? (string)__jsonMedium : (string)_medium;}
            {_wide = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("wide"), out var __jsonWide) ? (string)__jsonWide : (string)_wide;}
            {_large = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("large"), out var __jsonLarge) ? (string)__jsonLarge : (string)_large;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="IconFileUris" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="IconFileUris" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._small)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._small.ToString()) : null, "small" ,container.Add );
            AddIf( null != (((object)this._medium)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._medium.ToString()) : null, "medium" ,container.Add );
            AddIf( null != (((object)this._wide)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._wide.ToString()) : null, "wide" ,container.Add );
            AddIf( null != (((object)this._large)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._large.ToString()) : null, "large" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}