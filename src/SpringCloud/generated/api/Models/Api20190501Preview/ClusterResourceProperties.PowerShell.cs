namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Service properties payload</summary>
    [System.ComponentModel.TypeConverter(typeof(ClusterResourcePropertiesTypeConverter))]
    public partial class ClusterResourceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ClusterResourceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerProperty = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties) content.GetValueForProperty("ConfigServerProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerProperty, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.NetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Trace = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties) content.GetValueForProperty("Trace",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Trace, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TracePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ServiceId = (string) content.GetValueForProperty("ServiceId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ServiceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Version = (int?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Version, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceError = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError) content.GetValueForProperty("TraceError",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceError, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyError = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError) content.GetValueForProperty("ConfigServerPropertyError",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyError, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr = (string) content.GetValueForProperty("NetworkProfileServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyConfigServer = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings) content.GetValueForProperty("ConfigServerPropertyConfigServer",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyConfigServer, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorMessage = (string) content.GetValueForProperty("ConfigServerPropertiesErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorCode = (string) content.GetValueForProperty("ConfigServerPropertiesErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorCode = (string) content.GetValueForProperty("TraceErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState?) content.GetValueForProperty("TraceState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceEnabled = (bool?) content.GetValueForProperty("TraceEnabled",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceAppInsightInstrumentationKey = (string) content.GetValueForProperty("TraceAppInsightInstrumentationKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceAppInsightInstrumentationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorMessage = (string) content.GetValueForProperty("TraceErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState?) content.GetValueForProperty("ConfigServerPropertyState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerGitProperty = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty) content.GetValueForProperty("ConfigServerGitProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerGitProperty, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerGitPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId = (string) content.GetValueForProperty("NetworkProfileAppSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileAppNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUsername = (string) content.GetValueForProperty("GitPropertyUsername",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUri = (string) content.GetValueForProperty("GitPropertyUri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertySearchPath = (string[]) content.GetValueForProperty("GitPropertySearchPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertySearchPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKey = (string) content.GetValueForProperty("GitPropertyHostKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPrivateKey = (string) content.GetValueForProperty("GitPropertyPrivateKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPrivateKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPassword = (string) content.GetValueForProperty("GitPropertyPassword",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyLabel = (string) content.GetValueForProperty("GitPropertyLabel",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyRepository = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[]) content.GetValueForProperty("GitPropertyRepository",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyRepository, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.GitPatternRepositoryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKeyAlgorithm = (string) content.GetValueForProperty("GitPropertyHostKeyAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKeyAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyStrictHostKeyChecking = (bool?) content.GetValueForProperty("GitPropertyStrictHostKeyChecking",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyStrictHostKeyChecking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ClusterResourceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerProperty = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties) content.GetValueForProperty("ConfigServerProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerProperty, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.NetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Trace = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties) content.GetValueForProperty("Trace",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Trace, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TracePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ServiceId = (string) content.GetValueForProperty("ServiceId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ServiceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Version = (int?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).Version, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceError = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError) content.GetValueForProperty("TraceError",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceError, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyError = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError) content.GetValueForProperty("ConfigServerPropertyError",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyError, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr = (string) content.GetValueForProperty("NetworkProfileServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyConfigServer = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings) content.GetValueForProperty("ConfigServerPropertyConfigServer",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyConfigServer, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorMessage = (string) content.GetValueForProperty("ConfigServerPropertiesErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorCode = (string) content.GetValueForProperty("ConfigServerPropertiesErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertiesErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorCode = (string) content.GetValueForProperty("TraceErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState?) content.GetValueForProperty("TraceState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceEnabled = (bool?) content.GetValueForProperty("TraceEnabled",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceAppInsightInstrumentationKey = (string) content.GetValueForProperty("TraceAppInsightInstrumentationKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceAppInsightInstrumentationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorMessage = (string) content.GetValueForProperty("TraceErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).TraceErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState?) content.GetValueForProperty("ConfigServerPropertyState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerPropertyState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerGitProperty = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty) content.GetValueForProperty("ConfigServerGitProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).ConfigServerGitProperty, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerGitPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId = (string) content.GetValueForProperty("NetworkProfileAppSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileAppNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUsername = (string) content.GetValueForProperty("GitPropertyUsername",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUri = (string) content.GetValueForProperty("GitPropertyUri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertySearchPath = (string[]) content.GetValueForProperty("GitPropertySearchPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertySearchPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKey = (string) content.GetValueForProperty("GitPropertyHostKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPrivateKey = (string) content.GetValueForProperty("GitPropertyPrivateKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPrivateKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPassword = (string) content.GetValueForProperty("GitPropertyPassword",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyLabel = (string) content.GetValueForProperty("GitPropertyLabel",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyRepository = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[]) content.GetValueForProperty("GitPropertyRepository",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyRepository, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.GitPatternRepositoryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKeyAlgorithm = (string) content.GetValueForProperty("GitPropertyHostKeyAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyHostKeyAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyStrictHostKeyChecking = (bool?) content.GetValueForProperty("GitPropertyStrictHostKeyChecking",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)this).GitPropertyStrictHostKeyChecking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ClusterResourceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ClusterResourceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClusterResourceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Service properties payload
    [System.ComponentModel.TypeConverter(typeof(ClusterResourcePropertiesTypeConverter))]
    public partial interface IClusterResourceProperties

    {

    }
}