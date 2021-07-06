namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ThrottlingMetricTypeConverter))]
    public partial class ThrottlingMetric
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThrottlingMetric"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetric" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetric DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ThrottlingMetric(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThrottlingMetric"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetric" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetric DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ThrottlingMetric(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ThrottlingMetric" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetric FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThrottlingMetric"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ThrottlingMetric(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Limit = (long) content.GetValueForProperty("Limit",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Limit, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Interval = (global::System.TimeSpan?) content.GetValueForProperty("Interval",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Interval, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThrottlingMetric"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ThrottlingMetric(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ThrottlingMetricType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Limit = (long) content.GetValueForProperty("Limit",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Limit, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Interval = (global::System.TimeSpan?) content.GetValueForProperty("Interval",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingMetricInternal)this).Interval, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ThrottlingMetricTypeConverter))]
    public partial interface IThrottlingMetric

    {

    }
}