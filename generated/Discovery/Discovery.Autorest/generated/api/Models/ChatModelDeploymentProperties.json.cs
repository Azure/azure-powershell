// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>
    /// Defines a deployment binding a specific model family to a user-defined deployment name for chat inference.
    /// </summary>
    public partial class ChatModelDeploymentProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject into a new instance of <see cref="ChatModelDeploymentProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ChatModelDeploymentProperties(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)_provisioningState;}
            {_modelFormat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("modelFormat"), out var __jsonModelFormat) ? (string)__jsonModelFormat : (string)_modelFormat;}
            {_modelName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("modelName"), out var __jsonModelName) ? (string)__jsonModelName : (string)_modelName;}
            {_modelVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("modelVersion"), out var __jsonModelVersion) ? (string)__jsonModelVersion : (string)_modelVersion;}
            {_skuName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("skuName"), out var __jsonSkuName) ? (string)__jsonSkuName : (string)_skuName;}
            {_capacity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber>("capacity"), out var __jsonCapacity) ? (int?)__jsonCapacity : _capacity;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IChatModelDeploymentProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json ? new ChatModelDeploymentProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ChatModelDeploymentProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ChatModelDeploymentProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._modelFormat)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._modelFormat.ToString()) : null, "modelFormat" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._modelName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._modelName.ToString()) : null, "modelName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._modelVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._modelVersion.ToString()) : null, "modelVersion" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._skuName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._skuName.ToString()) : null, "skuName" ,container.Add );
            }
            AddIf( null != this._capacity ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber((int)this._capacity) : null, "capacity" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}