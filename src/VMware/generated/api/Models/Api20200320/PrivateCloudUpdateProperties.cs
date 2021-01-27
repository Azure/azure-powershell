namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of a private cloud resource that may be updated</summary>
    public partial class PrivateCloudUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="IdentitySource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[] _identitySource;

        /// <summary>vCenter Single Sign On Identity Sources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[] IdentitySource { get => this._identitySource; set => this._identitySource = value; }

        /// <summary>Backing field for <see cref="Internet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum? _internet;

        /// <summary>Connectivity to internet is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum? Internet { get => this._internet; set => this._internet = value; }

        /// <summary>Backing field for <see cref="ManagementCluster" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster _managementCluster;

        /// <summary>The default cluster used for management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster ManagementCluster { get => (this._managementCluster = this._managementCluster ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ManagementCluster()); set => this._managementCluster = value; }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string[] ManagementClusterHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).Host; }

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public int? ManagementClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).ClusterId; }

        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ManagementClusterProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).ProvisioningState; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public int? ManagementClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal)ManagementCluster).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal)ManagementCluster).ClusterSize = value ?? default(int); }

        /// <summary>Internal Acessors for ManagementCluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementCluster { get => (this._managementCluster = this._managementCluster ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ManagementCluster()); set { {_managementCluster = value;} } }

        /// <summary>Internal Acessors for ManagementClusterHost</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementClusterHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).Host; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).Host = value; }

        /// <summary>Internal Acessors for ManagementClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).ClusterId = value; }

        /// <summary>Internal Acessors for ManagementClusterProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementClusterProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)ManagementCluster).ProvisioningState = value; }

        /// <summary>Creates an new <see cref="PrivateCloudUpdateProperties" /> instance.</summary>
        public PrivateCloudUpdateProperties()
        {

        }
    }
    /// The properties of a private cloud resource that may be updated
    public partial interface IPrivateCloudUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>vCenter Single Sign On Identity Sources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"vCenter Single Sign On Identity Sources",
        SerializedName = @"identitySources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[] IdentitySource { get; set; }
        /// <summary>Connectivity to internet is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connectivity to internet is enabled or disabled",
        SerializedName = @"internet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum? Internet { get; set; }
        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hosts",
        SerializedName = @"hosts",
        PossibleTypes = new [] { typeof(string) })]
        string[] ManagementClusterHost { get;  }
        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagementClusterId { get;  }
        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the cluster provisioning",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ManagementClusterProvisioningState { get;  }
        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The cluster size",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagementClusterSize { get; set; }

    }
    /// The properties of a private cloud resource that may be updated
    internal partial interface IPrivateCloudUpdatePropertiesInternal

    {
        /// <summary>vCenter Single Sign On Identity Sources</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[] IdentitySource { get; set; }
        /// <summary>Connectivity to internet is enabled or disabled</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum? Internet { get; set; }
        /// <summary>The default cluster used for management</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster ManagementCluster { get; set; }
        /// <summary>The hosts</summary>
        string[] ManagementClusterHost { get; set; }
        /// <summary>The identity</summary>
        int? ManagementClusterId { get; set; }
        /// <summary>The state of the cluster provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ManagementClusterProvisioningState { get; set; }
        /// <summary>The cluster size</summary>
        int? ManagementClusterSize { get; set; }

    }
}