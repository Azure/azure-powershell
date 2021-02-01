namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Base class to define the health summary of the resources contained under an Arm resource.
    /// </summary>
    public partial class ResourceHealthSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal
    {

        /// <summary>Backing field for <see cref="CategorizedResourceCount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts _categorizedResourceCount;

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts CategorizedResourceCount { get => (this._categorizedResourceCount = this._categorizedResourceCount ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummaryCategorizedResourceCounts()); set => this._categorizedResourceCount = value; }

        /// <summary>Backing field for <see cref="Issue" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] _issue;

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] Issue { get => this._issue; set => this._issue = value; }

        /// <summary>Backing field for <see cref="ResourceCount" /> property.</summary>
        private int? _resourceCount;

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ResourceCount { get => this._resourceCount; set => this._resourceCount = value; }

        /// <summary>Creates an new <see cref="ResourceHealthSummary" /> instance.</summary>
        public ResourceHealthSummary()
        {

        }
    }
    /// Base class to define the health summary of the resources contained under an Arm resource.
    public partial interface IResourceHealthSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts CategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] Issue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ResourceCount { get; set; }

    }
    /// Base class to define the health summary of the resources contained under an Arm resource.
    internal partial interface IResourceHealthSummaryInternal

    {
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts CategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] Issue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? ResourceCount { get; set; }

    }
}