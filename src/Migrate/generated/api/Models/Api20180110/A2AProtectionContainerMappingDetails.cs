namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A provider specific settings.</summary>
    public partial class A2AProtectionContainerMappingDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectionContainerMappingDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectionContainerMappingDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails __protectionContainerMappingProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerMappingProviderSpecificDetails();

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

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal)__protectionContainerMappingProviderSpecificDetails).InstanceType; }

        /// <summary>Backing field for <see cref="JobScheduleName" /> property.</summary>
        private string _jobScheduleName;

        /// <summary>The job schedule arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobScheduleName { get => this._jobScheduleName; set => this._jobScheduleName = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal)__protectionContainerMappingProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal)__protectionContainerMappingProviderSpecificDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="ScheduleName" /> property.</summary>
        private string _scheduleName;

        /// <summary>The schedule arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ScheduleName { get => this._scheduleName; set => this._scheduleName = value; }

        /// <summary>Creates an new <see cref="A2AProtectionContainerMappingDetails" /> instance.</summary>
        public A2AProtectionContainerMappingDetails()
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
            await eventListener.AssertNotNull(nameof(__protectionContainerMappingProviderSpecificDetails), __protectionContainerMappingProviderSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__protectionContainerMappingProviderSpecificDetails), __protectionContainerMappingProviderSpecificDetails);
        }
    }
    /// A2A provider specific settings.
    public partial interface IA2AProtectionContainerMappingDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails
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
        /// <summary>The job schedule arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The job schedule arm name.",
        SerializedName = @"jobScheduleName",
        PossibleTypes = new [] { typeof(string) })]
        string JobScheduleName { get; set; }
        /// <summary>The schedule arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The schedule arm name.",
        SerializedName = @"scheduleName",
        PossibleTypes = new [] { typeof(string) })]
        string ScheduleName { get; set; }

    }
    /// A2A provider specific settings.
    internal partial interface IA2AProtectionContainerMappingDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal
    {
        /// <summary>A value indicating whether the auto update is enabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get; set; }
        /// <summary>The automation account arm id.</summary>
        string AutomationAccountArmId { get; set; }
        /// <summary>The job schedule arm name.</summary>
        string JobScheduleName { get; set; }
        /// <summary>The schedule arm name.</summary>
        string ScheduleName { get; set; }

    }
}