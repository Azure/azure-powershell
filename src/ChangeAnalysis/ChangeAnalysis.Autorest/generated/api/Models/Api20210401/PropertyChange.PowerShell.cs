namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.PowerShell;

    /// <summary>Data of a property change.</summary>
    [System.ComponentModel.TypeConverter(typeof(PropertyChangeTypeConverter))]
    public partial class PropertyChange
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChange"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PropertyChange(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChange"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PropertyChange(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PropertyChange" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChange"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PropertyChange(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeType = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType?) content.GetValueForProperty("ChangeType",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeType, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeCategory = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory?) content.GetValueForProperty("ChangeCategory",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeCategory, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).JsonPath = (string) content.GetValueForProperty("JsonPath",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).JsonPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Level = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level?) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Level, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).OldValue = (string) content.GetValueForProperty("OldValue",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).OldValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).NewValue = (string) content.GetValueForProperty("NewValue",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).NewValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).IsDataMasked = (bool?) content.GetValueForProperty("IsDataMasked",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).IsDataMasked, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChange"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PropertyChange(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeType = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType?) content.GetValueForProperty("ChangeType",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeType, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeCategory = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory?) content.GetValueForProperty("ChangeCategory",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).ChangeCategory, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).JsonPath = (string) content.GetValueForProperty("JsonPath",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).JsonPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Level = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level?) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Level, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.Level.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).OldValue = (string) content.GetValueForProperty("OldValue",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).OldValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).NewValue = (string) content.GetValueForProperty("NewValue",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).NewValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).IsDataMasked = (bool?) content.GetValueForProperty("IsDataMasked",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChangeInternal)this).IsDataMasked, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Data of a property change.
    [System.ComponentModel.TypeConverter(typeof(PropertyChangeTypeConverter))]
    public partial interface IPropertyChange

    {

    }
}