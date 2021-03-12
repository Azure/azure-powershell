namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the SQL Server resource settings.</summary>
    public partial class SqlServerResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISqlServerResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISqlServerResourceSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings __resourceSettings = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings();

        /// <summary>
        /// The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).ResourceType = value ; }

        /// <summary>Gets or sets the target Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string TargetResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).TargetResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).TargetResourceName = value ; }

        /// <summary>Creates an new <see cref="SqlServerResourceSettings" /> instance.</summary>
        public SqlServerResourceSettings()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resourceSettings), __resourceSettings);
            await eventListener.AssertObjectIsValid(nameof(__resourceSettings), __resourceSettings);
        }
    }
    /// Defines the SQL Server resource settings.
    public partial interface ISqlServerResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings
    {

    }
    /// Defines the SQL Server resource settings.
    internal partial interface ISqlServerResourceSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal
    {

    }
}