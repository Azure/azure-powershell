namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>DetectorResponse resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(DetectorResponsePropertiesTypeConverter))]
    public partial class DetectorResponseProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DetectorResponseProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DetectorResponseProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DetectorResponseProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Dataset = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[]) content.GetValueForProperty("Dataset",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Dataset, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticDataTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataDescription = (string) content.GetValueForProperty("MetadataDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataCategory = (string) content.GetValueForProperty("MetadataCategory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSubCategory = (string) content.GetValueForProperty("MetadataSubCategory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSubCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSupportTopicId = (string) content.GetValueForProperty("MetadataSupportTopicId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSupportTopicId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DetectorResponseProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorInfo) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Dataset = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData[]) content.GetValueForProperty("Dataset",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).Dataset, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticDataTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataDescription = (string) content.GetValueForProperty("MetadataDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataCategory = (string) content.GetValueForProperty("MetadataCategory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSubCategory = (string) content.GetValueForProperty("MetadataSubCategory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSubCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSupportTopicId = (string) content.GetValueForProperty("MetadataSupportTopicId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponsePropertiesInternal)this).MetadataSupportTopicId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DetectorResponseProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorResponseProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// DetectorResponse resource specific properties
    [System.ComponentModel.TypeConverter(typeof(DetectorResponsePropertiesTypeConverter))]
    public partial interface IDetectorResponseProperties

    {

    }
}