namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of container network interface.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerNetworkInterfacePropertiesFormatTypeConverter))]
    public partial class ContainerNetworkInterfacePropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerNetworkInterfacePropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).Container = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainer) content.GetValueForProperty("Container",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).Container, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration) content.GetValueForProperty("ContainerNetworkInterfaceConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationName = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationType = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationEtag = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerId = (string) content.GetValueForProperty("ContainerId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationId = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormat) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceConfigurationPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("ContainerNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[]) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPConfigurationProfileTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesProvisioningState = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesProvisioningState, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerNetworkInterfacePropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).Container = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainer) content.GetValueForProperty("Container",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).Container, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration) content.GetValueForProperty("ContainerNetworkInterfaceConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationName = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationType = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationEtag = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerId = (string) content.GetValueForProperty("ContainerId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationId = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormat) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceConfigurationPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[]) content.GetValueForProperty("ContainerNetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[]) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPConfigurationProfileTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesProvisioningState = (string) content.GetValueForProperty("ContainerNetworkInterfaceConfigurationPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal)this).ContainerNetworkInterfaceConfigurationPropertiesProvisioningState, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerNetworkInterfacePropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerNetworkInterfacePropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerNetworkInterfacePropertiesFormat" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of container network interface.
    [System.ComponentModel.TypeConverter(typeof(ContainerNetworkInterfacePropertiesFormatTypeConverter))]
    public partial interface IContainerNetworkInterfacePropertiesFormat

    {

    }
}