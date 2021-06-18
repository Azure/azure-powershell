namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Restore target info for Item level restore operation</summary>
    [System.ComponentModel.TypeConverter(typeof(ItemLevelRestoreTargetInfoTypeConverter))]
    public partial class ItemLevelRestoreTargetInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ItemLevelRestoreTargetInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ItemLevelRestoreTargetInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ItemLevelRestoreTargetInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ItemLevelRestoreTargetInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).RestoreCriterion = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria[]) content.GetValueForProperty("RestoreCriterion",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).RestoreCriterion, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreCriteriaTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource) content.GetValueForProperty("DatasourceInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DatasourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceSetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet) content.GetValueForProperty("DatasourceSetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceSetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DatasourceSetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption = (string) content.GetValueForProperty("RecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation = (string) content.GetValueForProperty("RestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreTargetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ItemLevelRestoreTargetInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).RestoreCriterion = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria[]) content.GetValueForProperty("RestoreCriterion",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).RestoreCriterion, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreCriteriaTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource) content.GetValueForProperty("DatasourceInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DatasourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceSetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet) content.GetValueForProperty("DatasourceSetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreTargetInfoInternal)this).DatasourceSetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DatasourceSetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption = (string) content.GetValueForProperty("RecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation = (string) content.GetValueForProperty("RestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal)this).RestoreLocation, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Restore target info for Item level restore operation
    [System.ComponentModel.TypeConverter(typeof(ItemLevelRestoreTargetInfoTypeConverter))]
    public partial interface IItemLevelRestoreTargetInfo

    {

    }
}