namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Trigger based on total requests.</summary>
    public partial class RequestsBasedTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTriggerInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="TimeInterval" /> property.</summary>
        private string _timeInterval;

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TimeInterval { get => this._timeInterval; set => this._timeInterval = value; }

        /// <summary>Creates an new <see cref="RequestsBasedTrigger" /> instance.</summary>
        public RequestsBasedTrigger()
        {

        }
    }
    /// Trigger based on total requests.
    public partial interface IRequestsBasedTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get; set; }
        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time interval.",
        SerializedName = @"timeInterval",
        PossibleTypes = new [] { typeof(string) })]
        string TimeInterval { get; set; }

    }
    /// Trigger based on total requests.
    internal partial interface IRequestsBasedTriggerInternal

    {
        /// <summary>Request Count.</summary>
        int? Count { get; set; }
        /// <summary>Time interval.</summary>
        string TimeInterval { get; set; }

    }
}