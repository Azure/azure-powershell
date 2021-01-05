namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the refresh summary input.</summary>
    public partial class RefreshSummaryInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRefreshSummaryInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRefreshSummaryInputInternal
    {

        /// <summary>Backing field for <see cref="Goal" /> property.</summary>
        private string _goal;

        /// <summary>Gets or sets the goal for which summary needs to be refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Goal { get => this._goal; set => this._goal = value; }

        /// <summary>Creates an new <see cref="RefreshSummaryInput" /> instance.</summary>
        public RefreshSummaryInput()
        {

        }
    }
    /// Class representing the refresh summary input.
    public partial interface IRefreshSummaryInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the goal for which summary needs to be refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the goal for which summary needs to be refreshed.",
        SerializedName = @"goal",
        PossibleTypes = new [] { typeof(string) })]
        string Goal { get; set; }

    }
    /// Class representing the refresh summary input.
    internal partial interface IRefreshSummaryInputInternal

    {
        /// <summary>Gets or sets the goal for which summary needs to be refreshed.</summary>
        string Goal { get; set; }

    }
}