namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Endpoint addresses</summary>
    public partial class Endpoints
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject into a new instance of <see cref="Endpoints" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Endpoints(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_nsxtManager = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("nsxtManager"), out var __jsonNsxtManager) ? (string)__jsonNsxtManager : (string)NsxtManager;}
            {_vcsa = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("vcsa"), out var __jsonVcsa) ? (string)__jsonVcsa : (string)Vcsa;}
            {_hcxCloudManager = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("hcxCloudManager"), out var __jsonHcxCloudManager) ? (string)__jsonHcxCloudManager : (string)HcxCloudManager;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json ? new Endpoints(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="Endpoints" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Endpoints" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._nsxtManager)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._nsxtManager.ToString()) : null, "nsxtManager" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._vcsa)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._vcsa.ToString()) : null, "vcsa" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._hcxCloudManager)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._hcxCloudManager.ToString()) : null, "hcxCloudManager" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}