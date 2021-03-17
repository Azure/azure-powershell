namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMage disable protection provider specific input.</summary>
    public partial class InMageDisableProtectionProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDisableProtectionProviderSpecificInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDisableProtectionProviderSpecificInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput __disableProtectionProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DisableProtectionProviderSpecificInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInputInternal)__disableProtectionProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInputInternal)__disableProtectionProviderSpecificInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="ReplicaVMDeletionStatus" /> property.</summary>
        private string _replicaVMDeletionStatus;

        /// <summary>
        /// A value indicating whether the replica VM should be destroyed or retained. Values from Delete and Retain.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicaVMDeletionStatus { get => this._replicaVMDeletionStatus; set => this._replicaVMDeletionStatus = value; }

        /// <summary>
        /// Creates an new <see cref="InMageDisableProtectionProviderSpecificInput" /> instance.
        /// </summary>
        public InMageDisableProtectionProviderSpecificInput()
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
            await eventListener.AssertNotNull(nameof(__disableProtectionProviderSpecificInput), __disableProtectionProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__disableProtectionProviderSpecificInput), __disableProtectionProviderSpecificInput);
        }
    }
    /// InMage disable protection provider specific input.
    public partial interface IInMageDisableProtectionProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInput
    {
        /// <summary>
        /// A value indicating whether the replica VM should be destroyed or retained. Values from Delete and Retain.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the replica VM should be destroyed or retained. Values from Delete and Retain.",
        SerializedName = @"replicaVmDeletionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicaVMDeletionStatus { get; set; }

    }
    /// InMage disable protection provider specific input.
    internal partial interface IInMageDisableProtectionProviderSpecificInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisableProtectionProviderSpecificInputInternal
    {
        /// <summary>
        /// A value indicating whether the replica VM should be destroyed or retained. Values from Delete and Retain.
        /// </summary>
        string ReplicaVMDeletionStatus { get; set; }

    }
}