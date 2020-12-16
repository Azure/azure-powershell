namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>The properties that can be updated for a server.</summary>
    public partial class ServerUpdateParametersProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json ? new ServerUpdateParametersProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject into a new instance of <see cref="ServerUpdateParametersProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ServerUpdateParametersProperties(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_storageProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject>("storageProfile"), out var __jsonStorageProfile) ? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfile.FromJson(__jsonStorageProfile) : StorageProfile;}
            {_administratorLoginPassword = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("administratorLoginPassword"), out var __jsonAdministratorLoginPassword) ? (string)__jsonAdministratorLoginPassword : (string)AdministratorLoginPassword;}
            {_version = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("version"), out var __jsonVersion) ? (string)__jsonVersion : (string)Version;}
            {_sslEnforcement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("sslEnforcement"), out var __jsonSslEnforcement) ? (string)__jsonSslEnforcement : (string)SslEnforcement;}
            {_minimalTlsVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("minimalTlsVersion"), out var __jsonMinimalTlsVersion) ? (string)__jsonMinimalTlsVersion : (string)MinimalTlsVersion;}
            {_publicNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("publicNetworkAccess"), out var __jsonPublicNetworkAccess) ? (string)__jsonPublicNetworkAccess : (string)PublicNetworkAccess;}
            {_replicationRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("replicationRole"), out var __jsonReplicationRole) ? (string)__jsonReplicationRole : (string)ReplicationRole;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ServerUpdateParametersProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ServerUpdateParametersProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._storageProfile ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) this._storageProfile.ToJson(null,serializationMode) : null, "storageProfile" ,container.Add );
            AddIf( null != (((object)this._administratorLoginPassword)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._administratorLoginPassword.ToString()) : null, "administratorLoginPassword" ,container.Add );
            AddIf( null != (((object)this._version)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._version.ToString()) : null, "version" ,container.Add );
            AddIf( null != (((object)this._sslEnforcement)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._sslEnforcement.ToString()) : null, "sslEnforcement" ,container.Add );
            AddIf( null != (((object)this._minimalTlsVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._minimalTlsVersion.ToString()) : null, "minimalTlsVersion" ,container.Add );
            AddIf( null != (((object)this._publicNetworkAccess)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._publicNetworkAccess.ToString()) : null, "publicNetworkAccess" ,container.Add );
            AddIf( null != (((object)this._replicationRole)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._replicationRole.ToString()) : null, "replicationRole" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}