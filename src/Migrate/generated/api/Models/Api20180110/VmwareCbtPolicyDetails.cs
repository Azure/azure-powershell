namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMware Cbt specific policy details.</summary>
    public partial class VmwareCbtPolicyDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmwareCbtPolicyDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmwareCbtPolicyDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails __policyProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificDetails();

        /// <summary>Backing field for <see cref="AppConsistentFrequencyInMinute" /> property.</summary>
        private int? _appConsistentFrequencyInMinute;

        /// <summary>The app consistent snapshot frequency in minutes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? AppConsistentFrequencyInMinute { get => this._appConsistentFrequencyInMinute; set => this._appConsistentFrequencyInMinute = value; }

        /// <summary>Backing field for <see cref="CrashConsistentFrequencyInMinute" /> property.</summary>
        private int? _crashConsistentFrequencyInMinute;

        /// <summary>The crash consistent snapshot frequency in minutes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? CrashConsistentFrequencyInMinute { get => this._crashConsistentFrequencyInMinute; set => this._crashConsistentFrequencyInMinute = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)__policyProviderSpecificDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)__policyProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)__policyProviderSpecificDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="RecoveryPointHistoryInMinute" /> property.</summary>
        private int? _recoveryPointHistoryInMinute;

        /// <summary>The duration in minutes until which the recovery points need to be stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? RecoveryPointHistoryInMinute { get => this._recoveryPointHistoryInMinute; set => this._recoveryPointHistoryInMinute = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__policyProviderSpecificDetails), __policyProviderSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__policyProviderSpecificDetails), __policyProviderSpecificDetails);
        }

        /// <summary>Creates an new <see cref="VmwareCbtPolicyDetails" /> instance.</summary>
        public VmwareCbtPolicyDetails()
        {

        }
    }
    /// VMware Cbt specific policy details.
    public partial interface IVmwareCbtPolicyDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails
    {
        /// <summary>The app consistent snapshot frequency in minutes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The app consistent snapshot frequency in minutes.",
        SerializedName = @"appConsistentFrequencyInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? AppConsistentFrequencyInMinute { get; set; }
        /// <summary>The crash consistent snapshot frequency in minutes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The crash consistent snapshot frequency in minutes.",
        SerializedName = @"crashConsistentFrequencyInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? CrashConsistentFrequencyInMinute { get; set; }
        /// <summary>The duration in minutes until which the recovery points need to be stored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The duration in minutes until which the recovery points need to be stored.",
        SerializedName = @"recoveryPointHistoryInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? RecoveryPointHistoryInMinute { get; set; }

    }
    /// VMware Cbt specific policy details.
    internal partial interface IVmwareCbtPolicyDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal
    {
        /// <summary>The app consistent snapshot frequency in minutes.</summary>
        int? AppConsistentFrequencyInMinute { get; set; }
        /// <summary>The crash consistent snapshot frequency in minutes.</summary>
        int? CrashConsistentFrequencyInMinute { get; set; }
        /// <summary>The duration in minutes until which the recovery points need to be stored.</summary>
        int? RecoveryPointHistoryInMinute { get; set; }

    }
}