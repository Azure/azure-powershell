// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>Disconnected operation resource.</summary>
    public partial class DisconnectedOperation :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperation,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.TrackedResource();

        /// <summary>Azure Hybrid Windows Server Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BenefitPlanAzureHybridWindowsServerBenefit { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BenefitPlanAzureHybridWindowsServerBenefit; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BenefitPlanAzureHybridWindowsServerBenefit = value ?? null; }

        /// <summary>Number of Windows Server VMs to license under the Azure Hybrid Benefit plan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? BenefitPlanWindowsServerVMCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BenefitPlanWindowsServerVMCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BenefitPlanWindowsServerVMCount = value ?? default(int); }

        /// <summary>The auto renew setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationAutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationAutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationAutoRenew = value ?? null; }

        /// <summary>The billing status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationBillingStatus; }

        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string BillingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingModel; }

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ConnectionIntent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ConnectionIntent; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ConnectionIntent = value ?? null; }

        /// <summary>The connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ConnectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ConnectionStatus; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? CurrentCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentCore = value ?? default(int); }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string CurrentPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentPricingModel = value ?? null; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentStartDate; }

        /// <summary>The device version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string DeviceVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).DeviceVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).DeviceVersion = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for BenefitPlan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.BenefitPlan { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BenefitPlan; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BenefitPlan = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.BillingConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfiguration = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfigurationBillingStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.BillingConfigurationBillingStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationBillingStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationBillingStatus = value ?? null; }

        /// <summary>Internal Acessors for BillingConfigurationCurrent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.BillingConfigurationCurrent { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationCurrent; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationCurrent = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingConfigurationUpcoming</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.BillingConfigurationUpcoming { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationUpcoming; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingConfigurationUpcoming = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.BillingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).BillingModel = value ?? null; }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.ConnectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ConnectionStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ConnectionStatus = value ?? null; }

        /// <summary>Internal Acessors for CurrentEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.CurrentEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for CurrentStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.CurrentStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).CurrentStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for StampId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.StampId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).StampId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).StampId = value ?? null; }

        /// <summary>Internal Acessors for UpcomingEndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingEndDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingEndDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for UpcomingStartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationInternal.UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingStartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingStartDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationProperties()); set => this._property = value; }

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The registration intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string RegistrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).RegistrationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).RegistrationStatus = value ?? null; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string StampId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).StampId; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public int? UpcomingCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingCore = value ?? default(int); }

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingEndDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingEndDate; }

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpcomingPricingModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingPricingModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingPricingModel = value ?? null; }

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public global::System.DateTime? UpcomingStartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)Property).UpcomingStartDate; }

        /// <summary>Creates an new <see cref="DisconnectedOperation" /> instance.</summary>
        public DisconnectedOperation()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Disconnected operation resource.
    public partial interface IDisconnectedOperation :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResource
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
    /// Disconnected operation resource.
    internal partial interface IDisconnectedOperationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ITrackedResourceInternal
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
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties Property { get; set; }
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