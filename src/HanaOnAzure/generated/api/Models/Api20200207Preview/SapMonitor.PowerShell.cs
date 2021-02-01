namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.PowerShell;

    /// <summary>SAP monitor info on Azure (ARM properties and SAP monitor properties)</summary>
    [System.ComponentModel.TypeConverter(typeof(SapMonitorTypeConverter))]
    public partial class SapMonitor
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitor"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SapMonitor(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitor"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SapMonitor(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SapMonitor" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitor"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SapMonitor(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ManagedResourceGroupName = (string) content.GetValueForProperty("ManagedResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ManagedResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceArmId = (string) content.GetValueForProperty("LogAnalyticsWorkspaceArmId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).EnableCustomerAnalytic = (bool?) content.GetValueForProperty("EnableCustomerAnalytic",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).EnableCustomerAnalytic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceId = (string) content.GetValueForProperty("LogAnalyticsWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceSharedKey = (string) content.GetValueForProperty("LogAnalyticsWorkspaceSharedKey",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceSharedKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).CollectorVersion = (string) content.GetValueForProperty("CollectorVersion",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).CollectorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).MonitorSubnet = (string) content.GetValueForProperty("MonitorSubnet",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).MonitorSubnet, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitor"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SapMonitor(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ManagedResourceGroupName = (string) content.GetValueForProperty("ManagedResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).ManagedResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceArmId = (string) content.GetValueForProperty("LogAnalyticsWorkspaceArmId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).EnableCustomerAnalytic = (bool?) content.GetValueForProperty("EnableCustomerAnalytic",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).EnableCustomerAnalytic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceId = (string) content.GetValueForProperty("LogAnalyticsWorkspaceId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceSharedKey = (string) content.GetValueForProperty("LogAnalyticsWorkspaceSharedKey",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).LogAnalyticsWorkspaceSharedKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).CollectorVersion = (string) content.GetValueForProperty("CollectorVersion",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).CollectorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).MonitorSubnet = (string) content.GetValueForProperty("MonitorSubnet",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal)this).MonitorSubnet, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// SAP monitor info on Azure (ARM properties and SAP monitor properties)
    [System.ComponentModel.TypeConverter(typeof(SapMonitorTypeConverter))]
    public partial interface ISapMonitor

    {

    }
}