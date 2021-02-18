namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for solution properties.</summary>
    public partial class SolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CleanupState" /> property.</summary>
        private string _cleanupState;

        /// <summary>Gets or sets the cleanup state of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CleanupState { get => this._cleanupState; set => this._cleanupState = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetails _detail;

        /// <summary>Gets or sets the details of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetails Detail { get => (this._detail = this._detail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionDetails()); set => this._detail = value; }

        /// <summary>Gets or sets the count of assessments reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? DetailAssessmentCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal)Detail).AssessmentCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal)Detail).AssessmentCount = value ?? default(int); }

        /// <summary>Gets or sets the extended details reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails DetailExtendedDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal)Detail).ExtendedDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal)Detail).ExtendedDetail = value ?? null /* model class */; }

        /// <summary>Gets or sets the count of groups reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? DetailGroupCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal)Detail).GroupCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsInternal)Detail).GroupCount = value ?? default(int); }

        /// <summary>Backing field for <see cref="Goal" /> property.</summary>
        private string _goal;

        /// <summary>Gets or sets the goal of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Goal { get => this._goal; set => this._goal = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionPropertiesInternal.Detail { get => (this._detail = this._detail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionDetails()); set { {_detail = value;} } }

        /// <summary>Internal Acessors for Summary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionPropertiesInternal.Summary { get => (this._summary = this._summary ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionSummary()); set { {_summary = value;} } }

        /// <summary>Internal Acessors for SummaryInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionPropertiesInternal.SummaryInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)Summary).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)Summary).InstanceType = value; }

        /// <summary>Backing field for <see cref="Purpose" /> property.</summary>
        private string _purpose;

        /// <summary>Gets or sets the purpose of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Purpose { get => this._purpose; set => this._purpose = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Gets or sets the current status of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary _summary;

        /// <summary>Gets or sets the summary of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary Summary { get => (this._summary = this._summary ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionSummary()); set => this._summary = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SummaryInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)Summary).InstanceType; }

        /// <summary>Backing field for <see cref="Tool" /> property.</summary>
        private string _tool;

        /// <summary>Gets or sets the tool being used in the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Tool { get => this._tool; set => this._tool = value; }

        /// <summary>Creates an new <see cref="SolutionProperties" /> instance.</summary>
        public SolutionProperties()
        {

        }
    }
    /// Class for solution properties.
    public partial interface ISolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the cleanup state of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the cleanup state of the solution.",
        SerializedName = @"cleanupState",
        PossibleTypes = new [] { typeof(string) })]
        string CleanupState { get; set; }
        /// <summary>Gets or sets the count of assessments reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of assessments reported by the solution.",
        SerializedName = @"assessmentCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DetailAssessmentCount { get; set; }
        /// <summary>Gets or sets the extended details reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the extended details reported by the solution.",
        SerializedName = @"extendedDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails DetailExtendedDetail { get; set; }
        /// <summary>Gets or sets the count of groups reported by the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of groups reported by the solution.",
        SerializedName = @"groupCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DetailGroupCount { get; set; }
        /// <summary>Gets or sets the goal of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the goal of the solution.",
        SerializedName = @"goal",
        PossibleTypes = new [] { typeof(string) })]
        string Goal { get; set; }
        /// <summary>Gets or sets the purpose of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the purpose of the solution.",
        SerializedName = @"purpose",
        PossibleTypes = new [] { typeof(string) })]
        string Purpose { get; set; }
        /// <summary>Gets or sets the current status of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the current status of the solution.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryInstanceType { get;  }
        /// <summary>Gets or sets the tool being used in the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the tool being used in the solution.",
        SerializedName = @"tool",
        PossibleTypes = new [] { typeof(string) })]
        string Tool { get; set; }

    }
    /// Class for solution properties.
    internal partial interface ISolutionPropertiesInternal

    {
        /// <summary>Gets or sets the cleanup state of the solution.</summary>
        string CleanupState { get; set; }
        /// <summary>Gets or sets the details of the solution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetails Detail { get; set; }
        /// <summary>Gets or sets the count of assessments reported by the solution.</summary>
        int? DetailAssessmentCount { get; set; }
        /// <summary>Gets or sets the extended details reported by the solution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionDetailsExtendedDetails DetailExtendedDetail { get; set; }
        /// <summary>Gets or sets the count of groups reported by the solution.</summary>
        int? DetailGroupCount { get; set; }
        /// <summary>Gets or sets the goal of the solution.</summary>
        string Goal { get; set; }
        /// <summary>Gets or sets the purpose of the solution.</summary>
        string Purpose { get; set; }
        /// <summary>Gets or sets the current status of the solution.</summary>
        string Status { get; set; }
        /// <summary>Gets or sets the summary of the solution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary Summary { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string SummaryInstanceType { get; set; }
        /// <summary>Gets or sets the tool being used in the solution.</summary>
        string Tool { get; set; }

    }
}