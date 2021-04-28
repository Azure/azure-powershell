namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Restore target info for Item level restore operation</summary>
    public partial class ItemLevelRestoreTargetInfo
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new ItemLevelRestoreTargetInfo(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="ItemLevelRestoreTargetInfo" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ItemLevelRestoreTargetInfo(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __restoreTargetInfoBase = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreTargetInfoBase(json);
            {_restoreCriterion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("restoreCriteria"), out var __jsonRestoreCriteria) ? If( __jsonRestoreCriteria as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria) (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreCriteria.FromJson(__u) )) ))() : null : RestoreCriterion;}
            {_datasourceInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject>("datasourceInfo"), out var __jsonDatasourceInfo) ? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.Datasource.FromJson(__jsonDatasourceInfo) : DatasourceInfo;}
            {_datasourceSetInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject>("datasourceSetInfo"), out var __jsonDatasourceSetInfo) ? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DatasourceSet.FromJson(__jsonDatasourceSetInfo) : DatasourceSetInfo;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ItemLevelRestoreTargetInfo" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ItemLevelRestoreTargetInfo" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __restoreTargetInfoBase?.ToJson(container, serializationMode);
            if (null != this._restoreCriterion)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __x in this._restoreCriterion )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("restoreCriteria",__w);
            }
            AddIf( null != this._datasourceInfo ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) this._datasourceInfo.ToJson(null,serializationMode) : null, "datasourceInfo" ,container.Add );
            AddIf( null != this._datasourceSetInfo ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) this._datasourceSetInfo.ToJson(null,serializationMode) : null, "datasourceSetInfo" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}