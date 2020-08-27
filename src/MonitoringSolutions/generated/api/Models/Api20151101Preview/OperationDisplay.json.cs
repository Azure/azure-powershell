namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>Display metadata associated with the operation.</summary>
    public partial class OperationDisplay
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IOperationDisplay.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IOperationDisplay.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IOperationDisplay FromJson(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject json ? new OperationDisplay(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject into a new instance of <see cref="OperationDisplay" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal OperationDisplay(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_operation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonString>("operation"), out var __jsonOperation) ? (string)__jsonOperation : (string)Operation;}
            {_provider = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonString>("provider"), out var __jsonProvider) ? (string)__jsonProvider : (string)Provider;}
            {_resource = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonString>("resource"), out var __jsonResource) ? (string)__jsonResource : (string)Resource;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="OperationDisplay" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="OperationDisplay" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._operation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonString(this._operation.ToString()) : null, "operation" ,container.Add );
            AddIf( null != (((object)this._provider)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonString(this._provider.ToString()) : null, "provider" ,container.Add );
            AddIf( null != (((object)this._resource)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Json.JsonString(this._resource.ToString()) : null, "resource" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}