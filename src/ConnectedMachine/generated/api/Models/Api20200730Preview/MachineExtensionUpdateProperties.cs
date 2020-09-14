namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes Machine Extension Update Properties.</summary>
    public partial class MachineExtensionUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdatePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1 __machineExtensionUpdateProperties1 = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionUpdateProperties1();

        /// <summary>
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed,
        /// however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public bool? AutoUpgradeMinorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).AutoUpgradeMinorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).AutoUpgradeMinorVersion = value; }

        /// <summary>
        /// How the extension handler should be forced to update even if the extension configuration has not changed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string ForceUpdateTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).ForceUpdateTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).ForceUpdateTag = value; }

        /// <summary>
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdatePropertiesProtectedSettings ProtectedSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).ProtectedSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).ProtectedSetting = value; }

        /// <summary>The name of the extension handler publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Publisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).Publisher = value; }

        /// <summary>Json formatted public settings for the extension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdatePropertiesSettings Setting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).Setting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).Setting = value; }

        /// <summary>Specifies the type of the extension; an example is "CustomScriptExtension".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).Type = value; }

        /// <summary>Specifies the version of the script handler.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string TypeHandlerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).TypeHandlerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal)__machineExtensionUpdateProperties1).TypeHandlerVersion = value; }

        /// <summary>Creates an new <see cref="MachineExtensionUpdateProperties" /> instance.</summary>
        public MachineExtensionUpdateProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__machineExtensionUpdateProperties1), __machineExtensionUpdateProperties1);
            await eventListener.AssertObjectIsValid(nameof(__machineExtensionUpdateProperties1), __machineExtensionUpdateProperties1);
        }
    }
    /// Describes Machine Extension Update Properties.
    public partial interface IMachineExtensionUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1
    {

    }
    /// Describes Machine Extension Update Properties.
    internal partial interface IMachineExtensionUpdatePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionUpdateProperties1Internal
    {

    }
}