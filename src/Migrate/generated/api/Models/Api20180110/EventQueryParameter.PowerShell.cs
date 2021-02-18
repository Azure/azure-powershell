namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Implements the event query parameter.</summary>
    [System.ComponentModel.TypeConverter(typeof(EventQueryParameterTypeConverter))]
    public partial class EventQueryParameter
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventQueryParameter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameter DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EventQueryParameter(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventQueryParameter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameter DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EventQueryParameter(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventQueryParameter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EventQueryParameter(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventCode = (string) content.GetValueForProperty("EventCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).Severity = (string) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).Severity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventType = (string) content.GetValueForProperty("EventType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).FabricName = (string) content.GetValueForProperty("FabricName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).FabricName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectFriendlyName = (string) content.GetValueForProperty("AffectedObjectFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectCorrelationId = (string) content.GetValueForProperty("AffectedObjectCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventQueryParameter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EventQueryParameter(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventCode = (string) content.GetValueForProperty("EventCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).Severity = (string) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).Severity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventType = (string) content.GetValueForProperty("EventType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EventType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).FabricName = (string) content.GetValueForProperty("FabricName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).FabricName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectFriendlyName = (string) content.GetValueForProperty("AffectedObjectFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectCorrelationId = (string) content.GetValueForProperty("AffectedObjectCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).AffectedObjectCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameterInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EventQueryParameter" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventQueryParameter FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Implements the event query parameter.
    [System.ComponentModel.TypeConverter(typeof(EventQueryParameterTypeConverter))]
    public partial interface IEventQueryParameter

    {

    }
}