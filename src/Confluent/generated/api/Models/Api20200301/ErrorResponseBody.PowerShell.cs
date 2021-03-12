namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.PowerShell;

    /// <summary>Response body of Error</summary>
    [System.ComponentModel.TypeConverter(typeof(ErrorResponseBodyTypeConverter))]
    public partial class ErrorResponseBody
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBody"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ErrorResponseBody(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBody"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ErrorResponseBody(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBody"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ErrorResponseBody(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBodyTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBody"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ErrorResponseBody(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBodyTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorResponseBody" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Response body of Error
    [System.ComponentModel.TypeConverter(typeof(ErrorResponseBodyTypeConverter))]
    public partial interface IErrorResponseBody

    {

    }
}