// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The marketplace sku</summary>
    public partial class MarketplaceSku
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku FromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json ? new MarketplaceSku(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject into a new instance of <see cref="MarketplaceSku" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MarketplaceSku(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_operatingSystem = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject>("operatingSystem"), out var __jsonOperatingSystem) ? Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.SkuOperatingSystem.FromJson(__jsonOperatingSystem) : _operatingSystem;}
            {_catalogPlanId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("catalogPlanId"), out var __jsonCatalogPlanId) ? (string)__jsonCatalogPlanId : (string)_catalogPlanId;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("marketplaceSkuId"), out var __jsonMarketplaceSkuId) ? (string)__jsonMarketplaceSkuId : (string)_id;}
            {_type = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("type"), out var __jsonType) ? (string)__jsonType : (string)_type;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)_displayName;}
            {_summary = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("summary"), out var __jsonSummary) ? (string)__jsonSummary : (string)_summary;}
            {_longSummary = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("longSummary"), out var __jsonLongSummary) ? (string)__jsonLongSummary : (string)_longSummary;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)_description;}
            {_generation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("generation"), out var __jsonGeneration) ? (string)__jsonGeneration : (string)_generation;}
            {_displayRank = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNumber>("displayRank"), out var __jsonDisplayRank) ? (int?)__jsonDisplayRank : _displayRank;}
            {_version = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonArray>("marketplaceSkuVersions"), out var __jsonMarketplaceSkuVersions) ? If( __jsonMarketplaceSkuVersions as Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion) (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.MarketplaceSkuVersion.FromJson(__u) )) ))() : null : _version;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MarketplaceSku" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MarketplaceSku" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._operatingSystem ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) this._operatingSystem.ToJson(null,serializationMode) : null, "operatingSystem" ,container.Add );
            AddIf( null != (((object)this._catalogPlanId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._catalogPlanId.ToString()) : null, "catalogPlanId" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._id.ToString()) : null, "marketplaceSkuId" ,container.Add );
            AddIf( null != (((object)this._type)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._type.ToString()) : null, "type" ,container.Add );
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._summary)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._summary.ToString()) : null, "summary" ,container.Add );
            AddIf( null != (((object)this._longSummary)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._longSummary.ToString()) : null, "longSummary" ,container.Add );
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._generation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._generation.ToString()) : null, "generation" ,container.Add );
            AddIf( null != this._displayRank ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNumber((int)this._displayRank) : null, "displayRank" ,container.Add );
            if (null != this._version)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.XNodeArray();
                foreach( var __x in this._version )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("marketplaceSkuVersions",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}