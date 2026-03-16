// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>Access token request object</summary>
    public partial class AccessTokenRequest
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject into a new instance of <see cref="AccessTokenRequest" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AccessTokenRequest(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_publisherName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("publisherName"), out var __jsonPublisherName) ? (string)__jsonPublisherName : (string)_publisherName;}
            {_edgeMarketPlaceRegion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("edgeMarketPlaceRegion"), out var __jsonEdgeMarketPlaceRegion) ? (string)__jsonEdgeMarketPlaceRegion : (string)_edgeMarketPlaceRegion;}
            {_egeMarketPlaceResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("egeMarketPlaceResourceId"), out var __jsonEgeMarketPlaceResourceId) ? (string)__jsonEgeMarketPlaceResourceId : (string)_egeMarketPlaceResourceId;}
            {_hypervGeneration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("hypervGeneration"), out var __jsonHypervGeneration) ? (string)__jsonHypervGeneration : (string)_hypervGeneration;}
            {_marketPlaceSku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("marketPlaceSku"), out var __jsonMarketPlaceSku) ? (string)__jsonMarketPlaceSku : (string)_marketPlaceSku;}
            {_marketPlaceSkuVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("marketPlaceSkuVersion"), out var __jsonMarketPlaceSkuVersion) ? (string)__jsonMarketPlaceSkuVersion : (string)_marketPlaceSkuVersion;}
            {_deviceSku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("deviceSku"), out var __jsonDeviceSku) ? (string)__jsonDeviceSku : (string)_deviceSku;}
            {_deviceVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("deviceVersion"), out var __jsonDeviceVersion) ? (string)__jsonDeviceVersion : (string)_deviceVersion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequest.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequest.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequest FromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json ? new AccessTokenRequest(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AccessTokenRequest" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AccessTokenRequest" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._publisherName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._publisherName.ToString()) : null, "publisherName" ,container.Add );
            AddIf( null != (((object)this._edgeMarketPlaceRegion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._edgeMarketPlaceRegion.ToString()) : null, "edgeMarketPlaceRegion" ,container.Add );
            AddIf( null != (((object)this._egeMarketPlaceResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._egeMarketPlaceResourceId.ToString()) : null, "egeMarketPlaceResourceId" ,container.Add );
            AddIf( null != (((object)this._hypervGeneration)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._hypervGeneration.ToString()) : null, "hypervGeneration" ,container.Add );
            AddIf( null != (((object)this._marketPlaceSku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._marketPlaceSku.ToString()) : null, "marketPlaceSku" ,container.Add );
            AddIf( null != (((object)this._marketPlaceSkuVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._marketPlaceSkuVersion.ToString()) : null, "marketPlaceSkuVersion" ,container.Add );
            AddIf( null != (((object)this._deviceSku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._deviceSku.ToString()) : null, "deviceSku" ,container.Add );
            AddIf( null != (((object)this._deviceVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._deviceVersion.ToString()) : null, "deviceVersion" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}