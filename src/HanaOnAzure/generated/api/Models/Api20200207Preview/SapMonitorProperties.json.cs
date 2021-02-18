namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Describes the properties of a SAP monitor.</summary>
    public partial class SapMonitorProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json ? new SapMonitorProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject into a new instance of <see cref="SapMonitorProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SapMonitorProperties(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_managedResourceGroupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("managedResourceGroupName"), out var __jsonManagedResourceGroupName) ? (string)__jsonManagedResourceGroupName : (string)ManagedResourceGroupName;}
            {_logAnalyticsWorkspaceArmId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("logAnalyticsWorkspaceArmId"), out var __jsonLogAnalyticsWorkspaceArmId) ? (string)__jsonLogAnalyticsWorkspaceArmId : (string)LogAnalyticsWorkspaceArmId;}
            {_enableCustomerAnalytic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean>("enableCustomerAnalytics"), out var __jsonEnableCustomerAnalytics) ? (bool?)__jsonEnableCustomerAnalytics : EnableCustomerAnalytic;}
            {_logAnalyticsWorkspaceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("logAnalyticsWorkspaceId"), out var __jsonLogAnalyticsWorkspaceId) ? (string)__jsonLogAnalyticsWorkspaceId : (string)LogAnalyticsWorkspaceId;}
            {_logAnalyticsWorkspaceSharedKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("logAnalyticsWorkspaceSharedKey"), out var __jsonLogAnalyticsWorkspaceSharedKey) ? (string)__jsonLogAnalyticsWorkspaceSharedKey : (string)LogAnalyticsWorkspaceSharedKey;}
            {_sapMonitorCollectorVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("sapMonitorCollectorVersion"), out var __jsonSapMonitorCollectorVersion) ? (string)__jsonSapMonitorCollectorVersion : (string)SapMonitorCollectorVersion;}
            {_monitorSubnet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString>("monitorSubnet"), out var __jsonMonitorSubnet) ? (string)__jsonMonitorSubnet : (string)MonitorSubnet;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SapMonitorProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SapMonitorProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._managedResourceGroupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._managedResourceGroupName.ToString()) : null, "managedResourceGroupName" ,container.Add );
            }
            AddIf( null != (((object)this._logAnalyticsWorkspaceArmId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._logAnalyticsWorkspaceArmId.ToString()) : null, "logAnalyticsWorkspaceArmId" ,container.Add );
            AddIf( null != this._enableCustomerAnalytic ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonBoolean((bool)this._enableCustomerAnalytic) : null, "enableCustomerAnalytics" ,container.Add );
            AddIf( null != (((object)this._logAnalyticsWorkspaceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._logAnalyticsWorkspaceId.ToString()) : null, "logAnalyticsWorkspaceId" ,container.Add );
            AddIf( null != (((object)this._logAnalyticsWorkspaceSharedKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._logAnalyticsWorkspaceSharedKey.ToString()) : null, "logAnalyticsWorkspaceSharedKey" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._sapMonitorCollectorVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._sapMonitorCollectorVersion.ToString()) : null, "sapMonitorCollectorVersion" ,container.Add );
            }
            AddIf( null != (((object)this._monitorSubnet)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonString(this._monitorSubnet.ToString()) : null, "monitorSubnet" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}