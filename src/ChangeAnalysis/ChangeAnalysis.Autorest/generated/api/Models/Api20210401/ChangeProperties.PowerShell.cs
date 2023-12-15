namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.PowerShell;

    /// <summary>The properties of a change.</summary>
    [System.ComponentModel.TypeConverter(typeof(ChangePropertiesTypeConverter))]
    public partial class ChangeProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangeProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ChangeProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).TimeStamp = (global::System.DateTime?) content.GetValueForProperty("TimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).TimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).InitiatedByList = (string[]) content.GetValueForProperty("InitiatedByList",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).InitiatedByList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ChangeType = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType?) content.GetValueForProperty("ChangeType",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ChangeType, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).PropertyChange = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[]) content.GetValueForProperty("PropertyChange",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).PropertyChange, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange>(__y, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChangeTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangeProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ChangeProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).TimeStamp = (global::System.DateTime?) content.GetValueForProperty("TimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).TimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).InitiatedByList = (string[]) content.GetValueForProperty("InitiatedByList",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).InitiatedByList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ChangeType = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType?) content.GetValueForProperty("ChangeType",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).ChangeType, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).PropertyChange = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[]) content.GetValueForProperty("PropertyChange",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)this).PropertyChange, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange>(__y, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChangeTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangeProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ChangeProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangeProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ChangeProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ChangeProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of a change.
    [System.ComponentModel.TypeConverter(typeof(ChangePropertiesTypeConverter))]
    public partial interface IChangeProperties

    {

    }
}