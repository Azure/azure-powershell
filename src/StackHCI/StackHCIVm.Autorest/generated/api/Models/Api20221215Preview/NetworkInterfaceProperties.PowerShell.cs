namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.PowerShell;

    /// <summary>Properties under the network interface resource</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkInterfacePropertiesTypeConverter))]
    public partial class NetworkInterfaceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkInterfaceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkInterfaceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkInterfaceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkInterfaceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.InterfaceDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).MacAddress = (string) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).MacAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSettingDnsServer = (string[]) content.GetValueForProperty("DnsSettingDnsServer",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSettingDnsServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusProvisioningStatus) content.GetValueForProperty("StatusProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatusProvisioningStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorCode = (string) content.GetValueForProperty("StatusErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorMessage = (string) content.GetValueForProperty("StatusErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status?) content.GetValueForProperty("ProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatusOperationId = (string) content.GetValueForProperty("ProvisioningStatusOperationId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatusOperationId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkInterfaceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.InterfaceDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).MacAddress = (string) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).MacAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSettingDnsServer = (string[]) content.GetValueForProperty("DnsSettingDnsServer",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).DnsSettingDnsServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusProvisioningStatus) content.GetValueForProperty("StatusProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatusProvisioningStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorCode = (string) content.GetValueForProperty("StatusErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorMessage = (string) content.GetValueForProperty("StatusErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).StatusErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status?) content.GetValueForProperty("ProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatusOperationId = (string) content.GetValueForProperty("ProvisioningStatusOperationId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal)this).ProvisioningStatusOperationId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties under the network interface resource
    [System.ComponentModel.TypeConverter(typeof(NetworkInterfacePropertiesTypeConverter))]
    public partial interface INetworkInterfaceProperties

    {

    }
}