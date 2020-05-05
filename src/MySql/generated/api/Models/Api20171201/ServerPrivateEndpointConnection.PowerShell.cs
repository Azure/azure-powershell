namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.PowerShell;

    /// <summary>A private endpoint connection under a server</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerPrivateEndpointConnectionTypeConverter))]
    public partial class ServerPrivateEndpointConnection
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerPrivateEndpointConnection(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerPrivateEndpointConnection(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerPrivateEndpointConnection" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerPrivateEndpointConnection(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnectionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPrivateEndpointProperty) content.GetValueForProperty("PrivateEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpoint, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.PrivateEndpointPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionState = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateLinkServiceConnectionStateProperty) content.GetValueForProperty("PrivateLinkServiceConnectionState",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionState, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateLinkServiceConnectionStatePropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateEndpointProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateEndpointProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateStatus = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateStatus) content.GetValueForProperty("PrivateLinkServiceConnectionStateStatus",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateStatus, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpointId = (string) content.GetValueForProperty("PrivateEndpointId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateDescription = (string) content.GetValueForProperty("PrivateLinkServiceConnectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateActionsRequired = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateActionsRequire?) content.GetValueForProperty("PrivateLinkServiceConnectionStateActionsRequired",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateActionsRequired, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateActionsRequire.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerPrivateEndpointConnection(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnectionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPrivateEndpointProperty) content.GetValueForProperty("PrivateEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpoint, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.PrivateEndpointPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionState = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateLinkServiceConnectionStateProperty) content.GetValueForProperty("PrivateLinkServiceConnectionState",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionState, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateLinkServiceConnectionStatePropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateEndpointProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateEndpointProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateStatus = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateStatus) content.GetValueForProperty("PrivateLinkServiceConnectionStateStatus",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateStatus, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpointId = (string) content.GetValueForProperty("PrivateEndpointId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateEndpointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateDescription = (string) content.GetValueForProperty("PrivateLinkServiceConnectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateActionsRequired = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateActionsRequire?) content.GetValueForProperty("PrivateLinkServiceConnectionStateActionsRequired",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnectionInternal)this).PrivateLinkServiceConnectionStateActionsRequired, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PrivateLinkServiceConnectionStateActionsRequire.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A private endpoint connection under a server
    [System.ComponentModel.TypeConverter(typeof(ServerPrivateEndpointConnectionTypeConverter))]
    public partial interface IServerPrivateEndpointConnection

    {

    }
}