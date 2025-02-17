// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Terraform.Runtime.PowerShell;

    /// <summary>The status of the LRO operation.</summary>
    [System.ComponentModel.TypeConverter(typeof(OperationStatusTypeConverter))]
    public partial class OperationStatus
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.OperationStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OperationStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.OperationStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OperationStatus(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OperationStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="OperationStatus" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Terraform.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.OperationStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OperationStatus(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IExportResult) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ExportResultTypeConverter.ConvertFrom);
            }
            if (content.Contains("Error"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorDetailTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).ResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("StartTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("EndTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("PercentComplete"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).PercentComplete = (double?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).PercentComplete, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("Configuration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Configuration = (string) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Configuration, global::System.Convert.ToString);
            }
            if (content.Contains("SkippedResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).SkippedResource = (System.Collections.Generic.List<string>) content.GetValueForProperty("SkippedResource",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).SkippedResource, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Errors"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Errors = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>) content.GetValueForProperty("Errors",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Errors, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorDetailTypeConverter.ConvertFrom));
            }
            if (content.Contains("Code"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Code, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("Target"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Target, global::System.Convert.ToString);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Detail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Detail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorDetailTypeConverter.ConvertFrom));
            }
            if (content.Contains("AdditionalInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).AdditionalInfo = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorAdditionalInfo>) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).AdditionalInfo, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.OperationStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OperationStatus(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IExportResult) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ExportResultTypeConverter.ConvertFrom);
            }
            if (content.Contains("Error"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorDetailTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).ResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("StartTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("EndTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("PercentComplete"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).PercentComplete = (double?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).PercentComplete, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("Configuration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Configuration = (string) content.GetValueForProperty("Configuration",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Configuration, global::System.Convert.ToString);
            }
            if (content.Contains("SkippedResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).SkippedResource = (System.Collections.Generic.List<string>) content.GetValueForProperty("SkippedResource",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).SkippedResource, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Errors"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Errors = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>) content.GetValueForProperty("Errors",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Errors, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorDetailTypeConverter.ConvertFrom));
            }
            if (content.Contains("Code"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Code, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("Target"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Target, global::System.Convert.ToString);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Detail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).Detail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorDetailTypeConverter.ConvertFrom));
            }
            if (content.Contains("AdditionalInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).AdditionalInfo = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorAdditionalInfo>) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatusInternal)this).AdditionalInfo, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Terraform.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The status of the LRO operation.
    [System.ComponentModel.TypeConverter(typeof(OperationStatusTypeConverter))]
    public partial interface IOperationStatus

    {

    }
}