namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt specific resync input.</summary>
    public partial class VMwareCbtResyncInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtResyncInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtResyncInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput __resyncProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResyncProviderSpecificInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInputInternal)__resyncProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInputInternal)__resyncProviderSpecificInput).InstanceType = value ; }

        /// <summary>Backing field for <see cref="SkipCbtReset" /> property.</summary>
        private string _skipCbtReset;

        /// <summary>A value indicating whether CBT is to be reset.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SkipCbtReset { get => this._skipCbtReset; set => this._skipCbtReset = value; }

        /// <summary>Creates an new <see cref="VMwareCbtResyncInput" /> instance.</summary>
        public VMwareCbtResyncInput()
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
            await eventListener.AssertNotNull(nameof(__resyncProviderSpecificInput), __resyncProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__resyncProviderSpecificInput), __resyncProviderSpecificInput);
        }
    }
    /// VMwareCbt specific resync input.
    public partial interface IVMwareCbtResyncInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput
    {
        /// <summary>A value indicating whether CBT is to be reset.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A value indicating whether CBT is to be reset.",
        SerializedName = @"skipCbtReset",
        PossibleTypes = new [] { typeof(string) })]
        string SkipCbtReset { get; set; }

    }
    /// VMwareCbt specific resync input.
    internal partial interface IVMwareCbtResyncInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInputInternal
    {
        /// <summary>A value indicating whether CBT is to be reset.</summary>
        string SkipCbtReset { get; set; }

    }
}