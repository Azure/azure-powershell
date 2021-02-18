namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Payload of transaction node properties payload in the transaction node payload.</summary>
    public partial class TransactionNodeProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodeProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodeProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodeProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject json ? new TransactionNodeProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="TransactionNodeProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="TransactionNodeProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._dns)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString(this._dns.ToString()) : null, "dns" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._publicKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString(this._publicKey.ToString()) : null, "publicKey" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._userName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString(this._userName.ToString()) : null, "userName" ,container.Add );
            }
            AddIf( null != (((object)this._password)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString(this._password.ToString()) : null, "password" ,container.Add );
            if (null != this._firewallRule)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.XNodeArray();
                foreach( var __x in this._firewallRule )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("firewallRules",__w);
            }
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject into a new instance of <see cref="TransactionNodeProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal TransactionNodeProperties(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_dns = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString>("dns"), out var __jsonDns) ? (string)__jsonDns : (string)Dns;}
            {_publicKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString>("publicKey"), out var __jsonPublicKey) ? (string)__jsonPublicKey : (string)PublicKey;}
            {_userName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString>("userName"), out var __jsonUserName) ? (string)__jsonUserName : (string)UserName;}
            {_password = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonString>("password"), out var __jsonPassword) ? (string)__jsonPassword : (string)Password;}
            {_firewallRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonArray>("firewallRules"), out var __jsonFirewallRules) ? If( __jsonFirewallRules as Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule) (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.FirewallRule.FromJson(__u) )) ))() : null : FirewallRule;}
            AfterFromJson(json);
        }
    }
}