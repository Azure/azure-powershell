// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File share properties</summary>
    public partial class FileShareProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject into a new instance of <see cref="FileShareProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal FileShareProperties(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_nfsProtocolProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject>("nfsProtocolProperties"), out var __jsonNfsProtocolProperties) ? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolProperties.FromJson(__jsonNfsProtocolProperties) : _nfsProtocolProperty;}
            {_publicAccessProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject>("publicAccessProperties"), out var __jsonPublicAccessProperties) ? Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessProperties.FromJson(__jsonPublicAccessProperties) : _publicAccessProperty;}
            {_mountName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("mountName"), out var __jsonMountName) ? (string)__jsonMountName : (string)_mountName;}
            {_hostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("hostName"), out var __jsonHostName) ? (string)__jsonHostName : (string)_hostName;}
            {_mediaTier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("mediaTier"), out var __jsonMediaTier) ? (string)__jsonMediaTier : (string)_mediaTier;}
            {_redundancy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("redundancy"), out var __jsonRedundancy) ? (string)__jsonRedundancy : (string)_redundancy;}
            {_protocol = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("protocol"), out var __jsonProtocol) ? (string)__jsonProtocol : (string)_protocol;}
            {_provisionedStorageGiB = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("provisionedStorageGiB"), out var __jsonProvisionedStorageGiB) ? (int?)__jsonProvisionedStorageGiB : _provisionedStorageGiB;}
            {_provisionedStorageNextAllowedDowngrade = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("provisionedStorageNextAllowedDowngrade"), out var __jsonProvisionedStorageNextAllowedDowngrade) ? global::System.DateTime.TryParse((string)__jsonProvisionedStorageNextAllowedDowngrade, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonProvisionedStorageNextAllowedDowngradeValue) ? __jsonProvisionedStorageNextAllowedDowngradeValue : _provisionedStorageNextAllowedDowngrade : _provisionedStorageNextAllowedDowngrade;}
            {_provisionedIoPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("provisionedIOPerSec"), out var __jsonProvisionedIoPerSec) ? (int?)__jsonProvisionedIoPerSec : _provisionedIoPerSec;}
            {_provisionedIoPerSecNextAllowedDowngrade = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("provisionedIOPerSecNextAllowedDowngrade"), out var __jsonProvisionedIoPerSecNextAllowedDowngrade) ? global::System.DateTime.TryParse((string)__jsonProvisionedIoPerSecNextAllowedDowngrade, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonProvisionedIoPerSecNextAllowedDowngradeValue) ? __jsonProvisionedIoPerSecNextAllowedDowngradeValue : _provisionedIoPerSecNextAllowedDowngrade : _provisionedIoPerSecNextAllowedDowngrade;}
            {_provisionedThroughputMiBPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("provisionedThroughputMiBPerSec"), out var __jsonProvisionedThroughputMiBPerSec) ? (int?)__jsonProvisionedThroughputMiBPerSec : _provisionedThroughputMiBPerSec;}
            {_provisionedThroughputNextAllowedDowngrade = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("provisionedThroughputNextAllowedDowngrade"), out var __jsonProvisionedThroughputNextAllowedDowngrade) ? global::System.DateTime.TryParse((string)__jsonProvisionedThroughputNextAllowedDowngrade, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonProvisionedThroughputNextAllowedDowngradeValue) ? __jsonProvisionedThroughputNextAllowedDowngradeValue : _provisionedThroughputNextAllowedDowngrade : _provisionedThroughputNextAllowedDowngrade;}
            {_includedBurstIoPerSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("includedBurstIOPerSec"), out var __jsonIncludedBurstIoPerSec) ? (int?)__jsonIncludedBurstIoPerSec : _includedBurstIoPerSec;}
            {_maxBurstIoPerSecCredit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber>("maxBurstIOPerSecCredits"), out var __jsonMaxBurstIoPerSecCredits) ? (long?)__jsonMaxBurstIoPerSecCredits : _maxBurstIoPerSecCredit;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)_provisioningState;}
            {_publicNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString>("publicNetworkAccess"), out var __jsonPublicNetworkAccess) ? (string)__jsonPublicNetworkAccess : (string)_publicNetworkAccess;}
            {_privateEndpointConnection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonArray>("privateEndpointConnections"), out var __jsonPrivateEndpointConnections) ? If( __jsonPrivateEndpointConnections as Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection) (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PrivateEndpointConnection.FromJson(__u) )) ))() : null : _privateEndpointConnection;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject json ? new FileShareProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="FileShareProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="FileShareProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._mountName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._mountName.ToString()) : null, "mountName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._hostName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._hostName.ToString()) : null, "hostName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._mediaTier)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._mediaTier.ToString()) : null, "mediaTier" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._redundancy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._redundancy.ToString()) : null, "redundancy" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead)||serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeCreate))
            {
                AddIf( null != (((object)this._protocol)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._protocol.ToString()) : null, "protocol" ,container.Add );
            }
            AddIf( null != this._provisionedStorageGiB ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._provisionedStorageGiB) : null, "provisionedStorageGiB" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._provisionedStorageNextAllowedDowngrade ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._provisionedStorageNextAllowedDowngrade?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "provisionedStorageNextAllowedDowngrade" ,container.Add );
            }
            AddIf( null != this._provisionedIoPerSec ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._provisionedIoPerSec) : null, "provisionedIOPerSec" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._provisionedIoPerSecNextAllowedDowngrade ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._provisionedIoPerSecNextAllowedDowngrade?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "provisionedIOPerSecNextAllowedDowngrade" ,container.Add );
            }
            AddIf( null != this._provisionedThroughputMiBPerSec ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._provisionedThroughputMiBPerSec) : null, "provisionedThroughputMiBPerSec" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._provisionedThroughputNextAllowedDowngrade ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._provisionedThroughputNextAllowedDowngrade?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "provisionedThroughputNextAllowedDowngrade" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._includedBurstIoPerSec ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((int)this._includedBurstIoPerSec) : null, "includedBurstIOPerSec" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._maxBurstIoPerSecCredit ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNumber((long)this._maxBurstIoPerSecCredit) : null, "maxBurstIOPerSecCredits" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._publicNetworkAccess)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonString(this._publicNetworkAccess.ToString()) : null, "publicNetworkAccess" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._privateEndpointConnection)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.XNodeArray();
                    foreach( var __x in this._privateEndpointConnection )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("privateEndpointConnections",__w);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}