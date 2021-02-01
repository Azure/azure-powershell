namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Azure specific enable protection input.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVReplicaAzureEnableProtectionInputTypeConverter))]
    public partial class HyperVReplicaAzureEnableProtectionInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureEnableProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVReplicaAzureEnableProtectionInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureEnableProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVReplicaAzureEnableProtectionInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVReplicaAzureEnableProtectionInput" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureEnableProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVReplicaAzureEnableProtectionInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).HvHostVMId = (string) content.GetValueForProperty("HvHostVMId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).HvHostVMId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VMName = (string) content.GetValueForProperty("VMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VhdId = (string) content.GetValueForProperty("VhdId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VhdId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetStorageAccountId = (string) content.GetValueForProperty("TargetStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureNetworkId = (string) content.GetValueForProperty("TargetAzureNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureSubnetId = (string) content.GetValueForProperty("TargetAzureSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).EnableRdpOnTargetOption = (string) content.GetValueForProperty("EnableRdpOnTargetOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).EnableRdpOnTargetOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureVMName = (string) content.GetValueForProperty("TargetAzureVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).LogStorageAccountId = (string) content.GetValueForProperty("LogStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).LogStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).DisksToInclude = (string[]) content.GetValueForProperty("DisksToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).DisksToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV1ResourceGroupId = (string) content.GetValueForProperty("TargetAzureV1ResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV1ResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV2ResourceGroupId = (string) content.GetValueForProperty("TargetAzureV2ResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV2ResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).UseManagedDisk = (string) content.GetValueForProperty("UseManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).UseManagedDisk, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureEnableProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVReplicaAzureEnableProtectionInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).HvHostVMId = (string) content.GetValueForProperty("HvHostVMId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).HvHostVMId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VMName = (string) content.GetValueForProperty("VMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VhdId = (string) content.GetValueForProperty("VhdId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).VhdId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetStorageAccountId = (string) content.GetValueForProperty("TargetStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureNetworkId = (string) content.GetValueForProperty("TargetAzureNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureSubnetId = (string) content.GetValueForProperty("TargetAzureSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).EnableRdpOnTargetOption = (string) content.GetValueForProperty("EnableRdpOnTargetOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).EnableRdpOnTargetOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureVMName = (string) content.GetValueForProperty("TargetAzureVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).LogStorageAccountId = (string) content.GetValueForProperty("LogStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).LogStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).DisksToInclude = (string[]) content.GetValueForProperty("DisksToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).DisksToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV1ResourceGroupId = (string) content.GetValueForProperty("TargetAzureV1ResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV1ResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV2ResourceGroupId = (string) content.GetValueForProperty("TargetAzureV2ResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).TargetAzureV2ResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).UseManagedDisk = (string) content.GetValueForProperty("UseManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal)this).UseManagedDisk, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Azure specific enable protection input.
    [System.ComponentModel.TypeConverter(typeof(HyperVReplicaAzureEnableProtectionInputTypeConverter))]
    public partial interface IHyperVReplicaAzureEnableProtectionInput

    {

    }
}