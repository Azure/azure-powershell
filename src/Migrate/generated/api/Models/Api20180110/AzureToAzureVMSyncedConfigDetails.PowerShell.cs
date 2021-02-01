namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Azure to Azure VM synced configuration details.</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureToAzureVMSyncedConfigDetailsTypeConverter))]
    public partial class AzureToAzureVMSyncedConfigDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureToAzureVMSyncedConfigDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).RoleAssignment = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[]) content.GetValueForProperty("RoleAssignment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).RoleAssignment, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RoleAssignmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).InputEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[]) content.GetValueForProperty("InputEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).InputEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InputEndpointTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureToAzureVMSyncedConfigDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).RoleAssignment = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[]) content.GetValueForProperty("RoleAssignment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).RoleAssignment, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RoleAssignmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).InputEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[]) content.GetValueForProperty("InputEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsInternal)this).InputEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InputEndpointTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureToAzureVMSyncedConfigDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureToAzureVMSyncedConfigDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureToAzureVMSyncedConfigDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Azure to Azure VM synced configuration details.
    [System.ComponentModel.TypeConverter(typeof(AzureToAzureVMSyncedConfigDetailsTypeConverter))]
    public partial interface IAzureToAzureVMSyncedConfigDetails

    {

    }
}