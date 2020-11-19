namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Create network mappings input properties/behavior specific to vmm to vmm Network mapping.
    /// </summary>
    public partial class VmmToVmmCreateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmToVmmCreateNetworkMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmToVmmCreateNetworkMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput __fabricSpecificCreateNetworkMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificCreateNetworkMappingInput();

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal)__fabricSpecificCreateNetworkMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal)__fabricSpecificCreateNetworkMappingInput).InstanceType = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__fabricSpecificCreateNetworkMappingInput), __fabricSpecificCreateNetworkMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificCreateNetworkMappingInput), __fabricSpecificCreateNetworkMappingInput);
        }

        /// <summary>Creates an new <see cref="VmmToVmmCreateNetworkMappingInput" /> instance.</summary>
        public VmmToVmmCreateNetworkMappingInput()
        {

        }
    }
    /// Create network mappings input properties/behavior specific to vmm to vmm Network mapping.
    public partial interface IVmmToVmmCreateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput
    {

    }
    /// Create network mappings input properties/behavior specific to vmm to vmm Network mapping.
    internal partial interface IVmmToVmmCreateNetworkMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal
    {

    }
}