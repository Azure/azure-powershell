namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Json formatted public settings for the extension.</summary>
    public partial class MachineExtensionPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesSettingsInternal
    {

        /// <summary>Creates an new <see cref="MachineExtensionPropertiesSettings" /> instance.</summary>
        public MachineExtensionPropertiesSettings()
        {

        }
    }
    /// Json formatted public settings for the extension.
    public partial interface IMachineExtensionPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {

    }
    /// Json formatted public settings for the extension.
    internal partial interface IMachineExtensionPropertiesSettingsInternal

    {

    }
}