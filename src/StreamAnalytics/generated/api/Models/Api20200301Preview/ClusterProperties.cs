namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties associated with a Stream Analytics cluster.</summary>
    public partial class ClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CapacityAllocated" /> property.</summary>
        private int? _capacityAllocated;

        /// <summary>Represents the number of streaming units currently being used on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? CapacityAllocated { get => this._capacityAllocated; }

        /// <summary>Backing field for <see cref="CapacityAssigned" /> property.</summary>
        private int? _capacityAssigned;

        /// <summary>
        /// Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this
        /// would be the capacity allocated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? CapacityAssigned { get => this._capacityAssigned; }

        /// <summary>Backing field for <see cref="ClusterId" /> property.</summary>
        private string _clusterId;

        /// <summary>Unique identifier for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ClusterId { get => this._clusterId; }

        /// <summary>Backing field for <see cref="CreatedDate" /> property.</summary>
        private global::System.DateTime? _createdDate;

        /// <summary>The date this cluster was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedDate { get => this._createdDate; }

        /// <summary>Internal Acessors for CapacityAllocated</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal.CapacityAllocated { get => this._capacityAllocated; set { {_capacityAllocated = value;} } }

        /// <summary>Internal Acessors for CapacityAssigned</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal.CapacityAssigned { get => this._capacityAssigned; set { {_capacityAssigned = value;} } }

        /// <summary>Internal Acessors for ClusterId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal.ClusterId { get => this._clusterId; set { {_clusterId = value;} } }

        /// <summary>Internal Acessors for CreatedDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal.CreatedDate { get => this._createdDate; set { {_createdDate = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? _provisioningState;

        /// <summary>
        /// The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ClusterProperties" /> instance.</summary>
        public ClusterProperties()
        {

        }
    }
    /// The properties associated with a Stream Analytics cluster.
    public partial interface IClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>Represents the number of streaming units currently being used on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the number of streaming units currently being used on the cluster.",
        SerializedName = @"capacityAllocated",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityAllocated { get;  }
        /// <summary>
        /// Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this
        /// would be the capacity allocated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this would be the capacity allocated.",
        SerializedName = @"capacityAssigned",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityAssigned { get;  }
        /// <summary>Unique identifier for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unique identifier for the cluster.",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterId { get;  }
        /// <summary>The date this cluster was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date this cluster was created.",
        SerializedName = @"createdDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedDate { get;  }
        /// <summary>
        /// The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? ProvisioningState { get;  }

    }
    /// The properties associated with a Stream Analytics cluster.
    internal partial interface IClusterPropertiesInternal

    {
        /// <summary>Represents the number of streaming units currently being used on the cluster.</summary>
        int? CapacityAllocated { get; set; }
        /// <summary>
        /// Represents the sum of the SUs of all streaming jobs associated with the cluster. If all of the jobs were running, this
        /// would be the capacity allocated.
        /// </summary>
        int? CapacityAssigned { get; set; }
        /// <summary>Unique identifier for the cluster.</summary>
        string ClusterId { get; set; }
        /// <summary>The date this cluster was created.</summary>
        global::System.DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The status of the cluster provisioning. The three terminal states are: Succeeded, Failed and Canceled
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterProvisioningState? ProvisioningState { get; set; }

    }
}