namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Description of an operation available for Microsoft.Web resource provider.</summary>
    [System.ComponentModel.TypeConverter(typeof(CsmOperationDescriptionTypeConverter))]
    public partial class CsmOperationDescription
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CsmOperationDescription(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplay) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDisplayTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescriptionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Origin = (string) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Origin, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecification = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification) content.GetValueForProperty("ServiceSpecification",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecification, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ServiceSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayResource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationLogSpecification = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[]) content.GetValueForProperty("ServiceSpecificationLogSpecification",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationLogSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.LogSpecificationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationMetricSpecification = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[]) content.GetValueForProperty("ServiceSpecificationMetricSpecification",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationMetricSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MetricSpecificationTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CsmOperationDescription(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDisplay) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDisplayTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescriptionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Origin = (string) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).Origin, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecification = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IServiceSpecification) content.GetValueForProperty("ServiceSpecification",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecification, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ServiceSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).DisplayResource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationLogSpecification = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification[]) content.GetValueForProperty("ServiceSpecificationLogSpecification",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationLogSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.LogSpecificationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationMetricSpecification = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification[]) content.GetValueForProperty("ServiceSpecificationMetricSpecification",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescriptionInternal)this).ServiceSpecificationMetricSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMetricSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.MetricSpecificationTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescription" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescription DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CsmOperationDescription(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmOperationDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescription" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescription DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CsmOperationDescription(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CsmOperationDescription" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmOperationDescription FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Description of an operation available for Microsoft.Web resource provider.
    [System.ComponentModel.TypeConverter(typeof(CsmOperationDescriptionTypeConverter))]
    public partial interface ICsmOperationDescription

    {

    }
}