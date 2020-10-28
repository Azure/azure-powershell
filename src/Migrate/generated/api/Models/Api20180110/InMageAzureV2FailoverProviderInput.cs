namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageAzureV2 provider specific input for failover.</summary>
    public partial class InMageAzureV2FailoverProviderInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2FailoverProviderInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2FailoverProviderInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput __providerSpecificFailoverInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificFailoverInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)__providerSpecificFailoverInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)__providerSpecificFailoverInput).InstanceType = value; }

        /// <summary>Backing field for <see cref="RecoveryPointId" /> property.</summary>
        private string _recoveryPointId;

        /// <summary>
        /// The recovery point id to be passed to failover to a particular recovery point. In case of latest recovery point, null
        /// should be passed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryPointId { get => this._recoveryPointId; set => this._recoveryPointId = value; }

        /// <summary>Backing field for <see cref="VaultLocation" /> property.</summary>
        private string _vaultLocation;

        /// <summary>Location of the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VaultLocation { get => this._vaultLocation; set => this._vaultLocation = value; }

        /// <summary>Creates an new <see cref="InMageAzureV2FailoverProviderInput" /> instance.</summary>
        public InMageAzureV2FailoverProviderInput()
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
            await eventListener.AssertNotNull(nameof(__providerSpecificFailoverInput), __providerSpecificFailoverInput);
            await eventListener.AssertObjectIsValid(nameof(__providerSpecificFailoverInput), __providerSpecificFailoverInput);
        }
    }
    /// InMageAzureV2 provider specific input for failover.
    public partial interface IInMageAzureV2FailoverProviderInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput
    {
        /// <summary>
        /// The recovery point id to be passed to failover to a particular recovery point. In case of latest recovery point, null
        /// should be passed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point id to be passed to failover to a particular recovery point. In case of latest recovery point, null should be passed.",
        SerializedName = @"recoveryPointId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointId { get; set; }
        /// <summary>Location of the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location of the vault.",
        SerializedName = @"vaultLocation",
        PossibleTypes = new [] { typeof(string) })]
        string VaultLocation { get; set; }

    }
    /// InMageAzureV2 provider specific input for failover.
    internal partial interface IInMageAzureV2FailoverProviderInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal
    {
        /// <summary>
        /// The recovery point id to be passed to failover to a particular recovery point. In case of latest recovery point, null
        /// should be passed.
        /// </summary>
        string RecoveryPointId { get; set; }
        /// <summary>Location of the vault.</summary>
        string VaultLocation { get; set; }

    }
}