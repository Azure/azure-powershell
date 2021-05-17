namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.PowerShell;

    /// <summary>The report for session host information.</summary>
    [System.ComponentModel.TypeConverter(typeof(SessionHostHealthCheckReportTypeConverter))]
    public partial class SessionHostHealthCheckReport
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckReport"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReport"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReport DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SessionHostHealthCheckReport(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckReport"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReport"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReport DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SessionHostHealthCheckReport(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SessionHostHealthCheckReport" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReport FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckReport"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SessionHostHealthCheckReport(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetail = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails) content.GetValueForProperty("AdditionalFailureDetail",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetail, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckFailureDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckName = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName?) content.GetValueForProperty("HealthCheckName",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckName, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckResult = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult?) content.GetValueForProperty("HealthCheckResult",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckResult, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailMessage = (string) content.GetValueForProperty("AdditionalFailureDetailMessage",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailErrorCode = (int?) content.GetValueForProperty("AdditionalFailureDetailErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailErrorCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailLastHealthCheckDateTime = (global::System.DateTime?) content.GetValueForProperty("AdditionalFailureDetailLastHealthCheckDateTime",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailLastHealthCheckDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckReport"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SessionHostHealthCheckReport(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetail = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails) content.GetValueForProperty("AdditionalFailureDetail",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetail, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckFailureDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckName = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName?) content.GetValueForProperty("HealthCheckName",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckName, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckResult = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult?) content.GetValueForProperty("HealthCheckResult",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).HealthCheckResult, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailMessage = (string) content.GetValueForProperty("AdditionalFailureDetailMessage",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailErrorCode = (int?) content.GetValueForProperty("AdditionalFailureDetailErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailErrorCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailLastHealthCheckDateTime = (global::System.DateTime?) content.GetValueForProperty("AdditionalFailureDetailLastHealthCheckDateTime",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal)this).AdditionalFailureDetailLastHealthCheckDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The report for session host information.
    [System.ComponentModel.TypeConverter(typeof(SessionHostHealthCheckReportTypeConverter))]
    public partial interface ISessionHostHealthCheckReport

    {

    }
}