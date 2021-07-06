namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// Describes conditions applicable to the Input, Output, or the job overall, that warrant customer attention.
    /// </summary>
    public partial class Diagnostics :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnostics,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticsInternal
    {

        /// <summary>Backing field for <see cref="Condition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] _condition;

        /// <summary>
        /// A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] Condition { get => this._condition; }

        /// <summary>Internal Acessors for Condition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticsInternal.Condition { get => this._condition; set { {_condition = value;} } }

        /// <summary>Creates an new <see cref="Diagnostics" /> instance.</summary>
        public Diagnostics()
        {

        }
    }
    /// Describes conditions applicable to the Input, Output, or the job overall, that warrant customer attention.
    public partial interface IDiagnostics :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.",
        SerializedName = @"conditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] Condition { get;  }

    }
    /// Describes conditions applicable to the Input, Output, or the job overall, that warrant customer attention.
    internal partial interface IDiagnosticsInternal

    {
        /// <summary>
        /// A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] Condition { get; set; }

    }
}