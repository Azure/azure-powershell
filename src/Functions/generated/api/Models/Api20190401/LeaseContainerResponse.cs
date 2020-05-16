namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Lease Container response schema.</summary>
    public partial class LeaseContainerResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILeaseContainerResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILeaseContainerResponseInternal
    {

        /// <summary>Backing field for <see cref="LeaseId" /> property.</summary>
        private string _leaseId;

        /// <summary>
        /// Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release
        /// the lease.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LeaseId { get => this._leaseId; set => this._leaseId = value; }

        /// <summary>Backing field for <see cref="LeaseTimeSecond" /> property.</summary>
        private string _leaseTimeSecond;

        /// <summary>Approximate time remaining in the lease period, in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LeaseTimeSecond { get => this._leaseTimeSecond; set => this._leaseTimeSecond = value; }

        /// <summary>Creates an new <see cref="LeaseContainerResponse" /> instance.</summary>
        public LeaseContainerResponse()
        {

        }
    }
    /// Lease Container response schema.
    public partial interface ILeaseContainerResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release
        /// the lease.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release the lease.",
        SerializedName = @"leaseId",
        PossibleTypes = new [] { typeof(string) })]
        string LeaseId { get; set; }
        /// <summary>Approximate time remaining in the lease period, in seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Approximate time remaining in the lease period, in seconds.",
        SerializedName = @"leaseTimeSeconds",
        PossibleTypes = new [] { typeof(string) })]
        string LeaseTimeSecond { get; set; }

    }
    /// Lease Container response schema.
    internal partial interface ILeaseContainerResponseInternal

    {
        /// <summary>
        /// Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release
        /// the lease.
        /// </summary>
        string LeaseId { get; set; }
        /// <summary>Approximate time remaining in the lease period, in seconds.</summary>
        string LeaseTimeSecond { get; set; }

    }
}