namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan creation properties.</summary>
    public partial class CreateRecoveryPlanInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICreateRecoveryPlanInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FailoverDeploymentModel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel? _failoverDeploymentModel;

        /// <summary>The failover deployment model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel? FailoverDeploymentModel { get => this._failoverDeploymentModel; set => this._failoverDeploymentModel = value; }

        /// <summary>Backing field for <see cref="Group" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] _group;

        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get => this._group; set => this._group = value; }

        /// <summary>Backing field for <see cref="PrimaryFabricId" /> property.</summary>
        private string _primaryFabricId;

        /// <summary>The primary fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricId { get => this._primaryFabricId; set => this._primaryFabricId = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricId" /> property.</summary>
        private string _recoveryFabricId;

        /// <summary>The recovery fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricId { get => this._recoveryFabricId; set => this._recoveryFabricId = value; }

        /// <summary>Creates an new <see cref="CreateRecoveryPlanInputProperties" /> instance.</summary>
        public CreateRecoveryPlanInputProperties()
        {

        }
    }
    /// Recovery plan creation properties.
    public partial interface ICreateRecoveryPlanInputProperties :
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
    /// Recovery plan creation properties.
    internal partial interface ICreateRecoveryPlanInputPropertiesInternal

    {
        /// <summary>The failover deployment model.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.FailoverDeploymentModel? FailoverDeploymentModel { get; set; }
        /// <summary>The recovery plan groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }
        /// <summary>The primary fabric Id.</summary>
        string PrimaryFabricId { get; set; }
        /// <summary>The recovery fabric Id.</summary>
        string RecoveryFabricId { get; set; }

    }
}