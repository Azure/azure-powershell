namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Json formatted public settings for the extension.</summary>
    public partial class MachineExtensionPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineExtensionPropertiesSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineExtensionPropertiesSettingsInternal
    {

        /// <summary>Creates an new <see cref="MachineExtensionPropertiesSettings" /> instance.</summary>
        public MachineExtensionPropertiesSettings()
        {

        }
    }
    /// Json formatted public settings for the extension.
    public partial interface IMachineExtensionPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// Json formatted public settings for the extension.
    internal partial interface IMachineExtensionPropertiesSettingsInternal

    {

    }
}