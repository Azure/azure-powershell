namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the details of the solution.</summary>
    public partial class SolutionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal
    {

        /// <summary>Backing field for <see cref="AssessmentCount" /> property.</summary>
        private int? _assessmentCount;

        /// <summary>Gets or sets the count of assessments reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? AssessmentCount { get => this._assessmentCount; set => this._assessmentCount = value; }

        /// <summary>Backing field for <see cref="ExtendedDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails _extendedDetail;

        /// <summary>Gets or sets the extended details reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails ExtendedDetail { get => (this._extendedDetail = this._extendedDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionDetailsExtendedDetails()); set => this._extendedDetail = value; }

        /// <summary>Backing field for <see cref="GroupCount" /> property.</summary>
        private int? _groupCount;

        /// <summary>Gets or sets the count of groups reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? GroupCount { get => this._groupCount; set => this._groupCount = value; }

        /// <summary>Creates an new <see cref="SolutionDetails" /> instance.</summary>
        public SolutionDetails()
        {

        }
    }
    /// Class representing the details of the solution.
    public partial interface ISolutionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the count of assessments reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of assessments reported by the solution.",
        SerializedName = @"assessmentCount",
        PossibleTypes = new [] { typeof(int) })]
        int? AssessmentCount { get; set; }
        /// <summary>Gets or sets the extended details reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the extended details reported by the solution.",
        SerializedName = @"extendedDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails ExtendedDetail { get; set; }
        /// <summary>Gets or sets the count of groups reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of groups reported by the solution.",
        SerializedName = @"groupCount",
        PossibleTypes = new [] { typeof(int) })]
        int? GroupCount { get; set; }

    }
    /// Class representing the details of the solution.
    internal partial interface ISolutionDetailsInternal

    {
        /// <summary>Gets or sets the count of assessments reported by the solution.</summary>
        int? AssessmentCount { get; set; }
        /// <summary>Gets or sets the extended details reported by the solution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails ExtendedDetail { get; set; }
        /// <summary>Gets or sets the count of groups reported by the solution.</summary>
        int? GroupCount { get; set; }

    }
}