// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration state of a database.</summary>
    public partial class DatabaseMigrationState
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject into a new instance of <see cref="DatabaseMigrationState" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DatabaseMigrationState(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_databaseName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("databaseName"), out var __jsonDatabaseName) ? (string)__jsonDatabaseName : (string)_databaseName;}
            {_migrationState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationState"), out var __jsonMigrationState) ? (string)__jsonMigrationState : (string)_migrationState;}
            {_migrationOperation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationOperation"), out var __jsonMigrationOperation) ? (string)__jsonMigrationOperation : (string)_migrationOperation;}
            {_startedOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("startedOn"), out var __jsonStartedOn) ? global::System.DateTime.TryParse((string)__jsonStartedOn, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartedOnValue) ? __jsonStartedOnValue : _startedOn : _startedOn;}
            {_endedOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("endedOn"), out var __jsonEndedOn) ? global::System.DateTime.TryParse((string)__jsonEndedOn, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEndedOnValue) ? __jsonEndedOnValue : _endedOn : _endedOn;}
            {_fullLoadQueuedTable = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("fullLoadQueuedTables"), out var __jsonFullLoadQueuedTables) ? (int?)__jsonFullLoadQueuedTables : _fullLoadQueuedTable;}
            {_fullLoadErroredTable = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("fullLoadErroredTables"), out var __jsonFullLoadErroredTables) ? (int?)__jsonFullLoadErroredTables : _fullLoadErroredTable;}
            {_fullLoadLoadingTable = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("fullLoadLoadingTables"), out var __jsonFullLoadLoadingTables) ? (int?)__jsonFullLoadLoadingTables : _fullLoadLoadingTable;}
            {_fullLoadCompletedTable = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("fullLoadCompletedTables"), out var __jsonFullLoadCompletedTables) ? (int?)__jsonFullLoadCompletedTables : _fullLoadCompletedTable;}
            {_cdcUpdateCounter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("cdcUpdateCounter"), out var __jsonCdcUpdateCounter) ? (int?)__jsonCdcUpdateCounter : _cdcUpdateCounter;}
            {_cdcDeleteCounter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("cdcDeleteCounter"), out var __jsonCdcDeleteCounter) ? (int?)__jsonCdcDeleteCounter : _cdcDeleteCounter;}
            {_cdcInsertCounter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("cdcInsertCounter"), out var __jsonCdcInsertCounter) ? (int?)__jsonCdcInsertCounter : _cdcInsertCounter;}
            {_appliedChange = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("appliedChanges"), out var __jsonAppliedChanges) ? (int?)__jsonAppliedChanges : _appliedChange;}
            {_incomingChange = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("incomingChanges"), out var __jsonIncomingChanges) ? (int?)__jsonIncomingChanges : _incomingChange;}
            {_latency = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber>("latency"), out var __jsonLatency) ? (int?)__jsonLatency : _latency;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)_message;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json ? new DatabaseMigrationState(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DatabaseMigrationState" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DatabaseMigrationState" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._databaseName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._databaseName.ToString()) : null, "databaseName" ,container.Add );
            AddIf( null != (((object)this._migrationState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationState.ToString()) : null, "migrationState" ,container.Add );
            AddIf( null != (((object)this._migrationOperation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationOperation.ToString()) : null, "migrationOperation" ,container.Add );
            AddIf( null != this._startedOn ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._startedOn?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startedOn" ,container.Add );
            AddIf( null != this._endedOn ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._endedOn?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "endedOn" ,container.Add );
            AddIf( null != this._fullLoadQueuedTable ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._fullLoadQueuedTable) : null, "fullLoadQueuedTables" ,container.Add );
            AddIf( null != this._fullLoadErroredTable ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._fullLoadErroredTable) : null, "fullLoadErroredTables" ,container.Add );
            AddIf( null != this._fullLoadLoadingTable ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._fullLoadLoadingTable) : null, "fullLoadLoadingTables" ,container.Add );
            AddIf( null != this._fullLoadCompletedTable ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._fullLoadCompletedTable) : null, "fullLoadCompletedTables" ,container.Add );
            AddIf( null != this._cdcUpdateCounter ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._cdcUpdateCounter) : null, "cdcUpdateCounter" ,container.Add );
            AddIf( null != this._cdcDeleteCounter ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._cdcDeleteCounter) : null, "cdcDeleteCounter" ,container.Add );
            AddIf( null != this._cdcInsertCounter ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._cdcInsertCounter) : null, "cdcInsertCounter" ,container.Add );
            AddIf( null != this._appliedChange ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._appliedChange) : null, "appliedChanges" ,container.Add );
            AddIf( null != this._incomingChange ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._incomingChange) : null, "incomingChanges" ,container.Add );
            AddIf( null != this._latency ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNumber((int)this._latency) : null, "latency" ,container.Add );
            AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}