namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A protected disk details.</summary>
    public partial class A2AProtectedDiskDetails
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="A2AProtectedDiskDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal A2AProtectedDiskDetails(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_diskUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("diskUri"), out var __jsonDiskUri) ? (string)__jsonDiskUri : (string)DiskUri;}
            {_recoveryAzureStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureStorageAccountId"), out var __jsonRecoveryAzureStorageAccountId) ? (string)__jsonRecoveryAzureStorageAccountId : (string)RecoveryAzureStorageAccountId;}
            {_primaryDiskAzureStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("primaryDiskAzureStorageAccountId"), out var __jsonPrimaryDiskAzureStorageAccountId) ? (string)__jsonPrimaryDiskAzureStorageAccountId : (string)PrimaryDiskAzureStorageAccountId;}
            {_recoveryDiskUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryDiskUri"), out var __jsonRecoveryDiskUri) ? (string)__jsonRecoveryDiskUri : (string)RecoveryDiskUri;}
            {_diskName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("diskName"), out var __jsonDiskName) ? (string)__jsonDiskName : (string)DiskName;}
            {_diskCapacityInByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("diskCapacityInBytes"), out var __jsonDiskCapacityInBytes) ? (long?)__jsonDiskCapacityInBytes : DiskCapacityInByte;}
            {_primaryStagingAzureStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("primaryStagingAzureStorageAccountId"), out var __jsonPrimaryStagingAzureStorageAccountId) ? (string)__jsonPrimaryStagingAzureStorageAccountId : (string)PrimaryStagingAzureStorageAccountId;}
            {_diskType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("diskType"), out var __jsonDiskType) ? (string)__jsonDiskType : (string)DiskType;}
            {_resyncRequired = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonBoolean>("resyncRequired"), out var __jsonResyncRequired) ? (bool?)__jsonResyncRequired : ResyncRequired;}
            {_monitoringPercentageCompletion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("monitoringPercentageCompletion"), out var __jsonMonitoringPercentageCompletion) ? (int?)__jsonMonitoringPercentageCompletion : MonitoringPercentageCompletion;}
            {_monitoringJobType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("monitoringJobType"), out var __jsonMonitoringJobType) ? (string)__jsonMonitoringJobType : (string)MonitoringJobType;}
            {_dataPendingInStagingStorageAccountInMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("dataPendingInStagingStorageAccountInMB"), out var __jsonDataPendingInStagingStorageAccountInMb) ? (double?)__jsonDataPendingInStagingStorageAccountInMb : DataPendingInStagingStorageAccountInMb;}
            {_dataPendingAtSourceAgentInMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("dataPendingAtSourceAgentInMB"), out var __jsonDataPendingAtSourceAgentInMb) ? (double?)__jsonDataPendingAtSourceAgentInMb : DataPendingAtSourceAgentInMb;}
            {_isDiskEncrypted = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonBoolean>("isDiskEncrypted"), out var __jsonIsDiskEncrypted) ? (bool?)__jsonIsDiskEncrypted : IsDiskEncrypted;}
            {_secretIdentifier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("secretIdentifier"), out var __jsonSecretIdentifier) ? (string)__jsonSecretIdentifier : (string)SecretIdentifier;}
            {_dekKeyVaultArmId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("dekKeyVaultArmId"), out var __jsonDekKeyVaultArmId) ? (string)__jsonDekKeyVaultArmId : (string)DekKeyVaultArmId;}
            {_isDiskKeyEncrypted = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonBoolean>("isDiskKeyEncrypted"), out var __jsonIsDiskKeyEncrypted) ? (bool?)__jsonIsDiskKeyEncrypted : IsDiskKeyEncrypted;}
            {_keyIdentifier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("keyIdentifier"), out var __jsonKeyIdentifier) ? (string)__jsonKeyIdentifier : (string)KeyIdentifier;}
            {_kekKeyVaultArmId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("kekKeyVaultArmId"), out var __jsonKekKeyVaultArmId) ? (string)__jsonKekKeyVaultArmId : (string)KekKeyVaultArmId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new A2AProtectedDiskDetails(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="A2AProtectedDiskDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="A2AProtectedDiskDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._diskUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._diskUri.ToString()) : null, "diskUri" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureStorageAccountId.ToString()) : null, "recoveryAzureStorageAccountId" ,container.Add );
            AddIf( null != (((object)this._primaryDiskAzureStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._primaryDiskAzureStorageAccountId.ToString()) : null, "primaryDiskAzureStorageAccountId" ,container.Add );
            AddIf( null != (((object)this._recoveryDiskUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryDiskUri.ToString()) : null, "recoveryDiskUri" ,container.Add );
            AddIf( null != (((object)this._diskName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._diskName.ToString()) : null, "diskName" ,container.Add );
            AddIf( null != this._diskCapacityInByte ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._diskCapacityInByte) : null, "diskCapacityInBytes" ,container.Add );
            AddIf( null != (((object)this._primaryStagingAzureStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._primaryStagingAzureStorageAccountId.ToString()) : null, "primaryStagingAzureStorageAccountId" ,container.Add );
            AddIf( null != (((object)this._diskType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._diskType.ToString()) : null, "diskType" ,container.Add );
            AddIf( null != this._resyncRequired ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonBoolean((bool)this._resyncRequired) : null, "resyncRequired" ,container.Add );
            AddIf( null != this._monitoringPercentageCompletion ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._monitoringPercentageCompletion) : null, "monitoringPercentageCompletion" ,container.Add );
            AddIf( null != (((object)this._monitoringJobType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._monitoringJobType.ToString()) : null, "monitoringJobType" ,container.Add );
            AddIf( null != this._dataPendingInStagingStorageAccountInMb ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((double)this._dataPendingInStagingStorageAccountInMb) : null, "dataPendingInStagingStorageAccountInMB" ,container.Add );
            AddIf( null != this._dataPendingAtSourceAgentInMb ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((double)this._dataPendingAtSourceAgentInMb) : null, "dataPendingAtSourceAgentInMB" ,container.Add );
            AddIf( null != this._isDiskEncrypted ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonBoolean((bool)this._isDiskEncrypted) : null, "isDiskEncrypted" ,container.Add );
            AddIf( null != (((object)this._secretIdentifier)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._secretIdentifier.ToString()) : null, "secretIdentifier" ,container.Add );
            AddIf( null != (((object)this._dekKeyVaultArmId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._dekKeyVaultArmId.ToString()) : null, "dekKeyVaultArmId" ,container.Add );
            AddIf( null != this._isDiskKeyEncrypted ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonBoolean((bool)this._isDiskKeyEncrypted) : null, "isDiskKeyEncrypted" ,container.Add );
            AddIf( null != (((object)this._keyIdentifier)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._keyIdentifier.ToString()) : null, "keyIdentifier" ,container.Add );
            AddIf( null != (((object)this._kekKeyVaultArmId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._kekKeyVaultArmId.ToString()) : null, "kekKeyVaultArmId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}