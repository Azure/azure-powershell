namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ContainerThrottlingData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingDataInternal
    {

        /// <summary>Backing field for <see cref="Period" /> property.</summary>
        private int? _period;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Period { get => this._period; set => this._period = value; }

        /// <summary>Backing field for <see cref="ThrottledPeriod" /> property.</summary>
        private int? _throttledPeriod;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ThrottledPeriod { get => this._throttledPeriod; set => this._throttledPeriod = value; }

        /// <summary>Backing field for <see cref="ThrottledTime" /> property.</summary>
        private int? _throttledTime;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ThrottledTime { get => this._throttledTime; set => this._throttledTime = value; }

        /// <summary>Creates an new <see cref="ContainerThrottlingData" /> instance.</summary>
        public ContainerThrottlingData()
        {

        }
    }
    public partial interface IContainerThrottlingData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"periods",
        PossibleTypes = new [] { typeof(int) })]
        int? Period { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledPeriods",
        PossibleTypes = new [] { typeof(int) })]
        int? ThrottledPeriod { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"throttledTime",
        PossibleTypes = new [] { typeof(int) })]
        int? ThrottledTime { get; set; }

    }
    internal partial interface IContainerThrottlingDataInternal

    {
        int? Period { get; set; }

        int? ThrottledPeriod { get; set; }

        int? ThrottledTime { get; set; }

    }
}