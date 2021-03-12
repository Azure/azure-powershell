namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A container mapping input.</summary>
    public partial class A2AContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AContainerMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput __replicationProviderSpecificContainerMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificContainerMappingInput();

        /// <summary>Backing field for <see cref="AgentAutoUpdateStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus? _agentAutoUpdateStatus;

        /// <summary>A value indicating whether the auto update is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get => this._agentAutoUpdateStatus; set => this._agentAutoUpdateStatus = value; }

        /// <summary>Backing field for <see cref="AutomationAccountArmId" /> property.</summary>
        private string _automationAccountArmId;

        /// <summary>The automation account arm id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AutomationAccountArmId { get => this._automationAccountArmId; set => this._automationAccountArmId = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInputInternal)__replicationProviderSpecificContainerMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInputInternal)__replicationProviderSpecificContainerMappingInput).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="A2AContainerMappingInput" /> instance.</summary>
        public A2AContainerMappingInput()
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
            await eventListener.AssertNotNull(nameof(__replicationProviderSpecificContainerMappingInput), __replicationProviderSpecificContainerMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__replicationProviderSpecificContainerMappingInput), __replicationProviderSpecificContainerMappingInput);
        }
    }
    /// A2A container mapping input.
    public partial interface IA2AContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput
    {
        /// <summary>A value indicating whether the auto update is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the auto update is enabled.",
        SerializedName = @"agentAutoUpdateStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get; set; }
        /// <summary>The automation account arm id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The automation account arm id.",
        SerializedName = @"automationAccountArmId",
        PossibleTypes = new [] { typeof(string) })]
        string AutomationAccountArmId { get; set; }

    }
    /// A2A container mapping input.
    internal partial interface IA2AContainerMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInputInternal
    {
        /// <summary>A value indicating whether the auto update is enabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get; set; }
        /// <summary>The automation account arm id.</summary>
        string AutomationAccountArmId { get; set; }

    }
}