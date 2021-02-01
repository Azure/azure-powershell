namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Contains information about pre authorized client application.</summary>
    public partial class PreAuthorizedApplication :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationInternal
    {

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>Represents the application id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; set => this._appId = value; }

        /// <summary>Backing field for <see cref="Extension" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtension[] _extension;

        /// <summary>Collection of extensions from the resource application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtension[] Extension { get => this._extension; set => this._extension = value; }

        /// <summary>Backing field for <see cref="Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermission[] _permission;

        /// <summary>
        /// Collection of required app permissions/entitlements from the resource application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermission[] Permission { get => this._permission; set => this._permission = value; }

        /// <summary>Creates an new <see cref="PreAuthorizedApplication" /> instance.</summary>
        public PreAuthorizedApplication()
        {

        }
    }
    /// Contains information about pre authorized client application.
    public partial interface IPreAuthorizedApplication :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>Represents the application id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Represents the application id.",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }
        /// <summary>Collection of extensions from the resource application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of extensions from the resource application.",
        SerializedName = @"extensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtension) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtension[] Extension { get; set; }
        /// <summary>
        /// Collection of required app permissions/entitlements from the resource application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of required app permissions/entitlements from the resource application.",
        SerializedName = @"permissions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermission) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermission[] Permission { get; set; }

    }
    /// Contains information about pre authorized client application.
    internal partial interface IPreAuthorizedApplicationInternal

    {
        /// <summary>Represents the application id.</summary>
        string AppId { get; set; }
        /// <summary>Collection of extensions from the resource application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtension[] Extension { get; set; }
        /// <summary>
        /// Collection of required app permissions/entitlements from the resource application.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationPermission[] Permission { get; set; }

    }
}