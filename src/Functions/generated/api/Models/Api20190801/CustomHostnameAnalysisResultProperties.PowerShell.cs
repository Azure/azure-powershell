namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>CustomHostnameAnalysisResult resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(CustomHostnameAnalysisResultPropertiesTypeConverter))]
    public partial class CustomHostnameAnalysisResultProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CustomHostnameAnalysisResultProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfo = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) content.GetValueForProperty("CustomDomainVerificationFailureInfo",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfo, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ARecord = (string[]) content.GetValueForProperty("ARecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ARecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateCNameRecord = (string[]) content.GetValueForProperty("AlternateCNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateCNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateTxtRecord = (string[]) content.GetValueForProperty("AlternateTxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateTxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CNameRecord = (string[]) content.GetValueForProperty("CNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ConflictingAppResourceId = (string) content.GetValueForProperty("ConflictingAppResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ConflictingAppResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationTest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult?) content.GetValueForProperty("CustomDomainVerificationTest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationTest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictAcrossSubscription = (bool?) content.GetValueForProperty("HasConflictAcrossSubscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictAcrossSubscription, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictOnScaleUnit = (bool?) content.GetValueForProperty("HasConflictOnScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictOnScaleUnit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).IsHostnameAlreadyVerified = (bool?) content.GetValueForProperty("IsHostnameAlreadyVerified",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).IsHostnameAlreadyVerified, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).TxtRecord = (string[]) content.GetValueForProperty("TxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).TxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoExtendedCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoExtendedCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoExtendedCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoInnerError = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoInnerError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoInnerError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessage = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessageTemplate = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessageTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessageTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoParameter = (string[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoParameter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoParameter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CustomHostnameAnalysisResultProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfo = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) content.GetValueForProperty("CustomDomainVerificationFailureInfo",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfo, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ARecord = (string[]) content.GetValueForProperty("ARecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ARecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateCNameRecord = (string[]) content.GetValueForProperty("AlternateCNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateCNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateTxtRecord = (string[]) content.GetValueForProperty("AlternateTxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).AlternateTxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CNameRecord = (string[]) content.GetValueForProperty("CNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ConflictingAppResourceId = (string) content.GetValueForProperty("ConflictingAppResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).ConflictingAppResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationTest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult?) content.GetValueForProperty("CustomDomainVerificationTest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationTest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictAcrossSubscription = (bool?) content.GetValueForProperty("HasConflictAcrossSubscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictAcrossSubscription, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictOnScaleUnit = (bool?) content.GetValueForProperty("HasConflictOnScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).HasConflictOnScaleUnit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).IsHostnameAlreadyVerified = (bool?) content.GetValueForProperty("IsHostnameAlreadyVerified",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).IsHostnameAlreadyVerified, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).TxtRecord = (string[]) content.GetValueForProperty("TxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).TxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoExtendedCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoExtendedCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoExtendedCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoInnerError = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoInnerError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoInnerError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessage = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessageTemplate = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessageTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoMessageTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoParameter = (string[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoParameter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)this).CustomDomainVerificationFailureInfoParameter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CustomHostnameAnalysisResultProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CustomHostnameAnalysisResultProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CustomHostnameAnalysisResultProperties" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// CustomHostnameAnalysisResult resource specific properties
    [System.ComponentModel.TypeConverter(typeof(CustomHostnameAnalysisResultPropertiesTypeConverter))]
    public partial interface ICustomHostnameAnalysisResultProperties

    {

    }
}