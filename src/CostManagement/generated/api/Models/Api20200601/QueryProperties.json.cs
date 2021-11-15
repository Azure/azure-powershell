namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    public partial class QueryProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json ? new QueryProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject into a new instance of <see cref="QueryProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal QueryProperties(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_nextLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString>("nextLink"), out var __jsonNextLink) ? (string)__jsonNextLink : (string)NextLink;}
            {_column = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("columns"), out var __jsonColumns) ? If( __jsonColumns as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn) (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumn.FromJson(__u) )) ))() : null : Column;}
            {_row = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray>("rows"), out var __jsonRows) ? If( __jsonRows as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __p) ? new global::System.Func<string[][]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__p, (__o)=>(string[]) (If( __o as Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonArray, out var __n) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__n, (__m)=>(string) (__m is Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString __l ? (string)(__l.ToString()) : null)) ))() : null /* arrayOf */)) ))() : null : Row;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="QueryProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="QueryProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._nextLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(this._nextLink.ToString()) : null, "nextLink" ,container.Add );
            if (null != this._column)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __x in this._column )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("columns",__w);
            }
            if (null != this._row)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray();
                foreach( var __s in this._row )
                {
                    AddIf(null != __s ? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.XNodeArray(global::System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(__s, (__q) => null != (((object)__q)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonString(__q.ToString()) : null))) : null ,__r.Add);
                }
                container.Add("rows",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}