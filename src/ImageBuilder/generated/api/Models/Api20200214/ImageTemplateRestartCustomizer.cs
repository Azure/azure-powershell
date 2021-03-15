namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Reboots a VM and waits for it to come back online (Windows). Corresponds to Packer windows-restart provisioner
    /// </summary>
    public partial class ImageTemplateRestartCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateRestartCustomizer,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateRestartCustomizerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer __imageTemplateCustomizer = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateCustomizer();

        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name = value ?? null; }

        /// <summary>Backing field for <see cref="RestartCheckCommand" /> property.</summary>
        private string _restartCheckCommand;

        /// <summary>Command to check if restart succeeded [Default: '']</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string RestartCheckCommand { get => this._restartCheckCommand; set => this._restartCheckCommand = value; }

        /// <summary>Backing field for <see cref="RestartCommand" /> property.</summary>
        private string _restartCommand;

        /// <summary>
        /// Command to execute the restart [Default: 'shutdown /r /f /t 0 /c "packer restart"']
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string RestartCommand { get => this._restartCommand; set => this._restartCommand = value; }

        /// <summary>Backing field for <see cref="RestartTimeout" /> property.</summary>
        private string _restartTimeout;

        /// <summary>
        /// Restart timeout specified as a string of magnitude and unit, e.g. '5m' (5 minutes) or '2h' (2 hours) [Default: '5m']
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string RestartTimeout { get => this._restartTimeout; set => this._restartTimeout = value; }

        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type = value ; }

        /// <summary>Creates an new <see cref="ImageTemplateRestartCustomizer" /> instance.</summary>
        public ImageTemplateRestartCustomizer()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__imageTemplateCustomizer), __imageTemplateCustomizer);
            await eventListener.AssertObjectIsValid(nameof(__imageTemplateCustomizer), __imageTemplateCustomizer);
        }
    }
    /// Reboots a VM and waits for it to come back online (Windows). Corresponds to Packer windows-restart provisioner
    public partial interface IImageTemplateRestartCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer
    {
        /// <summary>Command to check if restart succeeded [Default: '']</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Command to check if restart succeeded [Default: '']",
        SerializedName = @"restartCheckCommand",
        PossibleTypes = new [] { typeof(string) })]
        string RestartCheckCommand { get; set; }
        /// <summary>
        /// Command to execute the restart [Default: 'shutdown /r /f /t 0 /c "packer restart"']
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Command to execute the restart [Default: 'shutdown /r /f /t 0 /c ""packer restart""']",
        SerializedName = @"restartCommand",
        PossibleTypes = new [] { typeof(string) })]
        string RestartCommand { get; set; }
        /// <summary>
        /// Restart timeout specified as a string of magnitude and unit, e.g. '5m' (5 minutes) or '2h' (2 hours) [Default: '5m']
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Restart timeout specified as a string of magnitude and unit, e.g. '5m' (5 minutes) or '2h' (2 hours) [Default: '5m']",
        SerializedName = @"restartTimeout",
        PossibleTypes = new [] { typeof(string) })]
        string RestartTimeout { get; set; }

    }
    /// Reboots a VM and waits for it to come back online (Windows). Corresponds to Packer windows-restart provisioner
    public partial interface IImageTemplateRestartCustomizerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal
    {
        /// <summary>Command to check if restart succeeded [Default: '']</summary>
        string RestartCheckCommand { get; set; }
        /// <summary>
        /// Command to execute the restart [Default: 'shutdown /r /f /t 0 /c "packer restart"']
        /// </summary>
        string RestartCommand { get; set; }
        /// <summary>
        /// Restart timeout specified as a string of magnitude and unit, e.g. '5m' (5 minutes) or '2h' (2 hours) [Default: '5m']
        /// </summary>
        string RestartTimeout { get; set; }

    }
}