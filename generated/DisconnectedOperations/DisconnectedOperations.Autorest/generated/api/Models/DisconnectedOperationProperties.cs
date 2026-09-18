// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The disconnected operation properties</summary>
    public partial class DisconnectedOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BenefitPlan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans _benefitPlan;

        /// <summary>The benefit plans</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans BenefitPlan { get => (this._benefitPlan = this._benefitPlan ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BenefitPlans()); set => this._benefitPlan = value; }

        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BenefitPlanAzureHybridWindowsServerBenefit { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).AzureHybridWindowsServerBenefit; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).AzureHybridWindowsServerBenefit = value ?? null; }

        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? BenefitPlanWindowsServerVMCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).WindowsServerVMCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).WindowsServerVMCount = value ?? default(int); }

        /// <summary>Backing field for <see cref="BillingConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration _billingConfiguration;

        /// <summary>The billing configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration BillingConfiguration { get => (this._billingConfiguration = this._billingConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingConfiguration()); set => this._billingConfiguration = value; }

        /// <summary>The auto renew setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationAutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).AutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).AutoRenew = value ?? null; }

        /// <summary>The billing status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).BillingStatus; }

        /// <summary>Backing field for <see cref="BillingModel" /> property.</summary>
        private string _billingModel= @"Capacity";

        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string BillingModel { get => this._billingModel; }

        /// <summary>Backing field for <see cref="ConnectionIntent" /> property.</summary>
        private string _connectionIntent;

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionIntent { get => this._connectionIntent; set => this._connectionIntent = value; }

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private string _connectionStatus;

        /// <summary>The connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionStatus { get => this._connectionStatus; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? CurrentCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentCore = value ?? default(int); }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string CurrentPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentPricingModel = value ?? null; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentStartDate; }

        /// <summary>Backing field for <see cref="DeviceVersion" /> property.</summary>
        private string _deviceVersion;

        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string DeviceVersion { get => this._deviceVersion; set => this._deviceVersion = value; }

        /// <summary>Internal Acessors for BenefitPlan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BenefitPlan { get => (this._benefitPlan = this._benefitPlan ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BenefitPlans()); set { {_benefitPlan = value;} } }

        /// <summary>Internal Acessors for BillingConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BillingConfiguration { get => (this._billingConfiguration = this._billingConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingConfiguration()); set { {_billingConfiguration = value;} } }

        /// <summary>Internal Acessors for BillingConfigurationBillingStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).BillingStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).BillingStatus = value ?? null; }

        /// <summary>Internal Acessors for BillingConfigurationCurrent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BillingConfigurationCurrent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Current; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Current = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfigurationUpcoming</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BillingConfigurationUpcoming { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Upcoming; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Upcoming = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.BillingModel { get => this._billingModel; set { {_billingModel = value;} } }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for CurrentEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for CurrentStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for StampId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.StampId { get => this._stampId; set { {_stampId = value;} } }

        /// <summary>Internal Acessors for UpcomingEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for UpcomingStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal.UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RegistrationStatus" /> property.</summary>
        private string _registrationStatus;

        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string RegistrationStatus { get => this._registrationStatus; set => this._registrationStatus = value; }

        /// <summary>Backing field for <see cref="StampId" /> property.</summary>
        private string _stampId;

        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string StampId { get => this._stampId; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? UpcomingCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingCore = value ?? default(int); }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpcomingPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingPricingModel = value ?? null; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingStartDate; }

        /// <summary>Creates an new <see cref="DisconnectedOperationProperties" /> instance.</summary>
        public DisconnectedOperationProperties()
        {

        }
    }
    /// The disconnected operation properties
    public partial interface IDisconnectedOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Azure Hybrid Windows Server Benefit plan",
        SerializedName = @"azureHybridWindowsServerBenefit",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BenefitPlanAzureHybridWindowsServerBenefit { get; set; }
        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of Windows Server VMs to license under the Azure Hybrid Benefit plan",
        SerializedName = @"windowsServerVmCount",
        PossibleTypes = new [] { typeof(int) })]
        int? BenefitPlanWindowsServerVMCount { get; set; }
        /// <summary>The auto renew setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The auto renew setting",
        SerializedName = @"autoRenew",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BillingConfigurationAutoRenew { get; set; }
        /// <summary>The billing status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing status",
        SerializedName = @"billingStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled", "Stopped")]
        string BillingConfigurationBillingStatus { get;  }
        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing model",
        SerializedName = @"billingModel",
        PossibleTypes = new [] { typeof(string) })]
        string BillingModel { get;  }
        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The connection intent",
        SerializedName = @"connectionIntent",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The connection status",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionStatus { get;  }
        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of cores",
        SerializedName = @"cores",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCore { get; set; }
        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing end date",
        SerializedName = @"endDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentEndDate { get;  }
        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The pricing model",
        SerializedName = @"pricingModel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string CurrentPricingModel { get; set; }
        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing start date",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentStartDate { get;  }
        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"The device version",
        SerializedName = @"deviceVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceVersion { get; set; }
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }
        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"The registration intent",
        SerializedName = @"registrationStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }
        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The unique GUID of the stamp",
        SerializedName = @"stampId",
        PossibleTypes = new [] { typeof(string) })]
        string StampId { get;  }
        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"The number of cores",
        SerializedName = @"cores",
        PossibleTypes = new [] { typeof(int) })]
        int? UpcomingCore { get; set; }
        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing end date",
        SerializedName = @"endDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? UpcomingEndDate { get;  }
        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"The pricing model",
        SerializedName = @"pricingModel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string UpcomingPricingModel { get; set; }
        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing start date",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? UpcomingStartDate { get;  }

    }
    /// The disconnected operation properties
    internal partial interface IDisconnectedOperationPropertiesInternal

    {
        /// <summary>The benefit plans</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans BenefitPlan { get; set; }
        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BenefitPlanAzureHybridWindowsServerBenefit { get; set; }
        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        int? BenefitPlanWindowsServerVMCount { get; set; }
        /// <summary>The billing configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration BillingConfiguration { get; set; }
        /// <summary>The auto renew setting</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BillingConfigurationAutoRenew { get; set; }
        /// <summary>The billing status</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled", "Stopped")]
        string BillingConfigurationBillingStatus { get; set; }
        /// <summary>The current billing configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod BillingConfigurationCurrent { get; set; }
        /// <summary>The upcoming billing configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod BillingConfigurationUpcoming { get; set; }
        /// <summary>The billing model</summary>
        string BillingModel { get; set; }
        /// <summary>The connection intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The connection status</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionStatus { get; set; }
        /// <summary>The number of cores</summary>
        int? CurrentCore { get; set; }
        /// <summary>The billing end date</summary>
        global::System.DateTime? CurrentEndDate { get; set; }
        /// <summary>The pricing model</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string CurrentPricingModel { get; set; }
        /// <summary>The billing start date</summary>
        global::System.DateTime? CurrentStartDate { get; set; }
        /// <summary>The device version</summary>
        string DeviceVersion { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The registration intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }
        /// <summary>The unique GUID of the stamp</summary>
        string StampId { get; set; }
        /// <summary>The number of cores</summary>
        int? UpcomingCore { get; set; }
        /// <summary>The billing end date</summary>
        global::System.DateTime? UpcomingEndDate { get; set; }
        /// <summary>The pricing model</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string UpcomingPricingModel { get; set; }
        /// <summary>The billing start date</summary>
        global::System.DateTime? UpcomingStartDate { get; set; }

    }
}