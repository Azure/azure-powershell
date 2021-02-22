namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt container creation input.</summary>
    public partial class VMwareCbtContainerCreationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtContainerCreationInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtContainerCreationInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput __replicationProviderSpecificContainerCreationInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificContainerCreationInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInputInternal)__replicationProviderSpecificContainerCreationInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInputInternal)__replicationProviderSpecificContainerCreationInput).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="VMwareCbtContainerCreationInput" /> instance.</summary>
        public VMwareCbtContainerCreationInput()
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
            await eventListener.AssertNotNull(nameof(__replicationProviderSpecificContainerCreationInput), __replicationProviderSpecificContainerCreationInput);
            await eventListener.AssertObjectIsValid(nameof(__replicationProviderSpecificContainerCreationInput), __replicationProviderSpecificContainerCreationInput);
        }
    }
    /// VMwareCbt container creation input.
    public partial interface IVMwareCbtContainerCreationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput
    {

    }
    /// VMwareCbt container creation input.
    internal partial interface IVMwareCbtContainerCreationInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInputInternal
    {

    }
}