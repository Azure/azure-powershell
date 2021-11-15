namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.PowerShell;

    /// <summary>The error detail.</summary>
    [System.ComponentModel.TypeConverter(typeof(ErrorDetailTypeConverter))]
    public partial class ErrorDetail
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ErrorDetail(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ErrorDetail(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ErrorDetail(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).AdditionalInfo = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorAdditionalInfo[]) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).AdditionalInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorDetailTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorDetail"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ErrorDetail(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).AdditionalInfo = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorAdditionalInfo[]) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).AdditionalInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetailInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ErrorDetailTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorDetail" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IErrorDetail FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The error detail.
    [System.ComponentModel.TypeConverter(typeof(ErrorDetailTypeConverter))]
    public partial interface IErrorDetail

    {

    }
}