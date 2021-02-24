namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Class encapsulating restore as files target parameters</summary>
    [System.ComponentModel.TypeConverter(typeof(RestoreFilesTargetInfoTypeConverter))]
    public partial class RestoreFilesTargetInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreFilesTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfo"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RestoreFilesTargetInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreFilesTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfo"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RestoreFilesTargetInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RestoreFilesTargetInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreFilesTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RestoreFilesTargetInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetail = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetDetails) content.GetValueForProperty("TargetDetail",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetail, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.TargetDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption = (string) content.GetValueForProperty("RecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation = (string) content.GetValueForProperty("RestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailFilePrefix = (string) content.GetValueForProperty("TargetDetailFilePrefix",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailFilePrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailUrl = (string) content.GetValueForProperty("TargetDetailUrl",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailRestoreTargetLocationType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType) content.GetValueForProperty("TargetDetailRestoreTargetLocationType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailRestoreTargetLocationType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreFilesTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RestoreFilesTargetInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetail = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetDetails) content.GetValueForProperty("TargetDetail",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetail, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.TargetDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption = (string) content.GetValueForProperty("RecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation = (string) content.GetValueForProperty("RestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailFilePrefix = (string) content.GetValueForProperty("TargetDetailFilePrefix",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailFilePrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailUrl = (string) content.GetValueForProperty("TargetDetailUrl",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailRestoreTargetLocationType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType) content.GetValueForProperty("TargetDetailRestoreTargetLocationType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreFilesTargetInfoInternal)this).TargetDetailRestoreTargetLocationType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class encapsulating restore as files target parameters
    [System.ComponentModel.TypeConverter(typeof(RestoreFilesTargetInfoTypeConverter))]
    public partial interface IRestoreFilesTargetInfo

    {

    }
}