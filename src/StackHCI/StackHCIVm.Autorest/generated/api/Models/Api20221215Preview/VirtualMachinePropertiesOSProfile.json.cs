namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// OsProfile - describes the configuration of the operating system and sets login data
    /// </summary>
    public partial class VirtualMachinePropertiesOSProfile
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json ? new VirtualMachinePropertiesOSProfile(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VirtualMachinePropertiesOSProfile" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VirtualMachinePropertiesOSProfile" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._linuxConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._linuxConfiguration.ToJson(null,serializationMode) : null, "linuxConfiguration" ,container.Add );
            AddIf( null != this._windowsConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._windowsConfiguration.ToJson(null,serializationMode) : null, "windowsConfiguration" ,container.Add );
            AddIf( null != (((object)this._adminPassword)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._adminPassword.ToString()) : null, "adminPassword" ,container.Add );
            AddIf( null != (((object)this._adminUsername)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._adminUsername.ToString()) : null, "adminUsername" ,container.Add );
            AddIf( null != (((object)this._computerName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._computerName.ToString()) : null, "computerName" ,container.Add );
            AddIf( null != (((object)this._oSType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._oSType.ToString()) : null, "osType" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject into a new instance of <see cref="VirtualMachinePropertiesOSProfile" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VirtualMachinePropertiesOSProfile(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_linuxConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("linuxConfiguration"), out var __jsonLinuxConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfiguration.FromJson(__jsonLinuxConfiguration) : LinuxConfiguration;}
            {_windowsConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("windowsConfiguration"), out var __jsonWindowsConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfiguration.FromJson(__jsonWindowsConfiguration) : WindowsConfiguration;}
            {_adminPassword = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("adminPassword"), out var __jsonAdminPassword) ? (string)__jsonAdminPassword : (string)AdminPassword;}
            {_adminUsername = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("adminUsername"), out var __jsonAdminUsername) ? (string)__jsonAdminUsername : (string)AdminUsername;}
            {_computerName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("computerName"), out var __jsonComputerName) ? (string)__jsonComputerName : (string)ComputerName;}
            {_oSType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("osType"), out var __jsonOSType) ? (string)__jsonOSType : (string)OSType;}
            AfterFromJson(json);
        }
    }
}