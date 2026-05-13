// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The disconnected operation manifest</summary>
    public partial class DisconnectedOperationDeploymentManifest :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal
    {

        /// <summary>Backing field for <see cref="BenefitPlan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans _benefitPlan;

        /// <summary>The benefit plans</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans BenefitPlan { get => (this._benefitPlan = this._benefitPlan ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BenefitPlans()); }

        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BenefitPlanAzureHybridWindowsServerBenefit { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).AzureHybridWindowsServerBenefit; }

        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? BenefitPlanWindowsServerVMCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).WindowsServerVMCount; }

        /// <summary>Backing field for <see cref="BillingConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration _billingConfiguration;

        /// <summary>The billing configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration BillingConfiguration { get => (this._billingConfiguration = this._billingConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingConfiguration()); }

        /// <summary>The auto renew setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationAutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).AutoRenew; }

        /// <summary>The billing status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).BillingStatus; }

        /// <summary>Backing field for <see cref="BillingModel" /> property.</summary>
        private string _billingModel= @"Capacity";

        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string BillingModel { get => this._billingModel; }

        /// <summary>Backing field for <see cref="Cloud" /> property.</summary>
        private string _cloud;

        /// <summary>The cloud in which the resource is registered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Cloud { get => this._cloud; }

        /// <summary>Backing field for <see cref="ConnectionIntent" /> property.</summary>
        private string _connectionIntent;

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionIntent { get => this._connectionIntent; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? CurrentCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentCore; }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string CurrentPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentPricingModel; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentStartDate; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for BenefitPlan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BenefitPlan { get => (this._benefitPlan = this._benefitPlan ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BenefitPlans()); set { {_benefitPlan = value;} } }

        /// <summary>Internal Acessors for BenefitPlanAzureHybridWindowsServerBenefit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BenefitPlanAzureHybridWindowsServerBenefit { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).AzureHybridWindowsServerBenefit; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).AzureHybridWindowsServerBenefit = value ?? null; }

        /// <summary>Internal Acessors for BenefitPlanWindowsServerVMCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BenefitPlanWindowsServerVMCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).WindowsServerVMCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlansInternal)BenefitPlan).WindowsServerVMCount = value ?? default(int); }

        /// <summary>Internal Acessors for BillingConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingConfiguration { get => (this._billingConfiguration = this._billingConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingConfiguration()); set { {_billingConfiguration = value;} } }

        /// <summary>Internal Acessors for BillingConfigurationAutoRenew</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingConfigurationAutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).AutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).AutoRenew = value ?? null; }

        /// <summary>Internal Acessors for BillingConfigurationBillingStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).BillingStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).BillingStatus = value ?? null; }

        /// <summary>Internal Acessors for BillingConfigurationCurrent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingConfigurationCurrent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Current; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Current = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfigurationUpcoming</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingConfigurationUpcoming { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Upcoming; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).Upcoming = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingModel { get => this._billingModel; set { {_billingModel = value;} } }

        /// <summary>Internal Acessors for Cloud</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.Cloud { get => this._cloud; set { {_cloud = value;} } }

        /// <summary>Internal Acessors for ConnectionIntent</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.ConnectionIntent { get => this._connectionIntent; set { {_connectionIntent = value;} } }

        /// <summary>Internal Acessors for CurrentCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.CurrentCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentCore = value ?? default(int); }

        /// <summary>Internal Acessors for CurrentEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for CurrentPricingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.CurrentPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentPricingModel = value ?? null; }

        /// <summary>Internal Acessors for CurrentStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).CurrentStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for ResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.ResourceId { get => this._resourceId; set { {_resourceId = value;} } }

        /// <summary>Internal Acessors for ResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.ResourceName { get => this._resourceName; set { {_resourceName = value;} } }

        /// <summary>Internal Acessors for StampId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.StampId { get => this._stampId; set { {_stampId = value;} } }

        /// <summary>Internal Acessors for UpcomingCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.UpcomingCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingCore = value ?? default(int); }

        /// <summary>Internal Acessors for UpcomingEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for UpcomingPricingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.UpcomingPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingPricingModel = value ?? null; }

        /// <summary>Internal Acessors for UpcomingStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The resource identifier of the disconnected operations resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; }

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>The resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceName { get => this._resourceName; }

        /// <summary>Backing field for <see cref="StampId" /> property.</summary>
        private string _stampId;

        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string StampId { get => this._stampId; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? UpcomingCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingCore; }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpcomingPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingPricingModel; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfigurationInternal)BillingConfiguration).UpcomingStartDate; }

        /// <summary>Creates an new <see cref="DisconnectedOperationDeploymentManifest" /> instance.</summary>
        public DisconnectedOperationDeploymentManifest()
        {

        }
    }
    /// The disconnected operation manifest
    public partial interface IDisconnectedOperationDeploymentManifest :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Azure Hybrid Windows Server Benefit plan",
        SerializedName = @"azureHybridWindowsServerBenefit",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BenefitPlanAzureHybridWindowsServerBenefit { get;  }
        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Number of Windows Server VMs to license under the Azure Hybrid Benefit plan",
        SerializedName = @"windowsServerVmCount",
        PossibleTypes = new [] { typeof(int) })]
        int? BenefitPlanWindowsServerVMCount { get;  }
        /// <summary>The auto renew setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The auto renew setting",
        SerializedName = @"autoRenew",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BillingConfigurationAutoRenew { get;  }
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
        /// <summary>The cloud in which the resource is registered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The cloud in which the resource is registered",
        SerializedName = @"cloud",
        PossibleTypes = new [] { typeof(string) })]
        string Cloud { get;  }
        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The connection intent",
        SerializedName = @"connectionIntent",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get;  }
        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The number of cores",
        SerializedName = @"cores",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCore { get;  }
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
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The pricing model",
        SerializedName = @"pricingModel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string CurrentPricingModel { get;  }
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
        /// <summary>The resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>The resource identifier of the disconnected operations resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource identifier of the disconnected operations resource",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get;  }
        /// <summary>The resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource name",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get;  }
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
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The number of cores",
        SerializedName = @"cores",
        PossibleTypes = new [] { typeof(int) })]
        int? UpcomingCore { get;  }
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
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The pricing model",
        SerializedName = @"pricingModel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string UpcomingPricingModel { get;  }
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
    /// The disconnected operation manifest
    internal partial interface IDisconnectedOperationDeploymentManifestInternal

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
        /// <summary>The cloud in which the resource is registered</summary>
        string Cloud { get; set; }
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
        /// <summary>The resource location</summary>
        string Location { get; set; }
        /// <summary>The resource identifier of the disconnected operations resource</summary>
        string ResourceId { get; set; }
        /// <summary>The resource name</summary>
        string ResourceName { get; set; }
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