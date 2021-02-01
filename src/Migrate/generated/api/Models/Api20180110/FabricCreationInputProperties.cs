namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Properties of site details provided during the time of site creation</summary>
    public partial class FabricCreationInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInput _customDetail;

        /// <summary>Fabric provider specific creation input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInput CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificCreationInput()); set => this._customDetail = value; }

        /// <summary>Gets the class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInputInternal)CustomDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInputInternal)CustomDetail).InstanceType = value ?? null; }

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricCreationInputPropertiesInternal.CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificCreationInput()); set { {_customDetail = value;} } }

        /// <summary>Creates an new <see cref="FabricCreationInputProperties" /> instance.</summary>
        public FabricCreationInputProperties()
        {

        }
    }
    /// Properties of site details provided during the time of site creation
    public partial interface IFabricCreationInputProperties :
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
    /// Properties of site details provided during the time of site creation
    internal partial interface IFabricCreationInputPropertiesInternal

    {
        /// <summary>Fabric provider specific creation input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificCreationInput CustomDetail { get; set; }
        /// <summary>Gets the class type.</summary>
        string CustomDetailInstanceType { get; set; }

    }
}