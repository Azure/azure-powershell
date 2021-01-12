namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Properties of a security alert policy.</summary>
    public partial class SecurityAlertPolicyProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json ? new SecurityAlertPolicyProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject into a new instance of <see cref="SecurityAlertPolicyProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SecurityAlertPolicyProperties(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_disabledAlert = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonArray>("disabledAlerts"), out var __jsonDisabledAlerts) ? If( __jsonDisabledAlerts as Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : DisabledAlert;}
            {_emailAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonArray>("emailAddresses"), out var __jsonEmailAddresses) ? If( __jsonEmailAddresses as Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : EmailAddress;}
            {_emailAccountAdmin = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonBoolean>("emailAccountAdmins"), out var __jsonEmailAccountAdmins) ? (bool?)__jsonEmailAccountAdmins : EmailAccountAdmin;}
            {_storageEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("storageEndpoint"), out var __jsonStorageEndpoint) ? (string)__jsonStorageEndpoint : (string)StorageEndpoint;}
            {_storageAccountAccessKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString>("storageAccountAccessKey"), out var __jsonStorageAccountAccessKey) ? (string)__jsonStorageAccountAccessKey : (string)StorageAccountAccessKey;}
            {_retentionDay = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNumber>("retentionDays"), out var __jsonRetentionDays) ? (int?)__jsonRetentionDays : RetentionDay;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SecurityAlertPolicyProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SecurityAlertPolicyProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            if (null != this._disabledAlert)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.XNodeArray();
                foreach( var __x in this._disabledAlert )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("disabledAlerts",__w);
            }
            if (null != this._emailAddress)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.XNodeArray();
                foreach( var __s in this._emailAddress )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("emailAddresses",__r);
            }
            AddIf( null != this._emailAccountAdmin ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonBoolean((bool)this._emailAccountAdmin) : null, "emailAccountAdmins" ,container.Add );
            AddIf( null != (((object)this._storageEndpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._storageEndpoint.ToString()) : null, "storageEndpoint" ,container.Add );
            AddIf( null != (((object)this._storageAccountAccessKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonString(this._storageAccountAccessKey.ToString()) : null, "storageAccountAccessKey" ,container.Add );
            AddIf( null != this._retentionDay ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNumber((int)this._retentionDay) : null, "retentionDays" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}