namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Properties under the virtual hard disk resource</summary>
    public partial class VirtualHardDiskProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDiskProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json ? new VirtualHardDiskProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VirtualHardDiskProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VirtualHardDiskProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._status ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._status.ToJson(null,serializationMode) : null, "status" ,container.Add );
            }
            AddIf( null != this._blockSizeByte ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber((int)this._blockSizeByte) : null, "blockSizeBytes" ,container.Add );
            AddIf( null != this._diskSizeGb ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber((long)this._diskSizeGb) : null, "diskSizeGB" ,container.Add );
            AddIf( null != this._dynamic ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonBoolean((bool)this._dynamic) : null, "dynamic" ,container.Add );
            AddIf( null != this._logicalSectorByte ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber((int)this._logicalSectorByte) : null, "logicalSectorBytes" ,container.Add );
            AddIf( null != this._physicalSectorByte ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber((int)this._physicalSectorByte) : null, "physicalSectorBytes" ,container.Add );
            AddIf( null != (((object)this._hyperVGeneration)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._hyperVGeneration.ToString()) : null, "hyperVGeneration" ,container.Add );
            AddIf( null != (((object)this._diskFileFormat)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._diskFileFormat.ToString()) : null, "diskFileFormat" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._containerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._containerId.ToString()) : null, "containerId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject into a new instance of <see cref="VirtualHardDiskProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VirtualHardDiskProperties(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("status"), out var __jsonStatus) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualHardDiskStatus.FromJson(__jsonStatus) : Status;}
            {_blockSizeByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber>("blockSizeBytes"), out var __jsonBlockSizeBytes) ? (int?)__jsonBlockSizeBytes : BlockSizeByte;}
            {_diskSizeGb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber>("diskSizeGB"), out var __jsonDiskSizeGb) ? (long?)__jsonDiskSizeGb : DiskSizeGb;}
            {_dynamic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonBoolean>("dynamic"), out var __jsonDynamic) ? (bool?)__jsonDynamic : Dynamic;}
            {_logicalSectorByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber>("logicalSectorBytes"), out var __jsonLogicalSectorBytes) ? (int?)__jsonLogicalSectorBytes : LogicalSectorByte;}
            {_physicalSectorByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNumber>("physicalSectorBytes"), out var __jsonPhysicalSectorBytes) ? (int?)__jsonPhysicalSectorBytes : PhysicalSectorByte;}
            {_hyperVGeneration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("hyperVGeneration"), out var __jsonHyperVGeneration) ? (string)__jsonHyperVGeneration : (string)HyperVGeneration;}
            {_diskFileFormat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("diskFileFormat"), out var __jsonDiskFileFormat) ? (string)__jsonDiskFileFormat : (string)DiskFileFormat;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_containerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("containerId"), out var __jsonContainerId) ? (string)__jsonContainerId : (string)ContainerId;}
            AfterFromJson(json);
        }
    }
}