namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Tables that will be included and excluded in the follower database</summary>
    public partial class TableLevelSharingProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json ? new TableLevelSharingProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject into a new instance of <see cref="TableLevelSharingProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal TableLevelSharingProperties(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_tablesToInclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("tablesToInclude"), out var __jsonTablesToInclude) ? If( __jsonTablesToInclude as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : TablesToInclude;}
            {_tablesToExclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("tablesToExclude"), out var __jsonTablesToExclude) ? If( __jsonTablesToExclude as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : TablesToExclude;}
            {_externalTablesToInclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("externalTablesToInclude"), out var __jsonExternalTablesToInclude) ? If( __jsonExternalTablesToInclude as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : ExternalTablesToInclude;}
            {_externalTablesToExclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("externalTablesToExclude"), out var __jsonExternalTablesToExclude) ? If( __jsonExternalTablesToExclude as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : ExternalTablesToExclude;}
            {_materializedViewsToInclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("materializedViewsToInclude"), out var __jsonMaterializedViewsToInclude) ? If( __jsonMaterializedViewsToInclude as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(string) (__a is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString ___z ? (string)(___z.ToString()) : null)) ))() : null : MaterializedViewsToInclude;}
            {_materializedViewsToExclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("materializedViewsToExclude"), out var __jsonMaterializedViewsToExclude) ? If( __jsonMaterializedViewsToExclude as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(string) (___v is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString ___u ? (string)(___u.ToString()) : null)) ))() : null : MaterializedViewsToExclude;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="TableLevelSharingProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="TableLevelSharingProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (null != this._tablesToInclude)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var __x in this._tablesToInclude )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("tablesToInclude",__w);
            }
            if (null != this._tablesToExclude)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var __s in this._tablesToExclude )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("tablesToExclude",__r);
            }
            if (null != this._externalTablesToInclude)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var __n in this._externalTablesToInclude )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("externalTablesToInclude",__m);
            }
            if (null != this._externalTablesToExclude)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var __i in this._externalTablesToExclude )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("externalTablesToExclude",__h);
            }
            if (null != this._materializedViewsToInclude)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var __d in this._materializedViewsToInclude )
                {
                    AddIf(null != (((object)__d)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(__d.ToString()) : null ,__c.Add);
                }
                container.Add("materializedViewsToInclude",__c);
            }
            if (null != this._materializedViewsToExclude)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var ___y in this._materializedViewsToExclude )
                {
                    AddIf(null != (((object)___y)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(___y.ToString()) : null ,___x.Add);
                }
                container.Add("materializedViewsToExclude",___x);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}