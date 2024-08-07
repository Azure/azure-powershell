// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Fleet.Runtime.PowerShell;

    /// <summary>The status of the wait duration.</summary>
    [System.ComponentModel.TypeConverter(typeof(WaitStatusTypeConverter))]
    public partial class WaitStatus
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.WaitStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WaitStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.WaitStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WaitStatus(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WaitStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="WaitStatus" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Fleet.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Runtime.SerializationMode.IncludeAll)?.ToString();

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

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.WaitStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WaitStatus(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.UpdateStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("WaitDurationInSecond"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).WaitDurationInSecond = (int?) content.GetValueForProperty("WaitDurationInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).WaitDurationInSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StatusError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusError = (Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorDetail) content.GetValueForProperty("StatusError",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusError, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.ErrorDetailTypeConverter.ConvertFrom);
            }
            if (content.Contains("StatusStartTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusStartTime = (global::System.DateTime?) content.GetValueForProperty("StatusStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("StatusCompletedTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusCompletedTime = (global::System.DateTime?) content.GetValueForProperty("StatusCompletedTime",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusCompletedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("StatusState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusState = (string) content.GetValueForProperty("StatusState",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusState, global::System.Convert.ToString);
            }
            if (content.Contains("Code"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Code, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("Target"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Target, global::System.Convert.ToString);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Detail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorDetail>) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Detail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.ErrorDetailTypeConverter.ConvertFrom));
            }
            if (content.Contains("AdditionalInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).AdditionalInfo = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorAdditionalInfo>) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).AdditionalInfo, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.WaitStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WaitStatus(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.UpdateStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("WaitDurationInSecond"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).WaitDurationInSecond = (int?) content.GetValueForProperty("WaitDurationInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).WaitDurationInSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StatusError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusError = (Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorDetail) content.GetValueForProperty("StatusError",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusError, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.ErrorDetailTypeConverter.ConvertFrom);
            }
            if (content.Contains("StatusStartTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusStartTime = (global::System.DateTime?) content.GetValueForProperty("StatusStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("StatusCompletedTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusCompletedTime = (global::System.DateTime?) content.GetValueForProperty("StatusCompletedTime",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusCompletedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("StatusState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusState = (string) content.GetValueForProperty("StatusState",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).StatusState, global::System.Convert.ToString);
            }
            if (content.Contains("Code"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Code, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("Target"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Target, global::System.Convert.ToString);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Detail = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorDetail>) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).Detail, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.ErrorDetailTypeConverter.ConvertFrom));
            }
            if (content.Contains("AdditionalInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).AdditionalInfo = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorAdditionalInfo>) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IWaitStatusInternal)this).AdditionalInfo, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }
    }
    /// The status of the wait duration.
    [System.ComponentModel.TypeConverter(typeof(WaitStatusTypeConverter))]
    public partial interface IWaitStatus

    {

    }
}