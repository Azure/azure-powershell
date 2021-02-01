namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Provider specific input for unpairing operations.</summary>
    public partial class ReplicationProviderContainerUnmappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>
        /// Creates an new <see cref="ReplicationProviderContainerUnmappingInput" /> instance.
        /// </summary>
        public ReplicationProviderContainerUnmappingInput()
        {

        }
    }
    /// Provider specific input for unpairing operations.
    public partial interface IReplicationProviderContainerUnmappingInput :
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
    /// Provider specific input for unpairing operations.
    internal partial interface IReplicationProviderContainerUnmappingInputInternal

    {
        /// <summary>The class type.</summary>
        string InstanceType { get; set; }

    }
}