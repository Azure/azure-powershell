namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt specific migrate input.</summary>
    public partial class VMwareCbtMigrateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtMigrateInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtMigrateInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput __migrateProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrateProviderSpecificInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInputInternal)__migrateProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInputInternal)__migrateProviderSpecificInput).InstanceType = value; }

        /// <summary>Backing field for <see cref="PerformShutdown" /> property.</summary>
        private string _performShutdown;

        /// <summary>A value indicating whether VM is to be shutdown.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PerformShutdown { get => this._performShutdown; set => this._performShutdown = value; }

        /// <summary>Creates an new <see cref="VMwareCbtMigrateInput" /> instance.</summary>
        public VMwareCbtMigrateInput()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__migrateProviderSpecificInput), __migrateProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__migrateProviderSpecificInput), __migrateProviderSpecificInput);
        }
    }
    /// VMwareCbt specific migrate input.
    public partial interface IVMwareCbtMigrateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInput
    {
        /// <summary>A value indicating whether VM is to be shutdown.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A value indicating whether VM is to be shutdown.",
        SerializedName = @"performShutdown",
        PossibleTypes = new [] { typeof(string) })]
        string PerformShutdown { get; set; }

    }
    /// VMwareCbt specific migrate input.
    internal partial interface IVMwareCbtMigrateInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrateProviderSpecificInputInternal
    {
        /// <summary>A value indicating whether VM is to be shutdown.</summary>
        string PerformShutdown { get; set; }

    }
}