namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageAzureV2 provider specific settings</summary>
    public partial class InMageAzureV2ReplicationDetails
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ReplicationDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ReplicationDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ReplicationDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new InMageAzureV2ReplicationDetails(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="InMageAzureV2ReplicationDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal InMageAzureV2ReplicationDetails(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __replicationProviderSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings(json);
            {_infrastructureVMId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("infrastructureVmId"), out var __jsonInfrastructureVMId) ? (string)__jsonInfrastructureVMId : (string)InfrastructureVMId;}
            {_vCenterInfrastructureId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vCenterInfrastructureId"), out var __jsonVCenterInfrastructureId) ? (string)__jsonVCenterInfrastructureId : (string)VCenterInfrastructureId;}
            {_protectionStage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("protectionStage"), out var __jsonProtectionStage) ? (string)__jsonProtectionStage : (string)ProtectionStage;}
            {_vMId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmId"), out var __jsonVMId) ? (string)__jsonVMId : (string)VMId;}
            {_vMProtectionState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmProtectionState"), out var __jsonVMProtectionState) ? (string)__jsonVMProtectionState : (string)VMProtectionState;}
            {_vMProtectionStateDescription = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmProtectionStateDescription"), out var __jsonVMProtectionStateDescription) ? (string)__jsonVMProtectionStateDescription : (string)VMProtectionStateDescription;}
            {_resyncProgressPercentage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("resyncProgressPercentage"), out var __jsonResyncProgressPercentage) ? (int?)__jsonResyncProgressPercentage : ResyncProgressPercentage;}
            {_rpoInSecond = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("rpoInSeconds"), out var __jsonRpoInSeconds) ? (long?)__jsonRpoInSeconds : RpoInSecond;}
            {_compressedDataRateInMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("compressedDataRateInMB"), out var __jsonCompressedDataRateInMb) ? (double?)__jsonCompressedDataRateInMb : CompressedDataRateInMb;}
            {_uncompressedDataRateInMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("uncompressedDataRateInMB"), out var __jsonUncompressedDataRateInMb) ? (double?)__jsonUncompressedDataRateInMb : UncompressedDataRateInMb;}
            {_iPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("ipAddress"), out var __jsonIPAddress) ? (string)__jsonIPAddress : (string)IPAddress;}
            {_agentVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("agentVersion"), out var __jsonAgentVersion) ? (string)__jsonAgentVersion : (string)AgentVersion;}
            {_agentExpiryDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("agentExpiryDate"), out var __jsonAgentExpiryDate) ? global::System.DateTime.TryParse((string)__jsonAgentExpiryDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonAgentExpiryDateValue) ? __jsonAgentExpiryDateValue : AgentExpiryDate : AgentExpiryDate;}
            {_isAgentUpdateRequired = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("isAgentUpdateRequired"), out var __jsonIsAgentUpdateRequired) ? (string)__jsonIsAgentUpdateRequired : (string)IsAgentUpdateRequired;}
            {_isRebootAfterUpdateRequired = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("isRebootAfterUpdateRequired"), out var __jsonIsRebootAfterUpdateRequired) ? (string)__jsonIsRebootAfterUpdateRequired : (string)IsRebootAfterUpdateRequired;}
            {_lastHeartbeat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastHeartbeat"), out var __jsonLastHeartbeat) ? global::System.DateTime.TryParse((string)__jsonLastHeartbeat, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastHeartbeatValue) ? __jsonLastHeartbeatValue : LastHeartbeat : LastHeartbeat;}
            {_processServerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("processServerId"), out var __jsonProcessServerId) ? (string)__jsonProcessServerId : (string)ProcessServerId;}
            {_multiVMGroupId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("multiVmGroupId"), out var __jsonMultiVMGroupId) ? (string)__jsonMultiVMGroupId : (string)MultiVMGroupId;}
            {_multiVMGroupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("multiVmGroupName"), out var __jsonMultiVMGroupName) ? (string)__jsonMultiVMGroupName : (string)MultiVMGroupName;}
            {_multiVMSyncStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("multiVmSyncStatus"), out var __jsonMultiVMSyncStatus) ? (string)__jsonMultiVMSyncStatus : (string)MultiVMSyncStatus;}
            {_protectedDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("protectedDisks"), out var __jsonProtectedDisks) ? If( __jsonProtectedDisks as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAzureV2ProtectedDiskDetails.FromJson(__u) )) ))() : null : ProtectedDisk;}
            {_diskResized = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("diskResized"), out var __jsonDiskResized) ? (string)__jsonDiskResized : (string)DiskResized;}
            {_masterTargetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("masterTargetId"), out var __jsonMasterTargetId) ? (string)__jsonMasterTargetId : (string)MasterTargetId;}
            {_sourceVMCpuCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("sourceVmCpuCount"), out var __jsonSourceVMCpuCount) ? (int?)__jsonSourceVMCpuCount : SourceVMCpuCount;}
            {_sourceVMRamSizeInMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("sourceVmRamSizeInMB"), out var __jsonSourceVMRamSizeInMb) ? (int?)__jsonSourceVMRamSizeInMb : SourceVMRamSizeInMb;}
            {_oSType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osType"), out var __jsonOSType) ? (string)__jsonOSType : (string)OSType;}
            {_vhdName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vhdName"), out var __jsonVhdName) ? (string)__jsonVhdName : (string)VhdName;}
            {_oSDiskId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osDiskId"), out var __jsonOSDiskId) ? (string)__jsonOSDiskId : (string)OSDiskId;}
            {_azureVMDiskDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("azureVMDiskDetails"), out var __jsonAzureVMDiskDetails) ? If( __jsonAzureVMDiskDetails as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureVMDiskDetails.FromJson(__p) )) ))() : null : AzureVMDiskDetail;}
            {_recoveryAzureVMName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureVMName"), out var __jsonRecoveryAzureVMName) ? (string)__jsonRecoveryAzureVMName : (string)RecoveryAzureVMName;}
            {_recoveryAzureVMSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureVMSize"), out var __jsonRecoveryAzureVMSize) ? (string)__jsonRecoveryAzureVMSize : (string)RecoveryAzureVMSize;}
            {_recoveryAzureStorageAccount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureStorageAccount"), out var __jsonRecoveryAzureStorageAccount) ? (string)__jsonRecoveryAzureStorageAccount : (string)RecoveryAzureStorageAccount;}
            {_recoveryAzureLogStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureLogStorageAccountId"), out var __jsonRecoveryAzureLogStorageAccountId) ? (string)__jsonRecoveryAzureLogStorageAccountId : (string)RecoveryAzureLogStorageAccountId;}
            {_vMNic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("vmNics"), out var __jsonVMNics) ? If( __jsonVMNics as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetails.FromJson(__k) )) ))() : null : VMNic;}
            {_selectedRecoveryAzureNetworkId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("selectedRecoveryAzureNetworkId"), out var __jsonSelectedRecoveryAzureNetworkId) ? (string)__jsonSelectedRecoveryAzureNetworkId : (string)SelectedRecoveryAzureNetworkId;}
            {_selectedSourceNicId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("selectedSourceNicId"), out var __jsonSelectedSourceNicId) ? (string)__jsonSelectedSourceNicId : (string)SelectedSourceNicId;}
            {_discoveryType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("discoveryType"), out var __jsonDiscoveryType) ? (string)__jsonDiscoveryType : (string)DiscoveryType;}
            {_enableRdpOnTargetOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("enableRdpOnTargetOption"), out var __jsonEnableRdpOnTargetOption) ? (string)__jsonEnableRdpOnTargetOption : (string)EnableRdpOnTargetOption;}
            {_datastore = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("datastores"), out var __jsonDatastores) ? If( __jsonDatastores as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : Datastore;}
            {_targetVMId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetVmId"), out var __jsonTargetVMId) ? (string)__jsonTargetVMId : (string)TargetVMId;}
            {_recoveryAzureResourceGroupId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureResourceGroupId"), out var __jsonRecoveryAzureResourceGroupId) ? (string)__jsonRecoveryAzureResourceGroupId : (string)RecoveryAzureResourceGroupId;}
            {_recoveryAvailabilitySetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAvailabilitySetId"), out var __jsonRecoveryAvailabilitySetId) ? (string)__jsonRecoveryAvailabilitySetId : (string)RecoveryAvailabilitySetId;}
            {_useManagedDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("useManagedDisks"), out var __jsonUseManagedDisks) ? (string)__jsonUseManagedDisks : (string)UseManagedDisk;}
            {_licenseType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("licenseType"), out var __jsonLicenseType) ? (string)__jsonLicenseType : (string)LicenseType;}
            {_validationError = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("validationErrors"), out var __jsonValidationErrors) ? If( __jsonValidationErrors as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError.FromJson(__a) )) ))() : null : ValidationError;}
            {_lastRpoCalculatedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastRpoCalculatedTime"), out var __jsonLastRpoCalculatedTime) ? global::System.DateTime.TryParse((string)__jsonLastRpoCalculatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastRpoCalculatedTimeValue) ? __jsonLastRpoCalculatedTimeValue : LastRpoCalculatedTime : LastRpoCalculatedTime;}
            {_lastUpdateReceivedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastUpdateReceivedTime"), out var __jsonLastUpdateReceivedTime) ? global::System.DateTime.TryParse((string)__jsonLastUpdateReceivedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastUpdateReceivedTimeValue) ? __jsonLastUpdateReceivedTimeValue : LastUpdateReceivedTime : LastUpdateReceivedTime;}
            {_replicaId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("replicaId"), out var __jsonReplicaId) ? (string)__jsonReplicaId : (string)ReplicaId;}
            {_oSVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osVersion"), out var __jsonOSVersion) ? (string)__jsonOSVersion : (string)OSVersion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="InMageAzureV2ReplicationDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="InMageAzureV2ReplicationDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            __replicationProviderSpecificSettings?.ToJson(container, serializationMode);
            AddIf( null != (((object)this._infrastructureVMId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._infrastructureVMId.ToString()) : null, "infrastructureVmId" ,container.Add );
            AddIf( null != (((object)this._vCenterInfrastructureId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vCenterInfrastructureId.ToString()) : null, "vCenterInfrastructureId" ,container.Add );
            AddIf( null != (((object)this._protectionStage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._protectionStage.ToString()) : null, "protectionStage" ,container.Add );
            AddIf( null != (((object)this._vMId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMId.ToString()) : null, "vmId" ,container.Add );
            AddIf( null != (((object)this._vMProtectionState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMProtectionState.ToString()) : null, "vmProtectionState" ,container.Add );
            AddIf( null != (((object)this._vMProtectionStateDescription)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMProtectionStateDescription.ToString()) : null, "vmProtectionStateDescription" ,container.Add );
            AddIf( null != this._resyncProgressPercentage ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._resyncProgressPercentage) : null, "resyncProgressPercentage" ,container.Add );
            AddIf( null != this._rpoInSecond ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._rpoInSecond) : null, "rpoInSeconds" ,container.Add );
            AddIf( null != this._compressedDataRateInMb ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((double)this._compressedDataRateInMb) : null, "compressedDataRateInMB" ,container.Add );
            AddIf( null != this._uncompressedDataRateInMb ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((double)this._uncompressedDataRateInMb) : null, "uncompressedDataRateInMB" ,container.Add );
            AddIf( null != (((object)this._iPAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._iPAddress.ToString()) : null, "ipAddress" ,container.Add );
            AddIf( null != (((object)this._agentVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._agentVersion.ToString()) : null, "agentVersion" ,container.Add );
            AddIf( null != this._agentExpiryDate ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._agentExpiryDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "agentExpiryDate" ,container.Add );
            AddIf( null != (((object)this._isAgentUpdateRequired)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._isAgentUpdateRequired.ToString()) : null, "isAgentUpdateRequired" ,container.Add );
            AddIf( null != (((object)this._isRebootAfterUpdateRequired)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._isRebootAfterUpdateRequired.ToString()) : null, "isRebootAfterUpdateRequired" ,container.Add );
            AddIf( null != this._lastHeartbeat ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastHeartbeat?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastHeartbeat" ,container.Add );
            AddIf( null != (((object)this._processServerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._processServerId.ToString()) : null, "processServerId" ,container.Add );
            AddIf( null != (((object)this._multiVMGroupId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._multiVMGroupId.ToString()) : null, "multiVmGroupId" ,container.Add );
            AddIf( null != (((object)this._multiVMGroupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._multiVMGroupName.ToString()) : null, "multiVmGroupName" ,container.Add );
            AddIf( null != (((object)this._multiVMSyncStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._multiVMSyncStatus.ToString()) : null, "multiVmSyncStatus" ,container.Add );
            if (null != this._protectedDisk)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._protectedDisk )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("protectedDisks",__w);
            }
            AddIf( null != (((object)this._diskResized)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._diskResized.ToString()) : null, "diskResized" ,container.Add );
            AddIf( null != (((object)this._masterTargetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._masterTargetId.ToString()) : null, "masterTargetId" ,container.Add );
            AddIf( null != this._sourceVMCpuCount ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._sourceVMCpuCount) : null, "sourceVmCpuCount" ,container.Add );
            AddIf( null != this._sourceVMRamSizeInMb ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._sourceVMRamSizeInMb) : null, "sourceVmRamSizeInMB" ,container.Add );
            AddIf( null != (((object)this._oSType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSType.ToString()) : null, "osType" ,container.Add );
            AddIf( null != (((object)this._vhdName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vhdName.ToString()) : null, "vhdName" ,container.Add );
            AddIf( null != (((object)this._oSDiskId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSDiskId.ToString()) : null, "osDiskId" ,container.Add );
            if (null != this._azureVMDiskDetail)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __s in this._azureVMDiskDetail )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("azureVMDiskDetails",__r);
            }
            AddIf( null != (((object)this._recoveryAzureVMName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureVMName.ToString()) : null, "recoveryAzureVMName" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureVMSize)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureVMSize.ToString()) : null, "recoveryAzureVMSize" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureStorageAccount)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureStorageAccount.ToString()) : null, "recoveryAzureStorageAccount" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureLogStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureLogStorageAccountId.ToString()) : null, "recoveryAzureLogStorageAccountId" ,container.Add );
            if (null != this._vMNic)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __n in this._vMNic )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("vmNics",__m);
            }
            AddIf( null != (((object)this._selectedRecoveryAzureNetworkId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._selectedRecoveryAzureNetworkId.ToString()) : null, "selectedRecoveryAzureNetworkId" ,container.Add );
            AddIf( null != (((object)this._selectedSourceNicId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._selectedSourceNicId.ToString()) : null, "selectedSourceNicId" ,container.Add );
            AddIf( null != (((object)this._discoveryType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._discoveryType.ToString()) : null, "discoveryType" ,container.Add );
            AddIf( null != (((object)this._enableRdpOnTargetOption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._enableRdpOnTargetOption.ToString()) : null, "enableRdpOnTargetOption" ,container.Add );
            if (null != this._datastore)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __i in this._datastore )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("datastores",__h);
            }
            AddIf( null != (((object)this._targetVMId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetVMId.ToString()) : null, "targetVmId" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureResourceGroupId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureResourceGroupId.ToString()) : null, "recoveryAzureResourceGroupId" ,container.Add );
            AddIf( null != (((object)this._recoveryAvailabilitySetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAvailabilitySetId.ToString()) : null, "recoveryAvailabilitySetId" ,container.Add );
            AddIf( null != (((object)this._useManagedDisk)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._useManagedDisk.ToString()) : null, "useManagedDisks" ,container.Add );
            AddIf( null != (((object)this._licenseType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._licenseType.ToString()) : null, "licenseType" ,container.Add );
            if (null != this._validationError)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __d in this._validationError )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("validationErrors",__c);
            }
            AddIf( null != this._lastRpoCalculatedTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastRpoCalculatedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastRpoCalculatedTime" ,container.Add );
            AddIf( null != this._lastUpdateReceivedTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastUpdateReceivedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastUpdateReceivedTime" ,container.Add );
            AddIf( null != (((object)this._replicaId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._replicaId.ToString()) : null, "replicaId" ,container.Add );
            AddIf( null != (((object)this._oSVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSVersion.ToString()) : null, "osVersion" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}