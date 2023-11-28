namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>A list of performance tiers.</summary>
    public partial class PerformanceTierListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties[] _value;

        /// <summary>The list of performance tiers</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PerformanceTierListResult" /> instance.</summary>
        public PerformanceTierListResult()
        {

        }
    }
    /// A list of performance tiers.
    public partial interface IPerformanceTierListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>The list of performance tiers</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of performance tiers",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties[] Value { get; set; }

    }
    /// A list of performance tiers.
    internal partial interface IPerformanceTierListResultInternal

    {
        /// <summary>The list of performance tiers</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties[] Value { get; set; }

    }
}