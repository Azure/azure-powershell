namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>User-defined filters to return data which will be purged from the table.</summary>
    [System.ComponentModel.TypeConverter(typeof(ComponentPurgeBodyFiltersTypeConverter))]
    public partial class ComponentPurgeBodyFilters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentPurgeBodyFilters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ComponentPurgeBodyFilters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Column = (string) content.GetValueForProperty("Column",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Column, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Operator = (string) content.GetValueForProperty("Operator",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Operator, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Value, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Key, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentPurgeBodyFilters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ComponentPurgeBodyFilters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Column = (string) content.GetValueForProperty("Column",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Column, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Operator = (string) content.GetValueForProperty("Operator",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Operator, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Value, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFiltersInternal)this).Key, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentPurgeBodyFilters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ComponentPurgeBodyFilters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentPurgeBodyFilters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ComponentPurgeBodyFilters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ComponentPurgeBodyFilters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeBodyFilters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// User-defined filters to return data which will be purged from the table.
    [System.ComponentModel.TypeConverter(typeof(ComponentPurgeBodyFiltersTypeConverter))]
    public partial interface IComponentPurgeBodyFilters

    {

    }
}