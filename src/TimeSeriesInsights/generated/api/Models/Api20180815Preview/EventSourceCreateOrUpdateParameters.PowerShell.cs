namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.PowerShell;

    /// <summary>Parameters supplied to the Create or Update Event Source operation.</summary>
    [System.ComponentModel.TypeConverter(typeof(EventSourceCreateOrUpdateParametersTypeConverter))]
    public partial class EventSourceCreateOrUpdateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventSourceCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EventSourceCreateOrUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventSourceCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EventSourceCreateOrUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventSourceCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EventSourceCreateOrUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.CreateOrUpdateTrackedResourcePropertiesTagsTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventSourceCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EventSourceCreateOrUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.CreateOrUpdateTrackedResourcePropertiesTagsTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EventSourceCreateOrUpdateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters supplied to the Create or Update Event Source operation.
    [System.ComponentModel.TypeConverter(typeof(EventSourceCreateOrUpdateParametersTypeConverter))]
    public partial interface IEventSourceCreateOrUpdateParameters

    {

    }
}