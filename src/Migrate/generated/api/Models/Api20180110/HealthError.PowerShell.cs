namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Health Error</summary>
    [System.ComponentModel.TypeConverter(typeof(HealthErrorTypeConverter))]
    public partial class HealthError
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HealthError(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HealthError(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HealthError" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HealthError(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).InnerHealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError[]) content.GetValueForProperty("InnerHealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).InnerHealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InnerHealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorSource = (string) content.GetValueForProperty("ErrorSource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorSource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorType = (string) content.GetValueForProperty("ErrorType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorLevel = (string) content.GetValueForProperty("ErrorLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCategory = (string) content.GetValueForProperty("ErrorCategory",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).SummaryMessage = (string) content.GetValueForProperty("SummaryMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).SummaryMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).PossibleCaus = (string) content.GetValueForProperty("PossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).PossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecommendedAction = (string) content.GetValueForProperty("RecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecommendedAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).CreationTimeUtc = (global::System.DateTime?) content.GetValueForProperty("CreationTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).CreationTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecoveryProviderErrorMessage = (string) content.GetValueForProperty("RecoveryProviderErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecoveryProviderErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).EntityId = (string) content.GetValueForProperty("EntityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).EntityId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HealthError(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).InnerHealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError[]) content.GetValueForProperty("InnerHealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).InnerHealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InnerHealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorSource = (string) content.GetValueForProperty("ErrorSource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorSource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorType = (string) content.GetValueForProperty("ErrorType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorLevel = (string) content.GetValueForProperty("ErrorLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCategory = (string) content.GetValueForProperty("ErrorCategory",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).SummaryMessage = (string) content.GetValueForProperty("SummaryMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).SummaryMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).PossibleCaus = (string) content.GetValueForProperty("PossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).PossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecommendedAction = (string) content.GetValueForProperty("RecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecommendedAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).CreationTimeUtc = (global::System.DateTime?) content.GetValueForProperty("CreationTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).CreationTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecoveryProviderErrorMessage = (string) content.GetValueForProperty("RecoveryProviderErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).RecoveryProviderErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).EntityId = (string) content.GetValueForProperty("EntityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorInternal)this).EntityId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Health Error
    [System.ComponentModel.TypeConverter(typeof(HealthErrorTypeConverter))]
    public partial interface IHealthError

    {

    }
}