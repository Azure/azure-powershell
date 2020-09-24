namespace Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Extensions;

    /// <summary>The properties of a cluster</summary>
    public partial class ClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementCluster"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementCluster __managementCluster = new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.ManagementCluster();

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public int? ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal)__managementCluster).ClusterId; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdatePropertiesInternal)__managementCluster).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdatePropertiesInternal)__managementCluster).ClusterSize = value; }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public string[] Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal)__managementCluster).Host; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal.ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal)__managementCluster).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal)__managementCluster).ClusterId = value; }

        /// <summary>Internal Acessors for Host</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal.Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal)__managementCluster).Host; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal)__managementCluster).Host = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ClusterProvisioningState? _provisioningState;

        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ClusterProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ClusterProperties" /> instance.</summary>
        public ClusterProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__managementCluster), __managementCluster);
            await eventListener.AssertObjectIsValid(nameof(__managementCluster), __managementCluster);
        }
    }
    /// The properties of a cluster
    public partial interface IClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementCluster
    {
        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the cluster provisioning",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ClusterProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ClusterProvisioningState? ProvisioningState { get;  }

    }
    /// The properties of a cluster
    internal partial interface IClusterPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal
    {
        /// <summary>The state of the cluster provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ClusterProvisioningState? ProvisioningState { get; set; }

    }
}