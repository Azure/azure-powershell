// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Supercomputer properties</summary>
    public partial class SupercomputerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal
    {

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityId = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityPrincipalId; }

        /// <summary>Backing field for <see cref="CustomerManagedKey" /> property.</summary>
        private string _customerManagedKey;

        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string CustomerManagedKey { get => this._customerManagedKey; set => this._customerManagedKey = value; }

        /// <summary>Backing field for <see cref="DiskEncryptionSetId" /> property.</summary>
        private string _diskEncryptionSetId;

        /// <summary>
        /// Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string DiskEncryptionSetId { get => this._diskEncryptionSetId; set => this._diskEncryptionSetId = value; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities _identity;

        /// <summary>Dictionary of identity properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities()); set => this._identity = value; }

        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities IdentityWorkloadIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).WorkloadIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).WorkloadIdentity = value ?? null /* model class */; }

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityId = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityPrincipalId; }

        /// <summary>Backing field for <see cref="LogAnalyticsClusterId" /> property.</summary>
        private string _logAnalyticsClusterId;

        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string LogAnalyticsClusterId { get => this._logAnalyticsClusterId; set => this._logAnalyticsClusterId = value; }

        /// <summary>Backing field for <see cref="ManagedOnBehalfOfConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources _managedOnBehalfOfConfiguration;

        /// <summary>
        /// Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages
        /// those resources on behalf of the resource owner.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources ManagedOnBehalfOfConfiguration { get => (this._managedOnBehalfOfConfiguration = this._managedOnBehalfOfConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources()); }

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource; }

        /// <summary>Backing field for <see cref="ManagedResourceGroup" /> property.</summary>
        private string _managedResourceGroup;

        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ManagedResourceGroup { get => this._managedResourceGroup; }

        /// <summary>Backing field for <see cref="ManagementSubnetId" /> property.</summary>
        private string _managementSubnetId;

        /// <summary>
        /// System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
        /// It should have connectivity to the system subnet and nodepool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ManagementSubnetId { get => this._managementSubnetId; set => this._managementSubnetId = value; }

        /// <summary>Internal Acessors for ClusterIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.ClusterIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityClientId = value ?? null; }

        /// <summary>Internal Acessors for ClusterIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.ClusterIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentityPrincipalId = value ?? null; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityClusterIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.IdentityClusterIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).ClusterIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for IdentityKubeletIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.IdentityKubeletIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for KubeletIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.KubeletIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityClientId = value ?? null; }

        /// <summary>Internal Acessors for KubeletIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.KubeletIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)Identity).KubeletIdentityPrincipalId = value ?? null; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.ManagedOnBehalfOfConfiguration { get => (this._managedOnBehalfOfConfiguration = this._managedOnBehalfOfConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources()); set { {_managedOnBehalfOfConfiguration = value;} } }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ManagedResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.ManagedResourceGroup { get => this._managedResourceGroup; set { {_managedResourceGroup = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="OutboundType" /> property.</summary>
        private string _outboundType;

        /// <summary>
        /// Network egress type provisioned for the supercomputer workloads.
        /// Defaults to LoadBalancer if not specified.
        /// If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string OutboundType { get => this._outboundType; set => this._outboundType = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SubnetId" /> property.</summary>
        private string _subnetId;

        /// <summary>
        /// System Subnet ID associated with managed NodePool for system resources.
        /// It should have connectivity to the child NodePool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SubnetId { get => this._subnetId; set => this._subnetId = value; }

        /// <summary>Backing field for <see cref="SystemSku" /> property.</summary>
        private string _systemSku;

        /// <summary>The SKU to use for the system node pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SystemSku { get => this._systemSku; set => this._systemSku = value; }

        /// <summary>Creates an new <see cref="SupercomputerProperties" /> instance.</summary>
        public SupercomputerProperties()
        {

        }
    }
    /// Supercomputer properties
    public partial interface ISupercomputerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityPrincipalId { get;  }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Whether or not to use a customer managed key when encrypting data at rest",
        SerializedName = @"customerManagedKeys",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>
        /// Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.",
        SerializedName = @"diskEncryptionSetId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionSetId { get; set; }
        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must be the resource ID of the identity resource.",
        SerializedName = @"workloadIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities IdentityWorkloadIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityPrincipalId { get;  }
        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.",
        SerializedName = @"logAnalyticsClusterId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticsClusterId { get; set; }
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Managed-On-Behalf-Of broker resources",
        SerializedName = @"moboBrokerResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get;  }
        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource group for resources managed on behalf of customer.",
        SerializedName = @"managedResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedResourceGroup { get;  }
        /// <summary>
        /// System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
        /// It should have connectivity to the system subnet and nodepool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
            It should have connectivity to the system subnet and nodepool subnets.",
        SerializedName = @"managementSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementSubnetId { get; set; }
        /// <summary>
        /// Network egress type provisioned for the supercomputer workloads.
        /// Defaults to LoadBalancer if not specified.
        /// If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Network egress type provisioned for the supercomputer workloads.
            Defaults to LoadBalancer if not specified.
            If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.",
        SerializedName = @"outboundType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("LoadBalancer", "None")]
        string OutboundType { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>
        /// System Subnet ID associated with managed NodePool for system resources.
        /// It should have connectivity to the child NodePool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"System Subnet ID associated with managed NodePool for system resources.
            It should have connectivity to the child NodePool subnets.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>The SKU to use for the system node pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The SKU to use for the system node pool.",
        SerializedName = @"systemSku",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_D4s_v6", "Standard_D4s_v5", "Standard_D4s_v4")]
        string SystemSku { get; set; }

    }
    /// Supercomputer properties
    internal partial interface ISupercomputerPropertiesInternal

    {
        /// <summary>The client ID of the assigned identity.</summary>
        string ClusterIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string ClusterIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string ClusterIdentityPrincipalId { get; set; }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>
        /// Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.
        /// </summary>
        string DiskEncryptionSetId { get; set; }
        /// <summary>Dictionary of identity properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities Identity { get; set; }
        /// <summary>Cluster identity ID.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity IdentityClusterIdentity { get; set; }
        /// <summary>
        /// Kubelet identity ID used by the supercomputer.
        /// This identity is used by the supercomputer at node level to access Azure resources.
        /// This identity must have ManagedIdentityOperator role on the clusterIdentity.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity IdentityKubeletIdentity { get; set; }
        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities IdentityWorkloadIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        string KubeletIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string KubeletIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string KubeletIdentityPrincipalId { get; set; }
        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        string LogAnalyticsClusterId { get; set; }
        /// <summary>
        /// Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages
        /// those resources on behalf of the resource owner.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources ManagedOnBehalfOfConfiguration { get; set; }
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get; set; }
        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        string ManagedResourceGroup { get; set; }
        /// <summary>
        /// System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
        /// It should have connectivity to the system subnet and nodepool subnets.
        /// </summary>
        string ManagementSubnetId { get; set; }
        /// <summary>
        /// Network egress type provisioned for the supercomputer workloads.
        /// Defaults to LoadBalancer if not specified.
        /// If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("LoadBalancer", "None")]
        string OutboundType { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// System Subnet ID associated with managed NodePool for system resources.
        /// It should have connectivity to the child NodePool subnets.
        /// </summary>
        string SubnetId { get; set; }
        /// <summary>The SKU to use for the system node pool.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_D4s_v6", "Standard_D4s_v5", "Standard_D4s_v4")]
        string SystemSku { get; set; }

    }
}