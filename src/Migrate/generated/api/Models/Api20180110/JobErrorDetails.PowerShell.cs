namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>This class contains the error details per object.</summary>
    [System.ComponentModel.TypeConverter(typeof(JobErrorDetailsTypeConverter))]
    public partial class JobErrorDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new JobErrorDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new JobErrorDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="JobErrorDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal JobErrorDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError) content.GetValueForProperty("ServiceErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ServiceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError) content.GetValueForProperty("ProviderErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ErrorLevel = (string) content.GetValueForProperty("ErrorLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ErrorLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).CreationTime = (global::System.DateTime?) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).CreationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).TaskId = (string) content.GetValueForProperty("TaskId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).TaskId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailCode = (string) content.GetValueForProperty("ServiceErrorDetailCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailMessage = (string) content.GetValueForProperty("ServiceErrorDetailMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailPossibleCaus = (string) content.GetValueForProperty("ServiceErrorDetailPossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailPossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailRecommendedAction = (string) content.GetValueForProperty("ServiceErrorDetailRecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailRecommendedAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailActivityId = (string) content.GetValueForProperty("ServiceErrorDetailActivityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailActivityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorCode = (int?) content.GetValueForProperty("ProviderErrorDetailErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorMessage = (string) content.GetValueForProperty("ProviderErrorDetailErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorId = (string) content.GetValueForProperty("ProviderErrorDetailErrorId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailPossibleCaus = (string) content.GetValueForProperty("ProviderErrorDetailPossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailPossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailRecommendedAction = (string) content.GetValueForProperty("ProviderErrorDetailRecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailRecommendedAction, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobErrorDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal JobErrorDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError) content.GetValueForProperty("ServiceErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ServiceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError) content.GetValueForProperty("ProviderErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ErrorLevel = (string) content.GetValueForProperty("ErrorLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ErrorLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).CreationTime = (global::System.DateTime?) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).CreationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).TaskId = (string) content.GetValueForProperty("TaskId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).TaskId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailCode = (string) content.GetValueForProperty("ServiceErrorDetailCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailMessage = (string) content.GetValueForProperty("ServiceErrorDetailMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailPossibleCaus = (string) content.GetValueForProperty("ServiceErrorDetailPossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailPossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailRecommendedAction = (string) content.GetValueForProperty("ServiceErrorDetailRecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailRecommendedAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailActivityId = (string) content.GetValueForProperty("ServiceErrorDetailActivityId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ServiceErrorDetailActivityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorCode = (int?) content.GetValueForProperty("ProviderErrorDetailErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorMessage = (string) content.GetValueForProperty("ProviderErrorDetailErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorId = (string) content.GetValueForProperty("ProviderErrorDetailErrorId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailErrorId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailPossibleCaus = (string) content.GetValueForProperty("ProviderErrorDetailPossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailPossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailRecommendedAction = (string) content.GetValueForProperty("ProviderErrorDetailRecommendedAction",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal)this).ProviderErrorDetailRecommendedAction, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// This class contains the error details per object.
    [System.ComponentModel.TypeConverter(typeof(JobErrorDetailsTypeConverter))]
    public partial interface IJobErrorDetails

    {

    }
}