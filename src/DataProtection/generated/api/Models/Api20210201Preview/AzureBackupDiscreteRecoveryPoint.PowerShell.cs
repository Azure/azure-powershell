namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Azure backup discrete RecoveryPoint</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureBackupDiscreteRecoveryPointTypeConverter))]
    public partial class AzureBackupDiscreteRecoveryPoint
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureBackupDiscreteRecoveryPoint"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureBackupDiscreteRecoveryPoint(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointDataStoresDetail = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetails[]) content.GetValueForProperty("RecoveryPointDataStoresDetail",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointDataStoresDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RecoveryPointDataStoreDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointTime = (global::System.DateTime) content.GetValueForProperty("RecoveryPointTime",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyName = (string) content.GetValueForProperty("PolicyName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyVersion = (string) content.GetValueForProperty("PolicyVersion",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointType = (string) content.GetValueForProperty("RecoveryPointType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagName = (string) content.GetValueForProperty("RetentionTagName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagVersion = (string) content.GetValueForProperty("RetentionTagVersion",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointInternal)this).ObjectType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureBackupDiscreteRecoveryPoint"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureBackupDiscreteRecoveryPoint(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointDataStoresDetail = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetails[]) content.GetValueForProperty("RecoveryPointDataStoresDetail",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointDataStoresDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RecoveryPointDataStoreDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointTime = (global::System.DateTime) content.GetValueForProperty("RecoveryPointTime",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyName = (string) content.GetValueForProperty("PolicyName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyVersion = (string) content.GetValueForProperty("PolicyVersion",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).PolicyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointType = (string) content.GetValueForProperty("RecoveryPointType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RecoveryPointType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagName = (string) content.GetValueForProperty("RetentionTagName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagVersion = (string) content.GetValueForProperty("RetentionTagVersion",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPointInternal)this).RetentionTagVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointInternal)this).ObjectType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureBackupDiscreteRecoveryPoint"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPoint"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPoint DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureBackupDiscreteRecoveryPoint(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureBackupDiscreteRecoveryPoint"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPoint"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPoint DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureBackupDiscreteRecoveryPoint(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureBackupDiscreteRecoveryPoint" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupDiscreteRecoveryPoint FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Azure backup discrete RecoveryPoint
    [System.ComponentModel.TypeConverter(typeof(AzureBackupDiscreteRecoveryPointTypeConverter))]
    public partial interface IAzureBackupDiscreteRecoveryPoint

    {

    }
}