namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto cluster principal assignments operation response.</summary>
    public partial class ClusterPrincipalAssignmentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignmentListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignmentListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignment[] _value;

        /// <summary>The list of Kusto cluster principal assignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignment[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ClusterPrincipalAssignmentListResult" /> instance.</summary>
        public ClusterPrincipalAssignmentListResult()
        {

        }
    }
    /// The list Kusto cluster principal assignments operation response.
    public partial interface IClusterPrincipalAssignmentListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto cluster principal assignments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto cluster principal assignments.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignment) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignment[] Value { get; set; }

    }
    /// The list Kusto cluster principal assignments operation response.
    internal partial interface IClusterPrincipalAssignmentListResultInternal

    {
        /// <summary>The list of Kusto cluster principal assignments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterPrincipalAssignment[] Value { get; set; }

    }
}