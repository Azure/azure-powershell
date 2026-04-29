// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share-related limits in the specified subscription/location.</summary>
    public partial class FileShareLimits
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject into a new instance of <see cref="FileShareLimits" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal FileShareLimits(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_maxFileShare = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxFileShares"), out var __jsonMaxFileShares) ? (int)__jsonMaxFileShares : _maxFileShare;}
            {_maxFileShareSnapshot = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxFileShareSnapshots"), out var __jsonMaxFileShareSnapshots) ? (int)__jsonMaxFileShareSnapshots : _maxFileShareSnapshot;}
            {_maxFileShareSubnet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxFileShareSubnets"), out var __jsonMaxFileShareSubnets) ? (int)__jsonMaxFileShareSubnets : _maxFileShareSubnet;}
            {_maxFileSharePrivateEndpointConnection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxFileSharePrivateEndpointConnections"), out var __jsonMaxFileSharePrivateEndpointConnections) ? (int)__jsonMaxFileSharePrivateEndpointConnections : _maxFileSharePrivateEndpointConnection;}
            {_minProvisionedStorageGiB = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("minProvisionedStorageGiB"), out var __jsonMinProvisionedStorageGiB) ? (int)__jsonMinProvisionedStorageGiB : _minProvisionedStorageGiB;}
            {_maxProvisionedStorageGiB = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxProvisionedStorageGiB"), out var __jsonMaxProvisionedStorageGiB) ? (int)__jsonMaxProvisionedStorageGiB : _maxProvisionedStorageGiB;}
            {_minProvisionedIoPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("minProvisionedIOPerSec"), out var __jsonMinProvisionedIoPerSec) ? (int)__jsonMinProvisionedIoPerSec : _minProvisionedIoPerSec;}
            {_maxProvisionedIoPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxProvisionedIOPerSec"), out var __jsonMaxProvisionedIoPerSec) ? (int)__jsonMaxProvisionedIoPerSec : _maxProvisionedIoPerSec;}
            {_minProvisionedThroughputMiBPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("minProvisionedThroughputMiBPerSec"), out var __jsonMinProvisionedThroughputMiBPerSec) ? (int)__jsonMinProvisionedThroughputMiBPerSec : _minProvisionedThroughputMiBPerSec;}
            {_maxProvisionedThroughputMiBPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxProvisionedThroughputMiBPerSec"), out var __jsonMaxProvisionedThroughputMiBPerSec) ? (int)__jsonMaxProvisionedThroughputMiBPerSec : _maxProvisionedThroughputMiBPerSec;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json ? new FileShareLimits(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="FileShareLimits" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="FileShareLimits" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxFileShare), "maxFileShares" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxFileShareSnapshot), "maxFileShareSnapshots" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxFileShareSubnet), "maxFileShareSubnets" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxFileSharePrivateEndpointConnection), "maxFileSharePrivateEndpointConnections" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._minProvisionedStorageGiB), "minProvisionedStorageGiB" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxProvisionedStorageGiB), "maxProvisionedStorageGiB" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._minProvisionedIoPerSec), "minProvisionedIOPerSec" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxProvisionedIoPerSec), "maxProvisionedIOPerSec" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._minProvisionedThroughputMiBPerSec), "minProvisionedThroughputMiBPerSec" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber(this._maxProvisionedThroughputMiBPerSec), "maxProvisionedThroughputMiBPerSec" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}