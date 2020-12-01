namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Permissions the identity has for keys, secrets, certificates and storage.</summary>
    public partial class Permissions
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json ? new Permissions(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject into a new instance of <see cref="Permissions" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Permissions(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_key = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray>("keys"), out var __jsonKeys) ? If( __jsonKeys as Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions) (__u is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString __t ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions)(__t.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions)""))) ))() : null : Key;}
            {_secret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray>("secrets"), out var __jsonSecrets) ? If( __jsonSecrets as Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions) (__p is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString __o ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions)(__o.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions)""))) ))() : null : Secret;}
            {_certificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray>("certificates"), out var __jsonCertificates) ? If( __jsonCertificates as Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions) (__k is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString __j ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions)(__j.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions)""))) ))() : null : Certificate;}
            {_storage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray>("storage"), out var __jsonStorage) ? If( __jsonStorage as Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions) (__f is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString __e ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions)(__e.ToString()) : ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions)""))) ))() : null : Storage;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="Permissions" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Permissions" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" />.
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
            if (null != this._key)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.XNodeArray();
                foreach( var __x in this._key )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("keys",__w);
            }
            if (null != this._secret)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.XNodeArray();
                foreach( var __s in this._secret )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("secrets",__r);
            }
            if (null != this._certificate)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.XNodeArray();
                foreach( var __n in this._certificate )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("certificates",__m);
            }
            if (null != this._storage)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.XNodeArray();
                foreach( var __i in this._storage )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("storage",__h);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}