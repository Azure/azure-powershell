namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.PowerShell;

    /// <summary>SecurityProfile - Specifies the security settings for the virtual machine.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualMachinePropertiesSecurityProfileTypeConverter))]
    public partial class VirtualMachinePropertiesSecurityProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualMachinePropertiesSecurityProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualMachinePropertiesSecurityProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualMachinePropertiesSecurityProfile" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualMachinePropertiesSecurityProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSetting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings) content.GetValueForProperty("UefiSetting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSetting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfileUefiSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).EnableTpm = (bool?) content.GetValueForProperty("EnableTpm",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).EnableTpm, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSettingSecureBootEnabled = (bool?) content.GetValueForProperty("UefiSettingSecureBootEnabled",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSettingSecureBootEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualMachinePropertiesSecurityProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSetting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings) content.GetValueForProperty("UefiSetting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSetting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfileUefiSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).EnableTpm = (bool?) content.GetValueForProperty("EnableTpm",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).EnableTpm, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSettingSecureBootEnabled = (bool?) content.GetValueForProperty("UefiSettingSecureBootEnabled",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)this).UefiSettingSecureBootEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }
    }
    /// SecurityProfile - Specifies the security settings for the virtual machine.
    [System.ComponentModel.TypeConverter(typeof(VirtualMachinePropertiesSecurityProfileTypeConverter))]
    public partial interface IVirtualMachinePropertiesSecurityProfile

    {

    }
}