// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The type used for update operations of the DisconnectedOperation.</summary>
    public partial class DisconnectedOperationUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal
    {

        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BenefitPlanAzureHybridWindowsServerBenefit { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BenefitPlanAzureHybridWindowsServerBenefit; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BenefitPlanAzureHybridWindowsServerBenefit = value ?? null; }

        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? BenefitPlanWindowsServerVMCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BenefitPlanWindowsServerVMCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BenefitPlanWindowsServerVMCount = value ?? default(int); }

        /// <summary>The auto renew setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationAutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationAutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationAutoRenew = value ?? null; }

        /// <summary>The billing status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationBillingStatus; }

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ConnectionIntent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).ConnectionIntent; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).ConnectionIntent = value ?? null; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? CurrentCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentCore = value ?? default(int); }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string CurrentPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentPricingModel = value ?? null; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentStartDate; }

        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string DeviceVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).DeviceVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).DeviceVersion = value ?? null; }

        /// <summary>Internal Acessors for BenefitPlan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.BenefitPlan { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BenefitPlan; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BenefitPlan = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.BillingConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfiguration = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfigurationBillingStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationBillingStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationBillingStatus = value ?? null; }

        /// <summary>Internal Acessors for BillingConfigurationCurrent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.BillingConfigurationCurrent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationCurrent; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationCurrent = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfigurationUpcoming</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.BillingConfigurationUpcoming { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationUpcoming; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).BillingConfigurationUpcoming = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for CurrentStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).CurrentStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for UpcomingEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for UpcomingStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateInternal.UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationUpdateProperties()); set => this._property = value; }

        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string RegistrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).RegistrationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).RegistrationStatus = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationUpdateTags()); set => this._tag = value; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? UpcomingCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingCore = value ?? default(int); }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpcomingPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingPricingModel = value ?? null; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdatePropertiesInternal)Property).UpcomingStartDate; }

        /// <summary>Creates an new <see cref="DisconnectedOperationUpdate" /> instance.</summary>
        public DisconnectedOperationUpdate()
        {

        }
    }
    /// The type used for update operations of the DisconnectedOperation.
    public partial interface IDisconnectedOperationUpdate :
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
        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The connection intent",
        SerializedName = @"connectionIntent",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
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
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags Tag { get; set; }
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
    /// The type used for update operations of the DisconnectedOperation.
    internal partial interface IDisconnectedOperationUpdateInternal

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
        /// <summary>The connection intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
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
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateProperties Property { get; set; }
        /// <summary>The registration intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Registered", "Unregistered")]
        string RegistrationStatus { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationUpdateTags Tag { get; set; }
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