namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Configure pairing input.</summary>
    public partial class CreateProtectionContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreateProtectionContainerMappingInputProperties()); set { {_property = value;} } }

        /// <summary>Applicable policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputPropertiesInternal)Property).PolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputPropertiesInternal)Property).PolicyId = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputProperties _property;

        /// <summary>Configure protection input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreateProtectionContainerMappingInputProperties()); set => this._property = value; }

        /// <summary>Provider specific input for pairing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput ProviderSpecificInput { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInput; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInput = value ?? null /* model class */; }

        /// <summary>The target unique protection container name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TargetProtectionContainerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputPropertiesInternal)Property).TargetProtectionContainerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputPropertiesInternal)Property).TargetProtectionContainerId = value ?? null; }

        /// <summary>Creates an new <see cref="CreateProtectionContainerMappingInput" /> instance.</summary>
        public CreateProtectionContainerMappingInput()
        {

        }
    }
    /// Configure pairing input.
    public partial interface ICreateProtectionContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Applicable policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Applicable policy.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>Provider specific input for pairing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provider specific input for pairing.",
        SerializedName = @"providerSpecificInput",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput ProviderSpecificInput { get; set; }
        /// <summary>The target unique protection container name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target unique protection container name.",
        SerializedName = @"targetProtectionContainerId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetProtectionContainerId { get; set; }

    }
    /// Configure pairing input.
    internal partial interface ICreateProtectionContainerMappingInputInternal

    {
        /// <summary>Applicable policy.</summary>
        string PolicyId { get; set; }
        /// <summary>Configure protection input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerMappingInputProperties Property { get; set; }
        /// <summary>Provider specific input for pairing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput ProviderSpecificInput { get; set; }
        /// <summary>The target unique protection container name.</summary>
        string TargetProtectionContainerId { get; set; }

    }
}