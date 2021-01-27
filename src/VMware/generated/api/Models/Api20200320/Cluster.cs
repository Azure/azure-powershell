namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>A cluster resource</summary>
    public partial class Cluster :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICluster,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Resource();

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public int? ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).ClusterId; }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string[] Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).Host; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for ClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterInternal.ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).ClusterId = value; }

        /// <summary>Internal Acessors for Host</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterInternal.Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).Host; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).Host = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterProperties Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ISku Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterProperties _property;

        /// <summary>The properties of a cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ClusterProperties()); set => this._property = value; }

        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementClusterInternal)Property).ProvisioningState; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public int? Size { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal)Property).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal)Property).ClusterSize = value ?? default(int); }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ISku _sku;

        /// <summary>The cluster SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Sku()); set => this._sku = value; }

        /// <summary>The name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ISkuInternal)Sku).Name = value ; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Cluster" /> instance.</summary>
        public Cluster()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// A cluster resource
    public partial interface ICluster :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResource
    {
        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterId { get;  }
        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hosts",
        SerializedName = @"hosts",
        PossibleTypes = new [] { typeof(string) })]
        string[] Host { get;  }
        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the cluster provisioning",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ProvisioningState { get;  }
        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The cluster size",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? Size { get; set; }
        /// <summary>The name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }

    }
    /// A cluster resource
    internal partial interface IClusterInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal
    {
        /// <summary>The identity</summary>
        int? ClusterId { get; set; }
        /// <summary>The hosts</summary>
        string[] Host { get; set; }
        /// <summary>The properties of a cluster resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterProperties Property { get; set; }
        /// <summary>The state of the cluster provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ProvisioningState { get; set; }
        /// <summary>The cluster size</summary>
        int? Size { get; set; }
        /// <summary>The cluster SKU</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ISku Sku { get; set; }
        /// <summary>The name of the SKU.</summary>
        string SkuName { get; set; }

    }
}