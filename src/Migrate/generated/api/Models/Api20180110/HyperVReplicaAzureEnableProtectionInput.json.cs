namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure specific enable protection input.</summary>
    public partial class HyperVReplicaAzureEnableProtectionInput
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new HyperVReplicaAzureEnableProtectionInput(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="HyperVReplicaAzureEnableProtectionInput" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HyperVReplicaAzureEnableProtectionInput(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __enableProtectionProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionProviderSpecificInput(json);
            {_hvHostVMId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("hvHostVmId"), out var __jsonHvHostVMId) ? (string)__jsonHvHostVMId : (string)HvHostVMId;}
            {_vMName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vmName"), out var __jsonVMName) ? (string)__jsonVMName : (string)VMName;}
            {_oSType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osType"), out var __jsonOSType) ? (string)__jsonOSType : (string)OSType;}
            {_vhdId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("vhdId"), out var __jsonVhdId) ? (string)__jsonVhdId : (string)VhdId;}
            {_targetStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetStorageAccountId"), out var __jsonTargetStorageAccountId) ? (string)__jsonTargetStorageAccountId : (string)TargetStorageAccountId;}
            {_targetAzureNetworkId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetAzureNetworkId"), out var __jsonTargetAzureNetworkId) ? (string)__jsonTargetAzureNetworkId : (string)TargetAzureNetworkId;}
            {_targetAzureSubnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetAzureSubnetId"), out var __jsonTargetAzureSubnetId) ? (string)__jsonTargetAzureSubnetId : (string)TargetAzureSubnetId;}
            {_enableRdpOnTargetOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("enableRdpOnTargetOption"), out var __jsonEnableRdpOnTargetOption) ? (string)__jsonEnableRdpOnTargetOption : (string)EnableRdpOnTargetOption;}
            {_targetAzureVMName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetAzureVmName"), out var __jsonTargetAzureVMName) ? (string)__jsonTargetAzureVMName : (string)TargetAzureVMName;}
            {_logStorageAccountId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("logStorageAccountId"), out var __jsonLogStorageAccountId) ? (string)__jsonLogStorageAccountId : (string)LogStorageAccountId;}
            {_disksToInclude = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("disksToInclude"), out var __jsonDisksToInclude) ? If( __jsonDisksToInclude as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : DisksToInclude;}
            {_targetAzureV1ResourceGroupId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetAzureV1ResourceGroupId"), out var __jsonTargetAzureV1ResourceGroupId) ? (string)__jsonTargetAzureV1ResourceGroupId : (string)TargetAzureV1ResourceGroupId;}
            {_targetAzureV2ResourceGroupId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("targetAzureV2ResourceGroupId"), out var __jsonTargetAzureV2ResourceGroupId) ? (string)__jsonTargetAzureV2ResourceGroupId : (string)TargetAzureV2ResourceGroupId;}
            {_useManagedDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("useManagedDisks"), out var __jsonUseManagedDisks) ? (string)__jsonUseManagedDisks : (string)UseManagedDisk;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HyperVReplicaAzureEnableProtectionInput" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HyperVReplicaAzureEnableProtectionInput" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
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
            __enableProtectionProviderSpecificInput?.ToJson(container, serializationMode);
            AddIf( null != (((object)this._hvHostVMId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._hvHostVMId.ToString()) : null, "hvHostVmId" ,container.Add );
            AddIf( null != (((object)this._vMName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vMName.ToString()) : null, "vmName" ,container.Add );
            AddIf( null != (((object)this._oSType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSType.ToString()) : null, "osType" ,container.Add );
            AddIf( null != (((object)this._vhdId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._vhdId.ToString()) : null, "vhdId" ,container.Add );
            AddIf( null != (((object)this._targetStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetStorageAccountId.ToString()) : null, "targetStorageAccountId" ,container.Add );
            AddIf( null != (((object)this._targetAzureNetworkId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetAzureNetworkId.ToString()) : null, "targetAzureNetworkId" ,container.Add );
            AddIf( null != (((object)this._targetAzureSubnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetAzureSubnetId.ToString()) : null, "targetAzureSubnetId" ,container.Add );
            AddIf( null != (((object)this._enableRdpOnTargetOption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._enableRdpOnTargetOption.ToString()) : null, "enableRdpOnTargetOption" ,container.Add );
            AddIf( null != (((object)this._targetAzureVMName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetAzureVMName.ToString()) : null, "targetAzureVmName" ,container.Add );
            AddIf( null != (((object)this._logStorageAccountId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._logStorageAccountId.ToString()) : null, "logStorageAccountId" ,container.Add );
            if (null != this._disksToInclude)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._disksToInclude )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("disksToInclude",__w);
            }
            AddIf( null != (((object)this._targetAzureV1ResourceGroupId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetAzureV1ResourceGroupId.ToString()) : null, "targetAzureV1ResourceGroupId" ,container.Add );
            AddIf( null != (((object)this._targetAzureV2ResourceGroupId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._targetAzureV2ResourceGroupId.ToString()) : null, "targetAzureV2ResourceGroupId" ,container.Add );
            AddIf( null != (((object)this._useManagedDisk)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._useManagedDisk.ToString()) : null, "useManagedDisks" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}