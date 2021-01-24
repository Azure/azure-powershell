namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan unplanned failover input.</summary>
    public partial class RecoveryPlanUnplannedFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputInternal
    {

        /// <summary>The failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputPropertiesInternal)Property).FailoverDirection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputPropertiesInternal)Property).FailoverDirection = value ; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanUnplannedFailoverInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputProperties _property;

        /// <summary>The recovery plan unplanned failover input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanUnplannedFailoverInputProperties()); set => this._property = value; }

        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputPropertiesInternal)Property).ProviderSpecificDetail = value ?? null /* arrayOf */; }

        /// <summary>A value indicating whether source site operations are required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.SourceSiteOperations SourceSiteOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputPropertiesInternal)Property).SourceSiteOperation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputPropertiesInternal)Property).SourceSiteOperation = value ; }

        /// <summary>Creates an new <see cref="RecoveryPlanUnplannedFailoverInput" /> instance.</summary>
        public RecoveryPlanUnplannedFailoverInput()
        {

        }
    }
    /// Recovery plan unplanned failover input.
    public partial interface IRecoveryPlanUnplannedFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The failover direction.",
        SerializedName = @"failoverDirection",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get; set; }
        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provider specific properties.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }
        /// <summary>A value indicating whether source site operations are required.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A value indicating whether source site operations are required.",
        SerializedName = @"sourceSiteOperations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.SourceSiteOperations) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.SourceSiteOperations SourceSiteOperation { get; set; }

    }
    /// Recovery plan unplanned failover input.
    internal partial interface IRecoveryPlanUnplannedFailoverInputInternal

    {
        /// <summary>The failover direction.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get; set; }
        /// <summary>The recovery plan unplanned failover input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanUnplannedFailoverInputProperties Property { get; set; }
        /// <summary>The provider specific properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }
        /// <summary>A value indicating whether source site operations are required.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.SourceSiteOperations SourceSiteOperation { get; set; }

    }
}