namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.PowerShell;

    /// <summary>Properties related to ServiceBus.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServiceBusTypeConverter))]
    public partial class ServiceBus
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ServiceBus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServiceBus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ServiceBus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServiceBus(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServiceBus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ServiceBus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServiceBus(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).PrimaryConnectionString = (string) content.GetValueForProperty("PrimaryConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).PrimaryConnectionString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).SecondaryConnectionString = (string) content.GetValueForProperty("SecondaryConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).SecondaryConnectionString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).EndpointType = (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType) content.GetValueForProperty("EndpointType",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).EndpointType, Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).CreatedTime = (global::System.DateTime?) content.GetValueForProperty("CreatedTime",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).CreatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).DeadLetterSecret = (string) content.GetValueForProperty("DeadLetterSecret",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).DeadLetterSecret, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ServiceBus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServiceBus(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).PrimaryConnectionString = (string) content.GetValueForProperty("PrimaryConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).PrimaryConnectionString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).SecondaryConnectionString = (string) content.GetValueForProperty("SecondaryConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IServiceBusInternal)this).SecondaryConnectionString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).EndpointType = (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType) content.GetValueForProperty("EndpointType",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).EndpointType, Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).CreatedTime = (global::System.DateTime?) content.GetValueForProperty("CreatedTime",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).CreatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).DeadLetterSecret = (string) content.GetValueForProperty("DeadLetterSecret",((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)this).DeadLetterSecret, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties related to ServiceBus.
    [System.ComponentModel.TypeConverter(typeof(ServiceBusTypeConverter))]
    public partial interface IServiceBus

    {

    }
}