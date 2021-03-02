namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(DimensionPropertiesTypeConverter))]
    public partial class DimensionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.DimensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DimensionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.DimensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DimensionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.DimensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DimensionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).FilterEnabled = (bool?) content.GetValueForProperty("FilterEnabled",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).FilterEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).GroupingEnabled = (bool?) content.GetValueForProperty("GroupingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).GroupingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Data = (string[]) content.GetValueForProperty("Data",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Data, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Total = (int?) content.GetValueForProperty("Total",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Total, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Category = (string) content.GetValueForProperty("Category",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Category, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageStart = (global::System.DateTime?) content.GetValueForProperty("UsageStart",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageStart, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageEnd = (global::System.DateTime?) content.GetValueForProperty("UsageEnd",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageEnd, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).NextLink, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.DimensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DimensionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).FilterEnabled = (bool?) content.GetValueForProperty("FilterEnabled",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).FilterEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).GroupingEnabled = (bool?) content.GetValueForProperty("GroupingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).GroupingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Data = (string[]) content.GetValueForProperty("Data",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Data, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Total = (int?) content.GetValueForProperty("Total",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Total, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Category = (string) content.GetValueForProperty("Category",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).Category, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageStart = (global::System.DateTime?) content.GetValueForProperty("UsageStart",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageStart, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageEnd = (global::System.DateTime?) content.GetValueForProperty("UsageEnd",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).UsageEnd, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionPropertiesInternal)this).NextLink, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DimensionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IDimensionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(DimensionPropertiesTypeConverter))]
    public partial interface IDimensionProperties

    {

    }
}