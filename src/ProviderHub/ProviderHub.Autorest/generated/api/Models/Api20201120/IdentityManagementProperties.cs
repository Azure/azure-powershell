namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class IdentityManagementProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IIdentityManagementPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; set => this._applicationId = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? _type;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="IdentityManagementProperties" /> instance.</summary>
        public IdentityManagementProperties()
        {

        }
    }
    public partial interface IIdentityManagementProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get; set; }

    }
    internal partial interface IIdentityManagementPropertiesInternal

    {
        string ApplicationId { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes? Type { get; set; }

    }
}