namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>ASR error model</summary>
    public partial class ServiceError :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceError,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IServiceErrorInternal
    {

        /// <summary>Backing field for <see cref="ActivityId" /> property.</summary>
        private string _activityId;

        /// <summary>Activity Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ActivityId { get => this._activityId; set => this._activityId = value; }

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

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

        /// <summary>Creates an new <see cref="ServiceError" /> instance.</summary>
        public ServiceError()
        {

        }
    }
    /// ASR error model
    public partial interface IServiceError :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Activity Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Activity Id.",
        SerializedName = @"activityId",
        PossibleTypes = new [] { typeof(string) })]
        string ActivityId { get; set; }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
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

    }
    /// ASR error model
    internal partial interface IServiceErrorInternal

    {
        /// <summary>Activity Id.</summary>
        string ActivityId { get; set; }
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>Error message.</summary>
        string Message { get; set; }
        /// <summary>Possible causes of error.</summary>
        string PossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        string RecommendedAction { get; set; }

    }
}