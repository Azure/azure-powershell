namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>App resource properties payload</summary>
    public partial class AppResourceProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject into a new instance of <see cref="AppResourceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AppResourceProperties(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_temporaryDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject>("temporaryDisk"), out var __jsonTemporaryDisk) ? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.TemporaryDisk.FromJson(__jsonTemporaryDisk) : TemporaryDisk;}
            {_persistentDisk = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject>("persistentDisk"), out var __jsonPersistentDisk) ? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.PersistentDisk.FromJson(__jsonPersistentDisk) : PersistentDisk;}
            {_public = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonBoolean>("public"), out var __jsonPublic) ? (bool?)__jsonPublic : Public;}
            {_url = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("url"), out var __jsonUrl) ? (string)__jsonUrl : (string)Url;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_activeDeploymentName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("activeDeploymentName"), out var __jsonActiveDeploymentName) ? (string)__jsonActiveDeploymentName : (string)ActiveDeploymentName;}
            {_fqdn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("fqdn"), out var __jsonFqdn) ? (string)__jsonFqdn : (string)Fqdn;}
            {_httpsOnly = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonBoolean>("httpsOnly"), out var __jsonHttpsOnly) ? (bool?)__jsonHttpsOnly : HttpsOnly;}
            {_createdTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("createdTime"), out var __jsonCreatedTime) ? global::System.DateTime.TryParse((string)__jsonCreatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedTimeValue) ? __jsonCreatedTimeValue : CreatedTime : CreatedTime;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResourceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json ? new AppResourceProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AppResourceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AppResourceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._temporaryDisk ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) this._temporaryDisk.ToJson(null,serializationMode) : null, "temporaryDisk" ,container.Add );
            AddIf( null != this._persistentDisk ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) this._persistentDisk.ToJson(null,serializationMode) : null, "persistentDisk" ,container.Add );
            AddIf( null != this._public ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonBoolean((bool)this._public) : null, "public" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._url)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._url.ToString()) : null, "url" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._activeDeploymentName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._activeDeploymentName.ToString()) : null, "activeDeploymentName" ,container.Add );
            AddIf( null != (((object)this._fqdn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._fqdn.ToString()) : null, "fqdn" ,container.Add );
            AddIf( null != this._httpsOnly ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonBoolean((bool)this._httpsOnly) : null, "httpsOnly" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._createdTime ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._createdTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdTime" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}