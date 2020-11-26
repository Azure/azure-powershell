namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper V Replica Azure provider specific settings.</summary>
    public partial class HyperVReplicaAzureReplicationDetails
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new HyperVReplicaAzureReplicationDetails(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="HyperVReplicaAzureReplicationDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HyperVReplicaAzureReplicationDetails(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __replicationProviderSpecificSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings(json);
            {_initialReplicationDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("initialReplicationDetails"), out var __jsonInitialReplicationDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetails.FromJson(__jsonInitialReplicationDetails) : InitialReplicationDetail;}
            {_oSDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("oSDetails"), out var __jsonOSDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails.FromJson(__jsonOSDetails) : OSDetail;}
            {_azureVMDiskDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("azureVmDiskDetails"), out var __jsonAzureVMDiskDetails) ? If( __jsonAzureVMDiskDetails as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureVMDiskDetails.FromJson(__u) )) ))() : null : AzureVMDiskDetail;}
            {_recoveryAzureVMName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureVmName"), out var __jsonRecoveryAzureVMName) ? (string)__jsonRecoveryAzureVMName : (string)RecoveryAzureVMName;}
            {_recoveryAzureVMSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureVMSize"), out var __jsonRecoveryAzureVMSize) ? (string)__jsonRecoveryAzureVMSize : (string)RecoveryAzureVMSize;}
            {_recoveryAzureStorageAccount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureStorageAccount"), out var __jsonRecoveryAzureStorageAccount) ? (string)__jsonRecoveryAzureStorageAccount : (string)RecoveryAzureStorageAccount;}
            {_recoveryAzureLogStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureLogStorageAccountId"), out var __jsonRecoveryAzureLogStorageAccountId) ? (string)__jsonRecoveryAzureLogStorageAccountId : (string)RecoveryAzureLogStorageAccountId;}
            {_lastReplicatedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastReplicatedTime"), out var __jsonLastReplicatedTime) ? global::System.DateTime.TryParse((string)__jsonLastReplicatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastReplicatedTimeValue) ? __jsonLastReplicatedTimeValue : LastReplicatedTime : LastReplicatedTime;}
            {_rpoInSecond = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("rpoInSeconds"), out var __jsonRpoInSeconds) ? (long?)__jsonRpoInSeconds : RpoInSecond;}
            {_lastRpoCalculatedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastRpoCalculatedTime"), out var __jsonLastRpoCalculatedTime) ? global::System.DateTime.TryParse((string)__jsonLastRpoCalculatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastRpoCalculatedTimeValue) ? __jsonLastRpoCalculatedTimeValue : LastRpoCalculatedTime : LastRpoCalculatedTime;}
            {_vMId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmId"), out var __jsonVMId) ? (string)__jsonVMId : (string)VMId;}
            {_vMProtectionState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmProtectionState"), out var __jsonVMProtectionState) ? (string)__jsonVMProtectionState : (string)VMProtectionState;}
            {_vMProtectionStateDescription = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmProtectionStateDescription"), out var __jsonVMProtectionStateDescription) ? (string)__jsonVMProtectionStateDescription : (string)VMProtectionStateDescription;}
            {_vMNic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("vmNics"), out var __jsonVMNics) ? If( __jsonVMNics as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetails.FromJson(__p) )) ))() : null : VMNic;}
            {_selectedRecoveryAzureNetworkId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("selectedRecoveryAzureNetworkId"), out var __jsonSelectedRecoveryAzureNetworkId) ? (string)__jsonSelectedRecoveryAzureNetworkId : (string)SelectedRecoveryAzureNetworkId;}
            {_selectedSourceNicId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("selectedSourceNicId"), out var __jsonSelectedSourceNicId) ? (string)__jsonSelectedSourceNicId : (string)SelectedSourceNicId;}
            {_encryption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("encryption"), out var __jsonEncryption) ? (string)__jsonEncryption : (string)Encryption;}
            {_sourceVMRamSizeInMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("sourceVmRamSizeInMB"), out var __jsonSourceVMRamSizeInMb) ? (int?)__jsonSourceVMRamSizeInMb : SourceVMRamSizeInMb;}
            {_sourceVMCpuCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("sourceVmCpuCount"), out var __jsonSourceVMCpuCount) ? (int?)__jsonSourceVMCpuCount : SourceVMCpuCount;}
            {_enableRdpOnTargetOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("enableRdpOnTargetOption"), out var __jsonEnableRdpOnTargetOption) ? (string)__jsonEnableRdpOnTargetOption : (string)EnableRdpOnTargetOption;}
            {_recoveryAzureResourceGroupId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAzureResourceGroupId"), out var __jsonRecoveryAzureResourceGroupId) ? (string)__jsonRecoveryAzureResourceGroupId : (string)RecoveryAzureResourceGroupId;}
            {_recoveryAvailabilitySetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryAvailabilitySetId"), out var __jsonRecoveryAvailabilitySetId) ? (string)__jsonRecoveryAvailabilitySetId : (string)RecoveryAvailabilitySetId;}
            {_useManagedDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("useManagedDisks"), out var __jsonUseManagedDisks) ? (string)__jsonUseManagedDisks : (string)UseManagedDisk;}
            {_licenseType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("licenseType"), out var __jsonLicenseType) ? (string)__jsonLicenseType : (string)LicenseType;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HyperVReplicaAzureReplicationDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HyperVReplicaAzureReplicationDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._initialReplicationDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._initialReplicationDetail.ToJson(null,serializationMode) : null, "initialReplicationDetails" ,container.Add );
            AddIf( null != this._oSDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._oSDetail.ToJson(null,serializationMode) : null, "oSDetails" ,container.Add );
            if (null != this._azureVMDiskDetail)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._azureVMDiskDetail )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("azureVmDiskDetails",__w);
            }
            AddIf( null != (((object)this._recoveryAzureVMName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureVMName.ToString()) : null, "recoveryAzureVmName" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureVMSize)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureVMSize.ToString()) : null, "recoveryAzureVMSize" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureStorageAccount)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureStorageAccount.ToString()) : null, "recoveryAzureStorageAccount" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureLogStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureLogStorageAccountId.ToString()) : null, "recoveryAzureLogStorageAccountId" ,container.Add );
            AddIf( null != this._lastReplicatedTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastReplicatedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastReplicatedTime" ,container.Add );
            AddIf( null != this._rpoInSecond ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._rpoInSecond) : null, "rpoInSeconds" ,container.Add );
            AddIf( null != this._lastRpoCalculatedTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastRpoCalculatedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastRpoCalculatedTime" ,container.Add );
            AddIf( null != (((object)this._vMId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMId.ToString()) : null, "vmId" ,container.Add );
            AddIf( null != (((object)this._vMProtectionState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMProtectionState.ToString()) : null, "vmProtectionState" ,container.Add );
            AddIf( null != (((object)this._vMProtectionStateDescription)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMProtectionStateDescription.ToString()) : null, "vmProtectionStateDescription" ,container.Add );
            if (null != this._vMNic)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __s in this._vMNic )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("vmNics",__r);
            }
            AddIf( null != (((object)this._selectedRecoveryAzureNetworkId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._selectedRecoveryAzureNetworkId.ToString()) : null, "selectedRecoveryAzureNetworkId" ,container.Add );
            AddIf( null != (((object)this._selectedSourceNicId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._selectedSourceNicId.ToString()) : null, "selectedSourceNicId" ,container.Add );
            AddIf( null != (((object)this._encryption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._encryption.ToString()) : null, "encryption" ,container.Add );
            AddIf( null != this._sourceVMRamSizeInMb ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._sourceVMRamSizeInMb) : null, "sourceVmRamSizeInMB" ,container.Add );
            AddIf( null != this._sourceVMCpuCount ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._sourceVMCpuCount) : null, "sourceVmCpuCount" ,container.Add );
            AddIf( null != (((object)this._enableRdpOnTargetOption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._enableRdpOnTargetOption.ToString()) : null, "enableRdpOnTargetOption" ,container.Add );
            AddIf( null != (((object)this._recoveryAzureResourceGroupId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAzureResourceGroupId.ToString()) : null, "recoveryAzureResourceGroupId" ,container.Add );
            AddIf( null != (((object)this._recoveryAvailabilitySetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryAvailabilitySetId.ToString()) : null, "recoveryAvailabilitySetId" ,container.Add );
            AddIf( null != (((object)this._useManagedDisk)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._useManagedDisk.ToString()) : null, "useManagedDisks" ,container.Add );
            AddIf( null != (((object)this._licenseType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._licenseType.ToString()) : null, "licenseType" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}