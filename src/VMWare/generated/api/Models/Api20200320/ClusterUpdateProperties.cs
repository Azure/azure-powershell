namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of a cluster that may be updated</summary>
    public partial class ClusterUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IClusterUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClusterSize" /> property.</summary>
        private int? _clusterSize;

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public int? ClusterSize { get => this._clusterSize; set => this._clusterSize = value; }

        /// <summary>Creates an new <see cref="ClusterUpdateProperties" /> instance.</summary>
        public ClusterUpdateProperties()
        {

        }
    }
    /// The properties of a cluster that may be updated
    public partial interface IClusterUpdateProperties :
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
    /// The properties of a cluster that may be updated
    internal partial interface IClusterUpdatePropertiesInternal

    {
        /// <summary>The cluster size</summary>
        int? ClusterSize { get; set; }

    }
}