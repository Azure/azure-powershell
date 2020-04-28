namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Custom Parameters used for Cluster Creation.</summary>
    public partial class WorkspaceCustomParameters
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json ? new WorkspaceCustomParameters(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="WorkspaceCustomParameters" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="WorkspaceCustomParameters" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._amlWorkspaceId ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._amlWorkspaceId.ToJson(null,serializationMode) : null, "amlWorkspaceId" ,container.Add );
            AddIf( null != this._customPrivateSubnetName ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._customPrivateSubnetName.ToJson(null,serializationMode) : null, "customPrivateSubnetName" ,container.Add );
            AddIf( null != this._customPublicSubnetName ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._customPublicSubnetName.ToJson(null,serializationMode) : null, "customPublicSubnetName" ,container.Add );
            AddIf( null != this._customVirtualNetworkId ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._customVirtualNetworkId.ToJson(null,serializationMode) : null, "customVirtualNetworkId" ,container.Add );
            AddIf( null != this._enableNoPublicIP ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._enableNoPublicIP.ToJson(null,serializationMode) : null, "enableNoPublicIp" ,container.Add );
            AddIf( null != this._loadBalancerBackendPoolName ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._loadBalancerBackendPoolName.ToJson(null,serializationMode) : null, "loadBalancerBackendPoolName" ,container.Add );
            AddIf( null != this._loadBalancerId ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._loadBalancerId.ToJson(null,serializationMode) : null, "loadBalancerId" ,container.Add );
            AddIf( null != this._relayNamespaceName ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._relayNamespaceName.ToJson(null,serializationMode) : null, "relayNamespaceName" ,container.Add );
            AddIf( null != this._resourceTag ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._resourceTag.ToJson(null,serializationMode) : null, "resourceTags" ,container.Add );
            AddIf( null != this._storageAccountName ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._storageAccountName.ToJson(null,serializationMode) : null, "storageAccountName" ,container.Add );
            AddIf( null != this._storageAccountSkuName ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._storageAccountSkuName.ToJson(null,serializationMode) : null, "storageAccountSkuName" ,container.Add );
            AddIf( null != this._vnetAddressPrefix ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._vnetAddressPrefix.ToJson(null,serializationMode) : null, "vnetAddressPrefix" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject into a new instance of <see cref="WorkspaceCustomParameters" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal WorkspaceCustomParameters(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_amlWorkspaceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("amlWorkspaceId"), out var __jsonAmlWorkspaceId) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonAmlWorkspaceId) : AmlWorkspaceId;}
            {_customPrivateSubnetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("customPrivateSubnetName"), out var __jsonCustomPrivateSubnetName) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonCustomPrivateSubnetName) : CustomPrivateSubnetName;}
            {_customPublicSubnetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("customPublicSubnetName"), out var __jsonCustomPublicSubnetName) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonCustomPublicSubnetName) : CustomPublicSubnetName;}
            {_customVirtualNetworkId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("customVirtualNetworkId"), out var __jsonCustomVirtualNetworkId) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonCustomVirtualNetworkId) : CustomVirtualNetworkId;}
            {_enableNoPublicIP = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("enableNoPublicIp"), out var __jsonEnableNoPublicIP) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter.FromJson(__jsonEnableNoPublicIP) : EnableNoPublicIP;}
            {_loadBalancerBackendPoolName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("loadBalancerBackendPoolName"), out var __jsonLoadBalancerBackendPoolName) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonLoadBalancerBackendPoolName) : LoadBalancerBackendPoolName;}
            {_loadBalancerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("loadBalancerId"), out var __jsonLoadBalancerId) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonLoadBalancerId) : LoadBalancerId;}
            {_relayNamespaceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("relayNamespaceName"), out var __jsonRelayNamespaceName) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonRelayNamespaceName) : RelayNamespaceName;}
            {_resourceTag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("resourceTags"), out var __jsonResourceTags) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomObjectParameter.FromJson(__jsonResourceTags) : ResourceTag;}
            {_storageAccountName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("storageAccountName"), out var __jsonStorageAccountName) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonStorageAccountName) : StorageAccountName;}
            {_storageAccountSkuName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("storageAccountSkuName"), out var __jsonStorageAccountSkuName) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonStorageAccountSkuName) : StorageAccountSkuName;}
            {_vnetAddressPrefix = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("vnetAddressPrefix"), out var __jsonVnetAddressPrefix) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter.FromJson(__jsonVnetAddressPrefix) : VnetAddressPrefix;}
            AfterFromJson(json);
        }
    }
}