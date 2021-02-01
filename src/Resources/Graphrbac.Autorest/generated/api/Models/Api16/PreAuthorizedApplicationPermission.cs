namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Contains information about the pre-authorized permissions.</summary>
    public partial class PreAuthorizedApplicationPermission :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermission,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermissionInternal
    {

        /// <summary>Backing field for <see cref="AccessGrant" /> property.</summary>
        private string[] _accessGrant;

        /// <summary>The list of permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] AccessGrant { get => this._accessGrant; set => this._accessGrant = value; }

        /// <summary>Backing field for <see cref="DirectAccessGrant" /> property.</summary>
        private bool? _directAccessGrant;

        /// <summary>Indicates whether the permission set is DirectAccess or impersonation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? DirectAccessGrant { get => this._directAccessGrant; set => this._directAccessGrant = value; }

        /// <summary>Creates an new <see cref="PreAuthorizedApplicationPermission" /> instance.</summary>
        public PreAuthorizedApplicationPermission()
        {

        }
    }
    /// Contains information about the pre-authorized permissions.
    public partial interface IPreAuthorizedApplicationPermission :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>The list of permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of permissions.",
        SerializedName = @"accessGrants",
        PossibleTypes = new [] { typeof(string) })]
        string[] AccessGrant { get; set; }
        /// <summary>Indicates whether the permission set is DirectAccess or impersonation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the permission set is DirectAccess or impersonation.",
        SerializedName = @"directAccessGrant",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DirectAccessGrant { get; set; }

    }
    /// Contains information about the pre-authorized permissions.
    internal partial interface IPreAuthorizedApplicationPermissionInternal

    {
        /// <summary>The list of permissions.</summary>
        string[] AccessGrant { get; set; }
        /// <summary>Indicates whether the permission set is DirectAccess or impersonation.</summary>
        bool? DirectAccessGrant { get; set; }

    }
}