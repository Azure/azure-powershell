namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Properties specific to the monitor resource.</summary>
    public partial class MonitorProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject json ? new MonitorProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject into a new instance of <see cref="MonitorProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MonitorProperties(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_datadogOrganizationProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject>("datadogOrganizationProperties"), out var __jsonDatadogOrganizationProperties) ? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties.FromJson(__jsonDatadogOrganizationProperties) : DatadogOrganizationProperty;}
            {_userInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject>("userInfo"), out var __jsonUserInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfo.FromJson(__jsonUserInfo) : UserInfo;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_monitoringStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("monitoringStatus"), out var __jsonMonitoringStatus) ? (string)__jsonMonitoringStatus : (string)MonitoringStatus;}
            {_marketplaceSubscriptionStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("marketplaceSubscriptionStatus"), out var __jsonMarketplaceSubscriptionStatus) ? (string)__jsonMarketplaceSubscriptionStatus : (string)MarketplaceSubscriptionStatus;}
            {_liftrResourceCategory = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString>("liftrResourceCategory"), out var __jsonLiftrResourceCategory) ? (string)__jsonLiftrResourceCategory : (string)LiftrResourceCategory;}
            {_liftrResourcePreference = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNumber>("liftrResourcePreference"), out var __jsonLiftrResourcePreference) ? (int?)__jsonLiftrResourcePreference : LiftrResourcePreference;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MonitorProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MonitorProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._datadogOrganizationProperty ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) this._datadogOrganizationProperty.ToJson(null,serializationMode) : null, "datadogOrganizationProperties" ,container.Add );
            AddIf( null != this._userInfo ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) this._userInfo.ToJson(null,serializationMode) : null, "userInfo" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._monitoringStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._monitoringStatus.ToString()) : null, "monitoringStatus" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._marketplaceSubscriptionStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._marketplaceSubscriptionStatus.ToString()) : null, "marketplaceSubscriptionStatus" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._liftrResourceCategory)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonString(this._liftrResourceCategory.ToString()) : null, "liftrResourceCategory" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._liftrResourcePreference ? (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNumber((int)this._liftrResourcePreference) : null, "liftrResourcePreference" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}