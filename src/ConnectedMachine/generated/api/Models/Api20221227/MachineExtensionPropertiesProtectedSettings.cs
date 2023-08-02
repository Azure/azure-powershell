namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>
    /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    /// </summary>
    public partial class MachineExtensionPropertiesProtectedSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineExtensionPropertiesProtectedSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineExtensionPropertiesProtectedSettingsInternal
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
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    internal partial interface IMachineExtensionPropertiesProtectedSettingsInternal

    {

    }
}