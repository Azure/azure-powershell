namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Custom Parameters used for Cluster Creation.</summary>
    public partial class WorkspaceCustomParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal
    {

        /// <summary>Backing field for <see cref="AmlWorkspaceId" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _amlWorkspaceId;

        /// <summary>The Workspace ID of an Azure Machine Learning Workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter AmlWorkspaceId { get => (this._amlWorkspaceId = this._amlWorkspaceId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._amlWorkspaceId = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string AmlWorkspaceIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Value = value; }

        /// <summary>Backing field for <see cref="CustomPrivateSubnetName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _customPrivateSubnetName;

        /// <summary>The name of the Private Subnet within the Virtual Network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPrivateSubnetName { get => (this._customPrivateSubnetName = this._customPrivateSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._customPrivateSubnetName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomPrivateSubnetNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Value = value; }

        /// <summary>Backing field for <see cref="CustomPublicSubnetName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _customPublicSubnetName;

        /// <summary>The name of a Public Subnet within the Virtual Network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPublicSubnetName { get => (this._customPublicSubnetName = this._customPublicSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._customPublicSubnetName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomPublicSubnetNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Value = value; }

        /// <summary>Backing field for <see cref="CustomVirtualNetworkId" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _customVirtualNetworkId;

        /// <summary>The ID of a Virtual Network where this Databricks Cluster should be created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomVirtualNetworkId { get => (this._customVirtualNetworkId = this._customVirtualNetworkId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._customVirtualNetworkId = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomVirtualNetworkIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Value = value; }

        /// <summary>Backing field for <see cref="EnableNoPublicIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter _enableNoPublicIP;

        /// <summary>Should the Public IP be Disabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter EnableNoPublicIP { get => (this._enableNoPublicIP = this._enableNoPublicIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set => this._enableNoPublicIP = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool EnableNoPublicIPValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Value = value; }

        /// <summary>Backing field for <see cref="LoadBalancerBackendPoolName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _loadBalancerBackendPoolName;

        /// <summary>The name of a Backend Address Pool within an Azure Load Balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter LoadBalancerBackendPoolName { get => (this._loadBalancerBackendPoolName = this._loadBalancerBackendPoolName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._loadBalancerBackendPoolName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? LoadBalancerBackendPoolNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerBackendPoolName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string LoadBalancerBackendPoolNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerBackendPoolName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerBackendPoolName).Value = value; }

        /// <summary>Backing field for <see cref="LoadBalancerId" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _loadBalancerId;

        /// <summary>The Resource ID of an Azure Load Balancer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter LoadBalancerId { get => (this._loadBalancerId = this._loadBalancerId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._loadBalancerId = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? LoadBalancerIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerId).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string LoadBalancerIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerId).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerId).Value = value; }

        /// <summary>Internal Acessors for AmlWorkspaceId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.AmlWorkspaceId { get => (this._amlWorkspaceId = this._amlWorkspaceId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_amlWorkspaceId = value;} } }

        /// <summary>Internal Acessors for AmlWorkspaceIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.AmlWorkspaceIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Type = value; }

        /// <summary>Internal Acessors for CustomPrivateSubnetName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPrivateSubnetName { get => (this._customPrivateSubnetName = this._customPrivateSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_customPrivateSubnetName = value;} } }

        /// <summary>Internal Acessors for CustomPrivateSubnetNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPrivateSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Type = value; }

        /// <summary>Internal Acessors for CustomPublicSubnetName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPublicSubnetName { get => (this._customPublicSubnetName = this._customPublicSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_customPublicSubnetName = value;} } }

        /// <summary>Internal Acessors for CustomPublicSubnetNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPublicSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Type = value; }

        /// <summary>Internal Acessors for CustomVirtualNetworkId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomVirtualNetworkId { get => (this._customVirtualNetworkId = this._customVirtualNetworkId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_customVirtualNetworkId = value;} } }

        /// <summary>Internal Acessors for CustomVirtualNetworkIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomVirtualNetworkIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Type = value; }

        /// <summary>Internal Acessors for EnableNoPublicIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.EnableNoPublicIP { get => (this._enableNoPublicIP = this._enableNoPublicIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set { {_enableNoPublicIP = value;} } }

        /// <summary>Internal Acessors for EnableNoPublicIPType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.EnableNoPublicIPType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Type = value; }

        /// <summary>Internal Acessors for LoadBalancerBackendPoolName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.LoadBalancerBackendPoolName { get => (this._loadBalancerBackendPoolName = this._loadBalancerBackendPoolName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_loadBalancerBackendPoolName = value;} } }

        /// <summary>Internal Acessors for LoadBalancerBackendPoolNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.LoadBalancerBackendPoolNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerBackendPoolName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerBackendPoolName).Type = value; }

        /// <summary>Internal Acessors for LoadBalancerId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.LoadBalancerId { get => (this._loadBalancerId = this._loadBalancerId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_loadBalancerId = value;} } }

        /// <summary>Internal Acessors for LoadBalancerIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.LoadBalancerIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerId).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)LoadBalancerId).Type = value; }

        /// <summary>Internal Acessors for RelayNamespaceName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.RelayNamespaceName { get => (this._relayNamespaceName = this._relayNamespaceName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_relayNamespaceName = value;} } }

        /// <summary>Internal Acessors for RelayNamespaceNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.RelayNamespaceNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)RelayNamespaceName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)RelayNamespaceName).Type = value; }

        /// <summary>Internal Acessors for ResourceTag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.ResourceTag { get => (this._resourceTag = this._resourceTag ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomObjectParameter()); set { {_resourceTag = value;} } }

        /// <summary>Internal Acessors for ResourceTagType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.ResourceTagType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterInternal)ResourceTag).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterInternal)ResourceTag).Type = value; }

        /// <summary>Internal Acessors for StorageAccountName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.StorageAccountName { get => (this._storageAccountName = this._storageAccountName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_storageAccountName = value;} } }

        /// <summary>Internal Acessors for StorageAccountNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.StorageAccountNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountName).Type = value; }

        /// <summary>Internal Acessors for StorageAccountSkuName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.StorageAccountSkuName { get => (this._storageAccountSkuName = this._storageAccountSkuName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_storageAccountSkuName = value;} } }

        /// <summary>Internal Acessors for StorageAccountSkuNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.StorageAccountSkuNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountSkuName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountSkuName).Type = value; }

        /// <summary>Internal Acessors for VnetAddressPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.VnetAddressPrefix { get => (this._vnetAddressPrefix = this._vnetAddressPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_vnetAddressPrefix = value;} } }

        /// <summary>Internal Acessors for VnetAddressPrefixType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.VnetAddressPrefixType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)VnetAddressPrefix).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)VnetAddressPrefix).Type = value; }

        /// <summary>Backing field for <see cref="RelayNamespaceName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _relayNamespaceName;

        /// <summary>The name of an Azure Relay Namespace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter RelayNamespaceName { get => (this._relayNamespaceName = this._relayNamespaceName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._relayNamespaceName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RelayNamespaceNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)RelayNamespaceName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string RelayNamespaceNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)RelayNamespaceName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)RelayNamespaceName).Value = value; }

        /// <summary>Backing field for <see cref="ResourceTag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameter _resourceTag;

        /// <summary>
        /// A map of Tags which should be applied to the resources used by this Databricks Cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameter ResourceTag { get => (this._resourceTag = this._resourceTag ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomObjectParameter()); set => this._resourceTag = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? ResourceTagType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterInternal)ResourceTag).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterValue ResourceTagValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterInternal)ResourceTag).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterInternal)ResourceTag).Value = value; }

        /// <summary>Backing field for <see cref="StorageAccountName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _storageAccountName;

        /// <summary>The name which should be used for the Storage Account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter StorageAccountName { get => (this._storageAccountName = this._storageAccountName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._storageAccountName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? StorageAccountNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string StorageAccountNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountName).Value = value; }

        /// <summary>Backing field for <see cref="StorageAccountSkuName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _storageAccountSkuName;

        /// <summary>The SKU which should be used for this Storage Account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter StorageAccountSkuName { get => (this._storageAccountSkuName = this._storageAccountSkuName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._storageAccountSkuName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? StorageAccountSkuNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountSkuName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string StorageAccountSkuNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountSkuName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)StorageAccountSkuName).Value = value; }

        /// <summary>Backing field for <see cref="VnetAddressPrefix" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _vnetAddressPrefix;

        /// <summary>
        /// The first 2 octets of the virtual network /16 address range (e.g., '10.139' for the address range 10.139.0.0/16).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter VnetAddressPrefix { get => (this._vnetAddressPrefix = this._vnetAddressPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._vnetAddressPrefix = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? VnetAddressPrefixType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)VnetAddressPrefix).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string VnetAddressPrefixValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)VnetAddressPrefix).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)VnetAddressPrefix).Value = value; }

        /// <summary>Creates an new <see cref="WorkspaceCustomParameters" /> instance.</summary>
        public WorkspaceCustomParameters()
        {

        }
    }
    /// Custom Parameters used for Cluster Creation.
    public partial interface IWorkspaceCustomParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string AmlWorkspaceIdValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string CustomPrivateSubnetNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string CustomPublicSubnetNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string CustomVirtualNetworkIdValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(bool) })]
        bool EnableNoPublicIPValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? LoadBalancerBackendPoolNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string LoadBalancerBackendPoolNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? LoadBalancerIdType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string LoadBalancerIdValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RelayNamespaceNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string RelayNamespaceNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? ResourceTagType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterValue) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterValue ResourceTagValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? StorageAccountNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? StorageAccountSkuNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountSkuNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? VnetAddressPrefixType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string VnetAddressPrefixValue { get; set; }

    }
    /// Custom Parameters used for Cluster Creation.
    internal partial interface IWorkspaceCustomParametersInternal

    {
        /// <summary>The Workspace ID of an Azure Machine Learning Workspace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter AmlWorkspaceId { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string AmlWorkspaceIdValue { get; set; }
        /// <summary>The name of the Private Subnet within the Virtual Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPrivateSubnetName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomPrivateSubnetNameValue { get; set; }
        /// <summary>The name of a Public Subnet within the Virtual Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPublicSubnetName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomPublicSubnetNameValue { get; set; }
        /// <summary>The ID of a Virtual Network where this Databricks Cluster should be created</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomVirtualNetworkId { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomVirtualNetworkIdValue { get; set; }
        /// <summary>Should the Public IP be Disabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter EnableNoPublicIP { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool EnableNoPublicIPValue { get; set; }
        /// <summary>The name of a Backend Address Pool within an Azure Load Balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter LoadBalancerBackendPoolName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? LoadBalancerBackendPoolNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string LoadBalancerBackendPoolNameValue { get; set; }
        /// <summary>The Resource ID of an Azure Load Balancer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter LoadBalancerId { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? LoadBalancerIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string LoadBalancerIdValue { get; set; }
        /// <summary>The name of an Azure Relay Namespace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter RelayNamespaceName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RelayNamespaceNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string RelayNamespaceNameValue { get; set; }
        /// <summary>
        /// A map of Tags which should be applied to the resources used by this Databricks Cluster.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameter ResourceTag { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? ResourceTagType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomObjectParameterValue ResourceTagValue { get; set; }
        /// <summary>The name which should be used for the Storage Account</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter StorageAccountName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? StorageAccountNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string StorageAccountNameValue { get; set; }
        /// <summary>The SKU which should be used for this Storage Account</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter StorageAccountSkuName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? StorageAccountSkuNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string StorageAccountSkuNameValue { get; set; }
        /// <summary>
        /// The first 2 octets of the virtual network /16 address range (e.g., '10.139' for the address range 10.139.0.0/16).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter VnetAddressPrefix { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? VnetAddressPrefixType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string VnetAddressPrefixValue { get; set; }

    }
}