namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogInstallMethod
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject into a new instance of <see cref="DatadogInstallMethod" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DatadogInstallMethod(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_tool = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("tool"), out var __jsonTool) ? (string)__jsonTool : (string)Tool;}
            {_toolVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("toolVersion"), out var __jsonToolVersion) ? (string)__jsonToolVersion : (string)ToolVersion;}
            {_installerVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("installerVersion"), out var __jsonInstallerVersion) ? (string)__jsonInstallerVersion : (string)InstallerVersion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject json ? new DatadogInstallMethod(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DatadogInstallMethod" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DatadogInstallMethod" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._tool)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._tool.ToString()) : null, "tool" ,container.Add );
            AddIf( null != (((object)this._toolVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._toolVersion.ToString()) : null, "toolVersion" ,container.Add );
            AddIf( null != (((object)this._installerVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._installerVersion.ToString()) : null, "installerVersion" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}