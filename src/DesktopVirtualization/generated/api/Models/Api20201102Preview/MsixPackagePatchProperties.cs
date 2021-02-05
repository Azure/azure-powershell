namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>MSIX Package properties that can be patched.</summary>
    public partial class MsixPackagePatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackagePatchProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackagePatchPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name for MSIX Package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="IsActive" /> property.</summary>
        private bool? _isActive;

        /// <summary>Set a version of the package to be active across hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? IsActive { get => this._isActive; set => this._isActive = value; }

        /// <summary>Backing field for <see cref="IsRegularRegistration" /> property.</summary>
        private bool? _isRegularRegistration;

        /// <summary>Set Registration mode. Regular or Delayed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? IsRegularRegistration { get => this._isRegularRegistration; set => this._isRegularRegistration = value; }

        /// <summary>Creates an new <see cref="MsixPackagePatchProperties" /> instance.</summary>
        public MsixPackagePatchProperties()
        {

        }
    }
    /// MSIX Package properties that can be patched.
    public partial interface IMsixPackagePatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Display name for MSIX Package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display name for MSIX Package.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Set a version of the package to be active across hostpool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Set a version of the package to be active across hostpool. ",
        SerializedName = @"isActive",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsActive { get; set; }
        /// <summary>Set Registration mode. Regular or Delayed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Set Registration mode. Regular or Delayed.",
        SerializedName = @"isRegularRegistration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsRegularRegistration { get; set; }

    }
    /// MSIX Package properties that can be patched.
    internal partial interface IMsixPackagePatchPropertiesInternal

    {
        /// <summary>Display name for MSIX Package.</summary>
        string DisplayName { get; set; }
        /// <summary>Set a version of the package to be active across hostpool.</summary>
        bool? IsActive { get; set; }
        /// <summary>Set Registration mode. Regular or Delayed.</summary>
        bool? IsRegularRegistration { get; set; }

    }
}