namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Class encapsulating restore target parameters</summary>
    [System.ComponentModel.TypeConverter(typeof(RestoreTargetInfoTypeConverter))]
    public partial class RestoreTargetInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfo"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RestoreTargetInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfo"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RestoreTargetInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RestoreTargetInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RestoreTargetInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDatasource) content.GetValueForProperty("DatasourceInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DatasourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDatasourceSet) content.GetValueForProperty("DatasourceSetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DatasourceSetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RecoveryOption = (string) content.GetValueForProperty("RecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RestoreLocation = (string) content.GetValueForProperty("RestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RestoreLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoDatasourceType = (string) content.GetValueForProperty("DatasourceInfoDatasourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoDatasourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoObjectType = (string) content.GetValueForProperty("DatasourceInfoObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceId = (string) content.GetValueForProperty("DatasourceInfoResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceLocation = (string) content.GetValueForProperty("DatasourceInfoResourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceName = (string) content.GetValueForProperty("DatasourceInfoResourceName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceType = (string) content.GetValueForProperty("DatasourceInfoResourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceUri = (string) content.GetValueForProperty("DatasourceInfoResourceUri",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoDatasourceType = (string) content.GetValueForProperty("DatasourceSetInfoDatasourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoDatasourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoObjectType = (string) content.GetValueForProperty("DatasourceSetInfoObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceId = (string) content.GetValueForProperty("DatasourceSetInfoResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceLocation = (string) content.GetValueForProperty("DatasourceSetInfoResourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceName = (string) content.GetValueForProperty("DatasourceSetInfoResourceName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceType = (string) content.GetValueForProperty("DatasourceSetInfoResourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceUri = (string) content.GetValueForProperty("DatasourceSetInfoResourceUri",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceUri, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.RestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RestoreTargetInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDatasource) content.GetValueForProperty("DatasourceInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DatasourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDatasourceSet) content.GetValueForProperty("DatasourceSetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DatasourceSetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RecoveryOption = (string) content.GetValueForProperty("RecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RestoreLocation = (string) content.GetValueForProperty("RestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoBaseInternal)this).RestoreLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoDatasourceType = (string) content.GetValueForProperty("DatasourceInfoDatasourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoDatasourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoObjectType = (string) content.GetValueForProperty("DatasourceInfoObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceId = (string) content.GetValueForProperty("DatasourceInfoResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceLocation = (string) content.GetValueForProperty("DatasourceInfoResourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceName = (string) content.GetValueForProperty("DatasourceInfoResourceName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceType = (string) content.GetValueForProperty("DatasourceInfoResourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceUri = (string) content.GetValueForProperty("DatasourceInfoResourceUri",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceInfoResourceUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoDatasourceType = (string) content.GetValueForProperty("DatasourceSetInfoDatasourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoDatasourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoObjectType = (string) content.GetValueForProperty("DatasourceSetInfoObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceId = (string) content.GetValueForProperty("DatasourceSetInfoResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceLocation = (string) content.GetValueForProperty("DatasourceSetInfoResourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceName = (string) content.GetValueForProperty("DatasourceSetInfoResourceName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceType = (string) content.GetValueForProperty("DatasourceSetInfoResourceType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceUri = (string) content.GetValueForProperty("DatasourceSetInfoResourceUri",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreTargetInfoInternal)this).DatasourceSetInfoResourceUri, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class encapsulating restore target parameters
    [System.ComponentModel.TypeConverter(typeof(RestoreTargetInfoTypeConverter))]
    public partial interface IRestoreTargetInfo

    {

    }
}