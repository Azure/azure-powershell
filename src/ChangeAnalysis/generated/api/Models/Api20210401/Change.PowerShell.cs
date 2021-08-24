namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.PowerShell;

    /// <summary>The detected change.</summary>
    [System.ComponentModel.TypeConverter(typeof(ChangeTypeConverter))]
    public partial class Change
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.Change"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Change(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ChangeType = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType?) content.GetValueForProperty("ChangeType",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ChangeType, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).TimeStamp = (global::System.DateTime?) content.GetValueForProperty("TimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).TimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).InitiatedByList = (string[]) content.GetValueForProperty("InitiatedByList",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).InitiatedByList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).PropertyChange = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[]) content.GetValueForProperty("PropertyChange",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).PropertyChange, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange>(__y, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChangeTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.Change"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Change(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ChangeType = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType?) content.GetValueForProperty("ChangeType",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ChangeType, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).TimeStamp = (global::System.DateTime?) content.GetValueForProperty("TimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).TimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).InitiatedByList = (string[]) content.GetValueForProperty("InitiatedByList",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).InitiatedByList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).PropertyChange = (Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[]) content.GetValueForProperty("PropertyChange",((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal)this).PropertyChange, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange>(__y, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.PropertyChangeTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.Change"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Change(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.Change"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Change(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Change" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The detected change.
    [System.ComponentModel.TypeConverter(typeof(ChangeTypeConverter))]
    public partial interface IChange

    {

    }
}