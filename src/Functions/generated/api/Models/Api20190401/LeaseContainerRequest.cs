namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Lease Container request schema.</summary>
    public partial class LeaseContainerRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILeaseContainerRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILeaseContainerRequestInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private string _action;

        /// <summary>Specifies the lease action. Can be one of the available actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="BreakPeriod" /> property.</summary>
        private int? _breakPeriod;

        /// <summary>
        /// Optional. For a break action, proposed duration the lease should continue before it is broken, in seconds, between 0 and
        /// 60.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? BreakPeriod { get => this._breakPeriod; set => this._breakPeriod = value; }

        /// <summary>Backing field for <see cref="LeaseDuration" /> property.</summary>
        private int? _leaseDuration;

        /// <summary>
        /// Required for acquire. Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? LeaseDuration { get => this._leaseDuration; set => this._leaseDuration = value; }

        /// <summary>Backing field for <see cref="LeaseId" /> property.</summary>
        private string _leaseId;

        /// <summary>Identifies the lease. Can be specified in any valid GUID string format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LeaseId { get => this._leaseId; set => this._leaseId = value; }

        /// <summary>Backing field for <see cref="ProposedLeaseId" /> property.</summary>
        private string _proposedLeaseId;

        /// <summary>
        /// Optional for acquire, required for change. Proposed lease ID, in a GUID string format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ProposedLeaseId { get => this._proposedLeaseId; set => this._proposedLeaseId = value; }

        /// <summary>Creates an new <see cref="LeaseContainerRequest" /> instance.</summary>
        public LeaseContainerRequest()
        {

        }
    }
    /// Lease Container request schema.
    public partial interface ILeaseContainerRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the lease action. Can be one of the available actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the lease action. Can be one of the available actions.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(string) })]
        string Action { get; set; }
        /// <summary>
        /// Optional. For a break action, proposed duration the lease should continue before it is broken, in seconds, between 0 and
        /// 60.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional. For a break action, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60.",
        SerializedName = @"breakPeriod",
        PossibleTypes = new [] { typeof(int) })]
        int? BreakPeriod { get; set; }
        /// <summary>
        /// Required for acquire. Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Required for acquire. Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires.",
        SerializedName = @"leaseDuration",
        PossibleTypes = new [] { typeof(int) })]
        int? LeaseDuration { get; set; }
        /// <summary>Identifies the lease. Can be specified in any valid GUID string format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identifies the lease. Can be specified in any valid GUID string format.",
        SerializedName = @"leaseId",
        PossibleTypes = new [] { typeof(string) })]
        string LeaseId { get; set; }
        /// <summary>
        /// Optional for acquire, required for change. Proposed lease ID, in a GUID string format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional for acquire, required for change. Proposed lease ID, in a GUID string format.",
        SerializedName = @"proposedLeaseId",
        PossibleTypes = new [] { typeof(string) })]
        string ProposedLeaseId { get; set; }

    }
    /// Lease Container request schema.
    internal partial interface ILeaseContainerRequestInternal

    {
        /// <summary>Specifies the lease action. Can be one of the available actions.</summary>
        string Action { get; set; }
        /// <summary>
        /// Optional. For a break action, proposed duration the lease should continue before it is broken, in seconds, between 0 and
        /// 60.
        /// </summary>
        int? BreakPeriod { get; set; }
        /// <summary>
        /// Required for acquire. Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires.
        /// </summary>
        int? LeaseDuration { get; set; }
        /// <summary>Identifies the lease. Can be specified in any valid GUID string format.</summary>
        string LeaseId { get; set; }
        /// <summary>
        /// Optional for acquire, required for change. Proposed lease ID, in a GUID string format.
        /// </summary>
        string ProposedLeaseId { get; set; }

    }
}