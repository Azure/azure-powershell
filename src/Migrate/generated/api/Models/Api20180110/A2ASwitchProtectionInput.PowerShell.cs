namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>A2A specific switch protection input.</summary>
    [System.ComponentModel.TypeConverter(typeof(A2ASwitchProtectionInputTypeConverter))]
    public partial class A2ASwitchProtectionInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2ASwitchProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal A2ASwitchProtectionInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo) content.GetValueForProperty("DiskEncryptionInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryContainerId = (string) content.GetValueForProperty("RecoveryContainerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryContainerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails[]) content.GetValueForProperty("VMDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AvmDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMManagedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails[]) content.GetValueForProperty("VMManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMManagedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AvmManagedDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryResourceGroupId = (string) content.GetValueForProperty("RecoveryResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryCloudServiceId = (string) content.GetValueForProperty("RecoveryCloudServiceId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryCloudServiceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryAvailabilitySetId = (string) content.GetValueForProperty("RecoveryAvailabilitySetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryAvailabilitySetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryBootDiagStorageAccountId = (string) content.GetValueForProperty("RecoveryBootDiagStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryBootDiagStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoDiskEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoKeyEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.KeyEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier = (string) content.GetValueForProperty("DiskEncryptionKeyInfoSecretIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("DiskEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2ASwitchProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal A2ASwitchProtectionInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo) content.GetValueForProperty("DiskEncryptionInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryContainerId = (string) content.GetValueForProperty("RecoveryContainerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryContainerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails[]) content.GetValueForProperty("VMDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AvmDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMManagedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails[]) content.GetValueForProperty("VMManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).VMManagedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AvmManagedDiskInputDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryResourceGroupId = (string) content.GetValueForProperty("RecoveryResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryCloudServiceId = (string) content.GetValueForProperty("RecoveryCloudServiceId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryCloudServiceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryAvailabilitySetId = (string) content.GetValueForProperty("RecoveryAvailabilitySetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryAvailabilitySetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryBootDiagStorageAccountId = (string) content.GetValueForProperty("RecoveryBootDiagStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).RecoveryBootDiagStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoDiskEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoDiskEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo) content.GetValueForProperty("DiskEncryptionInfoKeyEncryptionKeyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionInfoKeyEncryptionKeyInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.KeyEncryptionKeyInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier = (string) content.GetValueForProperty("DiskEncryptionKeyInfoSecretIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoSecretIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("DiskEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).DiskEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId = (string) content.GetValueForProperty("KeyEncryptionKeyInfoKeyVaultResourceArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal)this).KeyEncryptionKeyInfoKeyVaultResourceArmId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2ASwitchProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new A2ASwitchProtectionInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2ASwitchProtectionInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new A2ASwitchProtectionInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="A2ASwitchProtectionInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A2A specific switch protection input.
    [System.ComponentModel.TypeConverter(typeof(A2ASwitchProtectionInputTypeConverter))]
    public partial interface IA2ASwitchProtectionInput

    {

    }
}