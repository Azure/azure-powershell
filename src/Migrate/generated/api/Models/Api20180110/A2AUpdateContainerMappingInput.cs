namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A update protection container mapping.</summary>
    public partial class A2AUpdateContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AUpdateContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AUpdateContainerMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput __replicationProviderSpecificUpdateContainerMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificUpdateContainerMappingInput();

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
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInputInternal)__replicationProviderSpecificUpdateContainerMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInputInternal)__replicationProviderSpecificUpdateContainerMappingInput).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="A2AUpdateContainerMappingInput" /> instance.</summary>
        public A2AUpdateContainerMappingInput()
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
            await eventListener.AssertNotNull(nameof(__replicationProviderSpecificUpdateContainerMappingInput), __replicationProviderSpecificUpdateContainerMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__replicationProviderSpecificUpdateContainerMappingInput), __replicationProviderSpecificUpdateContainerMappingInput);
        }
    }
    /// A2A update protection container mapping.
    public partial interface IA2AUpdateContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput
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
    /// A2A update protection container mapping.
    internal partial interface IA2AUpdateContainerMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInputInternal
    {
        /// <summary>A value indicating whether the auto update is enabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get; set; }
        /// <summary>The automation account arm id.</summary>
        string AutomationAccountArmId { get; set; }

    }
}