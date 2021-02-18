namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>
    /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    /// </summary>
    public partial class MachineExtensionPropertiesProtectedSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionPropertiesProtectedSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionPropertiesProtectedSettingsInternal
    {

        /// <summary>
        /// Creates an new <see cref="MachineExtensionPropertiesProtectedSettings" /> instance.
        /// </summary>
        public MachineExtensionPropertiesProtectedSettings()
        {

        }
    }
    /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    public partial interface IMachineExtensionPropertiesProtectedSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {

    }
    /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    internal partial interface IMachineExtensionPropertiesProtectedSettingsInternal

    {

    }
}