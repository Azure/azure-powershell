namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication protected item.</summary>
    public partial class ReplicationProtectedItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItem,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>The Current active location of the PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ActiveLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ActiveLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ActiveLocation = value ?? null; }

        /// <summary>The allowed operations on the Replication protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] AllowedOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).AllowedOperation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).AllowedOperation = value ?? null /* arrayOf */; }

        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentScenarioJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenarioJobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenarioJobId = value ?? null; }

        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentScenarioName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenarioName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenarioName = value ?? null; }

        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentScenarioStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenarioStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenarioStartTime = value ?? default(global::System.DateTime); }

        /// <summary>The consolidated failover health for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FailoverHealth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).FailoverHealth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).FailoverHealth = value ?? null; }

        /// <summary>The recovery point ARM Id to which the Vm was failed over.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FailoverRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).FailoverRecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).FailoverRecoveryPointId = value ?? null; }

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>List of health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).HealthError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).HealthError = value ?? null /* arrayOf */; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>The Last successful failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastSuccessfulFailoverTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).LastSuccessfulFailoverTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).LastSuccessfulFailoverTime = value ?? default(global::System.DateTime); }

        /// <summary>The Last successful test failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastSuccessfulTestFailoverTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).LastSuccessfulTestFailoverTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).LastSuccessfulTestFailoverTime = value ?? default(global::System.DateTime); }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for CurrentScenario</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemInternal.CurrentScenario { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenario; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).CurrentScenario = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProtectedItemProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemInternal.ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProviderSpecificDetail = value; }

        /// <summary>Internal Acessors for ProviderSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemInternal.ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProviderSpecificDetailInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProviderSpecificDetailInstanceType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>The name of Policy governing this PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PolicyFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PolicyFriendlyName = value ?? null; }

        /// <summary>The ID of Policy governing this PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PolicyId = value ?? null; }

        /// <summary>The friendly name of the primary fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryFabricFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PrimaryFabricFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PrimaryFabricFriendlyName = value ?? null; }

        /// <summary>The fabric provider of the primary fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryFabricProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PrimaryFabricProvider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PrimaryFabricProvider = value ?? null; }

        /// <summary>The name of primary protection container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryProtectionContainerFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PrimaryProtectionContainerFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).PrimaryProtectionContainerFriendlyName = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties _property;

        /// <summary>The custom data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProtectedItemProperties()); set => this._property = value; }

        /// <summary>The protected item ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProtectableItemId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectableItemId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectableItemId = value ?? null; }

        /// <summary>The type of protected item type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProtectedItemType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectedItemType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectedItemType = value ?? null; }

        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProtectionState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectionState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectionState = value ?? null; }

        /// <summary>The protection state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProtectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectionStateDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProtectionStateDescription = value ?? null; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ProviderSpecificDetailInstanceType; }

        /// <summary>The recovery container Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryContainerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryContainerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryContainerId = value ?? null; }

        /// <summary>The friendly name of recovery fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryFabricFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryFabricFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryFabricFriendlyName = value ?? null; }

        /// <summary>The Arm Id of recovery fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryFabricId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryFabricId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryFabricId = value ?? null; }

        /// <summary>The name of recovery container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryProtectionContainerFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryProtectionContainerFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryProtectionContainerFriendlyName = value ?? null; }

        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryServicesProviderId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryServicesProviderId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).RecoveryServicesProviderId = value ?? null; }

        /// <summary>
        /// The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated
        /// with the VM's replication group into account. This is a string representation of the ProtectionHealth enumeration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ReplicationHealth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ReplicationHealth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).ReplicationHealth = value ?? null; }

        /// <summary>The Test failover state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TestFailoverState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).TestFailoverState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).TestFailoverState = value ?? null; }

        /// <summary>The Test failover state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TestFailoverStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).TestFailoverStateDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)Property).TestFailoverStateDescription = value ?? null; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ReplicationProtectedItem" /> instance.</summary>
        public ReplicationProtectedItem()
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
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Replication protected item.
    public partial interface IReplicationProtectedItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>The Current active location of the PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Current active location of the PE.",
        SerializedName = @"activeLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveLocation { get; set; }
        /// <summary>The allowed operations on the Replication protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The allowed operations on the Replication protected item.",
        SerializedName = @"allowedOperations",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedOperation { get; set; }
        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM Id of the job being executed.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentScenarioJobId { get; set; }
        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scenario name.",
        SerializedName = @"scenarioName",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentScenarioName { get; set; }
        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the workflow.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentScenarioStartTime { get; set; }
        /// <summary>The consolidated failover health for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The consolidated failover health for the VM.",
        SerializedName = @"failoverHealth",
        PossibleTypes = new [] { typeof(string) })]
        string FailoverHealth { get; set; }
        /// <summary>The recovery point ARM Id to which the Vm was failed over.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point ARM Id to which the Vm was failed over.",
        SerializedName = @"failoverRecoveryPointId",
        PossibleTypes = new [] { typeof(string) })]
        string FailoverRecoveryPointId { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>List of health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of health errors.",
        SerializedName = @"healthErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The Last successful failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Last successful failover time.",
        SerializedName = @"lastSuccessfulFailoverTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastSuccessfulFailoverTime { get; set; }
        /// <summary>The Last successful test failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Last successful test failover time.",
        SerializedName = @"lastSuccessfulTestFailoverTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastSuccessfulTestFailoverTime { get; set; }
        /// <summary>The name of Policy governing this PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of Policy governing this PE.",
        SerializedName = @"policyFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyFriendlyName { get; set; }
        /// <summary>The ID of Policy governing this PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of Policy governing this PE.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>The friendly name of the primary fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name of the primary fabric.",
        SerializedName = @"primaryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The fabric provider of the primary fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fabric provider of the primary fabric.",
        SerializedName = @"primaryFabricProvider",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricProvider { get; set; }
        /// <summary>The name of primary protection container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of primary protection container friendly name.",
        SerializedName = @"primaryProtectionContainerFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryProtectionContainerFriendlyName { get; set; }
        /// <summary>The protected item ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protected item ARM Id.",
        SerializedName = @"protectableItemId",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectableItemId { get; set; }
        /// <summary>The type of protected item type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of protected item type.",
        SerializedName = @"protectedItemType",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectedItemType { get; set; }
        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection status.",
        SerializedName = @"protectionState",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectionState { get; set; }
        /// <summary>The protection state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection state description.",
        SerializedName = @"protectionStateDescription",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectionStateDescription { get; set; }
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get;  }
        /// <summary>The recovery container Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery container Id.",
        SerializedName = @"recoveryContainerId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryContainerId { get; set; }
        /// <summary>The friendly name of recovery fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name of recovery fabric.",
        SerializedName = @"recoveryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The Arm Id of recovery fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Arm Id of recovery fabric.",
        SerializedName = @"recoveryFabricId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricId { get; set; }
        /// <summary>The name of recovery container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of recovery container friendly name.",
        SerializedName = @"recoveryProtectionContainerFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryProtectionContainerFriendlyName { get; set; }
        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery provider ARM Id.",
        SerializedName = @"recoveryServicesProviderId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryServicesProviderId { get; set; }
        /// <summary>
        /// The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated
        /// with the VM's replication group into account. This is a string representation of the ProtectionHealth enumeration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated with the VM's replication group into account. This is a string representation of the ProtectionHealth enumeration.",
        SerializedName = @"replicationHealth",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationHealth { get; set; }
        /// <summary>The Test failover state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Test failover state.",
        SerializedName = @"testFailoverState",
        PossibleTypes = new [] { typeof(string) })]
        string TestFailoverState { get; set; }
        /// <summary>The Test failover state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Test failover state description.",
        SerializedName = @"testFailoverStateDescription",
        PossibleTypes = new [] { typeof(string) })]
        string TestFailoverStateDescription { get; set; }

    }
    /// Replication protected item.
    internal partial interface IReplicationProtectedItemInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>The Current active location of the PE.</summary>
        string ActiveLocation { get; set; }
        /// <summary>The allowed operations on the Replication protected item.</summary>
        string[] AllowedOperation { get; set; }
        /// <summary>The current scenario.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails CurrentScenario { get; set; }
        /// <summary>ARM Id of the job being executed.</summary>
        string CurrentScenarioJobId { get; set; }
        /// <summary>Scenario name.</summary>
        string CurrentScenarioName { get; set; }
        /// <summary>Start time of the workflow.</summary>
        global::System.DateTime? CurrentScenarioStartTime { get; set; }
        /// <summary>The consolidated failover health for the VM.</summary>
        string FailoverHealth { get; set; }
        /// <summary>The recovery point ARM Id to which the Vm was failed over.</summary>
        string FailoverRecoveryPointId { get; set; }
        /// <summary>The name.</summary>
        string FriendlyName { get; set; }
        /// <summary>List of health errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The Last successful failover time.</summary>
        global::System.DateTime? LastSuccessfulFailoverTime { get; set; }
        /// <summary>The Last successful test failover time.</summary>
        global::System.DateTime? LastSuccessfulTestFailoverTime { get; set; }
        /// <summary>The name of Policy governing this PE.</summary>
        string PolicyFriendlyName { get; set; }
        /// <summary>The ID of Policy governing this PE.</summary>
        string PolicyId { get; set; }
        /// <summary>The friendly name of the primary fabric.</summary>
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The fabric provider of the primary fabric.</summary>
        string PrimaryFabricProvider { get; set; }
        /// <summary>The name of primary protection container friendly name.</summary>
        string PrimaryProtectionContainerFriendlyName { get; set; }
        /// <summary>The custom data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties Property { get; set; }
        /// <summary>The protected item ARM Id.</summary>
        string ProtectableItemId { get; set; }
        /// <summary>The type of protected item type.</summary>
        string ProtectedItemType { get; set; }
        /// <summary>The protection status.</summary>
        string ProtectionState { get; set; }
        /// <summary>The protection state description.</summary>
        string ProtectionStateDescription { get; set; }
        /// <summary>The Replication provider custom settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings ProviderSpecificDetail { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The recovery container Id.</summary>
        string RecoveryContainerId { get; set; }
        /// <summary>The friendly name of recovery fabric.</summary>
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The Arm Id of recovery fabric.</summary>
        string RecoveryFabricId { get; set; }
        /// <summary>The name of recovery container friendly name.</summary>
        string RecoveryProtectionContainerFriendlyName { get; set; }
        /// <summary>The recovery provider ARM Id.</summary>
        string RecoveryServicesProviderId { get; set; }
        /// <summary>
        /// The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated
        /// with the VM's replication group into account. This is a string representation of the ProtectionHealth enumeration.
        /// </summary>
        string ReplicationHealth { get; set; }
        /// <summary>The Test failover state.</summary>
        string TestFailoverState { get; set; }
        /// <summary>The Test failover state description.</summary>
        string TestFailoverStateDescription { get; set; }

    }
}