namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>SAP monitor info on Azure (ARM properties and SAP monitor properties)</summary>
    public partial class SapMonitor :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.TrackedResource();

        /// <summary>The version of the payload running in the Collector VM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string CollectorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).SapMonitorCollectorVersion; }

        /// <summary>The value indicating whether to send analytics to Microsoft</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public bool? EnableCustomerAnalytic { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).EnableCustomerAnalytic; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).EnableCustomerAnalytic = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Id; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>The ARM ID of the Log Analytics Workspace that is used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string LogAnalyticsWorkspaceArmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).LogAnalyticsWorkspaceArmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).LogAnalyticsWorkspaceArmId = value; }

        /// <summary>The workspace ID of the log analytics workspace to be used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string LogAnalyticsWorkspaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).LogAnalyticsWorkspaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).LogAnalyticsWorkspaceId = value; }

        /// <summary>The shared key of the log analytics workspace that is used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string LogAnalyticsWorkspaceSharedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).LogAnalyticsWorkspaceSharedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).LogAnalyticsWorkspaceSharedKey = value; }

        /// <summary>The name of the resource group the SAP Monitor resources get deployed into.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string ManagedResourceGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).ManagedResourceGroupName; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for CollectorVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal.CollectorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).SapMonitorCollectorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).SapMonitorCollectorVersion = value; }

        /// <summary>Internal Acessors for ManagedResourceGroupName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal.ManagedResourceGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).ManagedResourceGroupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).ManagedResourceGroupName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitorProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>The subnet which the SAP monitor will be deployed in</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string MonitorSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).MonitorSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).MonitorSubnet = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties _property;

        /// <summary>SAP monitor properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.SapMonitorProperties()); set => this._property = value; }

        /// <summary>State of provisioning of the HanaInstance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="SapMonitor" /> instance.</summary>
        public SapMonitor()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// SAP monitor info on Azure (ARM properties and SAP monitor properties)
    public partial interface ISapMonitor :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResource
    {
        /// <summary>The version of the payload running in the Collector VM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The version of the payload running in the Collector VM",
        SerializedName = @"sapMonitorCollectorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string CollectorVersion { get;  }
        /// <summary>The value indicating whether to send analytics to Microsoft</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value indicating whether to send analytics to Microsoft",
        SerializedName = @"enableCustomerAnalytics",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableCustomerAnalytic { get; set; }
        /// <summary>The ARM ID of the Log Analytics Workspace that is used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM ID of the Log Analytics Workspace that is used for monitoring",
        SerializedName = @"logAnalyticsWorkspaceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticsWorkspaceArmId { get; set; }
        /// <summary>The workspace ID of the log analytics workspace to be used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace ID of the log analytics workspace to be used for monitoring",
        SerializedName = @"logAnalyticsWorkspaceId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticsWorkspaceId { get; set; }
        /// <summary>The shared key of the log analytics workspace that is used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The shared key of the log analytics workspace that is used for monitoring",
        SerializedName = @"logAnalyticsWorkspaceSharedKey",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticsWorkspaceSharedKey { get; set; }
        /// <summary>The name of the resource group the SAP Monitor resources get deployed into.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the resource group the SAP Monitor resources get deployed into.",
        SerializedName = @"managedResourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedResourceGroupName { get;  }
        /// <summary>The subnet which the SAP monitor will be deployed in</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The subnet which the SAP monitor will be deployed in",
        SerializedName = @"monitorSubnet",
        PossibleTypes = new [] { typeof(string) })]
        string MonitorSubnet { get; set; }
        /// <summary>State of provisioning of the HanaInstance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of provisioning of the HanaInstance",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get;  }

    }
    /// SAP monitor info on Azure (ARM properties and SAP monitor properties)
    internal partial interface ISapMonitorInternal :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceInternal
    {
        /// <summary>The version of the payload running in the Collector VM</summary>
        string CollectorVersion { get; set; }
        /// <summary>The value indicating whether to send analytics to Microsoft</summary>
        bool? EnableCustomerAnalytic { get; set; }
        /// <summary>The ARM ID of the Log Analytics Workspace that is used for monitoring</summary>
        string LogAnalyticsWorkspaceArmId { get; set; }
        /// <summary>The workspace ID of the log analytics workspace to be used for monitoring</summary>
        string LogAnalyticsWorkspaceId { get; set; }
        /// <summary>The shared key of the log analytics workspace that is used for monitoring</summary>
        string LogAnalyticsWorkspaceSharedKey { get; set; }
        /// <summary>The name of the resource group the SAP Monitor resources get deployed into.</summary>
        string ManagedResourceGroupName { get; set; }
        /// <summary>The subnet which the SAP monitor will be deployed in</summary>
        string MonitorSubnet { get; set; }
        /// <summary>SAP monitor properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties Property { get; set; }
        /// <summary>State of provisioning of the HanaInstance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get; set; }

    }
}