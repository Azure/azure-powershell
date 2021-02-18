namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class contains the error details per object.</summary>
    public partial class JobErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal
    {

        /// <summary>Backing field for <see cref="CreationTime" /> property.</summary>
        private global::System.DateTime? _creationTime;

        /// <summary>The creation time of job error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationTime { get => this._creationTime; set => this._creationTime = value; }

        /// <summary>Backing field for <see cref="ErrorLevel" /> property.</summary>
        private string _errorLevel;

        /// <summary>Error level of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ErrorLevel { get => this._errorLevel; set => this._errorLevel = value; }

        /// <summary>Internal Acessors for ProviderErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal.ProviderErrorDetail { get => (this._providerErrorDetail = this._providerErrorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderError()); set { {_providerErrorDetail = value;} } }

        /// <summary>Internal Acessors for ServiceErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobErrorDetailsInternal.ServiceErrorDetail { get => (this._serviceErrorDetail = this._serviceErrorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ServiceError()); set { {_serviceErrorDetail = value;} } }

        /// <summary>Backing field for <see cref="ProviderErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError _providerErrorDetail;

        /// <summary>The Provider error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError ProviderErrorDetail { get => (this._providerErrorDetail = this._providerErrorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderError()); set => this._providerErrorDetail = value; }

        /// <summary>The Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? ProviderErrorDetailErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).ErrorCode = value ?? default(int); }

        /// <summary>The Provider error Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderErrorDetailErrorId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).ErrorId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).ErrorId = value ?? null; }

        /// <summary>The Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderErrorDetailErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).ErrorMessage = value ?? null; }

        /// <summary>The possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderErrorDetailPossibleCaus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).PossibleCaus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).PossibleCaus = value ?? null; }

        /// <summary>The recommended action to resolve the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderErrorDetailRecommendedAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).RecommendedAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderErrorInternal)ProviderErrorDetail).RecommendedAction = value ?? null; }

        /// <summary>Backing field for <see cref="ServiceErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError _serviceErrorDetail;

        /// <summary>The Service error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError ServiceErrorDetail { get => (this._serviceErrorDetail = this._serviceErrorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ServiceError()); set => this._serviceErrorDetail = value; }

        /// <summary>Activity Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServiceErrorDetailActivityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).ActivityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).ActivityId = value ?? null; }

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServiceErrorDetailCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).Code = value ?? null; }

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServiceErrorDetailMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).Message = value ?? null; }

        /// <summary>Possible causes of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServiceErrorDetailPossibleCaus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).PossibleCaus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).PossibleCaus = value ?? null; }

        /// <summary>Recommended action to resolve error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ServiceErrorDetailRecommendedAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).RecommendedAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal)ServiceErrorDetail).RecommendedAction = value ?? null; }

        /// <summary>Backing field for <see cref="TaskId" /> property.</summary>
        private string _taskId;

        /// <summary>The Id of the task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TaskId { get => this._taskId; set => this._taskId = value; }

        /// <summary>Creates an new <see cref="JobErrorDetails" /> instance.</summary>
        public JobErrorDetails()
        {

        }
    }
    /// This class contains the error details per object.
    public partial interface IJobErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The creation time of job error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The creation time of job error.",
        SerializedName = @"creationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationTime { get; set; }
        /// <summary>Error level of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error level of error.",
        SerializedName = @"errorLevel",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorLevel { get; set; }
        /// <summary>The Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Error code.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(int) })]
        int? ProviderErrorDetailErrorCode { get; set; }
        /// <summary>The Provider error Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Provider error Id.",
        SerializedName = @"errorId",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderErrorDetailErrorId { get; set; }
        /// <summary>The Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Error message.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderErrorDetailErrorMessage { get; set; }
        /// <summary>The possible causes for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The possible causes for the error.",
        SerializedName = @"possibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderErrorDetailPossibleCaus { get; set; }
        /// <summary>The recommended action to resolve the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recommended action to resolve the error.",
        SerializedName = @"recommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderErrorDetailRecommendedAction { get; set; }
        /// <summary>Activity Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Activity Id.",
        SerializedName = @"activityId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceErrorDetailActivityId { get; set; }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceErrorDetailCode { get; set; }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceErrorDetailMessage { get; set; }
        /// <summary>Possible causes of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Possible causes of error.",
        SerializedName = @"possibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceErrorDetailPossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recommended action to resolve error.",
        SerializedName = @"recommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceErrorDetailRecommendedAction { get; set; }
        /// <summary>The Id of the task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the task.",
        SerializedName = @"taskId",
        PossibleTypes = new [] { typeof(string) })]
        string TaskId { get; set; }

    }
    /// This class contains the error details per object.
    internal partial interface IJobErrorDetailsInternal

    {
        /// <summary>The creation time of job error.</summary>
        global::System.DateTime? CreationTime { get; set; }
        /// <summary>Error level of error.</summary>
        string ErrorLevel { get; set; }
        /// <summary>The Provider error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderError ProviderErrorDetail { get; set; }
        /// <summary>The Error code.</summary>
        int? ProviderErrorDetailErrorCode { get; set; }
        /// <summary>The Provider error Id.</summary>
        string ProviderErrorDetailErrorId { get; set; }
        /// <summary>The Error message.</summary>
        string ProviderErrorDetailErrorMessage { get; set; }
        /// <summary>The possible causes for the error.</summary>
        string ProviderErrorDetailPossibleCaus { get; set; }
        /// <summary>The recommended action to resolve the error.</summary>
        string ProviderErrorDetailRecommendedAction { get; set; }
        /// <summary>The Service error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError ServiceErrorDetail { get; set; }
        /// <summary>Activity Id.</summary>
        string ServiceErrorDetailActivityId { get; set; }
        /// <summary>Error code.</summary>
        string ServiceErrorDetailCode { get; set; }
        /// <summary>Error message.</summary>
        string ServiceErrorDetailMessage { get; set; }
        /// <summary>Possible causes of error.</summary>
        string ServiceErrorDetailPossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        string ServiceErrorDetailRecommendedAction { get; set; }
        /// <summary>The Id of the task.</summary>
        string TaskId { get; set; }

    }
}