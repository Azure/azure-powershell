namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.PowerShell;

    /// <summary>Defines the resource properties for the update.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualMachineUpdatePropertiesTypeConverter))]
    public partial class VirtualMachineUpdateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualMachineUpdateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualMachineUpdateProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualMachineUpdateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualMachineUpdateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate) content.GetValueForProperty("HardwareProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.HardwareProfileUpdateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageProfileUpdateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkProfileUpdateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileVMSize = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum?) content.GetValueForProperty("HardwareProfileVMSize",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileVMSize, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileProcessor = (int?) content.GetValueForProperty("HardwareProfileProcessor",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileProcessor, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileMemoryMb = (long?) content.GetValueForProperty("HardwareProfileMemoryMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileMemoryMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfileDataDisk = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[]) content.GetValueForProperty("StorageProfileDataDisk",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfileDataDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageProfileUpdateDataDisksItemTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfileNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[]) content.GetValueForProperty("NetworkProfileNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfileNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkProfileUpdateNetworkInterfacesItemTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualMachineUpdateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHardwareProfileUpdate) content.GetValueForProperty("HardwareProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.HardwareProfileUpdateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdate) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageProfileUpdateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdate) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkProfileUpdateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileVMSize = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum?) content.GetValueForProperty("HardwareProfileVMSize",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileVMSize, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileProcessor = (int?) content.GetValueForProperty("HardwareProfileProcessor",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileProcessor, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileMemoryMb = (long?) content.GetValueForProperty("HardwareProfileMemoryMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).HardwareProfileMemoryMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfileDataDisk = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem[]) content.GetValueForProperty("StorageProfileDataDisk",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).StorageProfileDataDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageProfileUpdateDataDisksItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageProfileUpdateDataDisksItemTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfileNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem[]) content.GetValueForProperty("NetworkProfileNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineUpdatePropertiesInternal)this).NetworkProfileNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkProfileUpdateNetworkInterfacesItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkProfileUpdateNetworkInterfacesItemTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// Defines the resource properties for the update.
    [System.ComponentModel.TypeConverter(typeof(VirtualMachineUpdatePropertiesTypeConverter))]
    public partial interface IVirtualMachineUpdateProperties

    {

    }
}