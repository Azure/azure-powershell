namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto database properties.</summary>
    public partial class ReadOnlyFollowingDatabaseProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IReadOnlyFollowingDatabaseProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IReadOnlyFollowingDatabaseProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IReadOnlyFollowingDatabaseProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json ? new ReadOnlyFollowingDatabaseProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject into a new instance of <see cref="ReadOnlyFollowingDatabaseProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ReadOnlyFollowingDatabaseProperties(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_statistics = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject>("statistics"), out var __jsonStatistics) ? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabaseStatistics.FromJson(__jsonStatistics) : Statistics;}
            {_attachedDatabaseConfigurationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("attachedDatabaseConfigurationName"), out var __jsonAttachedDatabaseConfigurationName) ? (string)__jsonAttachedDatabaseConfigurationName : (string)AttachedDatabaseConfigurationName;}
            {_hotCachePeriod = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("hotCachePeriod"), out var __jsonHotCachePeriod) ? global::System.Xml.XmlConvert.ToTimeSpan( __jsonHotCachePeriod ) : HotCachePeriod;}
            {_leaderClusterResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("leaderClusterResourceId"), out var __jsonLeaderClusterResourceId) ? (string)__jsonLeaderClusterResourceId : (string)LeaderClusterResourceId;}
            {_principalsModificationKind = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("principalsModificationKind"), out var __jsonPrincipalsModificationKind) ? (string)__jsonPrincipalsModificationKind : (string)PrincipalsModificationKind;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_softDeletePeriod = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("softDeletePeriod"), out var __jsonSoftDeletePeriod) ? global::System.Xml.XmlConvert.ToTimeSpan( __jsonSoftDeletePeriod ) : SoftDeletePeriod;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ReadOnlyFollowingDatabaseProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ReadOnlyFollowingDatabaseProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._statistics ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) this._statistics.ToJson(null,serializationMode) : null, "statistics" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._attachedDatabaseConfigurationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._attachedDatabaseConfigurationName.ToString()) : null, "attachedDatabaseConfigurationName" ,container.Add );
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode)(null != this._hotCachePeriod ? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(global::System.Xml.XmlConvert.ToString((global::System.TimeSpan)this._hotCachePeriod)): null), "hotCachePeriod" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._leaderClusterResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._leaderClusterResourceId.ToString()) : null, "leaderClusterResourceId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._principalsModificationKind)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._principalsModificationKind.ToString()) : null, "principalsModificationKind" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode)(null != this._softDeletePeriod ? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(global::System.Xml.XmlConvert.ToString((global::System.TimeSpan)this._softDeletePeriod)): null), "softDeletePeriod" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}