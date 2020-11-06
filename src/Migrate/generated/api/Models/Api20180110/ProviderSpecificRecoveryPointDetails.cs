namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication provider specific recovery point details.</summary>
    public partial class ProviderSpecificRecoveryPointDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Creates an new <see cref="ProviderSpecificRecoveryPointDetails" /> instance.</summary>
        public ProviderSpecificRecoveryPointDetails()
        {

        }
    }
    /// Replication provider specific recovery point details.
    public partial interface IProviderSpecificRecoveryPointDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the provider type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }

    }
    /// Replication provider specific recovery point details.
    internal partial interface IProviderSpecificRecoveryPointDetailsInternal

    {
        /// <summary>Gets the provider type.</summary>
        string InstanceType { get; set; }

    }
}