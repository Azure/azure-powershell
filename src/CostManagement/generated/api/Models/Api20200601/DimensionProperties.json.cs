namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    public partial class DimensionProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject into a new instance of <see cref="DimensionProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DimensionProperties(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_filterEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonBoolean>("filterEnabled"), out var __jsonFilterEnabled) ? (bool?)__jsonFilterEnabled : FilterEnabled;}
            {_groupingEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonBoolean>("groupingEnabled"), out var __jsonGroupingEnabled) ? (bool?)__jsonGroupingEnabled : GroupingEnabled;}
            {_data = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("data"), out var __jsonData) ? If( __jsonData as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : Data;}
            {_total = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber>("total"), out var __jsonTotal) ? (int?)__jsonTotal : Total;}
            {_category = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("category"), out var __jsonCategory) ? (string)__jsonCategory : (string)Category;}
            {_usageStart = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("usageStart"), out var __jsonUsageStart) ? global::System.DateTime.TryParse((string)__jsonUsageStart, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonUsageStartValue) ? __jsonUsageStartValue : UsageStart : UsageStart;}
            {_usageEnd = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("usageEnd"), out var __jsonUsageEnd) ? global::System.DateTime.TryParse((string)__jsonUsageEnd, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonUsageEndValue) ? __jsonUsageEndValue : UsageEnd : UsageEnd;}
            {_nextLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("nextLink"), out var __jsonNextLink) ? (string)__jsonNextLink : (string)NextLink;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json ? new DimensionProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DimensionProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DimensionProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._filterEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonBoolean((bool)this._filterEnabled) : null, "filterEnabled" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._groupingEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonBoolean((bool)this._groupingEnabled) : null, "groupingEnabled" ,container.Add );
            }
            if (null != this._data)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __x in this._data )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("data",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._total ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNumber((int)this._total) : null, "total" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._category)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._category.ToString()) : null, "category" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._usageStart ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._usageStart?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "usageStart" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._usageEnd ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._usageEnd?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "usageEnd" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._nextLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._nextLink.ToString()) : null, "nextLink" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}