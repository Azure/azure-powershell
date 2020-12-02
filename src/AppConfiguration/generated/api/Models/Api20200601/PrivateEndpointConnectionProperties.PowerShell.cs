namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.PowerShell;

    /// <summary>Properties of a private endpoint connection.</summary>
    [System.ComponentModel.TypeConverter(typeof(PrivateEndpointConnectionPropertiesTypeConverter))]
    public partial class PrivateEndpointConnectionProperties
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PrivateEndpointConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PrivateEndpointConnectionProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PrivateEndpointConnectionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PrivateEndpointConnectionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpoint) content.GetValueForProperty("PrivateEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpoint, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionState = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkServiceConnectionState) content.GetValueForProperty("PrivateLinkServiceConnectionState",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionState, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateLinkServiceConnectionStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpointId = (string) content.GetValueForProperty("PrivateEndpointId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateDescription = (string) content.GetValueForProperty("PrivateLinkServiceConnectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateActionsRequired = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ActionsRequired?) content.GetValueForProperty("PrivateLinkServiceConnectionStateActionsRequired",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateActionsRequired, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ActionsRequired.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateStatus = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ConnectionStatus?) content.GetValueForProperty("PrivateLinkServiceConnectionStateStatus",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateStatus, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ConnectionStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PrivateEndpointConnectionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpoint) content.GetValueForProperty("PrivateEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpoint, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionState = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateLinkServiceConnectionState) content.GetValueForProperty("PrivateLinkServiceConnectionState",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionState, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateLinkServiceConnectionStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpointId = (string) content.GetValueForProperty("PrivateEndpointId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateEndpointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateDescription = (string) content.GetValueForProperty("PrivateLinkServiceConnectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateActionsRequired = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ActionsRequired?) content.GetValueForProperty("PrivateLinkServiceConnectionStateActionsRequired",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateActionsRequired, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ActionsRequired.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateStatus = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ConnectionStatus?) content.GetValueForProperty("PrivateLinkServiceConnectionStateStatus",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionPropertiesInternal)this).PrivateLinkServiceConnectionStateStatus, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ConnectionStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of a private endpoint connection.
    [System.ComponentModel.TypeConverter(typeof(PrivateEndpointConnectionPropertiesTypeConverter))]
    public partial interface IPrivateEndpointConnectionProperties

    {

    }
}