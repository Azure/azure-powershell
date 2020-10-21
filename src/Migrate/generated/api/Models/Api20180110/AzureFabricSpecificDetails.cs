namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure Fabric Specific Details.</summary>
    public partial class AzureFabricSpecificDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureFabricSpecificDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureFabricSpecificDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails __fabricSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails();

        /// <summary>Backing field for <see cref="ContainerId" /> property.</summary>
        private string[] _containerId;

        /// <summary>The container Ids for the Azure fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] ContainerId { get => this._containerId; set => this._containerId = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The Location for the Azure fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType = value; }

        /// <summary>Creates an new <see cref="AzureFabricSpecificDetails" /> instance.</summary>
        public AzureFabricSpecificDetails()
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
            await eventListener.AssertNotNull(nameof(__fabricSpecificDetails), __fabricSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificDetails), __fabricSpecificDetails);
        }
    }
    /// Azure Fabric Specific Details.
    public partial interface IAzureFabricSpecificDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails
    {
        /// <summary>The container Ids for the Azure fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The container Ids for the Azure fabric.",
        SerializedName = @"containerIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] ContainerId { get; set; }
        /// <summary>The Location for the Azure fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Location for the Azure fabric.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }

    }
    /// Azure Fabric Specific Details.
    internal partial interface IAzureFabricSpecificDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal
    {
        /// <summary>The container Ids for the Azure fabric.</summary>
        string[] ContainerId { get; set; }
        /// <summary>The Location for the Azure fabric.</summary>
        string Location { get; set; }

    }
}