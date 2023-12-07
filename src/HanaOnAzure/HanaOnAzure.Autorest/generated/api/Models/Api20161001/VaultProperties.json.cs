namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Properties of the vault</summary>
    public partial class VaultProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json ? new VaultProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VaultProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VaultProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._sku ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) this._sku.ToJson(null,serializationMode) : null, "sku" ,container.Add );
            AddIf( null != (((object)this._tenantId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._tenantId.ToString()) : null, "tenantId" ,container.Add );
            if (null != this._accessPolicy)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.XNodeArray();
                foreach( var __x in this._accessPolicy )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("accessPolicies",__w);
            }
            AddIf( null != (((object)this._vaultUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._vaultUri.ToString()) : null, "vaultUri" ,container.Add );
            AddIf( null != this._enabledForDeployment ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean((bool)this._enabledForDeployment) : null, "enabledForDeployment" ,container.Add );
            AddIf( null != this._enabledForDiskEncryption ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean((bool)this._enabledForDiskEncryption) : null, "enabledForDiskEncryption" ,container.Add );
            AddIf( null != this._enabledForTemplateDeployment ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean((bool)this._enabledForTemplateDeployment) : null, "enabledForTemplateDeployment" ,container.Add );
            AddIf( null != this._enableSoftDelete ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean((bool)this._enableSoftDelete) : null, "enableSoftDelete" ,container.Add );
            AddIf( null != (((object)this._createMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._createMode.ToString()) : null, "createMode" ,container.Add );
            AddIf( null != this._enablePurgeProtection ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean((bool)this._enablePurgeProtection) : null, "enablePurgeProtection" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject into a new instance of <see cref="VaultProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VaultProperties(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_sku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject>("sku"), out var __jsonSku) ? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.Sku.FromJson(__jsonSku) : Sku;}
            {_tenantId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("tenantId"), out var __jsonTenantId) ? (string)__jsonTenantId : (string)TenantId;}
            {_accessPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray>("accessPolicies"), out var __jsonAccessPolicies) ? If( __jsonAccessPolicies as Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry) (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.AccessPolicyEntry.FromJson(__u) )) ))() : null : AccessPolicy;}
            {_vaultUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("vaultUri"), out var __jsonVaultUri) ? (string)__jsonVaultUri : (string)VaultUri;}
            {_enabledForDeployment = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean>("enabledForDeployment"), out var __jsonEnabledForDeployment) ? (bool?)__jsonEnabledForDeployment : EnabledForDeployment;}
            {_enabledForDiskEncryption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean>("enabledForDiskEncryption"), out var __jsonEnabledForDiskEncryption) ? (bool?)__jsonEnabledForDiskEncryption : EnabledForDiskEncryption;}
            {_enabledForTemplateDeployment = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean>("enabledForTemplateDeployment"), out var __jsonEnabledForTemplateDeployment) ? (bool?)__jsonEnabledForTemplateDeployment : EnabledForTemplateDeployment;}
            {_enableSoftDelete = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean>("enableSoftDelete"), out var __jsonEnableSoftDelete) ? (bool?)__jsonEnableSoftDelete : EnableSoftDelete;}
            {_createMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("createMode"), out var __jsonCreateMode) ? (string)__jsonCreateMode : (string)CreateMode;}
            {_enablePurgeProtection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean>("enablePurgeProtection"), out var __jsonEnablePurgeProtection) ? (bool?)__jsonEnablePurgeProtection : EnablePurgeProtection;}
            AfterFromJson(json);
        }
    }
}