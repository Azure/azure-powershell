namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>The machine extension instance view.</summary>
    public partial class MachineExtensionPropertiesInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionPropertiesInstanceView,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionPropertiesInstanceViewInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView __machineExtensionInstanceView = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineExtensionInstanceView();

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Name = value; }

        /// <summary>Internal Acessors for StatusCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.StatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusCode = value; }

        /// <summary>Internal Acessors for StatusDisplayStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.StatusDisplayStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusDisplayStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusDisplayStatus = value; }

        /// <summary>Internal Acessors for StatusLevel</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.StatusLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusLevel = value; }

        /// <summary>Internal Acessors for StatusMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.StatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusMessage = value; }

        /// <summary>Internal Acessors for StatusTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.StatusTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusTime = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Type = value; }

        /// <summary>Internal Acessors for TypeHandlerVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal.TypeHandlerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).TypeHandlerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).TypeHandlerVersion = value; }

        /// <summary>The machine extension name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Name; }

        /// <summary>Instance view status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewStatus Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Status = value; }

        /// <summary>The status code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string StatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusCode; }

        /// <summary>The short localizable label for the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string StatusDisplayStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusDisplayStatus; }

        /// <summary>The level code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes? StatusLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusLevel; }

        /// <summary>The detailed status message, including for alerts and error messages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string StatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusMessage; }

        /// <summary>The time of the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public global::System.DateTime? StatusTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).StatusTime; }

        /// <summary>Specifies the type of the extension; an example is "CustomScriptExtension".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).Type; }

        /// <summary>Specifies the version of the script handler.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string TypeHandlerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal)__machineExtensionInstanceView).TypeHandlerVersion; }

        /// <summary>Creates an new <see cref="MachineExtensionPropertiesInstanceView" /> instance.</summary>
        public MachineExtensionPropertiesInstanceView()
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
            await eventListener.AssertNotNull(nameof(__machineExtensionInstanceView), __machineExtensionInstanceView);
            await eventListener.AssertObjectIsValid(nameof(__machineExtensionInstanceView), __machineExtensionInstanceView);
        }
    }
    /// The machine extension instance view.
    public partial interface IMachineExtensionPropertiesInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView
    {

    }
    /// The machine extension instance view.
    internal partial interface IMachineExtensionPropertiesInstanceViewInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceViewInternal
    {

    }
}