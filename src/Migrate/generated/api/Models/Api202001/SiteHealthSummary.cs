namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Site health summary model.</summary>
    public partial class SiteHealthSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal
    {

        /// <summary>Backing field for <see cref="AffectedObjectsCount" /> property.</summary>
        private long? _affectedObjectsCount;

        /// <summary>Count of affected objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? AffectedObjectsCount { get => this._affectedObjectsCount; set => this._affectedObjectsCount = value; }

        /// <summary>Backing field for <see cref="AffectedResource" /> property.</summary>
        private string[] _affectedResource;

        /// <summary>Affected resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] AffectedResource { get => this._affectedResource; set => this._affectedResource = value; }

        /// <summary>Backing field for <see cref="AffectedResourceType" /> property.</summary>
        private string _affectedResourceType;

        /// <summary>Affected resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedResourceType { get => this._affectedResourceType; }

        /// <summary>Backing field for <see cref="ApplianceName" /> property.</summary>
        private string _applianceName;

        /// <summary>Appliance name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ApplianceName { get => this._applianceName; }

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; }

        /// <summary>Backing field for <see cref="ErrorId" /> property.</summary>
        private long? _errorId;

        /// <summary>Error Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? ErrorId { get => this._errorId; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; }

        /// <summary>Backing field for <see cref="HitCount" /> property.</summary>
        private long? _hitCount;

        /// <summary>Hit count of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? HitCount { get => this._hitCount; set => this._hitCount = value; }

        /// <summary>Internal Acessors for AffectedResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.AffectedResourceType { get => this._affectedResourceType; set { {_affectedResourceType = value;} } }

        /// <summary>Internal Acessors for ApplianceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.ApplianceName { get => this._applianceName; set { {_applianceName = value;} } }

        /// <summary>Internal Acessors for ErrorCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.ErrorCode { get => this._errorCode; set { {_errorCode = value;} } }

        /// <summary>Internal Acessors for ErrorId</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.ErrorId { get => this._errorId; set { {_errorId = value;} } }

        /// <summary>Internal Acessors for ErrorMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.ErrorMessage { get => this._errorMessage; set { {_errorMessage = value;} } }

        /// <summary>Internal Acessors for RemediationGuidance</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.RemediationGuidance { get => this._remediationGuidance; set { {_remediationGuidance = value;} } }

        /// <summary>Internal Acessors for Severity</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.Severity { get => this._severity; set { {_severity = value;} } }

        /// <summary>Internal Acessors for SummaryMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryInternal.SummaryMessage { get => this._summaryMessage; set { {_summaryMessage = value;} } }

        /// <summary>Backing field for <see cref="RemediationGuidance" /> property.</summary>
        private string _remediationGuidance;

        /// <summary>Remediation guidance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RemediationGuidance { get => this._remediationGuidance; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private string _severity;

        /// <summary>Severity of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Severity { get => this._severity; }

        /// <summary>Backing field for <see cref="SummaryMessage" /> property.</summary>
        private string _summaryMessage;

        /// <summary>Summary message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SummaryMessage { get => this._summaryMessage; }

        /// <summary>Creates an new <see cref="SiteHealthSummary" /> instance.</summary>
        public SiteHealthSummary()
        {

        }
    }
    /// Site health summary model.
    public partial interface ISiteHealthSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Count of affected objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Count of affected objects.",
        SerializedName = @"affectedObjectsCount",
        PossibleTypes = new [] { typeof(long) })]
        long? AffectedObjectsCount { get; set; }
        /// <summary>Affected resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Affected resources.",
        SerializedName = @"affectedResources",
        PossibleTypes = new [] { typeof(string) })]
        string[] AffectedResource { get; set; }
        /// <summary>Affected resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Affected resource type.",
        SerializedName = @"affectedResourceType",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedResourceType { get;  }
        /// <summary>Appliance name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Appliance name.",
        SerializedName = @"applianceName",
        PossibleTypes = new [] { typeof(string) })]
        string ApplianceName { get;  }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get;  }
        /// <summary>Error Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error Id.",
        SerializedName = @"errorId",
        PossibleTypes = new [] { typeof(long) })]
        long? ErrorId { get;  }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get;  }
        /// <summary>Hit count of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hit count of the error.",
        SerializedName = @"hitCount",
        PossibleTypes = new [] { typeof(long) })]
        long? HitCount { get; set; }
        /// <summary>Remediation guidance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Remediation guidance.",
        SerializedName = @"remediationGuidance",
        PossibleTypes = new [] { typeof(string) })]
        string RemediationGuidance { get;  }
        /// <summary>Severity of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Severity of error.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(string) })]
        string Severity { get;  }
        /// <summary>Summary message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Summary message.",
        SerializedName = @"summaryMessage",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryMessage { get;  }

    }
    /// Site health summary model.
    internal partial interface ISiteHealthSummaryInternal

    {
        /// <summary>Count of affected objects.</summary>
        long? AffectedObjectsCount { get; set; }
        /// <summary>Affected resources.</summary>
        string[] AffectedResource { get; set; }
        /// <summary>Affected resource type.</summary>
        string AffectedResourceType { get; set; }
        /// <summary>Appliance name.</summary>
        string ApplianceName { get; set; }
        /// <summary>Error code.</summary>
        string ErrorCode { get; set; }
        /// <summary>Error Id.</summary>
        long? ErrorId { get; set; }
        /// <summary>Error message.</summary>
        string ErrorMessage { get; set; }
        /// <summary>Hit count of the error.</summary>
        long? HitCount { get; set; }
        /// <summary>Remediation guidance.</summary>
        string RemediationGuidance { get; set; }
        /// <summary>Severity of error.</summary>
        string Severity { get; set; }
        /// <summary>Summary message.</summary>
        string SummaryMessage { get; set; }

    }
}