namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Site details provided during the time of site creation</summary>
    public partial class FabricCreationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputInternal
    {

        /// <summary>Gets the class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputPropertiesInternal)Property).CustomDetailInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputPropertiesInternal)Property).CustomDetailInstanceType = value ?? null; }

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputInternal.CustomDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputPropertiesInternal)Property).CustomDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputPropertiesInternal)Property).CustomDetail = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricCreationInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputProperties _property;

        /// <summary>Fabric creation input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricCreationInputProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="FabricCreationInput" /> instance.</summary>
        public FabricCreationInput()
        {

        }
    }
    /// Site details provided during the time of site creation
    public partial interface IFabricCreationInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDetailInstanceType { get; set; }

    }
    /// Site details provided during the time of site creation
    internal partial interface IFabricCreationInputInternal

    {
        /// <summary>Fabric provider specific creation input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInput CustomDetail { get; set; }
        /// <summary>Gets the class type.</summary>
        string CustomDetailInstanceType { get; set; }
        /// <summary>Fabric creation input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputProperties Property { get; set; }

    }
}