namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Implements the Event class.</summary>
    [System.ComponentModel.TypeConverter(typeof(EventTypeConverter))]
    public partial class Event
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Event"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEvent" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEvent DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Event(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Event"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEvent" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEvent DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Event(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Event"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Event(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectCorrelationId = (string) content.GetValueForProperty("AffectedObjectCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).EventType = (string) content.GetValueForProperty("EventType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).EventType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectFriendlyName = (string) content.GetValueForProperty("AffectedObjectFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails) content.GetValueForProperty("SpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventSpecificDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Severity = (string) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Severity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).TimeOfOccurrence = (global::System.DateTime?) content.GetValueForProperty("TimeOfOccurrence",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).TimeOfOccurrence, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).FabricId = (string) content.GetValueForProperty("FabricId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).FabricId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetailInstanceType = (string) content.GetValueForProperty("SpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Event"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Event(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectCorrelationId = (string) content.GetValueForProperty("AffectedObjectCorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectCorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).EventType = (string) content.GetValueForProperty("EventType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).EventType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectFriendlyName = (string) content.GetValueForProperty("AffectedObjectFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).AffectedObjectFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails) content.GetValueForProperty("SpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventSpecificDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Severity = (string) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).Severity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).TimeOfOccurrence = (global::System.DateTime?) content.GetValueForProperty("TimeOfOccurrence",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).TimeOfOccurrence, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).FabricId = (string) content.GetValueForProperty("FabricId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).FabricId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetailInstanceType = (string) content.GetValueForProperty("SpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).SpecificDetailInstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Event" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEvent FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Implements the Event class.
    [System.ComponentModel.TypeConverter(typeof(EventTypeConverter))]
    public partial interface IEvent

    {

    }
}