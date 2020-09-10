namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Custom domain analysis.</summary>
    [System.ComponentModel.TypeConverter(typeof(CustomHostnameAnalysisResultTypeConverter))]
    public partial class CustomHostnameAnalysisResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CustomHostnameAnalysisResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ARecord = (string[]) content.GetValueForProperty("ARecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ARecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfo = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) content.GetValueForProperty("CustomDomainVerificationFailureInfo",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfo, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationTest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult?) content.GetValueForProperty("CustomDomainVerificationTest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationTest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictOnScaleUnit = (bool?) content.GetValueForProperty("HasConflictOnScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictOnScaleUnit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictAcrossSubscription = (bool?) content.GetValueForProperty("HasConflictAcrossSubscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictAcrossSubscription, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ConflictingAppResourceId = (string) content.GetValueForProperty("ConflictingAppResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ConflictingAppResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CNameRecord = (string[]) content.GetValueForProperty("CNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).TxtRecord = (string[]) content.GetValueForProperty("TxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).TxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).IsHostnameAlreadyVerified = (bool?) content.GetValueForProperty("IsHostnameAlreadyVerified",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).IsHostnameAlreadyVerified, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateCNameRecord = (string[]) content.GetValueForProperty("AlternateCNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateCNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateTxtRecord = (string[]) content.GetValueForProperty("AlternateTxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateTxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoExtendedCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoExtendedCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoExtendedCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessageTemplate = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessageTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessageTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoParameter = (string[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoParameter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoParameter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoInnerError = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoInnerError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoInnerError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessage = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessage, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CustomHostnameAnalysisResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ARecord = (string[]) content.GetValueForProperty("ARecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ARecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfo = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) content.GetValueForProperty("CustomDomainVerificationFailureInfo",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfo, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationTest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult?) content.GetValueForProperty("CustomDomainVerificationTest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationTest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictOnScaleUnit = (bool?) content.GetValueForProperty("HasConflictOnScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictOnScaleUnit, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictAcrossSubscription = (bool?) content.GetValueForProperty("HasConflictAcrossSubscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).HasConflictAcrossSubscription, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ConflictingAppResourceId = (string) content.GetValueForProperty("ConflictingAppResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).ConflictingAppResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CNameRecord = (string[]) content.GetValueForProperty("CNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).TxtRecord = (string[]) content.GetValueForProperty("TxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).TxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).IsHostnameAlreadyVerified = (bool?) content.GetValueForProperty("IsHostnameAlreadyVerified",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).IsHostnameAlreadyVerified, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateCNameRecord = (string[]) content.GetValueForProperty("AlternateCNameRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateCNameRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateTxtRecord = (string[]) content.GetValueForProperty("AlternateTxtRecord",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).AlternateTxtRecord, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoExtendedCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoExtendedCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoExtendedCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessageTemplate = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessageTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessageTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoParameter = (string[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoParameter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoParameter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoInnerError = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[]) content.GetValueForProperty("CustomDomainVerificationFailureInfoInnerError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoInnerError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoCode = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessage = (string) content.GetValueForProperty("CustomDomainVerificationFailureInfoMessage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal)this).CustomDomainVerificationFailureInfoMessage, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CustomHostnameAnalysisResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CustomHostnameAnalysisResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CustomHostnameAnalysisResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Custom domain analysis.
    [System.ComponentModel.TypeConverter(typeof(CustomHostnameAnalysisResultTypeConverter))]
    public partial interface ICustomHostnameAnalysisResult

    {

    }
}