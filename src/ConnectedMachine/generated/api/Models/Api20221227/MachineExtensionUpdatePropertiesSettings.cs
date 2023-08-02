namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Json formatted public settings for the extension.</summary>
    public partial class MachineExtensionUpdatePropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineExtensionUpdatePropertiesSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineExtensionUpdatePropertiesSettingsInternal
    {

        /// <summary>
        /// Creates an new <see cref="MachineExtensionUpdatePropertiesSettings" /> instance.
        /// </summary>
        public MachineExtensionUpdatePropertiesSettings()
        {

        }
    }
    /// Json formatted public settings for the extension.
    public partial interface IMachineExtensionUpdatePropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// Json formatted public settings for the extension.
    internal partial interface IMachineExtensionUpdatePropertiesSettingsInternal

    {

    }
}