namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Implements InnerHealthError class. HealthError object has a list of InnerHealthErrors as child errors. InnerHealthError
    /// is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are
    /// exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as
    /// Exception -&gt; InnerException.
    /// </summary>
    public partial class InnerHealthError :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthError,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInnerHealthErrorInternal
    {

        /// <summary>Backing field for <see cref="CreationTimeUtc" /> property.</summary>
        private global::System.DateTime? _creationTimeUtc;

        /// <summary>Error creation time (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationTimeUtc { get => this._creationTimeUtc; set => this._creationTimeUtc = value; }

        /// <summary>Backing field for <see cref="EntityId" /> property.</summary>
        private string _entityId;

        /// <summary>ID of the entity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EntityId { get => this._entityId; set => this._entityId = value; }

        /// <summary>Backing field for <see cref="ErrorCategory" /> property.</summary>
        private string _errorCategory;

        /// <summary>Category of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorCategory { get => this._errorCategory; set => this._errorCategory = value; }

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; set => this._errorCode = value; }

        /// <summary>Backing field for <see cref="ErrorLevel" /> property.</summary>
        private string _errorLevel;

        /// <summary>Level of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorLevel { get => this._errorLevel; set => this._errorLevel = value; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; set => this._errorMessage = value; }

        /// <summary>Backing field for <see cref="ErrorSource" /> property.</summary>
        private string _errorSource;

        /// <summary>Source of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorSource { get => this._errorSource; set => this._errorSource = value; }

        /// <summary>Backing field for <see cref="ErrorType" /> property.</summary>
        private string _errorType;

        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorType { get => this._errorType; set => this._errorType = value; }

        /// <summary>Backing field for <see cref="PossibleCaus" /> property.</summary>
        private string _possibleCaus;

        /// <summary>Possible causes of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PossibleCaus { get => this._possibleCaus; set => this._possibleCaus = value; }

        /// <summary>Backing field for <see cref="RecommendedAction" /> property.</summary>
        private string _recommendedAction;

        /// <summary>Recommended action to resolve error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecommendedAction { get => this._recommendedAction; set => this._recommendedAction = value; }

        /// <summary>Backing field for <see cref="RecoveryProviderErrorMessage" /> property.</summary>
        private string _recoveryProviderErrorMessage;

        /// <summary>DRA error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryProviderErrorMessage { get => this._recoveryProviderErrorMessage; set => this._recoveryProviderErrorMessage = value; }

        /// <summary>Backing field for <see cref="SummaryMessage" /> property.</summary>
        private string _summaryMessage;

        /// <summary>Summary message of the entity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SummaryMessage { get => this._summaryMessage; set => this._summaryMessage = value; }

        /// <summary>Creates an new <see cref="InnerHealthError" /> instance.</summary>
        public InnerHealthError()
        {

        }
    }
    /// Implements InnerHealthError class. HealthError object has a list of InnerHealthErrors as child errors. InnerHealthError
    /// is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are
    /// exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as
    /// Exception -&gt; InnerException.
    public partial interface IInnerHealthError :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Error creation time (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error creation time (UTC)",
        SerializedName = @"creationTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationTimeUtc { get; set; }
        /// <summary>ID of the entity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID of the entity.",
        SerializedName = @"entityId",
        PossibleTypes = new [] { typeof(string) })]
        string EntityId { get; set; }
        /// <summary>Category of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Category of error.",
        SerializedName = @"errorCategory",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCategory { get; set; }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get; set; }
        /// <summary>Level of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Level of error.",
        SerializedName = @"errorLevel",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorLevel { get; set; }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get; set; }
        /// <summary>Source of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source of error.",
        SerializedName = @"errorSource",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorSource { get; set; }
        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of error.",
        SerializedName = @"errorType",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorType { get; set; }
        /// <summary>Possible causes of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Possible causes of error.",
        SerializedName = @"possibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string PossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recommended action to resolve error.",
        SerializedName = @"recommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendedAction { get; set; }
        /// <summary>DRA error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DRA error message.",
        SerializedName = @"recoveryProviderErrorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryProviderErrorMessage { get; set; }
        /// <summary>Summary message of the entity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Summary message of the entity.",
        SerializedName = @"summaryMessage",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryMessage { get; set; }

    }
    /// Implements InnerHealthError class. HealthError object has a list of InnerHealthErrors as child errors. InnerHealthError
    /// is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are
    /// exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as
    /// Exception -&gt; InnerException.
    internal partial interface IInnerHealthErrorInternal

    {
        /// <summary>Error creation time (UTC)</summary>
        global::System.DateTime? CreationTimeUtc { get; set; }
        /// <summary>ID of the entity.</summary>
        string EntityId { get; set; }
        /// <summary>Category of error.</summary>
        string ErrorCategory { get; set; }
        /// <summary>Error code.</summary>
        string ErrorCode { get; set; }
        /// <summary>Level of error.</summary>
        string ErrorLevel { get; set; }
        /// <summary>Error message.</summary>
        string ErrorMessage { get; set; }
        /// <summary>Source of error.</summary>
        string ErrorSource { get; set; }
        /// <summary>Type of error.</summary>
        string ErrorType { get; set; }
        /// <summary>Possible causes of error.</summary>
        string PossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        string RecommendedAction { get; set; }
        /// <summary>DRA error message.</summary>
        string RecoveryProviderErrorMessage { get; set; }
        /// <summary>Summary message of the entity.</summary>
        string SummaryMessage { get; set; }

    }
}