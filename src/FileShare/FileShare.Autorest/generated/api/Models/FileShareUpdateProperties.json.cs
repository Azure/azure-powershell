// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The updatable properties of the FileShare.</summary>
    public partial class FileShareUpdateProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject into a new instance of <see cref="FileShareUpdateProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal FileShareUpdateProperties(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_nfsProtocolProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject>("nfsProtocolProperties"), out var __jsonNfsProtocolProperties) ? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolProperties.FromJson(__jsonNfsProtocolProperties) : _nfsProtocolProperty;}
            {_publicAccessProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject>("publicAccessProperties"), out var __jsonPublicAccessProperties) ? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessProperties.FromJson(__jsonPublicAccessProperties) : _publicAccessProperty;}
            {_provisionedStorageGiB = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("provisionedStorageGiB"), out var __jsonProvisionedStorageGiB) ? (int?)__jsonProvisionedStorageGiB : _provisionedStorageGiB;}
            {_provisionedIoPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("provisionedIOPerSec"), out var __jsonProvisionedIoPerSec) ? (int?)__jsonProvisionedIoPerSec : _provisionedIoPerSec;}
            {_provisionedThroughputMiBPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("provisionedThroughputMiBPerSec"), out var __jsonProvisionedThroughputMiBPerSec) ? (int?)__jsonProvisionedThroughputMiBPerSec : _provisionedThroughputMiBPerSec;}
            {_publicNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("publicNetworkAccess"), out var __jsonPublicNetworkAccess) ? (string)__jsonPublicNetworkAccess : (string)_publicNetworkAccess;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json ? new FileShareUpdateProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="FileShareUpdateProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="FileShareUpdateProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._nfsProtocolProperty ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) this._nfsProtocolProperty.ToJson(null,serializationMode) : null, "nfsProtocolProperties" ,container.Add );
            AddIf( null != this._publicAccessProperty ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) this._publicAccessProperty.ToJson(null,serializationMode) : null, "publicAccessProperties" ,container.Add );
            AddIf( null != this._provisionedStorageGiB ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._provisionedStorageGiB) : null, "provisionedStorageGiB" ,container.Add );
            AddIf( null != this._provisionedIoPerSec ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._provisionedIoPerSec) : null, "provisionedIOPerSec" ,container.Add );
            AddIf( null != this._provisionedThroughputMiBPerSec ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._provisionedThroughputMiBPerSec) : null, "provisionedThroughputMiBPerSec" ,container.Add );
            AddIf( null != (((object)this._publicNetworkAccess)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._publicNetworkAccess.ToString()) : null, "publicNetworkAccess" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}