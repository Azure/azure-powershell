namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.PowerShell;

    /// <summary>
    /// OsProfile - describes the configuration of the operating system and sets login data
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualMachinePropertiesOSProfileTypeConverter))]
    public partial class VirtualMachinePropertiesOSProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualMachinePropertiesOSProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualMachinePropertiesOSProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualMachinePropertiesOSProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualMachinePropertiesOSProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration) content.GetValueForProperty("LinuxConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfiguration, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration) content.GetValueForProperty("WindowsConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfiguration, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminPassword = (string) content.GetValueForProperty("AdminPassword",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminUsername = (string) content.GetValueForProperty("AdminUsername",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).ComputerName = (string) content.GetValueForProperty("ComputerName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).ComputerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSsh = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh) content.GetValueForProperty("LinuxConfigurationSsh",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSsh, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSshTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationDisablePasswordAuthentication = (bool?) content.GetValueForProperty("LinuxConfigurationDisablePasswordAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationDisablePasswordAuthentication, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationProvisionVMAgent = (bool?) content.GetValueForProperty("LinuxConfigurationProvisionVMAgent",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationProvisionVMAgent, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationSsh = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh) content.GetValueForProperty("WindowConfigurationSsh",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationSsh, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationSshTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationEnableAutomaticUpdate = (bool?) content.GetValueForProperty("WindowConfigurationEnableAutomaticUpdate",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationEnableAutomaticUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationTimeZone = (string) content.GetValueForProperty("WindowConfigurationTimeZone",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationTimeZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationProvisionVMAgent = (bool?) content.GetValueForProperty("WindowConfigurationProvisionVMAgent",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationProvisionVMAgent, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSshPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]) content.GetValueForProperty("LinuxConfigurationSshPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSshPublicKey, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItemTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfigurationSshPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]) content.GetValueForProperty("WindowsConfigurationSshPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfigurationSshPublicKey, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItemTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualMachinePropertiesOSProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration) content.GetValueForProperty("LinuxConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfiguration, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration) content.GetValueForProperty("WindowsConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfiguration, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminPassword = (string) content.GetValueForProperty("AdminPassword",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminUsername = (string) content.GetValueForProperty("AdminUsername",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).AdminUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).ComputerName = (string) content.GetValueForProperty("ComputerName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).ComputerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSsh = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh) content.GetValueForProperty("LinuxConfigurationSsh",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSsh, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSshTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationDisablePasswordAuthentication = (bool?) content.GetValueForProperty("LinuxConfigurationDisablePasswordAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationDisablePasswordAuthentication, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationProvisionVMAgent = (bool?) content.GetValueForProperty("LinuxConfigurationProvisionVMAgent",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationProvisionVMAgent, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationSsh = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh) content.GetValueForProperty("WindowConfigurationSsh",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationSsh, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationSshTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationEnableAutomaticUpdate = (bool?) content.GetValueForProperty("WindowConfigurationEnableAutomaticUpdate",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationEnableAutomaticUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationTimeZone = (string) content.GetValueForProperty("WindowConfigurationTimeZone",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationTimeZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationProvisionVMAgent = (bool?) content.GetValueForProperty("WindowConfigurationProvisionVMAgent",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowConfigurationProvisionVMAgent, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSshPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]) content.GetValueForProperty("LinuxConfigurationSshPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).LinuxConfigurationSshPublicKey, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItemTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfigurationSshPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]) content.GetValueForProperty("WindowsConfigurationSshPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)this).WindowsConfigurationSshPublicKey, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItemTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// OsProfile - describes the configuration of the operating system and sets login data
    [System.ComponentModel.TypeConverter(typeof(VirtualMachinePropertiesOSProfileTypeConverter))]
    public partial interface IVirtualMachinePropertiesOSProfile

    {

    }
}