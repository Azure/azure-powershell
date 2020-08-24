namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Describes the properties of a SAP monitor.</summary>
    public partial class SapMonitorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal
    {

        /// <summary>Backing field for <see cref="EnableCustomerAnalytic" /> property.</summary>
        private bool? _enableCustomerAnalytic;

        /// <summary>The value indicating whether to send analytics to Microsoft</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? EnableCustomerAnalytic { get => this._enableCustomerAnalytic; set => this._enableCustomerAnalytic = value; }

        /// <summary>Backing field for <see cref="LogAnalyticsWorkspaceArmId" /> property.</summary>
        private string _logAnalyticsWorkspaceArmId;

        /// <summary>The ARM ID of the Log Analytics Workspace that is used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string LogAnalyticsWorkspaceArmId { get => this._logAnalyticsWorkspaceArmId; set => this._logAnalyticsWorkspaceArmId = value; }

        /// <summary>Backing field for <see cref="LogAnalyticsWorkspaceId" /> property.</summary>
        private string _logAnalyticsWorkspaceId;

        /// <summary>The workspace ID of the log analytics workspace to be used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string LogAnalyticsWorkspaceId { get => this._logAnalyticsWorkspaceId; set => this._logAnalyticsWorkspaceId = value; }

        /// <summary>Backing field for <see cref="LogAnalyticsWorkspaceSharedKey" /> property.</summary>
        private string _logAnalyticsWorkspaceSharedKey;

        /// <summary>The shared key of the log analytics workspace that is used for monitoring</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string LogAnalyticsWorkspaceSharedKey { get => this._logAnalyticsWorkspaceSharedKey; set => this._logAnalyticsWorkspaceSharedKey = value; }

        /// <summary>Backing field for <see cref="ManagedResourceGroupName" /> property.</summary>
        private string _managedResourceGroupName;

        /// <summary>The name of the resource group the SAP Monitor resources get deployed into.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string ManagedResourceGroupName { get => this._managedResourceGroupName; }

        /// <summary>Internal Acessors for ManagedResourceGroupName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal.ManagedResourceGroupName { get => this._managedResourceGroupName; set { {_managedResourceGroupName = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SapMonitorCollectorVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitorPropertiesInternal.SapMonitorCollectorVersion { get => this._sapMonitorCollectorVersion; set { {_sapMonitorCollectorVersion = value;} } }

        /// <summary>Backing field for <see cref="MonitorSubnet" /> property.</summary>
        private string _monitorSubnet;

        /// <summary>The subnet which the SAP monitor will be deployed in</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string MonitorSubnet { get => this._monitorSubnet; set => this._monitorSubnet = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? _provisioningState;

        /// <summary>State of provisioning of the HanaInstance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SapMonitorCollectorVersion" /> property.</summary>
        private string _sapMonitorCollectorVersion;

        /// <summary>The version of the payload running in the Collector VM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string SapMonitorCollectorVersion { get => this._sapMonitorCollectorVersion; }

        /// <summary>Creates an new <see cref="SapMonitorProperties" /> instance.</summary>
        public SapMonitorProperties()
        {

        }
    }
    /// Describes the properties of a SAP monitor.
    public partial interface ISapMonitorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
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
        /// <summary>The version of the payload running in the Collector VM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The version of the payload running in the Collector VM",
        SerializedName = @"sapMonitorCollectorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string SapMonitorCollectorVersion { get;  }

    }
    /// Describes the properties of a SAP monitor.
    internal partial interface ISapMonitorPropertiesInternal

    {
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
        /// <summary>State of provisioning of the HanaInstance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.HanaProvisioningStatesEnum? ProvisioningState { get; set; }
        /// <summary>The version of the payload running in the Collector VM</summary>
        string SapMonitorCollectorVersion { get; set; }

    }
}