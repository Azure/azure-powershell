namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Represents a RegistrationInfo definition.</summary>
    public partial class RegistrationInfoPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IRegistrationInfoPatch,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IRegistrationInfoPatchInternal
    {

        /// <summary>Backing field for <see cref="ExpirationTime" /> property.</summary>
        private global::System.DateTime? _expirationTime;

        /// <summary>Expiration time of registration token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpirationTime { get => this._expirationTime; set => this._expirationTime = value; }

        /// <summary>Backing field for <see cref="RegistrationTokenOperation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? _registrationTokenOperation;

        /// <summary>The type of resetting the token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? RegistrationTokenOperation { get => this._registrationTokenOperation; set => this._registrationTokenOperation = value; }

        /// <summary>Creates an new <see cref="RegistrationInfoPatch" /> instance.</summary>
        public RegistrationInfoPatch()
        {

        }
    }
    /// Represents a RegistrationInfo definition.
    public partial interface IRegistrationInfoPatch :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Expiration time of registration token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Expiration time of registration token.",
        SerializedName = @"expirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>The type of resetting the token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of resetting the token.",
        SerializedName = @"registrationTokenOperation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? RegistrationTokenOperation { get; set; }

    }
    /// Represents a RegistrationInfo definition.
    internal partial interface IRegistrationInfoPatchInternal

    {
        /// <summary>Expiration time of registration token.</summary>
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>The type of resetting the token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation? RegistrationTokenOperation { get; set; }

    }
}