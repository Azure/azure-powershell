namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// StorageProfile - contains information about the disks and storage information for the virtual machine
    /// </summary>
    public partial class VirtualMachinePropertiesStorageProfile
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json ? new VirtualMachinePropertiesStorageProfile(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VirtualMachinePropertiesStorageProfile" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VirtualMachinePropertiesStorageProfile" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._imageReference ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._imageReference.ToJson(null,serializationMode) : null, "imageReference" ,container.Add );
            AddIf( null != this._oSDisk ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._oSDisk.ToJson(null,serializationMode) : null, "osDisk" ,container.Add );
            if (null != this._dataDisk)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.XNodeArray();
                foreach( var __x in this._dataDisk )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("dataDisks",__w);
            }
            AddIf( null != (((object)this._vMConfigStoragePathId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._vMConfigStoragePathId.ToString()) : null, "vmConfigStoragePathId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject into a new instance of <see cref="VirtualMachinePropertiesStorageProfile" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VirtualMachinePropertiesStorageProfile(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_imageReference = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("imageReference"), out var __jsonImageReference) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileImageReference.FromJson(__jsonImageReference) : ImageReference;}
            {_oSDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("osDisk"), out var __jsonOSDisk) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileOSDisk.FromJson(__jsonOSDisk) : OSDisk;}
            {_dataDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonArray>("dataDisks"), out var __jsonDataDisks) ? If( __jsonDataDisks as Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem) (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfileDataDisksItem.FromJson(__u) )) ))() : null : DataDisk;}
            {_vMConfigStoragePathId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("vmConfigStoragePathId"), out var __jsonVMConfigStoragePathId) ? (string)__jsonVMConfigStoragePathId : (string)VMConfigStoragePathId;}
            AfterFromJson(json);
        }
    }
}