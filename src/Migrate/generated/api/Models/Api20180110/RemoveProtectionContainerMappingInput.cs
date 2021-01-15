namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Container unpairing input.</summary>
    public partial class RemoveProtectionContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RemoveProtectionContainerMappingInputProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputInternal.ProviderSpecificInput { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInput; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInput = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputProperties _property;

        /// <summary>Configure protection input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RemoveProtectionContainerMappingInputProperties()); set => this._property = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificInputInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInputInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInputInstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="RemoveProtectionContainerMappingInput" /> instance.</summary>
        public RemoveProtectionContainerMappingInput()
        {

        }
    }
    /// Container unpairing input.
    public partial interface IRemoveProtectionContainerMappingInput :
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
    /// Container unpairing input.
    internal partial interface IRemoveProtectionContainerMappingInputInternal

    {
        /// <summary>Configure protection input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRemoveProtectionContainerMappingInputProperties Property { get; set; }
        /// <summary>Provider specific input for unpairing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderContainerUnmappingInput ProviderSpecificInput { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificInputInstanceType { get; set; }

    }
}