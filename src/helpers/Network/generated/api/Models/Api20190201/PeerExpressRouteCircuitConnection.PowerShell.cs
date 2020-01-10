namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>
    /// Peer Express Route Circuit Connection in an ExpressRouteCircuitPeering resource.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(PeerExpressRouteCircuitConnectionTypeConverter))]
    public partial class PeerExpressRouteCircuitConnection
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PeerExpressRouteCircuitConnection(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PeerExpressRouteCircuitConnection(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PeerExpressRouteCircuitConnection" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PeerExpressRouteCircuitConnection(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnectionPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("ExpressRouteCircuitPeering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeering, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("PeerExpressRouteCircuitPeering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeering, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AddressPrefix = (string) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AuthResourceGuid = (string) content.GetValueForProperty("AuthResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AuthResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).CircuitConnectionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus?) content.GetValueForProperty("CircuitConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).CircuitConnectionStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ConnectionName = (string) content.GetValueForProperty("ConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeeringId = (string) content.GetValueForProperty("ExpressRouteCircuitPeeringId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeeringId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeeringId = (string) content.GetValueForProperty("PeerExpressRouteCircuitPeeringId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeeringId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnection"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PeerExpressRouteCircuitConnection(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnectionPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("ExpressRouteCircuitPeering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeering, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("PeerExpressRouteCircuitPeering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeering, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AddressPrefix = (string) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AuthResourceGuid = (string) content.GetValueForProperty("AuthResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).AuthResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).CircuitConnectionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus?) content.GetValueForProperty("CircuitConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).CircuitConnectionStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ConnectionName = (string) content.GetValueForProperty("ConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ConnectionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeeringId = (string) content.GetValueForProperty("ExpressRouteCircuitPeeringId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).ExpressRouteCircuitPeeringId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeeringId = (string) content.GetValueForProperty("PeerExpressRouteCircuitPeeringId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal)this).PeerExpressRouteCircuitPeeringId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Peer Express Route Circuit Connection in an ExpressRouteCircuitPeering resource.
    [System.ComponentModel.TypeConverter(typeof(PeerExpressRouteCircuitConnectionTypeConverter))]
    public partial interface IPeerExpressRouteCircuitConnection

    {

    }
}