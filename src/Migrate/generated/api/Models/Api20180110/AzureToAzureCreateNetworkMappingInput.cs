namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Create network mappings input properties/behavior specific to Azure to Azure Network mapping.
    /// </summary>
    public partial class AzureToAzureCreateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureCreateNetworkMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureCreateNetworkMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput __fabricSpecificCreateNetworkMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificCreateNetworkMappingInput();

        /// <summary>The instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal)__fabricSpecificCreateNetworkMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal)__fabricSpecificCreateNetworkMappingInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="PrimaryNetworkId" /> property.</summary>
        private string _primaryNetworkId;

        /// <summary>The primary azure vnet Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryNetworkId { get => this._primaryNetworkId; set => this._primaryNetworkId = value; }

        /// <summary>Creates an new <see cref="AzureToAzureCreateNetworkMappingInput" /> instance.</summary>
        public AzureToAzureCreateNetworkMappingInput()
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
            await eventListener.AssertNotNull(nameof(__fabricSpecificCreateNetworkMappingInput), __fabricSpecificCreateNetworkMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificCreateNetworkMappingInput), __fabricSpecificCreateNetworkMappingInput);
        }
    }
    /// Create network mappings input properties/behavior specific to Azure to Azure Network mapping.
    public partial interface IAzureToAzureCreateNetworkMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInput
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
    /// Create network mappings input properties/behavior specific to Azure to Azure Network mapping.
    internal partial interface IAzureToAzureCreateNetworkMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreateNetworkMappingInputInternal
    {
        /// <summary>The primary azure vnet Id.</summary>
        string PrimaryNetworkId { get; set; }

    }
}