namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.PowerShell;

    /// <summary>The properties that are associated with a Service Bus Queue output.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServiceBusQueueOutputDataSourcePropertiesTypeConverter))]
    public partial class ServiceBusQueueOutputDataSourceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServiceBusQueueOutputDataSourceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServiceBusQueueOutputDataSourceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServiceBusQueueOutputDataSourceProperties" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServiceBusQueueOutputDataSourceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).QueueName = (string) content.GetValueForProperty("QueueName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).QueueName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).PropertyColumn = (string[]) content.GetValueForProperty("PropertyColumn",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).PropertyColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).SystemPropertyColumn = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumns) content.GetValueForProperty("SystemPropertyColumn",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).SystemPropertyColumn, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumnsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).ServiceBusNamespace = (string) content.GetValueForProperty("ServiceBusNamespace",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).ServiceBusNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyName = (string) content.GetValueForProperty("SharedAccessPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyKey = (string) content.GetValueForProperty("SharedAccessPolicyKey",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).AuthenticationMode = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode?) content.GetValueForProperty("AuthenticationMode",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).AuthenticationMode, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServiceBusQueueOutputDataSourceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).QueueName = (string) content.GetValueForProperty("QueueName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).QueueName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).PropertyColumn = (string[]) content.GetValueForProperty("PropertyColumn",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).PropertyColumn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).SystemPropertyColumn = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumns) content.GetValueForProperty("SystemPropertyColumn",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)this).SystemPropertyColumn, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumnsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).ServiceBusNamespace = (string) content.GetValueForProperty("ServiceBusNamespace",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).ServiceBusNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyName = (string) content.GetValueForProperty("SharedAccessPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyKey = (string) content.GetValueForProperty("SharedAccessPolicyKey",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).SharedAccessPolicyKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).AuthenticationMode = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode?) content.GetValueForProperty("AuthenticationMode",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)this).AuthenticationMode, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties that are associated with a Service Bus Queue output.
    [System.ComponentModel.TypeConverter(typeof(ServiceBusQueueOutputDataSourcePropertiesTypeConverter))]
    public partial interface IServiceBusQueueOutputDataSourceProperties

    {

    }
}