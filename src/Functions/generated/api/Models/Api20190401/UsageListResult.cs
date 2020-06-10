namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The response from the List Usages operation.</summary>
    public partial class UsageListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsage[] _value;

        /// <summary>Gets or sets the list of Storage Resource Usages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsage[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="UsageListResult" /> instance.</summary>
        public UsageListResult()
        {

        }
    }
    /// The response from the List Usages operation.
    public partial interface IUsageListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the list of Storage Resource Usages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of Storage Resource Usages.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsage) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsage[] Value { get; set; }

    }
    /// The response from the List Usages operation.
    internal partial interface IUsageListResultInternal

    {
        /// <summary>Gets or sets the list of Storage Resource Usages.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsage[] Value { get; set; }

    }
}