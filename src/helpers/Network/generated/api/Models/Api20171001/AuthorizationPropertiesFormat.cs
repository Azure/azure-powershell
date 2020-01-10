namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    public partial class AuthorizationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAuthorizationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAuthorizationPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AuthorizationKey" /> property.</summary>
        private string _authorizationKey;

        /// <summary>The authorization key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthorizationKey { get => this._authorizationKey; set => this._authorizationKey = value; }

        /// <summary>Backing field for <see cref="AuthorizationUseStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus? _authorizationUseStatus;

        /// <summary>AuthorizationUseStatus. Possible values are: 'Available' and 'InUse'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus? AuthorizationUseStatus { get => this._authorizationUseStatus; set => this._authorizationUseStatus = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Creates an new <see cref="AuthorizationPropertiesFormat" /> instance.</summary>
        public AuthorizationPropertiesFormat()
        {

        }
    }
    public partial interface IAuthorizationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The authorization key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The authorization key.",
        SerializedName = @"authorizationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorizationKey { get; set; }
        /// <summary>AuthorizationUseStatus. Possible values are: 'Available' and 'InUse'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AuthorizationUseStatus. Possible values are: 'Available' and 'InUse'.",
        SerializedName = @"authorizationUseStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus? AuthorizationUseStatus { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    internal partial interface IAuthorizationPropertiesFormatInternal

    {
        /// <summary>The authorization key.</summary>
        string AuthorizationKey { get; set; }
        /// <summary>AuthorizationUseStatus. Possible values are: 'Available' and 'InUse'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthorizationUseStatus? AuthorizationUseStatus { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}