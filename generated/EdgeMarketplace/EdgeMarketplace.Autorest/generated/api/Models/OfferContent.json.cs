// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The offer content</summary>
    public partial class OfferContent
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent FromJson(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json ? new OfferContent(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject into a new instance of <see cref="OfferContent" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal OfferContent(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_offerPublisher = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject>("offerPublisher"), out var __jsonOfferPublisher) ? Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferPublisher.FromJson(__jsonOfferPublisher) : _offerPublisher;}
            {_iconFileUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject>("iconFileUris"), out var __jsonIconFileUris) ? Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IconFileUris.FromJson(__jsonIconFileUris) : _iconFileUri;}
            {_termsAndCondition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject>("termsAndConditions"), out var __jsonTermsAndConditions) ? Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.TermsAndConditions.FromJson(__jsonTermsAndConditions) : _termsAndCondition;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)_displayName;}
            {_summary = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("summary"), out var __jsonSummary) ? (string)__jsonSummary : (string)_summary;}
            {_longSummary = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("longSummary"), out var __jsonLongSummary) ? (string)__jsonLongSummary : (string)_longSummary;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)_description;}
            {_offerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("offerId"), out var __jsonOfferId) ? (string)__jsonOfferId : (string)_offerId;}
            {_offerType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("offerType"), out var __jsonOfferType) ? (string)__jsonOfferType : (string)_offerType;}
            {_supportUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("supportUri"), out var __jsonSupportUri) ? (string)__jsonSupportUri : (string)_supportUri;}
            {_popularity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNumber>("popularity"), out var __jsonPopularity) ? (int?)__jsonPopularity : _popularity;}
            {_availability = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("availability"), out var __jsonAvailability) ? (string)__jsonAvailability : (string)_availability;}
            {_releaseType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString>("releaseType"), out var __jsonReleaseType) ? (string)__jsonReleaseType : (string)_releaseType;}
            {_categoryId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonArray>("categoryIds"), out var __jsonCategoryIds) ? If( __jsonCategoryIds as Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _categoryId;}
            {_operatingSystem = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonArray>("operatingSystems"), out var __jsonOperatingSystems) ? If( __jsonOperatingSystems as Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : _operatingSystem;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="OfferContent" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="OfferContent" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._offerPublisher ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) this._offerPublisher.ToJson(null,serializationMode) : null, "offerPublisher" ,container.Add );
            AddIf( null != this._iconFileUri ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) this._iconFileUri.ToJson(null,serializationMode) : null, "iconFileUris" ,container.Add );
            AddIf( null != this._termsAndCondition ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) this._termsAndCondition.ToJson(null,serializationMode) : null, "termsAndConditions" ,container.Add );
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._summary)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._summary.ToString()) : null, "summary" ,container.Add );
            AddIf( null != (((object)this._longSummary)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._longSummary.ToString()) : null, "longSummary" ,container.Add );
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._offerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._offerId.ToString()) : null, "offerId" ,container.Add );
            AddIf( null != (((object)this._offerType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._offerType.ToString()) : null, "offerType" ,container.Add );
            AddIf( null != (((object)this._supportUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._supportUri.ToString()) : null, "supportUri" ,container.Add );
            AddIf( null != this._popularity ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNumber((int)this._popularity) : null, "popularity" ,container.Add );
            AddIf( null != (((object)this._availability)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._availability.ToString()) : null, "availability" ,container.Add );
            AddIf( null != (((object)this._releaseType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(this._releaseType.ToString()) : null, "releaseType" ,container.Add );
            if (null != this._categoryId)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.XNodeArray();
                foreach( var __x in this._categoryId )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("categoryIds",__w);
            }
            if (null != this._operatingSystem)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.XNodeArray();
                foreach( var __s in this._operatingSystem )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("operatingSystems",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}