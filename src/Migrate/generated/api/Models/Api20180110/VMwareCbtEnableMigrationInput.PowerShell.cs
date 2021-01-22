namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>VMwareCbt specific enable migration input.</summary>
    [System.ComponentModel.TypeConverter(typeof(VMwareCbtEnableMigrationInputTypeConverter))]
    public partial class VMwareCbtEnableMigrationInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtEnableMigrationInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VMwareCbtEnableMigrationInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtEnableMigrationInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VMwareCbtEnableMigrationInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VMwareCbtEnableMigrationInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtEnableMigrationInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VMwareCbtEnableMigrationInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).VmwareMachineId = (string) content.GetValueForProperty("VmwareMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).VmwareMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DisksToInclude = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]) content.GetValueForProperty("DisksToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DisksToInclude, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtDiskInputTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).LicenseType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType?) content.GetValueForProperty("LicenseType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).LicenseType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DataMoverRunAsAccountId = (string) content.GetValueForProperty("DataMoverRunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DataMoverRunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).SnapshotRunAsAccountId = (string) content.GetValueForProperty("SnapshotRunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).SnapshotRunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMName = (string) content.GetValueForProperty("TargetVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMSize = (string) content.GetValueForProperty("TargetVMSize",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetResourceGroupId = (string) content.GetValueForProperty("TargetResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetNetworkId = (string) content.GetValueForProperty("TargetNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetSubnetName = (string) content.GetValueForProperty("TargetSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilitySetId = (string) content.GetValueForProperty("TargetAvailabilitySetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilitySetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilityZone = (string) content.GetValueForProperty("TargetAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilityZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetBootDiagnosticsStorageAccountId = (string) content.GetValueForProperty("TargetBootDiagnosticsStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetBootDiagnosticsStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).PerformAutoResync = (string) content.GetValueForProperty("PerformAutoResync",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).PerformAutoResync, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtEnableMigrationInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VMwareCbtEnableMigrationInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).VmwareMachineId = (string) content.GetValueForProperty("VmwareMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).VmwareMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DisksToInclude = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput[]) content.GetValueForProperty("DisksToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DisksToInclude, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtDiskInput>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtDiskInputTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).LicenseType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType?) content.GetValueForProperty("LicenseType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).LicenseType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DataMoverRunAsAccountId = (string) content.GetValueForProperty("DataMoverRunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).DataMoverRunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).SnapshotRunAsAccountId = (string) content.GetValueForProperty("SnapshotRunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).SnapshotRunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMName = (string) content.GetValueForProperty("TargetVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMSize = (string) content.GetValueForProperty("TargetVMSize",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetVMSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetResourceGroupId = (string) content.GetValueForProperty("TargetResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetNetworkId = (string) content.GetValueForProperty("TargetNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetSubnetName = (string) content.GetValueForProperty("TargetSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilitySetId = (string) content.GetValueForProperty("TargetAvailabilitySetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilitySetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilityZone = (string) content.GetValueForProperty("TargetAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetAvailabilityZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetBootDiagnosticsStorageAccountId = (string) content.GetValueForProperty("TargetBootDiagnosticsStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).TargetBootDiagnosticsStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).PerformAutoResync = (string) content.GetValueForProperty("PerformAutoResync",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtEnableMigrationInputInternal)this).PerformAutoResync, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableMigrationProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// VMwareCbt specific enable migration input.
    [System.ComponentModel.TypeConverter(typeof(VMwareCbtEnableMigrationInputTypeConverter))]
    public partial interface IVMwareCbtEnableMigrationInput

    {

    }
}