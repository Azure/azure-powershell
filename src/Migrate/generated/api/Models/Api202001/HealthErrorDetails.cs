namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Error contract returned when some exception occurs in Rest API.</summary>
    public partial class HealthErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Error name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private long? _id;

        /// <summary>Error ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? Id { get => this._id; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Backing field for <see cref="MessageParameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters _messageParameter;

        /// <summary>Message parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters MessageParameter { get => (this._messageParameter = this._messageParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsMessageParameters()); }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for MessageParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.MessageParameter { get => (this._messageParameter = this._messageParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsMessageParameters()); set { {_messageParameter = value;} } }

        /// <summary>Internal Acessors for PossibleCaus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.PossibleCaus { get => this._possibleCaus; set { {_possibleCaus = value;} } }

        /// <summary>Internal Acessors for RecommendedAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.RecommendedAction { get => this._recommendedAction; set { {_recommendedAction = value;} } }

        /// <summary>Internal Acessors for Severity</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.Severity { get => this._severity; set { {_severity = value;} } }

        /// <summary>Internal Acessors for Source</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.Source { get => this._source; set { {_source = value;} } }

        /// <summary>Internal Acessors for SummaryMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsInternal.SummaryMessage { get => this._summaryMessage; set { {_summaryMessage = value;} } }

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

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Error source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Source { get => this._source; }

        /// <summary>Backing field for <see cref="SummaryMessage" /> property.</summary>
        private string _summaryMessage;

        /// <summary>Error summary message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SummaryMessage { get => this._summaryMessage; }

        /// <summary>Creates an new <see cref="HealthErrorDetails" /> instance.</summary>
        public HealthErrorDetails()
        {

        }
    }
    /// Error contract returned when some exception occurs in Rest API.
    public partial interface IHealthErrorDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Error name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error name.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Error ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(long) })]
        long? Id { get;  }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Message parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Message parameters.",
        SerializedName = @"messageParameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters MessageParameter { get;  }
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
        /// <summary>Error source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error source.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get;  }
        /// <summary>Error summary message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error summary message.",
        SerializedName = @"summaryMessage",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryMessage { get;  }

    }
    /// Error contract returned when some exception occurs in Rest API.
    internal partial interface IHealthErrorDetailsInternal

    {
        /// <summary>Error name.</summary>
        string Code { get; set; }
        /// <summary>Error ID.</summary>
        long? Id { get; set; }
        /// <summary>Error message.</summary>
        string Message { get; set; }
        /// <summary>Message parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetailsMessageParameters MessageParameter { get; set; }
        /// <summary>Possible causes of error.</summary>
        string PossibleCaus { get; set; }
        /// <summary>Recommended action to resolve error.</summary>
        string RecommendedAction { get; set; }
        /// <summary>Error severity.</summary>
        string Severity { get; set; }
        /// <summary>Error source.</summary>
        string Source { get; set; }
        /// <summary>Error summary message.</summary>
        string SummaryMessage { get; set; }

    }
}