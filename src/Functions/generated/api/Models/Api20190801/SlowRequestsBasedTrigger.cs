namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Trigger based on request execution time.</summary>
    public partial class SlowRequestsBasedTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTriggerInternal
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

        /// <summary>Backing field for <see cref="TimeTaken" /> property.</summary>
        private string _timeTaken;

        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TimeTaken { get => this._timeTaken; set => this._timeTaken = value; }

        /// <summary>Creates an new <see cref="SlowRequestsBasedTrigger" /> instance.</summary>
        public SlowRequestsBasedTrigger()
        {

        }
    }
    /// Trigger based on request execution time.
    public partial interface ISlowRequestsBasedTrigger :
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
        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time taken.",
        SerializedName = @"timeTaken",
        PossibleTypes = new [] { typeof(string) })]
        string TimeTaken { get; set; }

    }
    /// Trigger based on request execution time.
    internal partial interface ISlowRequestsBasedTriggerInternal

    {
        /// <summary>Request Count.</summary>
        int? Count { get; set; }
        /// <summary>Time interval.</summary>
        string TimeInterval { get; set; }
        /// <summary>Time taken.</summary>
        string TimeTaken { get; set; }

    }
}