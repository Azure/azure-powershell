namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Protection container mapping properties.</summary>
    public partial class ProtectionContainerMappingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Health" /> property.</summary>
        private string _health;

        /// <summary>Health of pairing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Health { get => this._health; set => this._health = value; }

        /// <summary>Backing field for <see cref="HealthErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthErrorDetail;

        /// <summary>Health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get => this._healthErrorDetail; set => this._healthErrorDetail = value; }

        /// <summary>Backing field for <see cref="PolicyFriendlyName" /> property.</summary>
        private string _policyFriendlyName;

        /// <summary>Friendly name of replication policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyFriendlyName { get => this._policyFriendlyName; set => this._policyFriendlyName = value; }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>Policy ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; set => this._policyId = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails _providerSpecificDetail;

        /// <summary>Provider specific provider details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerMappingProviderSpecificDetails()); set => this._providerSpecificDetail = value; }

        /// <summary>Backing field for <see cref="SourceFabricFriendlyName" /> property.</summary>
        private string _sourceFabricFriendlyName;

        /// <summary>Friendly name of source fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceFabricFriendlyName { get => this._sourceFabricFriendlyName; set => this._sourceFabricFriendlyName = value; }

        /// <summary>
        /// Backing field for <see cref="SourceProtectionContainerFriendlyName" /> property.
        /// </summary>
        private string _sourceProtectionContainerFriendlyName;

        /// <summary>Friendly name of source protection container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceProtectionContainerFriendlyName { get => this._sourceProtectionContainerFriendlyName; set => this._sourceProtectionContainerFriendlyName = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>Association Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="TargetFabricFriendlyName" /> property.</summary>
        private string _targetFabricFriendlyName;

        /// <summary>Friendly name of target fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetFabricFriendlyName { get => this._targetFabricFriendlyName; set => this._targetFabricFriendlyName = value; }

        /// <summary>
        /// Backing field for <see cref="TargetProtectionContainerFriendlyName" /> property.
        /// </summary>
        private string _targetProtectionContainerFriendlyName;

        /// <summary>Friendly name of paired container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetProtectionContainerFriendlyName { get => this._targetProtectionContainerFriendlyName; set => this._targetProtectionContainerFriendlyName = value; }

        /// <summary>Backing field for <see cref="TargetProtectionContainerId" /> property.</summary>
        private string _targetProtectionContainerId;

        /// <summary>Paired protection container ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetProtectionContainerId { get => this._targetProtectionContainerId; set => this._targetProtectionContainerId = value; }

        /// <summary>Creates an new <see cref="ProtectionContainerMappingProperties" /> instance.</summary>
        public ProtectionContainerMappingProperties()
        {

        }
    }
    /// Protection container mapping properties.
    public partial interface IProtectionContainerMappingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Health of pairing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Health of pairing.",
        SerializedName = @"health",
        PossibleTypes = new [] { typeof(string) })]
        string Health { get; set; }
        /// <summary>Health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Health error.",
        SerializedName = @"healthErrorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get; set; }
        /// <summary>Friendly name of replication policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of replication policy.",
        SerializedName = @"policyFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyFriendlyName { get; set; }
        /// <summary>Policy ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Policy ARM Id.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>Provider specific provider details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provider specific provider details.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails ProviderSpecificDetail { get; set; }
        /// <summary>Friendly name of source fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of source fabric.",
        SerializedName = @"sourceFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceFabricFriendlyName { get; set; }
        /// <summary>Friendly name of source protection container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of source protection container.",
        SerializedName = @"sourceProtectionContainerFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceProtectionContainerFriendlyName { get; set; }
        /// <summary>Association Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Association Status",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }
        /// <summary>Friendly name of target fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of target fabric.",
        SerializedName = @"targetFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetFabricFriendlyName { get; set; }
        /// <summary>Friendly name of paired container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of paired container.",
        SerializedName = @"targetProtectionContainerFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetProtectionContainerFriendlyName { get; set; }
        /// <summary>Paired protection container ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Paired protection container ARM ID.",
        SerializedName = @"targetProtectionContainerId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetProtectionContainerId { get; set; }

    }
    /// Protection container mapping properties.
    internal partial interface IProtectionContainerMappingPropertiesInternal

    {
        /// <summary>Health of pairing.</summary>
        string Health { get; set; }
        /// <summary>Health error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get; set; }
        /// <summary>Friendly name of replication policy.</summary>
        string PolicyFriendlyName { get; set; }
        /// <summary>Policy ARM Id.</summary>
        string PolicyId { get; set; }
        /// <summary>Provider specific provider details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails ProviderSpecificDetail { get; set; }
        /// <summary>Friendly name of source fabric.</summary>
        string SourceFabricFriendlyName { get; set; }
        /// <summary>Friendly name of source protection container.</summary>
        string SourceProtectionContainerFriendlyName { get; set; }
        /// <summary>Association Status</summary>
        string State { get; set; }
        /// <summary>Friendly name of target fabric.</summary>
        string TargetFabricFriendlyName { get; set; }
        /// <summary>Friendly name of paired container.</summary>
        string TargetProtectionContainerFriendlyName { get; set; }
        /// <summary>Paired protection container ARM ID.</summary>
        string TargetProtectionContainerId { get; set; }

    }
}