namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>The workspace properties.</summary>
    public partial class WorkspaceProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json ? new WorkspaceProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="WorkspaceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="WorkspaceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._parameter ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._parameter.ToJson(null,serializationMode) : null, "parameters" ,container.Add );
            AddIf( null != this._createdBy ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._createdBy.ToJson(null,serializationMode) : null, "createdBy" ,container.Add );
            AddIf( null != this._updatedBy ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._updatedBy.ToJson(null,serializationMode) : null, "updatedBy" ,container.Add );
            AddIf( null != this._storageAccountIdentity ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._storageAccountIdentity.ToJson(null,serializationMode) : null, "storageAccountIdentity" ,container.Add );
            AddIf( null != (((object)this._managedResourceGroupId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._managedResourceGroupId.ToString()) : null, "managedResourceGroupId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._uiDefinitionUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._uiDefinitionUri.ToString()) : null, "uiDefinitionUri" ,container.Add );
            if (null != this._authorization)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.XNodeArray();
                foreach( var __x in this._authorization )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("authorizations",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._createdDateTime ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._createdDateTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdDateTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._workspaceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._workspaceId.ToString()) : null, "workspaceId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._workspaceUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._workspaceUrl.ToString()) : null, "workspaceUrl" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject into a new instance of <see cref="WorkspaceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal WorkspaceProperties(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_parameter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("parameters"), out var __jsonParameters) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters.FromJson(__jsonParameters) : Parameter;}
            {_createdBy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("createdBy"), out var __jsonCreatedBy) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.CreatedBy.FromJson(__jsonCreatedBy) : CreatedBy;}
            {_updatedBy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("updatedBy"), out var __jsonUpdatedBy) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.CreatedBy.FromJson(__jsonUpdatedBy) : UpdatedBy;}
            {_storageAccountIdentity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("storageAccountIdentity"), out var __jsonStorageAccountIdentity) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ManagedIdentityConfiguration.FromJson(__jsonStorageAccountIdentity) : StorageAccountIdentity;}
            {_managedResourceGroupId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("managedResourceGroupId"), out var __jsonManagedResourceGroupId) ? (string)__jsonManagedResourceGroupId : (string)ManagedResourceGroupId;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_uiDefinitionUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("uiDefinitionUri"), out var __jsonUiDefinitionUri) ? (string)__jsonUiDefinitionUri : (string)UiDefinitionUri;}
            {_authorization = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonArray>("authorizations"), out var __jsonAuthorizations) ? If( __jsonAuthorizations as Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization) (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceProviderAuthorization.FromJson(__u) )) ))() : null : Authorization;}
            {_createdDateTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("createdDateTime"), out var __jsonCreatedDateTime) ? global::System.DateTime.TryParse((string)__jsonCreatedDateTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedDateTimeValue) ? __jsonCreatedDateTimeValue : CreatedDateTime : CreatedDateTime;}
            {_workspaceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("workspaceId"), out var __jsonWorkspaceId) ? (string)__jsonWorkspaceId : (string)WorkspaceId;}
            {_workspaceUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("workspaceUrl"), out var __jsonWorkspaceUrl) ? (string)__jsonWorkspaceUrl : (string)WorkspaceUrl;}
            AfterFromJson(json);
        }
    }
}