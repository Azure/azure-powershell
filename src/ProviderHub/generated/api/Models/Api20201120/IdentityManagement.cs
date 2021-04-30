namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class IdentityManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagement,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? _type;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="IdentityManagement" /> instance.</summary>
        public IdentityManagement()
        {

        }
    }
    public partial interface IIdentityManagement :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get; set; }

    }
    internal partial interface IIdentityManagementInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get; set; }

    }
}