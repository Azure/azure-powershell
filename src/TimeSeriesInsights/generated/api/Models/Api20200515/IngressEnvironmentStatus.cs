namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>An object that represents the status of ingress on an environment.</summary>
    public partial class IngressEnvironmentStatus :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatus,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal
    {

        /// <summary>Internal Acessors for StateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetails Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal.StateDetail { get => (this._stateDetail = this._stateDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.EnvironmentStateDetails()); set { {_stateDetail = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? _state;

        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="StateDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetails _stateDetail;

        /// <summary>An object that contains the details about an environment's state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetails StateDetail { get => (this._stateDetail = this._stateDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.EnvironmentStateDetails()); }

        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StateDetailCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetailsInternal)StateDetail).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetailsInternal)StateDetail).Code = value; }

        /// <summary>A message that describes the state in detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StateDetailMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetailsInternal)StateDetail).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetailsInternal)StateDetail).Message = value; }

        /// <summary>Creates an new <see cref="IngressEnvironmentStatus" /> instance.</summary>
        public IngressEnvironmentStatus()
        {

        }
    }
    /// An object that represents the status of ingress on an environment.
    public partial interface IIngressEnvironmentStatus :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This string represents the state of ingress operations on an environment. It can be ""Disabled"", ""Ready"", ""Running"", ""Paused"" or ""Unknown""",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? State { get; set; }
        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically handle specific cases.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string StateDetailCode { get; set; }
        /// <summary>A message that describes the state in detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A message that describes the state in detail.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string StateDetailMessage { get; set; }

    }
    /// An object that represents the status of ingress on an environment.
    internal partial interface IIngressEnvironmentStatusInternal

    {
        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? State { get; set; }
        /// <summary>An object that contains the details about an environment's state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetails StateDetail { get; set; }
        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        string StateDetailCode { get; set; }
        /// <summary>A message that describes the state in detail.</summary>
        string StateDetailMessage { get; set; }

    }
}