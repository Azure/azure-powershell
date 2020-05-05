namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>The workspace provider authorization.</summary>
    public partial class WorkspaceProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorizationInternal
    {

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>
        /// The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace
        /// resources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; set => this._principalId = value; }

        /// <summary>Backing field for <see cref="RoleDefinitionId" /> property.</summary>
        private string _roleDefinitionId;

        /// <summary>
        /// The provider's role definition identifier. This role will define all the permissions that the provider must have on the
        /// workspace's container resource group. This role definition cannot have permission to delete the resource group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string RoleDefinitionId { get => this._roleDefinitionId; set => this._roleDefinitionId = value; }

        /// <summary>Creates an new <see cref="WorkspaceProviderAuthorization" /> instance.</summary>
        public WorkspaceProviderAuthorization()
        {

        }
    }
    /// The workspace provider authorization.
    public partial interface IWorkspaceProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace
        /// resources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace resources.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }
        /// <summary>
        /// The provider's role definition identifier. This role will define all the permissions that the provider must have on the
        /// workspace's container resource group. This role definition cannot have permission to delete the resource group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider's role definition identifier. This role will define all the permissions that the provider must have on the workspace's container resource group. This role definition cannot have permission to delete the resource group.",
        SerializedName = @"roleDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string RoleDefinitionId { get; set; }

    }
    /// The workspace provider authorization.
    internal partial interface IWorkspaceProviderAuthorizationInternal

    {
        /// <summary>
        /// The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the workspace
        /// resources.
        /// </summary>
        string PrincipalId { get; set; }
        /// <summary>
        /// The provider's role definition identifier. This role will define all the permissions that the provider must have on the
        /// workspace's container resource group. This role definition cannot have permission to delete the resource group.
        /// </summary>
        string RoleDefinitionId { get; set; }

    }
}