namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>class to define the summary of the health error details.</summary>
    public partial class HealthErrorSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummaryInternal
    {

        /// <summary>Backing field for <see cref="AffectedResourceCorrelationId" /> property.</summary>
        private string[] _affectedResourceCorrelationId;

        /// <summary>
        /// The list of affected resource correlation Ids. This can be used to uniquely identify the count of items affected by a
        /// specific category and severity as well as count of item affected by an specific issue.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] AffectedResourceCorrelationId { get => this._affectedResourceCorrelationId; set => this._affectedResourceCorrelationId = value; }

        /// <summary>Backing field for <see cref="AffectedResourceSubtype" /> property.</summary>
        private string _affectedResourceSubtype;

        /// <summary>
        /// The sub type of any subcomponent within the ARM resource that this might be applicable. Value remains null if not applicable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedResourceSubtype { get => this._affectedResourceSubtype; set => this._affectedResourceSubtype = value; }

        /// <summary>Backing field for <see cref="AffectedResourceType" /> property.</summary>
        private string _affectedResourceType;

        /// <summary>The type of affected ARM resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedResourceType { get => this._affectedResourceType; set => this._affectedResourceType = value; }

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HealthErrorCategory? _category;

        /// <summary>The category of the health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HealthErrorCategory? Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Severity? _severity;

        /// <summary>Severity of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Severity? Severity { get => this._severity; set => this._severity = value; }

        /// <summary>Backing field for <see cref="SummaryCode" /> property.</summary>
        private string _summaryCode;

        /// <summary>The code of the health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SummaryCode { get => this._summaryCode; set => this._summaryCode = value; }

        /// <summary>Backing field for <see cref="SummaryMessage" /> property.</summary>
        private string _summaryMessage;

        /// <summary>The summary message of the health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SummaryMessage { get => this._summaryMessage; set => this._summaryMessage = value; }

        /// <summary>Creates an new <see cref="HealthErrorSummary" /> instance.</summary>
        public HealthErrorSummary()
        {

        }
    }
    /// class to define the summary of the health error details.
    public partial interface IHealthErrorSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The list of affected resource correlation Ids. This can be used to uniquely identify the count of items affected by a
        /// specific category and severity as well as count of item affected by an specific issue.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of affected resource correlation Ids. This can be used to uniquely identify the count of items affected by a specific category and severity as well as count of item affected by an specific issue.",
        SerializedName = @"affectedResourceCorrelationIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] AffectedResourceCorrelationId { get; set; }
        /// <summary>
        /// The sub type of any subcomponent within the ARM resource that this might be applicable. Value remains null if not applicable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The sub type of any subcomponent within the ARM resource that this might be applicable. Value remains null if not applicable.",
        SerializedName = @"affectedResourceSubtype",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedResourceSubtype { get; set; }
        /// <summary>The type of affected ARM resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of affected ARM resource.",
        SerializedName = @"affectedResourceType",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedResourceType { get; set; }
        /// <summary>The category of the health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The category of the health error.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HealthErrorCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HealthErrorCategory? Category { get; set; }
        /// <summary>Severity of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Severity of error.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Severity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Severity? Severity { get; set; }
        /// <summary>The code of the health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of the health error.",
        SerializedName = @"summaryCode",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryCode { get; set; }
        /// <summary>The summary message of the health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The summary message of the health error.",
        SerializedName = @"summaryMessage",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryMessage { get; set; }

    }
    /// class to define the summary of the health error details.
    internal partial interface IHealthErrorSummaryInternal

    {
        /// <summary>
        /// The list of affected resource correlation Ids. This can be used to uniquely identify the count of items affected by a
        /// specific category and severity as well as count of item affected by an specific issue.
        /// </summary>
        string[] AffectedResourceCorrelationId { get; set; }
        /// <summary>
        /// The sub type of any subcomponent within the ARM resource that this might be applicable. Value remains null if not applicable.
        /// </summary>
        string AffectedResourceSubtype { get; set; }
        /// <summary>The type of affected ARM resource.</summary>
        string AffectedResourceType { get; set; }
        /// <summary>The category of the health error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HealthErrorCategory? Category { get; set; }
        /// <summary>Severity of error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.Severity? Severity { get; set; }
        /// <summary>The code of the health error.</summary>
        string SummaryCode { get; set; }
        /// <summary>The summary message of the health error.</summary>
        string SummaryMessage { get; set; }

    }
}