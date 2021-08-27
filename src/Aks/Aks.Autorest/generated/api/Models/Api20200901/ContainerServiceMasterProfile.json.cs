namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile for the container service master.</summary>
    public partial class ContainerServiceMasterProfile
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject into a new instance of <see cref="ContainerServiceMasterProfile" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ContainerServiceMasterProfile(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_count = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNumber>("count"), out var __jsonCount) ? (int?)__jsonCount : Count;}
            {_dnsPrefix = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("dnsPrefix"), out var __jsonDnsPrefix) ? (string)__jsonDnsPrefix : (string)DnsPrefix;}
            {_vMSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("vmSize"), out var __jsonVMSize) ? (string)__jsonVMSize : (string)VMSize;}
            {_oSDiskSizeGb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNumber>("osDiskSizeGB"), out var __jsonOSDiskSizeGb) ? (int?)__jsonOSDiskSizeGb : OSDiskSizeGb;}
            {_vnetSubnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("vnetSubnetID"), out var __jsonVnetSubnetId) ? (string)__jsonVnetSubnetId : (string)VnetSubnetId;}
            {_firstConsecutiveStaticIP = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("firstConsecutiveStaticIP"), out var __jsonFirstConsecutiveStaticIP) ? (string)__jsonFirstConsecutiveStaticIP : (string)FirstConsecutiveStaticIP;}
            {_storageProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("storageProfile"), out var __jsonStorageProfile) ? (string)__jsonStorageProfile : (string)StorageProfile;}
            {_fqdn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("fqdn"), out var __jsonFqdn) ? (string)__jsonFqdn : (string)Fqdn;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json ? new ContainerServiceMasterProfile(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ContainerServiceMasterProfile" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ContainerServiceMasterProfile" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._count ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNumber((int)this._count) : null, "count" ,container.Add );
            AddIf( null != (((object)this._dnsPrefix)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._dnsPrefix.ToString()) : null, "dnsPrefix" ,container.Add );
            AddIf( null != (((object)this._vMSize)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._vMSize.ToString()) : null, "vmSize" ,container.Add );
            AddIf( null != this._oSDiskSizeGb ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNumber((int)this._oSDiskSizeGb) : null, "osDiskSizeGB" ,container.Add );
            AddIf( null != (((object)this._vnetSubnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._vnetSubnetId.ToString()) : null, "vnetSubnetID" ,container.Add );
            AddIf( null != (((object)this._firstConsecutiveStaticIP)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._firstConsecutiveStaticIP.ToString()) : null, "firstConsecutiveStaticIP" ,container.Add );
            AddIf( null != (((object)this._storageProfile)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._storageProfile.ToString()) : null, "storageProfile" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._fqdn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._fqdn.ToString()) : null, "fqdn" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}