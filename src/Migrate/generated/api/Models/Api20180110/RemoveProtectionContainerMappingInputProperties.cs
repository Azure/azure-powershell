namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Unpairing input properties.</summary>
    public partial class RemoveProtectionContainerMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputPropertiesInternal
    {

        /// <summary>Internal Acessors for ProviderSpecificInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputPropertiesInternal.ProviderSpecificInput { get => (this._providerSpecificInput = this._providerSpecificInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderContainerUnmappingInput()); set { {_providerSpecificInput = value;} } }

        /// <summary>Backing field for <see cref="ProviderSpecificInput" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput _providerSpecificInput;

        /// <summary>Provider specific input for unpairing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput ProviderSpecificInput { get => (this._providerSpecificInput = this._providerSpecificInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderContainerUnmappingInput()); set => this._providerSpecificInput = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificInputInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInputInternal)ProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInputInternal)ProviderSpecificInput).InstanceType = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="RemoveProtectionContainerMappingInputProperties" /> instance.
        /// </summary>
        public RemoveProtectionContainerMappingInputProperties()
        {

        }
    }
    /// Unpairing input properties.
    public partial interface IRemoveProtectionContainerMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificInputInstanceType { get; set; }

    }
    /// Unpairing input properties.
    internal partial interface IRemoveProtectionContainerMappingInputPropertiesInternal

    {
        /// <summary>Provider specific input for unpairing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput ProviderSpecificInput { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificInputInstanceType { get; set; }

    }
}