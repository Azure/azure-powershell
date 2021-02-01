namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>
    /// Implements InnerHealthError class. HealthError object has a list of InnerHealthErrors as child errors. InnerHealthError
    /// is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are
    /// exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as
    /// Exception -&gt; InnerException.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(InnerHealthErrorTypeConverter))]
    public partial class InnerHealthError
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InnerHealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InnerHealthError(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InnerHealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InnerHealthError(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InnerHealthError" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InnerHealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InnerHealthError(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorSource = (string) content.GetValueForProperty("ErrorSource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorSource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorType = (string) content.GetValueForProperty("ErrorType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorLevel = (string) content.GetValueForProperty("ErrorLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCategory = (string) content.GetValueForProperty("ErrorCategory",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).SummaryMessage = (string) content.GetValueForProperty("SummaryMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).SummaryMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).PossibleCaus = (string) content.GetValueForProperty("PossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).PossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecommendedAction = (string) content.GetValueForProperty("RecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecommendedAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).CreationTimeUtc = (global::System.DateTime?) content.GetValueForProperty("CreationTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).CreationTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecoveryProviderErrorMessage = (string) content.GetValueForProperty("RecoveryProviderErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecoveryProviderErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).EntityId = (string) content.GetValueForProperty("EntityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).EntityId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InnerHealthError"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InnerHealthError(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorSource = (string) content.GetValueForProperty("ErrorSource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorSource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorType = (string) content.GetValueForProperty("ErrorType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorLevel = (string) content.GetValueForProperty("ErrorLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCategory = (string) content.GetValueForProperty("ErrorCategory",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCategory, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).SummaryMessage = (string) content.GetValueForProperty("SummaryMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).SummaryMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).PossibleCaus = (string) content.GetValueForProperty("PossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).PossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecommendedAction = (string) content.GetValueForProperty("RecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecommendedAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).CreationTimeUtc = (global::System.DateTime?) content.GetValueForProperty("CreationTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).CreationTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecoveryProviderErrorMessage = (string) content.GetValueForProperty("RecoveryProviderErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).RecoveryProviderErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).EntityId = (string) content.GetValueForProperty("EntityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal)this).EntityId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Implements InnerHealthError class. HealthError object has a list of InnerHealthErrors as child errors. InnerHealthError
    /// is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are
    /// exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as
    /// Exception -&gt; InnerException.
    [System.ComponentModel.TypeConverter(typeof(InnerHealthErrorTypeConverter))]
    public partial interface IInnerHealthError

    {

    }
}