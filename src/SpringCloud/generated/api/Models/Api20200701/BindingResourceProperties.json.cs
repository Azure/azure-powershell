namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Binding resource properties payload</summary>
    public partial class BindingResourceProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject into a new instance of <see cref="BindingResourceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal BindingResourceProperties(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_resourceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("resourceName"), out var __jsonResourceName) ? (string)__jsonResourceName : (string)ResourceName;}
            {_resourceType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("resourceType"), out var __jsonResourceType) ? (string)__jsonResourceType : (string)ResourceType;}
            {_resourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("resourceId"), out var __jsonResourceId) ? (string)__jsonResourceId : (string)ResourceId;}
            {_key = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("key"), out var __jsonKey) ? (string)__jsonKey : (string)Key;}
            {_bindingParameter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject>("bindingParameters"), out var __jsonBindingParameters) ? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourcePropertiesBindingParameters.FromJson(__jsonBindingParameters) : BindingParameter;}
            {_generatedProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("generatedProperties"), out var __jsonGeneratedProperties) ? (string)__jsonGeneratedProperties : (string)GeneratedProperty;}
            {_createdAt = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("createdAt"), out var __jsonCreatedAt) ? (string)__jsonCreatedAt : (string)CreatedAt;}
            {_updatedAt = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("updatedAt"), out var __jsonUpdatedAt) ? (string)__jsonUpdatedAt : (string)UpdatedAt;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json ? new BindingResourceProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="BindingResourceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="BindingResourceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._resourceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._resourceName.ToString()) : null, "resourceName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._resourceType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._resourceType.ToString()) : null, "resourceType" ,container.Add );
            }
            AddIf( null != (((object)this._resourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._resourceId.ToString()) : null, "resourceId" ,container.Add );
            AddIf( null != (((object)this._key)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._key.ToString()) : null, "key" ,container.Add );
            AddIf( null != this._bindingParameter ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) this._bindingParameter.ToJson(null,serializationMode) : null, "bindingParameters" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._generatedProperty)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._generatedProperty.ToString()) : null, "generatedProperties" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._createdAt)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._createdAt.ToString()) : null, "createdAt" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._updatedAt)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._updatedAt.ToString()) : null, "updatedAt" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}