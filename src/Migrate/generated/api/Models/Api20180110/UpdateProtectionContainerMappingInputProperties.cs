namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Container pairing update input.</summary>
    public partial class UpdateProtectionContainerMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputPropertiesInternal
    {

        /// <summary>Internal Acessors for ProviderSpecificInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputPropertiesInternal.ProviderSpecificInput { get => (this._providerSpecificInput = this._providerSpecificInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificUpdateContainerMappingInput()); set { {_providerSpecificInput = value;} } }

        /// <summary>Backing field for <see cref="ProviderSpecificInput" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput _providerSpecificInput;

        /// <summary>Provider specific input for updating protection container mapping.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput ProviderSpecificInput { get => (this._providerSpecificInput = this._providerSpecificInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificUpdateContainerMappingInput()); set => this._providerSpecificInput = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificInputInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInputInternal)ProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInputInternal)ProviderSpecificInput).InstanceType = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="UpdateProtectionContainerMappingInputProperties" /> instance.
        /// </summary>
        public UpdateProtectionContainerMappingInputProperties()
        {

        }
    }
    /// Container pairing update input.
    public partial interface IUpdateProtectionContainerMappingInputProperties :
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
    /// Container pairing update input.
    internal partial interface IUpdateProtectionContainerMappingInputPropertiesInternal

    {
        /// <summary>Provider specific input for updating protection container mapping.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput ProviderSpecificInput { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificInputInstanceType { get; set; }

    }
}