// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    public partial class DiscoveryIdentity
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject into a new instance of <see cref="DiscoveryIdentity" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DiscoveryIdentity(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_subscriptionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("subscriptionId"), out var __jsonSubscriptionId) ? (string)__jsonSubscriptionId : (string)_subscriptionId;}
            {_resourceGroupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("resourceGroupName"), out var __jsonResourceGroupName) ? (string)__jsonResourceGroupName : (string)_resourceGroupName;}
            {_bookshelfName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("bookshelfName"), out var __jsonBookshelfName) ? (string)__jsonBookshelfName : (string)_bookshelfName;}
            {_privateEndpointConnectionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("privateEndpointConnectionName"), out var __jsonPrivateEndpointConnectionName) ? (string)__jsonPrivateEndpointConnectionName : (string)_privateEndpointConnectionName;}
            {_privateLinkResourceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("privateLinkResourceName"), out var __jsonPrivateLinkResourceName) ? (string)__jsonPrivateLinkResourceName : (string)_privateLinkResourceName;}
            {_toolName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("toolName"), out var __jsonToolName) ? (string)__jsonToolName : (string)_toolName;}
            {_workspaceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("workspaceName"), out var __jsonWorkspaceName) ? (string)__jsonWorkspaceName : (string)_workspaceName;}
            {_projectName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("projectName"), out var __jsonProjectName) ? (string)__jsonProjectName : (string)_projectName;}
            {_chatModelDeploymentName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("chatModelDeploymentName"), out var __jsonChatModelDeploymentName) ? (string)__jsonChatModelDeploymentName : (string)_chatModelDeploymentName;}
            {_supercomputerName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("supercomputerName"), out var __jsonSupercomputerName) ? (string)__jsonSupercomputerName : (string)_supercomputerName;}
            {_nodePoolName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("nodePoolName"), out var __jsonNodePoolName) ? (string)__jsonNodePoolName : (string)_nodePoolName;}
            {_storageContainerName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("storageContainerName"), out var __jsonStorageContainerName) ? (string)__jsonStorageContainerName : (string)_storageContainerName;}
            {_storageAssetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("storageAssetName"), out var __jsonStorageAssetName) ? (string)__jsonStorageAssetName : (string)_storageAssetName;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)_id;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject json ? new DiscoveryIdentity(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DiscoveryIdentity" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DiscoveryIdentity" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._subscriptionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._subscriptionId.ToString()) : null, "subscriptionId" ,container.Add );
            AddIf( null != (((object)this._resourceGroupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._resourceGroupName.ToString()) : null, "resourceGroupName" ,container.Add );
            AddIf( null != (((object)this._bookshelfName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._bookshelfName.ToString()) : null, "bookshelfName" ,container.Add );
            AddIf( null != (((object)this._privateEndpointConnectionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._privateEndpointConnectionName.ToString()) : null, "privateEndpointConnectionName" ,container.Add );
            AddIf( null != (((object)this._privateLinkResourceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._privateLinkResourceName.ToString()) : null, "privateLinkResourceName" ,container.Add );
            AddIf( null != (((object)this._toolName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._toolName.ToString()) : null, "toolName" ,container.Add );
            AddIf( null != (((object)this._workspaceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._workspaceName.ToString()) : null, "workspaceName" ,container.Add );
            AddIf( null != (((object)this._projectName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._projectName.ToString()) : null, "projectName" ,container.Add );
            AddIf( null != (((object)this._chatModelDeploymentName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._chatModelDeploymentName.ToString()) : null, "chatModelDeploymentName" ,container.Add );
            AddIf( null != (((object)this._supercomputerName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._supercomputerName.ToString()) : null, "supercomputerName" ,container.Add );
            AddIf( null != (((object)this._nodePoolName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._nodePoolName.ToString()) : null, "nodePoolName" ,container.Add );
            AddIf( null != (((object)this._storageContainerName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._storageContainerName.ToString()) : null, "storageContainerName" ,container.Add );
            AddIf( null != (((object)this._storageAssetName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._storageAssetName.ToString()) : null, "storageAssetName" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}