namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>HyperV Replica Blue policy input.</summary>
    public partial class HyperVReplicaBluePolicyInput
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new HyperVReplicaBluePolicyInput(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="HyperVReplicaBluePolicyInput" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HyperVReplicaBluePolicyInput(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __policyProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificInput(json);
            {_replicationFrequencyInSecond = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("replicationFrequencyInSeconds"), out var __jsonReplicationFrequencyInSeconds) ? (int?)__jsonReplicationFrequencyInSeconds : ReplicationFrequencyInSecond;}
            {_recoveryPoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("recoveryPoints"), out var __jsonRecoveryPoints) ? (int?)__jsonRecoveryPoints : RecoveryPoint;}
            {_applicationConsistentSnapshotFrequencyInHour = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("applicationConsistentSnapshotFrequencyInHours"), out var __jsonApplicationConsistentSnapshotFrequencyInHours) ? (int?)__jsonApplicationConsistentSnapshotFrequencyInHours : ApplicationConsistentSnapshotFrequencyInHour;}
            {_compression = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("compression"), out var __jsonCompression) ? (string)__jsonCompression : (string)Compression;}
            {_initialReplicationMethod = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("initialReplicationMethod"), out var __jsonInitialReplicationMethod) ? (string)__jsonInitialReplicationMethod : (string)InitialReplicationMethod;}
            {_onlineReplicationStartTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("onlineReplicationStartTime"), out var __jsonOnlineReplicationStartTime) ? (string)__jsonOnlineReplicationStartTime : (string)OnlineReplicationStartTime;}
            {_offlineReplicationImportPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("offlineReplicationImportPath"), out var __jsonOfflineReplicationImportPath) ? (string)__jsonOfflineReplicationImportPath : (string)OfflineReplicationImportPath;}
            {_offlineReplicationExportPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("offlineReplicationExportPath"), out var __jsonOfflineReplicationExportPath) ? (string)__jsonOfflineReplicationExportPath : (string)OfflineReplicationExportPath;}
            {_replicationPort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("replicationPort"), out var __jsonReplicationPort) ? (int?)__jsonReplicationPort : ReplicationPort;}
            {_allowedAuthenticationType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("allowedAuthenticationType"), out var __jsonAllowedAuthenticationType) ? (int?)__jsonAllowedAuthenticationType : AllowedAuthenticationType;}
            {_replicaDeletion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("replicaDeletion"), out var __jsonReplicaDeletion) ? (string)__jsonReplicaDeletion : (string)ReplicaDeletion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HyperVReplicaBluePolicyInput" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HyperVReplicaBluePolicyInput" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __policyProviderSpecificInput?.ToJson(container, serializationMode);
            AddIf( null != this._replicationFrequencyInSecond ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._replicationFrequencyInSecond) : null, "replicationFrequencyInSeconds" ,container.Add );
            AddIf( null != this._recoveryPoint ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._recoveryPoint) : null, "recoveryPoints" ,container.Add );
            AddIf( null != this._applicationConsistentSnapshotFrequencyInHour ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._applicationConsistentSnapshotFrequencyInHour) : null, "applicationConsistentSnapshotFrequencyInHours" ,container.Add );
            AddIf( null != (((object)this._compression)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._compression.ToString()) : null, "compression" ,container.Add );
            AddIf( null != (((object)this._initialReplicationMethod)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._initialReplicationMethod.ToString()) : null, "initialReplicationMethod" ,container.Add );
            AddIf( null != (((object)this._onlineReplicationStartTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._onlineReplicationStartTime.ToString()) : null, "onlineReplicationStartTime" ,container.Add );
            AddIf( null != (((object)this._offlineReplicationImportPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._offlineReplicationImportPath.ToString()) : null, "offlineReplicationImportPath" ,container.Add );
            AddIf( null != (((object)this._offlineReplicationExportPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._offlineReplicationExportPath.ToString()) : null, "offlineReplicationExportPath" ,container.Add );
            AddIf( null != this._replicationPort ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._replicationPort) : null, "replicationPort" ,container.Add );
            AddIf( null != this._allowedAuthenticationType ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._allowedAuthenticationType) : null, "allowedAuthenticationType" ,container.Add );
            AddIf( null != (((object)this._replicaDeletion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._replicaDeletion.ToString()) : null, "replicaDeletion" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}