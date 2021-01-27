namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>An update of a cluster resource</summary>
    public partial class ClusterUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateInternal
    {

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal)Property).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal)Property).ClusterSize = value ?? default(int); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ClusterUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateProperties _property;

        /// <summary>The properties of a cluster resource that may be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ClusterUpdateProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="ClusterUpdate" /> instance.</summary>
        public ClusterUpdate()
        {

        }
    }
    /// An update of a cluster resource
    public partial interface IClusterUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The cluster size",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterSize { get; set; }

    }
    /// An update of a cluster resource
    internal partial interface IClusterUpdateInternal

    {
        /// <summary>The cluster size</summary>
        int? ClusterSize { get; set; }
        /// <summary>The properties of a cluster resource that may be updated</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateProperties Property { get; set; }

    }
}