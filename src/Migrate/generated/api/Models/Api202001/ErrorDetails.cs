namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Error contract returned when some exception occurs in Rest API.</summary>
    public partial class ErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal
    {

        /// <summary>Backing field for <see cref="AgentErrorCode" /> property.</summary>
        private string _agentErrorCode;

        /// <summary>Agent error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentErrorCode { get => this._agentErrorCode; }

        /// <summary>Backing field for <see cref="AgentErrorMessage" /> property.</summary>
        private string _agentErrorMessage;

        /// <summary>Error message from the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentErrorMessage { get => this._agentErrorMessage; }

        /// <summary>Backing field for <see cref="AgentErrorPossibleCaus" /> property.</summary>
        private string _agentErrorPossibleCaus;

        /// <summary>Possible causes for the agent error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentErrorPossibleCaus { get => this._agentErrorPossibleCaus; }

        /// <summary>Backing field for <see cref="AgentErrorRecommendedAction" /> property.</summary>
        private string _agentErrorRecommendedAction;

        /// <summary>Recommended action for the agent error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentErrorRecommendedAction { get => this._agentErrorRecommendedAction; }

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="IsAgentReportedError" /> property.</summary>
        private bool? _isAgentReportedError;

        /// <summary>Value indicating whether the error originated from a agent or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsAgentReportedError { get => this._isAgentReportedError; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for AgentErrorCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.AgentErrorCode { get => this._agentErrorCode; set { {_agentErrorCode = value;} } }

        /// <summary>Internal Acessors for AgentErrorMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.AgentErrorMessage { get => this._agentErrorMessage; set { {_agentErrorMessage = value;} } }

        /// <summary>Internal Acessors for AgentErrorPossibleCaus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.AgentErrorPossibleCaus { get => this._agentErrorPossibleCaus; set { {_agentErrorPossibleCaus = value;} } }

        /// <summary>Internal Acessors for AgentErrorRecommendedAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.AgentErrorRecommendedAction { get => this._agentErrorRecommendedAction; set { {_agentErrorRecommendedAction = value;} } }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for IsAgentReportedError</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.IsAgentReportedError { get => this._isAgentReportedError; set { {_isAgentReportedError = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for PossibleCaus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.PossibleCaus { get => this._possibleCaus; set { {_possibleCaus = value;} } }

        /// <summary>Internal Acessors for RecommendedAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.RecommendedAction { get => this._recommendedAction; set { {_recommendedAction = value;} } }

        /// <summary>Internal Acessors for Severity</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetailsInternal.Severity { get => this._severity; set { {_severity = value;} } }

        /// <summary>Backing field for <see cref="PossibleCaus" /> property.</summary>
        private string _possibleCaus;

        /// <summary>Possible causes of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PossibleCaus { get => this._possibleCaus; }

        /// <summary>Backing field for <see cref="RecommendedAction" /> property.</summary>
        private string _recommendedAction;

        /// <summary>Recommended action to resolve error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecommendedAction { get => this._recommendedAction; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private string _severity;

        /// <summary>Error severity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Severity { get => this._severity; }

        /// <summary>Creates an new <see cref="ErrorDetails" /> instance.</summary>
        public ErrorDetails()
        {

        }
    }
    /// Error contract returned when some exception occurs in Rest API.
    public partial interface IErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Agent error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Agent error code.",
        SerializedName = @"agentErrorCode",
        PossibleTypes = new [] { typeof(string) })]
        string AgentErrorCode { get;  }
        /// <summary>Error message from the agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message from the agent.",
        SerializedName = @"agentErrorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string AgentErrorMessage { get;  }
        /// <summary>Possible causes for the agent error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Possible causes for the agent error.",
        SerializedName = @"agentErrorPossibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string AgentErrorPossibleCaus { get;  }
        /// <summary>Recommended action for the agent error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Recommended action for the agent error.",
        SerializedName = @"agentErrorRecommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string AgentErrorRecommendedAction { get;  }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Value indicating whether the error originated from a agent or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether the error originated from a agent or not.",
        SerializedName = @"isAgentReportedError",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsAgentReportedError { get;  }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Possible causes of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Possible causes of error.",
        SerializedName = @"possibleCauses",
        PossibleTypes = new [] { typeof(string) })]
        string PossibleCaus { get;  }
        /// <summary>Recommended action to resolve error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Recommended action to resolve error.",
        SerializedName = @"recommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendedAction { get;  }
        /// <summary>Error severity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error severity.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(string) })]
        string Severity { get;  }

    }
    /// Error contract returned when some exception occurs in Rest API.
    internal partial interface IErrorDetailsInternal

    {
        /// <summary>Agent error code.</summary>
        string AgentErrorCode { get; set; }
        /// <summary>Error message from the agent.</summary>
        string AgentErrorMessage { get; set; }
        /// <summary>Possible causes for the agent error.</summary>
        string AgentErrorPossibleCaus { get; set; }
        /// <summary>Recommended action for the agent error.</summary>
        string AgentErrorRecommendedAction { get; set; }
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>Value indicating whether the error originated from a agent or not.</summary>
        bool? IsAgentReportedError { get; set; }
        /// <summary>Error message.</summary>
        string Message { get; set; }
        /// <summary>Possible causes of error.</summary>
        string PossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        string RecommendedAction { get; set; }
        /// <summary>Error severity.</summary>
        string Severity { get; set; }

    }
}