namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication protected item custom data details.</summary>
    public partial class ReplicationProtectedItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActiveLocation" /> property.</summary>
        private string _activeLocation;

        /// <summary>The Current active location of the PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ActiveLocation { get => this._activeLocation; set => this._activeLocation = value; }

        /// <summary>Backing field for <see cref="AllowedOperation" /> property.</summary>
        private string[] _allowedOperation;

        /// <summary>The allowed operations on the Replication protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] AllowedOperation { get => this._allowedOperation; set => this._allowedOperation = value; }

        /// <summary>Backing field for <see cref="CurrentScenario" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails _currentScenario;

        /// <summary>The current scenario.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails CurrentScenario { get => (this._currentScenario = this._currentScenario ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetails()); set => this._currentScenario = value; }

        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentScenarioJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).JobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).JobId = value ?? null; }

        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentScenarioName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).ScenarioName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).ScenarioName = value ?? null; }

        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentScenarioStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).StartTime = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="FailoverHealth" /> property.</summary>
        private string _failoverHealth;

        /// <summary>The consolidated failover health for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FailoverHealth { get => this._failoverHealth; set => this._failoverHealth = value; }

        /// <summary>Backing field for <see cref="FailoverRecoveryPointId" /> property.</summary>
        private string _failoverRecoveryPointId;

        /// <summary>The recovery point ARM Id to which the Vm was failed over.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FailoverRecoveryPointId { get => this._failoverRecoveryPointId; set => this._failoverRecoveryPointId = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="HealthError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthError;

        /// <summary>List of health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => this._healthError; set => this._healthError = value; }

        /// <summary>Backing field for <see cref="LastSuccessfulFailoverTime" /> property.</summary>
        private global::System.DateTime? _lastSuccessfulFailoverTime;

        /// <summary>The Last successful failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastSuccessfulFailoverTime { get => this._lastSuccessfulFailoverTime; set => this._lastSuccessfulFailoverTime = value; }

        /// <summary>Backing field for <see cref="LastSuccessfulTestFailoverTime" /> property.</summary>
        private global::System.DateTime? _lastSuccessfulTestFailoverTime;

        /// <summary>The Last successful test failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastSuccessfulTestFailoverTime { get => this._lastSuccessfulTestFailoverTime; set => this._lastSuccessfulTestFailoverTime = value; }

        /// <summary>Internal Acessors for CurrentScenario</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal.CurrentScenario { get => (this._currentScenario = this._currentScenario ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetails()); set { {_currentScenario = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal.ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)ProviderSpecificDetail).InstanceType = value; }

        /// <summary>Backing field for <see cref="PolicyFriendlyName" /> property.</summary>
        private string _policyFriendlyName;

        /// <summary>The name of Policy governing this PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyFriendlyName { get => this._policyFriendlyName; set => this._policyFriendlyName = value; }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>The ID of Policy governing this PE.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; set => this._policyId = value; }

        /// <summary>Backing field for <see cref="PrimaryFabricFriendlyName" /> property.</summary>
        private string _primaryFabricFriendlyName;

        /// <summary>The friendly name of the primary fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricFriendlyName { get => this._primaryFabricFriendlyName; set => this._primaryFabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="PrimaryFabricProvider" /> property.</summary>
        private string _primaryFabricProvider;

        /// <summary>The fabric provider of the primary fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricProvider { get => this._primaryFabricProvider; set => this._primaryFabricProvider = value; }

        /// <summary>
        /// Backing field for <see cref="PrimaryProtectionContainerFriendlyName" /> property.
        /// </summary>
        private string _primaryProtectionContainerFriendlyName;

        /// <summary>The name of primary protection container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryProtectionContainerFriendlyName { get => this._primaryProtectionContainerFriendlyName; set => this._primaryProtectionContainerFriendlyName = value; }

        /// <summary>Backing field for <see cref="ProtectableItemId" /> property.</summary>
        private string _protectableItemId;

        /// <summary>The protected item ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectableItemId { get => this._protectableItemId; set => this._protectableItemId = value; }

        /// <summary>Backing field for <see cref="ProtectedItemType" /> property.</summary>
        private string _protectedItemType;

        /// <summary>The type of protected item type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectedItemType { get => this._protectedItemType; set => this._protectedItemType = value; }

        /// <summary>Backing field for <see cref="ProtectionState" /> property.</summary>
        private string _protectionState;

        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectionState { get => this._protectionState; set => this._protectionState = value; }

        /// <summary>Backing field for <see cref="ProtectionStateDescription" /> property.</summary>
        private string _protectionStateDescription;

        /// <summary>The protection state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectionStateDescription { get => this._protectionStateDescription; set => this._protectionStateDescription = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings _providerSpecificDetail;

        /// <summary>The Replication provider custom settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings()); set => this._providerSpecificDetail = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)ProviderSpecificDetail).InstanceType; }

        /// <summary>Backing field for <see cref="RecoveryContainerId" /> property.</summary>
        private string _recoveryContainerId;

        /// <summary>The recovery container Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryContainerId { get => this._recoveryContainerId; set => this._recoveryContainerId = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricFriendlyName" /> property.</summary>
        private string _recoveryFabricFriendlyName;

        /// <summary>The friendly name of recovery fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricFriendlyName { get => this._recoveryFabricFriendlyName; set => this._recoveryFabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricId" /> property.</summary>
        private string _recoveryFabricId;

        /// <summary>The Arm Id of recovery fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricId { get => this._recoveryFabricId; set => this._recoveryFabricId = value; }

        /// <summary>
        /// Backing field for <see cref="RecoveryProtectionContainerFriendlyName" /> property.
        /// </summary>
        private string _recoveryProtectionContainerFriendlyName;

        /// <summary>The name of recovery container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryProtectionContainerFriendlyName { get => this._recoveryProtectionContainerFriendlyName; set => this._recoveryProtectionContainerFriendlyName = value; }

        /// <summary>Backing field for <see cref="RecoveryServicesProviderId" /> property.</summary>
        private string _recoveryServicesProviderId;

        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryServicesProviderId { get => this._recoveryServicesProviderId; set => this._recoveryServicesProviderId = value; }

        /// <summary>Backing field for <see cref="ReplicationHealth" /> property.</summary>
        private string _replicationHealth;

        /// <summary>
        /// The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated
        /// with the VM's replication group into account. This is a string representation of the ProtectionHealth enumeration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicationHealth { get => this._replicationHealth; set => this._replicationHealth = value; }

        /// <summary>Backing field for <see cref="TestFailoverState" /> property.</summary>
        private string _testFailoverState;

        /// <summary>The Test failover state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TestFailoverState { get => this._testFailoverState; set => this._testFailoverState = value; }

        /// <summary>Backing field for <see cref="TestFailoverStateDescription" /> property.</summary>
        private string _testFailoverStateDescription;

        /// <summary>The Test failover state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TestFailoverStateDescription { get => this._testFailoverStateDescription; set => this._testFailoverStateDescription = value; }

        /// <summary>Creates an new <see cref="ReplicationProtectedItemProperties" /> instance.</summary>
        public ReplicationProtectedItemProperties()
        {

        }
    }
    /// Replication protected item custom data details.
    public partial interface IReplicationProtectedItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
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
    /// Replication protected item custom data details.
    internal partial interface IReplicationProtectedItemPropertiesInternal

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