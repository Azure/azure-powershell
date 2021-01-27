namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell;

    /// <summary>A REST API operation</summary>
    [System.ComponentModel.TypeConverter(typeof(OperationTypeConverter))]
    public partial class Operation
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Operation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperation" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperation DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Operation(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Operation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperation" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperation DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Operation(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Operation" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperation FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Operation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Operation(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationDisplay) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.OperationDisplayTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.OperationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).IsDataAction = (bool?) content.GetValueForProperty("IsDataAction",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).IsDataAction, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Origin = (string) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Origin, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecification = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecification) content.GetValueForProperty("ServiceSpecification",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecification, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ServiceSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayResource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationLogSpecification = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification[]) content.GetValueForProperty("ServiceSpecificationLogSpecification",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationLogSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.LogSpecificationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationMetricSpecification = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification[]) content.GetValueForProperty("ServiceSpecificationMetricSpecification",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationMetricSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.MetricSpecificationTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Operation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Operation(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationDisplay) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.OperationDisplayTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.OperationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).IsDataAction = (bool?) content.GetValueForProperty("IsDataAction",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).IsDataAction, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Origin = (string) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).Origin, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecification = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IServiceSpecification) content.GetValueForProperty("ServiceSpecification",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecification, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ServiceSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayResource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationLogSpecification = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification[]) content.GetValueForProperty("ServiceSpecificationLogSpecification",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationLogSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ILogSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.LogSpecificationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationMetricSpecification = (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification[]) content.GetValueForProperty("ServiceSpecificationMetricSpecification",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IOperationInternal)this).ServiceSpecificationMetricSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.MetricSpecificationTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A REST API operation
    [System.ComponentModel.TypeConverter(typeof(OperationTypeConverter))]
    public partial interface IOperation

    {

    }
}