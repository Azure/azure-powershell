namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update network mappings input properties/behavior specific to vmm to vmm.</summary>
    public partial class VmmToVmmUpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmToVmmUpdateNetworkMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmToVmmUpdateNetworkMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput __fabricSpecificUpdateNetworkMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificUpdateNetworkMappingInput();

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal)__fabricSpecificUpdateNetworkMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal)__fabricSpecificUpdateNetworkMappingInput).InstanceType = value ?? null; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__fabricSpecificUpdateNetworkMappingInput), __fabricSpecificUpdateNetworkMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificUpdateNetworkMappingInput), __fabricSpecificUpdateNetworkMappingInput);
        }

        /// <summary>Creates an new <see cref="VmmToVmmUpdateNetworkMappingInput" /> instance.</summary>
        public VmmToVmmUpdateNetworkMappingInput()
        {

        }
    }
    /// Update network mappings input properties/behavior specific to vmm to vmm.
    public partial interface IVmmToVmmUpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput
    {

    }
    /// Update network mappings input properties/behavior specific to vmm to vmm.
    internal partial interface IVmmToVmmUpdateNetworkMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal
    {

    }
}