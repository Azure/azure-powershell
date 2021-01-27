namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of a private cloud resource</summary>
    public partial class PrivateCloudProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json ? new PrivateCloudProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject into a new instance of <see cref="PrivateCloudProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal PrivateCloudProperties(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __privateCloudUpdateProperties = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.PrivateCloudUpdateProperties(json);
            {_circuit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject>("circuit"), out var __jsonCircuit) ? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Circuit.FromJson(__jsonCircuit) : Circuit;}
            {_endpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject>("endpoints"), out var __jsonEndpoints) ? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Endpoints.FromJson(__jsonEndpoints) : Endpoint;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_networkBlock = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("networkBlock"), out var __jsonNetworkBlock) ? (string)__jsonNetworkBlock : (string)NetworkBlock;}
            {_managementNetwork = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("managementNetwork"), out var __jsonManagementNetwork) ? (string)__jsonManagementNetwork : (string)ManagementNetwork;}
            {_provisioningNetwork = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("provisioningNetwork"), out var __jsonProvisioningNetwork) ? (string)__jsonProvisioningNetwork : (string)ProvisioningNetwork;}
            {_vmotionNetwork = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("vmotionNetwork"), out var __jsonVmotionNetwork) ? (string)__jsonVmotionNetwork : (string)VmotionNetwork;}
            {_vcenterPassword = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("vcenterPassword"), out var __jsonVcenterPassword) ? (string)__jsonVcenterPassword : (string)VcenterPassword;}
            {_nsxtPassword = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("nsxtPassword"), out var __jsonNsxtPassword) ? (string)__jsonNsxtPassword : (string)NsxtPassword;}
            {_vcenterCertificateThumbprint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("vcenterCertificateThumbprint"), out var __jsonVcenterCertificateThumbprint) ? (string)__jsonVcenterCertificateThumbprint : (string)VcenterCertificateThumbprint;}
            {_nsxtCertificateThumbprint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("nsxtCertificateThumbprint"), out var __jsonNsxtCertificateThumbprint) ? (string)__jsonNsxtCertificateThumbprint : (string)NsxtCertificateThumbprint;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="PrivateCloudProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="PrivateCloudProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __privateCloudUpdateProperties?.ToJson(container, serializationMode);
            AddIf( null != this._circuit ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) this._circuit.ToJson(null,serializationMode) : null, "circuit" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._endpoint ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) this._endpoint.ToJson(null,serializationMode) : null, "endpoints" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._networkBlock)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._networkBlock.ToString()) : null, "networkBlock" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._managementNetwork)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._managementNetwork.ToString()) : null, "managementNetwork" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningNetwork)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._provisioningNetwork.ToString()) : null, "provisioningNetwork" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._vmotionNetwork)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._vmotionNetwork.ToString()) : null, "vmotionNetwork" ,container.Add );
            }
            AddIf( null != (((object)this._vcenterPassword)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._vcenterPassword.ToString()) : null, "vcenterPassword" ,container.Add );
            AddIf( null != (((object)this._nsxtPassword)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._nsxtPassword.ToString()) : null, "nsxtPassword" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._vcenterCertificateThumbprint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._vcenterCertificateThumbprint.ToString()) : null, "vcenterCertificateThumbprint" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._nsxtCertificateThumbprint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._nsxtCertificateThumbprint.ToString()) : null, "nsxtCertificateThumbprint" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}