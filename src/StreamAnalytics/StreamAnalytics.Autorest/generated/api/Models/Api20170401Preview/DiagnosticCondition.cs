namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// Condition applicable to the resource, or to the job overall, that warrant customer attention.
    /// </summary>
    public partial class DiagnosticCondition :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticConditionInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The opaque diagnostic code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// The human-readable message describing the condition in detail. Localized in the Accept-Language of the client request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticConditionInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticConditionInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Since</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticConditionInternal.Since { get => this._since; set { {_since = value;} } }

        /// <summary>Backing field for <see cref="Since" /> property.</summary>
        private string _since;

        /// <summary>
        /// The UTC timestamp of when the condition started. Customers should be able to find a corresponding event in the ops log
        /// around this time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Since { get => this._since; }

        /// <summary>Creates an new <see cref="DiagnosticCondition" /> instance.</summary>
        public DiagnosticCondition()
        {

        }
    }
    /// Condition applicable to the resource, or to the job overall, that warrant customer attention.
    public partial interface IDiagnosticCondition :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The opaque diagnostic code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The opaque diagnostic code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>
        /// The human-readable message describing the condition in detail. Localized in the Accept-Language of the client request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The human-readable message describing the condition in detail. Localized in the Accept-Language of the client request.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>
        /// The UTC timestamp of when the condition started. Customers should be able to find a corresponding event in the ops log
        /// around this time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The UTC timestamp of when the condition started. Customers should be able to find a corresponding event in the ops log around this time.",
        SerializedName = @"since",
        PossibleTypes = new [] { typeof(string) })]
        string Since { get;  }

    }
    /// Condition applicable to the resource, or to the job overall, that warrant customer attention.
    internal partial interface IDiagnosticConditionInternal

    {
        /// <summary>The opaque diagnostic code.</summary>
        string Code { get; set; }
        /// <summary>
        /// The human-readable message describing the condition in detail. Localized in the Accept-Language of the client request.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// The UTC timestamp of when the condition started. Customers should be able to find a corresponding event in the ops log
        /// around this time.
        /// </summary>
        string Since { get; set; }

    }
}