namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// LinuxConfiguration - linux specific configuration values for the virtual machine
    /// </summary>
    public partial class VirtualMachinePropertiesOSProfileLinuxConfiguration
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json ? new VirtualMachinePropertiesOSProfileLinuxConfiguration(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VirtualMachinePropertiesOSProfileLinuxConfiguration" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VirtualMachinePropertiesOSProfileLinuxConfiguration" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"
        /// />.
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
            AddIf( null != this._ssh ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._ssh.ToJson(null,serializationMode) : null, "ssh" ,container.Add );
            AddIf( null != this._disablePasswordAuthentication ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonBoolean((bool)this._disablePasswordAuthentication) : null, "disablePasswordAuthentication" ,container.Add );
            AddIf( null != this._provisionVMAgent ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonBoolean((bool)this._provisionVMAgent) : null, "provisionVMAgent" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject into a new instance of <see cref="VirtualMachinePropertiesOSProfileLinuxConfiguration"
        /// />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VirtualMachinePropertiesOSProfileLinuxConfiguration(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_ssh = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("ssh"), out var __jsonSsh) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSsh.FromJson(__jsonSsh) : Ssh;}
            {_disablePasswordAuthentication = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonBoolean>("disablePasswordAuthentication"), out var __jsonDisablePasswordAuthentication) ? (bool?)__jsonDisablePasswordAuthentication : DisablePasswordAuthentication;}
            {_provisionVMAgent = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonBoolean>("provisionVMAgent"), out var __jsonProvisionVMAgent) ? (bool?)__jsonProvisionVMAgent : ProvisionVMAgent;}
            AfterFromJson(json);
        }
    }
}