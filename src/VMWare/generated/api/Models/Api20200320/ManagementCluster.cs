namespace Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Extensions;

    /// <summary>The properties of a default cluster</summary>
    public partial class ManagementCluster :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementCluster,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdateProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdateProperties __clusterUpdateProperties = new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.ClusterUpdateProperties();

        /// <summary>Backing field for <see cref="ClusterId" /> property.</summary>
        private int? _clusterId;

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        public int? ClusterId { get => this._clusterId; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdatePropertiesInternal)__clusterUpdateProperties).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdatePropertiesInternal)__clusterUpdateProperties).ClusterSize = value; }

        /// <summary>Backing field for <see cref="Host" /> property.</summary>
        private string[] _host;

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        public string[] Host { get => this._host; }

        /// <summary>Internal Acessors for ClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal.ClusterId { get => this._clusterId; set { {_clusterId = value;} } }

        /// <summary>Internal Acessors for Host</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IManagementClusterInternal.Host { get => this._host; set { {_host = value;} } }

        /// <summary>Creates an new <see cref="ManagementCluster" /> instance.</summary>
        public ManagementCluster()
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
            await eventListener.AssertNotNull(nameof(__clusterUpdateProperties), __clusterUpdateProperties);
            await eventListener.AssertObjectIsValid(nameof(__clusterUpdateProperties), __clusterUpdateProperties);
        }
    }
    /// The properties of a default cluster
    public partial interface IManagementCluster :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdateProperties
    {
        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterId { get;  }
        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hosts",
        SerializedName = @"hosts",
        PossibleTypes = new [] { typeof(string) })]
        string[] Host { get;  }

    }
    /// The properties of a default cluster
    internal partial interface IManagementClusterInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IClusterUpdatePropertiesInternal
    {
        /// <summary>The identity</summary>
        int? ClusterId { get; set; }
        /// <summary>The hosts</summary>
        string[] Host { get; set; }

    }
}