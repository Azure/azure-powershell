namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderAuthorization
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json ? new ResourceProviderAuthorization(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject into a new instance of <see cref="ResourceProviderAuthorization" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ResourceProviderAuthorization(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_applicationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("applicationId"), out var __jsonApplicationId) ? (string)__jsonApplicationId : (string)ApplicationId;}
            {_roleDefinitionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("roleDefinitionId"), out var __jsonRoleDefinitionId) ? (string)__jsonRoleDefinitionId : (string)RoleDefinitionId;}
            {_managedByRoleDefinitionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString>("managedByRoleDefinitionId"), out var __jsonManagedByRoleDefinitionId) ? (string)__jsonManagedByRoleDefinitionId : (string)ManagedByRoleDefinitionId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ResourceProviderAuthorization" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ResourceProviderAuthorization" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._applicationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._applicationId.ToString()) : null, "applicationId" ,container.Add );
            AddIf( null != (((object)this._roleDefinitionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._roleDefinitionId.ToString()) : null, "roleDefinitionId" ,container.Add );
            AddIf( null != (((object)this._managedByRoleDefinitionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonString(this._managedByRoleDefinitionId.ToString()) : null, "managedByRoleDefinitionId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}