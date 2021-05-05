namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>
    /// Error object used by layers that have access to localized content, and propagate that to user
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(UserFacingErrorTypeConverter))]
    public partial class UserFacingError
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UserFacingError(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UserFacingError(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UserFacingError" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UserFacingError(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).InnerError = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IInnerError) content.GetValueForProperty("InnerError",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).InnerError, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.InnerErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsRetryable = (bool?) content.GetValueForProperty("IsRetryable",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsRetryable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsUserError = (bool?) content.GetValueForProperty("IsUserError",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsUserError, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingErrorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).RecommendedAction = (string[]) content.GetValueForProperty("RecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).RecommendedAction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Target, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UserFacingError(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).InnerError = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IInnerError) content.GetValueForProperty("InnerError",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).InnerError, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.InnerErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsRetryable = (bool?) content.GetValueForProperty("IsRetryable",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsRetryable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsUserError = (bool?) content.GetValueForProperty("IsUserError",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).IsUserError, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingErrorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).RecommendedAction = (string[]) content.GetValueForProperty("RecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).RecommendedAction, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingErrorInternal)this).Target, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Error object used by layers that have access to localized content, and propagate that to user
    [System.ComponentModel.TypeConverter(typeof(UserFacingErrorTypeConverter))]
    public partial interface IUserFacingError

    {

    }
}