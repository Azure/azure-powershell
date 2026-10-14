// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>NodePool properties</summary>
    public partial class NodePoolProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.INodePoolProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json ? new NodePoolProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject into a new instance of <see cref="NodePoolProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal NodePoolProperties(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)_provisioningState;}
            {_subnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("subnetId"), out var __jsonSubnetId) ? (string)__jsonSubnetId : (string)_subnetId;}
            {_vMSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("vmSize"), out var __jsonVMSize) ? (string)__jsonVMSize : (string)_vMSize;}
            {_maxNodeCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber>("maxNodeCount"), out var __jsonMaxNodeCount) ? (int)__jsonMaxNodeCount : _maxNodeCount;}
            {_minNodeCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber>("minNodeCount"), out var __jsonMinNodeCount) ? (int?)__jsonMinNodeCount : _minNodeCount;}
            {_scaleSetPriority = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("scaleSetPriority"), out var __jsonScaleSetPriority) ? (string)__jsonScaleSetPriority : (string)_scaleSetPriority;}
            {_oSDiskSizeGb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber>("osDiskSizeGb"), out var __jsonOSDiskSizeGb) ? (int?)__jsonOSDiskSizeGb : _oSDiskSizeGb;}
            {_imageCacheLowerThreshold = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber>("imageCacheLowerThreshold"), out var __jsonImageCacheLowerThreshold) ? (int?)__jsonImageCacheLowerThreshold : _imageCacheLowerThreshold;}
            {_imageCacheUpperThreshold = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber>("imageCacheUpperThreshold"), out var __jsonImageCacheUpperThreshold) ? (int?)__jsonImageCacheUpperThreshold : _imageCacheUpperThreshold;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="NodePoolProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NodePoolProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
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
                AddIf( null != (((object)this._subnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._subnetId.ToString()) : null, "subnetId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._vMSize)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._vMSize.ToString()) : null, "vmSize" ,container.Add );
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber(this._maxNodeCount), "maxNodeCount" ,container.Add );
            AddIf( null != this._minNodeCount ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber((int)this._minNodeCount) : null, "minNodeCount" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._scaleSetPriority)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._scaleSetPriority.ToString()) : null, "scaleSetPriority" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != this._oSDiskSizeGb ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber((int)this._oSDiskSizeGb) : null, "osDiskSizeGb" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != this._imageCacheLowerThreshold ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber((int)this._imageCacheLowerThreshold) : null, "imageCacheLowerThreshold" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != this._imageCacheUpperThreshold ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNumber((int)this._imageCacheUpperThreshold) : null, "imageCacheUpperThreshold" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}