namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the refresh summary status of the migrate project.</summary>
    public partial class RefreshSummaryResult :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRefreshSummaryResult,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRefreshSummaryResultInternal
    {

        /// <summary>Backing field for <see cref="IsRefreshed" /> property.</summary>
        private bool? _isRefreshed;

        /// <summary>
        /// Gets or sets a value indicating whether the migrate project summary is refreshed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsRefreshed { get => this._isRefreshed; set => this._isRefreshed = value; }

        /// <summary>Creates an new <see cref="RefreshSummaryResult" /> instance.</summary>
        public RefreshSummaryResult()
        {

        }
    }
    /// Class representing the refresh summary status of the migrate project.
    public partial interface IRefreshSummaryResult :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets a value indicating whether the migrate project summary is refreshed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether the migrate project summary is refreshed.",
        SerializedName = @"isRefreshed",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsRefreshed { get; set; }

    }
    /// Class representing the refresh summary status of the migrate project.
    internal partial interface IRefreshSummaryResultInternal

    {
        /// <summary>
        /// Gets or sets a value indicating whether the migrate project summary is refreshed.
        /// </summary>
        bool? IsRefreshed { get; set; }

    }
}