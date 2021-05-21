namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The SKU of the cluster. This determines the size/capacity of the cluster. Required on PUT (CreateOrUpdate) requests.
    /// </summary>
    public partial class ClusterSku :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSku,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterSkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>
        /// Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with
        /// a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? _name;

        /// <summary>
        /// Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ClusterSku" /> instance.</summary>
        public ClusterSku()
        {

        }
    }
    /// The SKU of the cluster. This determines the size/capacity of the cluster. Required on PUT (CreateOrUpdate) requests.
    public partial interface IClusterSku :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with
        /// a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>
        /// Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? Name { get; set; }

    }
    /// The SKU of the cluster. This determines the size/capacity of the cluster. Required on PUT (CreateOrUpdate) requests.
    internal partial interface IClusterSkuInternal

    {
        /// <summary>
        /// Denotes the number of streaming units the cluster can support. Valid values for this property are multiples of 36 with
        /// a minimum value of 36 and maximum value of 216. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        int? Capacity { get; set; }
        /// <summary>
        /// Specifies the SKU name of the cluster. Required on PUT (CreateOrUpdate) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName? Name { get; set; }

    }
}