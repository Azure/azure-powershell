namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell;

    /// <summary>The container group properties</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerGroupPropertiesTypeConverter))]
    public partial class ContainerGroupProperties
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerGroupProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddress = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddress, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupPropertiesInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Diagnostic = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics) content.GetValueForProperty("Diagnostic",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Diagnostic, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupDiagnosticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfig = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration) content.GetValueForProperty("DnsConfig",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfig, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.DnsConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionProperty = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties) content.GetValueForProperty("EncryptionProperty",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionProperty, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EncryptionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Container = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[]) content.GetValueForProperty("Container",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Container, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ImageRegistryCredentials = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[]) content.GetValueForProperty("ImageRegistryCredentials",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ImageRegistryCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ImageRegistryCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).RestartPolicy = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy?) content.GetValueForProperty("RestartPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).RestartPolicy, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Volume = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[]) content.GetValueForProperty("Volume",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Volume, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.VolumeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku?) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InitContainer = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[]) content.GetValueForProperty("InitContainer",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InitContainer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerDefinitionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DiagnosticLogAnalytic = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics) content.GetValueForProperty("DiagnosticLogAnalytic",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DiagnosticLogAnalytic, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyName = (string) content.GetValueForProperty("EncryptionPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyVersion = (string) content.GetValueForProperty("EncryptionPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressPort = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[]) content.GetValueForProperty("IPAddressPort",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressPort, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.PortTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressType = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType) content.GetValueForProperty("IPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressType, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressIP = (string) content.GetValueForProperty("IPAddressIP",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressDnsNameLabel = (string) content.GetValueForProperty("IPAddressDnsNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressDnsNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressFqdn = (string) content.GetValueForProperty("IPAddressFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewEvent = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[]) content.GetValueForProperty("InstanceViewEvent",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewEvent, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EventTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewState = (string) content.GetValueForProperty("InstanceViewState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceId = (string) content.GetValueForProperty("LogAnalyticWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceKey = (string) content.GetValueForProperty("LogAnalyticWorkspaceKey",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticLogType = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType?) content.GetValueForProperty("LogAnalyticLogType",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticLogType, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticMetadata = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata) content.GetValueForProperty("LogAnalyticMetadata",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticMetadata, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfileId = (string) content.GetValueForProperty("NetworkProfileId",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigNameServer = (string[]) content.GetValueForProperty("DnsConfigNameServer",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigNameServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigSearchDomain = (string) content.GetValueForProperty("DnsConfigSearchDomain",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigSearchDomain, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigOption = (string) content.GetValueForProperty("DnsConfigOption",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyVaultBaseUrl = (string) content.GetValueForProperty("EncryptionPropertyVaultBaseUrl",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyVaultBaseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceResourceId = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId) content.GetValueForProperty("LogAnalyticWorkspaceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceResourceId, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsWorkspaceResourceIdTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerGroupProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddress = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddress, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupPropertiesInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Diagnostic = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics) content.GetValueForProperty("Diagnostic",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Diagnostic, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupDiagnosticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfig = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration) content.GetValueForProperty("DnsConfig",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfig, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.DnsConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionProperty = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties) content.GetValueForProperty("EncryptionProperty",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionProperty, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EncryptionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Container = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[]) content.GetValueForProperty("Container",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Container, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ImageRegistryCredentials = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[]) content.GetValueForProperty("ImageRegistryCredentials",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).ImageRegistryCredentials, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ImageRegistryCredentialTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).RestartPolicy = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy?) content.GetValueForProperty("RestartPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).RestartPolicy, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Volume = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[]) content.GetValueForProperty("Volume",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Volume, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.VolumeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku?) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InitContainer = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[]) content.GetValueForProperty("InitContainer",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InitContainer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerDefinitionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DiagnosticLogAnalytic = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics) content.GetValueForProperty("DiagnosticLogAnalytic",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DiagnosticLogAnalytic, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyName = (string) content.GetValueForProperty("EncryptionPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyVersion = (string) content.GetValueForProperty("EncryptionPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressPort = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[]) content.GetValueForProperty("IPAddressPort",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressPort, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.PortTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressType = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType) content.GetValueForProperty("IPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressType, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressIP = (string) content.GetValueForProperty("IPAddressIP",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressDnsNameLabel = (string) content.GetValueForProperty("IPAddressDnsNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressDnsNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressFqdn = (string) content.GetValueForProperty("IPAddressFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).IPAddressFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewEvent = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[]) content.GetValueForProperty("InstanceViewEvent",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewEvent, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EventTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewState = (string) content.GetValueForProperty("InstanceViewState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).InstanceViewState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceId = (string) content.GetValueForProperty("LogAnalyticWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceKey = (string) content.GetValueForProperty("LogAnalyticWorkspaceKey",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticLogType = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType?) content.GetValueForProperty("LogAnalyticLogType",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticLogType, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticMetadata = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata) content.GetValueForProperty("LogAnalyticMetadata",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticMetadata, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfileId = (string) content.GetValueForProperty("NetworkProfileId",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).NetworkProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigNameServer = (string[]) content.GetValueForProperty("DnsConfigNameServer",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigNameServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigSearchDomain = (string) content.GetValueForProperty("DnsConfigSearchDomain",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigSearchDomain, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigOption = (string) content.GetValueForProperty("DnsConfigOption",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).DnsConfigOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyVaultBaseUrl = (string) content.GetValueForProperty("EncryptionPropertyVaultBaseUrl",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).EncryptionPropertyVaultBaseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceResourceId = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId) content.GetValueForProperty("LogAnalyticWorkspaceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)this).LogAnalyticWorkspaceResourceId, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsWorkspaceResourceIdTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerGroupProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerGroupProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerGroupProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The container group properties
    [System.ComponentModel.TypeConverter(typeof(ContainerGroupPropertiesTypeConverter))]
    public partial interface IContainerGroupProperties

    {

    }
}