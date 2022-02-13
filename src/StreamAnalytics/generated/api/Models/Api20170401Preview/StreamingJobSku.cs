namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a SKU.</summary>
    public partial class StreamingJobSku :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? _name;

        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="StreamingJobSku" /> instance.</summary>
        public StreamingJobSku()
        {

        }
    }
    /// The properties that are associated with a SKU.
    public partial interface IStreamingJobSku :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? Name { get; set; }

    }
    /// The properties that are associated with a SKU.
    internal partial interface IStreamingJobSkuInternal

    {
        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? Name { get; set; }

    }
}