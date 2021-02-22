namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Network Mapping model. Ideally it should have been possible to inherit this class from prev version in InheritedModels
    /// as long as there is no difference in structure or method signature. Since there were no base Models for certain fields
    /// and methods viz NetworkMappingProperties and Load with required return type, the class has been introduced in its entirety
    /// with references to base models to facilitate extensions in subsequent versions.
    /// </summary>
    public partial class NetworkMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FabricSpecificSettingInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).FabricSpecificSettingInstanceType; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for FabricSpecificSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal.FabricSpecificSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).FabricSpecificSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).FabricSpecificSetting = value; }

        /// <summary>Internal Acessors for FabricSpecificSettingInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal.FabricSpecificSettingInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).FabricSpecificSettingInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).FabricSpecificSettingInstanceType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>The primary fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryFabricFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).PrimaryFabricFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).PrimaryFabricFriendlyName = value ?? null; }

        /// <summary>The primary network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryNetworkFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).PrimaryNetworkFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).PrimaryNetworkFriendlyName = value ?? null; }

        /// <summary>The primary network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).PrimaryNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).PrimaryNetworkId = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties _property;

        /// <summary>The Network Mapping Properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingProperties()); set => this._property = value; }

        /// <summary>The recovery fabric ARM id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryFabricArmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryFabricArmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryFabricArmId = value ?? null; }

        /// <summary>The recovery fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryFabricFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryFabricFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryFabricFriendlyName = value ?? null; }

        /// <summary>The recovery network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryNetworkFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryNetworkFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryNetworkFriendlyName = value ?? null; }

        /// <summary>The recovery network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).RecoveryNetworkId = value ?? null; }

        /// <summary>The pairing state for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingPropertiesInternal)Property).State = value ?? null; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="NetworkMapping" /> instance.</summary>
        public NetworkMapping()
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
    /// Network Mapping model. Ideally it should have been possible to inherit this class from prev version in InheritedModels
    /// as long as there is no difference in structure or method signature. Since there were no base Models for certain fields
    /// and methods viz NetworkMappingProperties and Load with required return type, the class has been introduced in its entirety
    /// with references to base models to facilitate extensions in subsequent versions.
    public partial interface INetworkMapping :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricSpecificSettingInstanceType { get;  }
        /// <summary>The primary fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary fabric friendly name.",
        SerializedName = @"primaryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The primary network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary network friendly name.",
        SerializedName = @"primaryNetworkFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryNetworkFriendlyName { get; set; }
        /// <summary>The primary network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary network id for network mapping.",
        SerializedName = @"primaryNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryNetworkId { get; set; }
        /// <summary>The recovery fabric ARM id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric ARM id.",
        SerializedName = @"recoveryFabricArmId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricArmId { get; set; }
        /// <summary>The recovery fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric friendly name.",
        SerializedName = @"recoveryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The recovery network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery network friendly name.",
        SerializedName = @"recoveryNetworkFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryNetworkFriendlyName { get; set; }
        /// <summary>The recovery network id for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery network id for network mapping.",
        SerializedName = @"recoveryNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryNetworkId { get; set; }
        /// <summary>The pairing state for network mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The pairing state for network mapping.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

    }
    /// Network Mapping model. Ideally it should have been possible to inherit this class from prev version in InheritedModels
    /// as long as there is no difference in structure or method signature. Since there were no base Models for certain fields
    /// and methods viz NetworkMappingProperties and Load with required return type, the class has been introduced in its entirety
    /// with references to base models to facilitate extensions in subsequent versions.
    internal partial interface INetworkMappingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>The fabric specific settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings FabricSpecificSetting { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string FabricSpecificSettingInstanceType { get; set; }
        /// <summary>The primary fabric friendly name.</summary>
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The primary network friendly name.</summary>
        string PrimaryNetworkFriendlyName { get; set; }
        /// <summary>The primary network id for network mapping.</summary>
        string PrimaryNetworkId { get; set; }
        /// <summary>The Network Mapping Properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties Property { get; set; }
        /// <summary>The recovery fabric ARM id.</summary>
        string RecoveryFabricArmId { get; set; }
        /// <summary>The recovery fabric friendly name.</summary>
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The recovery network friendly name.</summary>
        string RecoveryNetworkFriendlyName { get; set; }
        /// <summary>The recovery network id for network mapping.</summary>
        string RecoveryNetworkId { get; set; }
        /// <summary>The pairing state for network mapping.</summary>
        string State { get; set; }

    }
}