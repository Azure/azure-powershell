namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Certificate resource payload.</summary>
    public partial class CertificateProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject into a new instance of <see cref="CertificateProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal CertificateProperties(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_activateDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("activateDate"), out var __jsonActivateDate) ? (string)__jsonActivateDate : (string)ActivateDate;}
            {_certVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("certVersion"), out var __jsonCertVersion) ? (string)__jsonCertVersion : (string)CertVersion;}
            {_dnsName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonArray>("dnsNames"), out var __jsonDnsNames) ? If( __jsonDnsNames as Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : DnsName;}
            {_expirationDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("expirationDate"), out var __jsonExpirationDate) ? (string)__jsonExpirationDate : (string)ExpirationDate;}
            {_issuedDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("issuedDate"), out var __jsonIssuedDate) ? (string)__jsonIssuedDate : (string)IssuedDate;}
            {_issuer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("issuer"), out var __jsonIssuer) ? (string)__jsonIssuer : (string)Issuer;}
            {_keyVaultCertName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("keyVaultCertName"), out var __jsonKeyVaultCertName) ? (string)__jsonKeyVaultCertName : (string)KeyVaultCertName;}
            {_subjectName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("subjectName"), out var __jsonSubjectName) ? (string)__jsonSubjectName : (string)SubjectName;}
            {_thumbprint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("thumbprint"), out var __jsonThumbprint) ? (string)__jsonThumbprint : (string)Thumbprint;}
            {_vaultUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("vaultUri"), out var __jsonVaultUri) ? (string)__jsonVaultUri : (string)VaultUri;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json ? new CertificateProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="CertificateProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="CertificateProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
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
                AddIf( null != (((object)this._activateDate)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._activateDate.ToString()) : null, "activateDate" ,container.Add );
            }
            AddIf( null != (((object)this._certVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._certVersion.ToString()) : null, "certVersion" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._dnsName)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.XNodeArray();
                    foreach( var __x in this._dnsName )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("dnsNames",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._expirationDate)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._expirationDate.ToString()) : null, "expirationDate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._issuedDate)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._issuedDate.ToString()) : null, "issuedDate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._issuer)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._issuer.ToString()) : null, "issuer" ,container.Add );
            }
            AddIf( null != (((object)this._keyVaultCertName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._keyVaultCertName.ToString()) : null, "keyVaultCertName" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._subjectName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._subjectName.ToString()) : null, "subjectName" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._thumbprint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._thumbprint.ToString()) : null, "thumbprint" ,container.Add );
            }
            AddIf( null != (((object)this._vaultUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._vaultUri.ToString()) : null, "vaultUri" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}