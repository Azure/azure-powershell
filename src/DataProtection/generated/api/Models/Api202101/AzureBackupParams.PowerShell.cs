namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Azure backup parameters</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureBackupParamsTypeConverter))]
    public partial class AzureBackupParams
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupParams"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureBackupParams(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParamsInternal)this).BackupType = (string) content.GetValueForProperty("BackupType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParamsInternal)this).BackupType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParametersInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParametersInternal)this).ObjectType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupParams"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureBackupParams(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParamsInternal)this).BackupType = (string) content.GetValueForProperty("BackupType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParamsInternal)this).BackupType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParametersInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupParametersInternal)this).ObjectType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupParams"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParams" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParams DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureBackupParams(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupParams"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParams" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParams DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureBackupParams(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureBackupParams" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupParams FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Azure backup parameters
    [System.ComponentModel.TypeConverter(typeof(AzureBackupParamsTypeConverter))]
    public partial interface IAzureBackupParams

    {

    }
}