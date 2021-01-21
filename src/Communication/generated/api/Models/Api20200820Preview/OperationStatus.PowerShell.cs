namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.PowerShell;

    /// <summary>The current status of an async operation</summary>
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OperationStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OperationStatus(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OperationStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationStatus"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponse) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).PercentComplete = (float?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).PercentComplete, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).ErrorResponseError = (Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseError) content.GetValueForProperty("ErrorResponseError",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).ErrorResponseError, Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponseErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Message, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.OperationStatus"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponse) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).PercentComplete = (float?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).PercentComplete, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).ErrorResponseError = (Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseError) content.GetValueForProperty("ErrorResponseError",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).ErrorResponseError, Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponseErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal)this).Message, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The current status of an async operation
    [System.ComponentModel.TypeConverter(typeof(OperationStatusTypeConverter))]
    public partial interface IOperationStatus

    {

    }
}