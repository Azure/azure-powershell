namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMage Azure V2 provider specific recovery point details.</summary>
    public partial class InMageAzureV2RecoveryPointDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2RecoveryPointDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2RecoveryPointDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails __providerSpecificRecoveryPointDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificRecoveryPointDetails();

        /// <summary>Gets the provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal)__providerSpecificRecoveryPointDetails).InstanceType; }

        /// <summary>Backing field for <see cref="IsMultiVMSyncPoint" /> property.</summary>
        private string _isMultiVMSyncPoint;

        /// <summary>A value indicating whether the recovery point is multi VM consistent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsMultiVMSyncPoint { get => this._isMultiVMSyncPoint; set => this._isMultiVMSyncPoint = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal)__providerSpecificRecoveryPointDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal)__providerSpecificRecoveryPointDetails).InstanceType = value; }

        /// <summary>Creates an new <see cref="InMageAzureV2RecoveryPointDetails" /> instance.</summary>
        public InMageAzureV2RecoveryPointDetails()
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
            await eventListener.AssertNotNull(nameof(__providerSpecificRecoveryPointDetails), __providerSpecificRecoveryPointDetails);
            await eventListener.AssertObjectIsValid(nameof(__providerSpecificRecoveryPointDetails), __providerSpecificRecoveryPointDetails);
        }
    }
    /// InMage Azure V2 provider specific recovery point details.
    public partial interface IInMageAzureV2RecoveryPointDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetails
    {
        /// <summary>A value indicating whether the recovery point is multi VM consistent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the recovery point is multi VM consistent.",
        SerializedName = @"isMultiVmSyncPoint",
        PossibleTypes = new [] { typeof(string) })]
        string IsMultiVMSyncPoint { get; set; }

    }
    /// InMage Azure V2 provider specific recovery point details.
    internal partial interface IInMageAzureV2RecoveryPointDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificRecoveryPointDetailsInternal
    {
        /// <summary>A value indicating whether the recovery point is multi VM consistent.</summary>
        string IsMultiVMSyncPoint { get; set; }

    }
}