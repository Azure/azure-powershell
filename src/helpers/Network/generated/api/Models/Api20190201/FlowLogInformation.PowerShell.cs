namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Information on the configuration of flow log and traffic analytics (optional) .</summary>
    [System.ComponentModel.TypeConverter(typeof(FlowLogInformationTypeConverter))]
    public partial class FlowLogInformation
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogInformation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FlowLogInformation(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogInformation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FlowLogInformation(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogInformation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FlowLogInformation(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticsConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties) content.GetValueForProperty("FlowAnalyticsConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticsConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).TargetResourceId = (string) content.GetValueForProperty("TargetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).TargetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters) content.GetValueForProperty("RetentionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicy, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RetentionPolicyParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties) content.GetValueForProperty("FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).StorageId = (string) content.GetValueForProperty("StorageId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).StorageId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Enabled = (bool) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogFormatParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId = (string) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion = (string) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationEnabled = (bool) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceId = (string) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval = (int?) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType?) content.GetValueForProperty("FormatType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatVersion = (int?) content.GetValueForProperty("FormatVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyDay = (int?) content.GetValueForProperty("RetentionPolicyDay",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyEnabled = (bool?) content.GetValueForProperty("RetentionPolicyEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogInformation"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FlowLogInformation(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticsConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties) content.GetValueForProperty("FlowAnalyticsConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticsConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).TargetResourceId = (string) content.GetValueForProperty("TargetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).TargetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters) content.GetValueForProperty("RetentionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicy, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RetentionPolicyParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties) content.GetValueForProperty("FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).StorageId = (string) content.GetValueForProperty("StorageId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).StorageId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Enabled = (bool) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogFormatParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId = (string) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion = (string) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationEnabled = (bool) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceId = (string) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationWorkspaceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval = (int?) content.GetValueForProperty("NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType?) content.GetValueForProperty("FormatType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatVersion = (int?) content.GetValueForProperty("FormatVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).FormatVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyDay = (int?) content.GetValueForProperty("RetentionPolicyDay",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyEnabled = (bool?) content.GetValueForProperty("RetentionPolicyEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal)this).RetentionPolicyEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FlowLogInformation" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Information on the configuration of flow log and traffic analytics (optional) .
    [System.ComponentModel.TypeConverter(typeof(FlowLogInformationTypeConverter))]
    public partial interface IFlowLogInformation

    {

    }
}