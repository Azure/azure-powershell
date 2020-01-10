namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A key-value pair that provides additional context on the issue.</summary>
    public partial class IssueContext :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContextInternal
    {

        /// <summary>Creates an new <see cref="IssueContext" /> instance.</summary>
        public IssueContext()
        {

        }
    }
    /// A key-value pair that provides additional context on the issue.
    public partial interface IIssueContext :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// A key-value pair that provides additional context on the issue.
    internal partial interface IIssueContextInternal

    {

    }
}