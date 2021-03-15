namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Updates network mappings input.</summary>
    public partial class AzureToAzureUpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureUpdateNetworkMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureUpdateNetworkMappingInputInternal,
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

        /// <summary>Backing field for <see cref="PrimaryNetworkId" /> property.</summary>
        private string _primaryNetworkId;

        /// <summary>The primary azure vnet Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryNetworkId { get => this._primaryNetworkId; set => this._primaryNetworkId = value; }

        /// <summary>Creates an new <see cref="AzureToAzureUpdateNetworkMappingInput" /> instance.</summary>
        public AzureToAzureUpdateNetworkMappingInput()
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
            await eventListener.AssertNotNull(nameof(__fabricSpecificUpdateNetworkMappingInput), __fabricSpecificUpdateNetworkMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificUpdateNetworkMappingInput), __fabricSpecificUpdateNetworkMappingInput);
        }
    }
    /// Updates network mappings input.
    public partial interface IAzureToAzureUpdateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInput
    {
        /// <summary>The primary azure vnet Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary azure vnet Id.",
        SerializedName = @"primaryNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryNetworkId { get; set; }

    }
    /// Updates network mappings input.
    internal partial interface IAzureToAzureUpdateNetworkMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificUpdateNetworkMappingInputInternal
    {
        /// <summary>The primary azure vnet Id.</summary>
        string PrimaryNetworkId { get; set; }

    }
}