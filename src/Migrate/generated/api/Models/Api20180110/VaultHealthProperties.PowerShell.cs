namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>class to define the health summary of the Vault.</summary>
    [System.ComponentModel.TypeConverter(typeof(VaultHealthPropertiesTypeConverter))]
    public partial class VaultHealthProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VaultHealthProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VaultHealthProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VaultHealthProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VaultHealthProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VaultHealthProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VaultHealthProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VaultHealthProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemsHealth = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary) content.GetValueForProperty("ProtectedItemsHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemsHealth, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricsHealth = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary) content.GetValueForProperty("FabricsHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricsHealth, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainersHealth = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary) content.GetValueForProperty("ContainersHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainersHealth, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).VaultError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("VaultError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).VaultError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthResourceCount = (int?) content.GetValueForProperty("ProtectedItemHealthResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthResourceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthIssue = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[]) content.GetValueForProperty("ProtectedItemHealthIssue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthIssue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorSummaryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthCategorizedResourceCount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) content.GetValueForProperty("ProtectedItemHealthCategorizedResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthCategorizedResourceCount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCountsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthResourceCount = (int?) content.GetValueForProperty("FabricHealthResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthResourceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthIssue = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[]) content.GetValueForProperty("FabricHealthIssue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthIssue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorSummaryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthCategorizedResourceCount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) content.GetValueForProperty("FabricHealthCategorizedResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthCategorizedResourceCount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCountsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthResourceCount = (int?) content.GetValueForProperty("ContainerHealthResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthResourceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthIssue = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[]) content.GetValueForProperty("ContainerHealthIssue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthIssue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorSummaryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthCategorizedResourceCount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) content.GetValueForProperty("ContainerHealthCategorizedResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthCategorizedResourceCount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCountsTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VaultHealthProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VaultHealthProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemsHealth = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary) content.GetValueForProperty("ProtectedItemsHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemsHealth, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricsHealth = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary) content.GetValueForProperty("FabricsHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricsHealth, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainersHealth = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary) content.GetValueForProperty("ContainersHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainersHealth, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).VaultError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("VaultError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).VaultError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthResourceCount = (int?) content.GetValueForProperty("ProtectedItemHealthResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthResourceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthIssue = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[]) content.GetValueForProperty("ProtectedItemHealthIssue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthIssue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorSummaryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthCategorizedResourceCount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) content.GetValueForProperty("ProtectedItemHealthCategorizedResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ProtectedItemHealthCategorizedResourceCount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCountsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthResourceCount = (int?) content.GetValueForProperty("FabricHealthResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthResourceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthIssue = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[]) content.GetValueForProperty("FabricHealthIssue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthIssue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorSummaryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthCategorizedResourceCount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) content.GetValueForProperty("FabricHealthCategorizedResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).FabricHealthCategorizedResourceCount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCountsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthResourceCount = (int?) content.GetValueForProperty("ContainerHealthResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthResourceCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthIssue = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[]) content.GetValueForProperty("ContainerHealthIssue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthIssue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorSummaryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthCategorizedResourceCount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) content.GetValueForProperty("ContainerHealthCategorizedResourceCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal)this).ContainerHealthCategorizedResourceCount, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCountsTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }
    }
    /// class to define the health summary of the Vault.
    [System.ComponentModel.TypeConverter(typeof(VaultHealthPropertiesTypeConverter))]
    public partial interface IVaultHealthProperties

    {

    }
}