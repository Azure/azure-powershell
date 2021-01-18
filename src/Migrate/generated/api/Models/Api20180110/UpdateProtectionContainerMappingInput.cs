namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Container pairing update input.</summary>
    public partial class UpdateProtectionContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateProtectionContainerMappingInputProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputInternal.ProviderSpecificInput { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInput; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInput = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputProperties _property;

        /// <summary>Update protection container mapping input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateProtectionContainerMappingInputProperties()); set => this._property = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificInputInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInputInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputPropertiesInternal)Property).ProviderSpecificInputInstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="UpdateProtectionContainerMappingInput" /> instance.</summary>
        public UpdateProtectionContainerMappingInput()
        {

        }
    }
    /// Container pairing update input.
    public partial interface IUpdateProtectionContainerMappingInput :
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
    internal partial interface IUpdateProtectionContainerMappingInputInternal

    {
        /// <summary>Update protection container mapping input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateProtectionContainerMappingInputProperties Property { get; set; }
        /// <summary>Provider specific input for updating protection container mapping.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificUpdateContainerMappingInput ProviderSpecificInput { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificInputInstanceType { get; set; }

    }
}