namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the load balancer.</summary>
    public partial class LoadBalancingRulePropertiesFormat
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancingRulePropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new LoadBalancingRulePropertiesFormat(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="LoadBalancingRulePropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal LoadBalancingRulePropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_backendAddressPool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("backendAddressPool"), out var __jsonBackendAddressPool) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource.FromJson(__jsonBackendAddressPool) : BackendAddressPool;}
            {_frontendIPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("frontendIPConfiguration"), out var __jsonFrontendIPConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource.FromJson(__jsonFrontendIPConfiguration) : FrontendIPConfiguration;}
            {_probe = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("probe"), out var __jsonProbe) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource.FromJson(__jsonProbe) : Probe;}
            {_backendPort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("backendPort"), out var __jsonBackendPort) ? (int?)__jsonBackendPort : BackendPort;}
            {_disableOutboundSnat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean>("disableOutboundSnat"), out var __jsonDisableOutboundSnat) ? (bool?)__jsonDisableOutboundSnat : DisableOutboundSnat;}
            {_enableFloatingIP = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean>("enableFloatingIP"), out var __jsonEnableFloatingIP) ? (bool?)__jsonEnableFloatingIP : EnableFloatingIP;}
            {_frontendPort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("frontendPort"), out var __jsonFrontendPort) ? (int)__jsonFrontendPort : FrontendPort;}
            {_idleTimeoutInMinutes = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("idleTimeoutInMinutes"), out var __jsonIdleTimeoutInMinutes) ? (int?)__jsonIdleTimeoutInMinutes : IdleTimeoutInMinutes;}
            {_loadDistribution = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("loadDistribution"), out var __jsonLoadDistribution) ? (string)__jsonLoadDistribution : (string)LoadDistribution;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_protocol = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("protocol"), out var __jsonProtocol) ? (string)__jsonProtocol : (string)Protocol;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="LoadBalancingRulePropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="LoadBalancingRulePropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._backendAddressPool ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._backendAddressPool.ToJson(null,serializationMode) : null, "backendAddressPool" ,container.Add );
            AddIf( null != this._frontendIPConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._frontendIPConfiguration.ToJson(null,serializationMode) : null, "frontendIPConfiguration" ,container.Add );
            AddIf( null != this._probe ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._probe.ToJson(null,serializationMode) : null, "probe" ,container.Add );
            AddIf( null != this._backendPort ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._backendPort) : null, "backendPort" ,container.Add );
            AddIf( null != this._disableOutboundSnat ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean((bool)this._disableOutboundSnat) : null, "disableOutboundSnat" ,container.Add );
            AddIf( null != this._enableFloatingIP ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean((bool)this._enableFloatingIP) : null, "enableFloatingIP" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber(this._frontendPort), "frontendPort" ,container.Add );
            AddIf( null != this._idleTimeoutInMinutes ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._idleTimeoutInMinutes) : null, "idleTimeoutInMinutes" ,container.Add );
            AddIf( null != (((object)this._loadDistribution)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._loadDistribution.ToString()) : null, "loadDistribution" ,container.Add );
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != (((object)this._protocol)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._protocol.ToString()) : null, "protocol" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}