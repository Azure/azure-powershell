namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Provider specific input for container creation operation.</summary>
    public partial class ReplicationProviderSpecificContainerCreationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>
        /// Creates an new <see cref="ReplicationProviderSpecificContainerCreationInput" /> instance.
        /// </summary>
        public ReplicationProviderSpecificContainerCreationInput()
        {

        }
    }
    /// Provider specific input for container creation operation.
    public partial interface IReplicationProviderSpecificContainerCreationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Provider specific input for container creation operation.
    internal partial interface IReplicationProviderSpecificContainerCreationInputInternal

    {
        /// <summary>The class type.</summary>
        string InstanceType { get; set; }

    }
}