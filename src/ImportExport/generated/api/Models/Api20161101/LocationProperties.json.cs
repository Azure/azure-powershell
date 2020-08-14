namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>location properties</summary>
    public partial class LocationProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json ? new LocationProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject into a new instance of <see cref="LocationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal LocationProperties(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_alternateLocation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray>("alternateLocations"), out var __jsonAlternateLocations) ? If( __jsonAlternateLocations as Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AlternateLocation;}
            {_city = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("city"), out var __jsonCity) ? (string)__jsonCity : (string)City;}
            {_countryOrRegion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("countryOrRegion"), out var __jsonCountryOrRegion) ? (string)__jsonCountryOrRegion : (string)CountryOrRegion;}
            {_phone = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("phone"), out var __jsonPhone) ? (string)__jsonPhone : (string)Phone;}
            {_postalCode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("postalCode"), out var __jsonPostalCode) ? (string)__jsonPostalCode : (string)PostalCode;}
            {_recipientName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("recipientName"), out var __jsonRecipientName) ? (string)__jsonRecipientName : (string)RecipientName;}
            {_stateOrProvince = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("stateOrProvince"), out var __jsonStateOrProvince) ? (string)__jsonStateOrProvince : (string)StateOrProvince;}
            {_streetAddress1 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("streetAddress1"), out var __jsonStreetAddress1) ? (string)__jsonStreetAddress1 : (string)StreetAddress1;}
            {_streetAddress2 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString>("streetAddress2"), out var __jsonStreetAddress2) ? (string)__jsonStreetAddress2 : (string)StreetAddress2;}
            {_supportedCarrier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray>("supportedCarriers"), out var __jsonSupportedCarriers) ? If( __jsonSupportedCarriers as Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : SupportedCarrier;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="LocationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="LocationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (null != this._alternateLocation)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.XNodeArray();
                foreach( var __x in this._alternateLocation )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("alternateLocations",__w);
            }
            AddIf( null != (((object)this._city)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._city.ToString()) : null, "city" ,container.Add );
            AddIf( null != (((object)this._countryOrRegion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._countryOrRegion.ToString()) : null, "countryOrRegion" ,container.Add );
            AddIf( null != (((object)this._phone)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._phone.ToString()) : null, "phone" ,container.Add );
            AddIf( null != (((object)this._postalCode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._postalCode.ToString()) : null, "postalCode" ,container.Add );
            AddIf( null != (((object)this._recipientName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._recipientName.ToString()) : null, "recipientName" ,container.Add );
            AddIf( null != (((object)this._stateOrProvince)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._stateOrProvince.ToString()) : null, "stateOrProvince" ,container.Add );
            AddIf( null != (((object)this._streetAddress1)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._streetAddress1.ToString()) : null, "streetAddress1" ,container.Add );
            AddIf( null != (((object)this._streetAddress2)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(this._streetAddress2.ToString()) : null, "streetAddress2" ,container.Add );
            if (null != this._supportedCarrier)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.XNodeArray();
                foreach( var __s in this._supportedCarrier )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("supportedCarriers",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}