namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Create protection container input.</summary>
    public partial class CreateProtectionContainerInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreateProtectionContainerInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputProperties _property;

        /// <summary>Create protection container input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreateProtectionContainerInputProperties()); set => this._property = value; }

        /// <summary>Provider specific inputs for container creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput[] ProviderSpecificInput { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputPropertiesInternal)Property).ProviderSpecificInput; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputPropertiesInternal)Property).ProviderSpecificInput = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="CreateProtectionContainerInput" /> instance.</summary>
        public CreateProtectionContainerInput()
        {

        }
    }
    /// Create protection container input.
    public partial interface ICreateProtectionContainerInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Provider specific inputs for container creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provider specific inputs for container creation.",
        SerializedName = @"providerSpecificInput",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput[] ProviderSpecificInput { get; set; }

    }
    /// Create protection container input.
    internal partial interface ICreateProtectionContainerInputInternal

    {
        /// <summary>Create protection container input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateProtectionContainerInputProperties Property { get; set; }
        /// <summary>Provider specific inputs for container creation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerCreationInput[] ProviderSpecificInput { get; set; }

    }
}