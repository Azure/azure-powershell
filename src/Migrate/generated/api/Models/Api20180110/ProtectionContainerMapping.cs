namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Protection container mapping object.</summary>
    public partial class ProtectionContainerMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMapping,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>Health of pairing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Health { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).Health; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).Health = value ?? null; }

        /// <summary>Health error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).HealthErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).HealthErrorDetail = value ?? null /* arrayOf */; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerMappingProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>Friendly name of replication policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).PolicyFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).PolicyFriendlyName = value ?? null; }

        /// <summary>Policy ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).PolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).PolicyId = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProperties _property;

        /// <summary>The custom data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerMappingProperties()); set => this._property = value; }

        /// <summary>Provider specific provider details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).ProviderSpecificDetail = value ?? null /* model class */; }

        /// <summary>Friendly name of source fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SourceFabricFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).SourceFabricFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).SourceFabricFriendlyName = value ?? null; }

        /// <summary>Friendly name of source protection container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SourceProtectionContainerFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).SourceProtectionContainerFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).SourceProtectionContainerFriendlyName = value ?? null; }

        /// <summary>Association Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).State = value ?? null; }

        /// <summary>Friendly name of target fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TargetFabricFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).TargetFabricFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).TargetFabricFriendlyName = value ?? null; }

        /// <summary>Friendly name of paired container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TargetProtectionContainerFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).TargetProtectionContainerFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).TargetProtectionContainerFriendlyName = value ?? null; }

        /// <summary>Paired protection container ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TargetProtectionContainerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).TargetProtectionContainerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingPropertiesInternal)Property).TargetProtectionContainerId = value ?? null; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ProtectionContainerMapping" /> instance.</summary>
        public ProtectionContainerMapping()
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
    /// Protection container mapping object.
    public partial interface IProtectionContainerMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
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
    /// Protection container mapping object.
    internal partial interface IProtectionContainerMappingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>Health of pairing.</summary>
        string Health { get; set; }
        /// <summary>Health error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get; set; }
        /// <summary>Friendly name of replication policy.</summary>
        string PolicyFriendlyName { get; set; }
        /// <summary>Policy ARM Id.</summary>
        string PolicyId { get; set; }
        /// <summary>The custom data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProperties Property { get; set; }
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