namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto database principal assignments operation response.</summary>
    public partial class DatabasePrincipalAssignmentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignmentListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignment[] _value;

        /// <summary>The list of Kusto database principal assignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignment[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DatabasePrincipalAssignmentListResult" /> instance.</summary>
        public DatabasePrincipalAssignmentListResult()
        {

        }
    }
    /// The list Kusto database principal assignments operation response.
    public partial interface IDatabasePrincipalAssignmentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto database principal assignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto database principal assignments.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignment) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignment[] Value { get; set; }

    }
    /// The list Kusto database principal assignments operation response.
    internal partial interface IDatabasePrincipalAssignmentListResultInternal

    {
        /// <summary>The list of Kusto database principal assignments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalAssignment[] Value { get; set; }

    }
}