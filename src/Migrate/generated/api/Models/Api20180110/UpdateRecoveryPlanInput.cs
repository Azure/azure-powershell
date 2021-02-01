namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update recovery plan input class.</summary>
    public partial class UpdateRecoveryPlanInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputInternal
    {

        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputPropertiesInternal)Property).Group; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputPropertiesInternal)Property).Group = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateRecoveryPlanInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputProperties _property;

        /// <summary>Recovery plan update properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateRecoveryPlanInputProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="UpdateRecoveryPlanInput" /> instance.</summary>
        public UpdateRecoveryPlanInput()
        {

        }
    }
    /// Update recovery plan input class.
    public partial interface IUpdateRecoveryPlanInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery plan groups.",
        SerializedName = @"groups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }

    }
    /// Update recovery plan input class.
    internal partial interface IUpdateRecoveryPlanInputInternal

    {
        /// <summary>The recovery plan groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }
        /// <summary>Recovery plan update properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateRecoveryPlanInputProperties Property { get; set; }

    }
}