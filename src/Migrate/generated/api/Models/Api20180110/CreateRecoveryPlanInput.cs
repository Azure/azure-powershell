namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Create recovery plan input class.</summary>
    public partial class CreateRecoveryPlanInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputInternal
    {

        /// <summary>The failover deployment model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel? FailoverDeploymentModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).FailoverDeploymentModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).FailoverDeploymentModel = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel)""); }

        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).Group; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).Group = value ; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreateRecoveryPlanInputProperties()); set { {_property = value;} } }

        /// <summary>The primary fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrimaryFabricId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).PrimaryFabricId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).PrimaryFabricId = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputProperties _property;

        /// <summary>Recovery plan creation properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CreateRecoveryPlanInputProperties()); set => this._property = value; }

        /// <summary>The recovery fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryFabricId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).RecoveryFabricId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal)Property).RecoveryFabricId = value ; }

        /// <summary>Creates an new <see cref="CreateRecoveryPlanInput" /> instance.</summary>
        public CreateRecoveryPlanInput()
        {

        }
    }
    /// Create recovery plan input class.
    public partial interface ICreateRecoveryPlanInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The failover deployment model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The failover deployment model.",
        SerializedName = @"failoverDeploymentModel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel? FailoverDeploymentModel { get; set; }
        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The recovery plan groups.",
        SerializedName = @"groups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }
        /// <summary>The primary fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The primary fabric Id.",
        SerializedName = @"primaryFabricId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricId { get; set; }
        /// <summary>The recovery fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The recovery fabric Id.",
        SerializedName = @"recoveryFabricId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricId { get; set; }

    }
    /// Create recovery plan input class.
    internal partial interface ICreateRecoveryPlanInputInternal

    {
        /// <summary>The failover deployment model.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel? FailoverDeploymentModel { get; set; }
        /// <summary>The recovery plan groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }
        /// <summary>The primary fabric Id.</summary>
        string PrimaryFabricId { get; set; }
        /// <summary>Recovery plan creation properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputProperties Property { get; set; }
        /// <summary>The recovery fabric Id.</summary>
        string RecoveryFabricId { get; set; }

    }
}