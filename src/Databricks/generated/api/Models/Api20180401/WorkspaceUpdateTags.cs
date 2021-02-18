namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class WorkspaceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="WorkspaceUpdateTags" /> instance.</summary>
        public WorkspaceUpdateTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IWorkspaceUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IWorkspaceUpdateTagsInternal

    {

    }
}