// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The hardware setting properties</summary>
    public partial class HardwareSettingProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json ? new HardwareSettingProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject into a new instance of <see cref="HardwareSettingProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HardwareSettingProperties(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)_provisioningState;}
            {_totalCore = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber>("totalCores"), out var __jsonTotalCores) ? (int)__jsonTotalCores : _totalCore;}
            {_diskSpaceInGb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber>("diskSpaceInGb"), out var __jsonDiskSpaceInGb) ? (int)__jsonDiskSpaceInGb : _diskSpaceInGb;}
            {_memoryInGb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber>("memoryInGb"), out var __jsonMemoryInGb) ? (int)__jsonMemoryInGb : _memoryInGb;}
            {_oem = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("oem"), out var __jsonOem) ? (string)__jsonOem : (string)_oem;}
            {_hardwareSku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("hardwareSku"), out var __jsonHardwareSku) ? (string)__jsonHardwareSku : (string)_hardwareSku;}
            {_node = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber>("nodes"), out var __jsonNodes) ? (int)__jsonNodes : _node;}
            {_versionAtRegistration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("versionAtRegistration"), out var __jsonVersionAtRegistration) ? (string)__jsonVersionAtRegistration : (string)_versionAtRegistration;}
            {_solutionBuilderExtension = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("solutionBuilderExtension"), out var __jsonSolutionBuilderExtension) ? (string)__jsonSolutionBuilderExtension : (string)_solutionBuilderExtension;}
            {_deviceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("deviceId"), out var __jsonDeviceId) ? (string)__jsonDeviceId : (string)_deviceId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HardwareSettingProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HardwareSettingProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber(this._totalCore), "totalCores" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber(this._diskSpaceInGb), "diskSpaceInGb" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber(this._memoryInGb), "memoryInGb" ,container.Add );
            AddIf( null != (((object)this._oem)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._oem.ToString()) : null, "oem" ,container.Add );
            AddIf( null != (((object)this._hardwareSku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._hardwareSku.ToString()) : null, "hardwareSku" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber(this._node), "nodes" ,container.Add );
            AddIf( null != (((object)this._versionAtRegistration)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._versionAtRegistration.ToString()) : null, "versionAtRegistration" ,container.Add );
            AddIf( null != (((object)this._solutionBuilderExtension)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._solutionBuilderExtension.ToString()) : null, "solutionBuilderExtension" ,container.Add );
            AddIf( null != (((object)this._deviceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._deviceId.ToString()) : null, "deviceId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}