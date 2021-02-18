namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Site health summary model.</summary>
    [System.ComponentModel.TypeConverter(typeof(SiteHealthSummaryTypeConverter))]
    public partial class SiteHealthSummary
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteHealthSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SiteHealthSummary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteHealthSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SiteHealthSummary(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SiteHealthSummary" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteHealthSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SiteHealthSummary(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ApplianceName = (string) content.GetValueForProperty("ApplianceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ApplianceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).SummaryMessage = (string) content.GetValueForProperty("SummaryMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).SummaryMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorId = (long?) content.GetValueForProperty("ErrorId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorId, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedObjectsCount = (long?) content.GetValueForProperty("AffectedObjectsCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedObjectsCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).HitCount = (long?) content.GetValueForProperty("HitCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).HitCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).Severity = (string) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).Severity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).RemediationGuidance = (string) content.GetValueForProperty("RemediationGuidance",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).RemediationGuidance, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResourceType = (string) content.GetValueForProperty("AffectedResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResource = (string[]) content.GetValueForProperty("AffectedResource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResource, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteHealthSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SiteHealthSummary(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ApplianceName = (string) content.GetValueForProperty("ApplianceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ApplianceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).SummaryMessage = (string) content.GetValueForProperty("SummaryMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).SummaryMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorId = (long?) content.GetValueForProperty("ErrorId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorId, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedObjectsCount = (long?) content.GetValueForProperty("AffectedObjectsCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedObjectsCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).HitCount = (long?) content.GetValueForProperty("HitCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).HitCount, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).Severity = (string) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).Severity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).RemediationGuidance = (string) content.GetValueForProperty("RemediationGuidance",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).RemediationGuidance, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResourceType = (string) content.GetValueForProperty("AffectedResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResource = (string[]) content.GetValueForProperty("AffectedResource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal)this).AffectedResource, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Site health summary model.
    [System.ComponentModel.TypeConverter(typeof(SiteHealthSummaryTypeConverter))]
    public partial interface ISiteHealthSummary

    {

    }
}