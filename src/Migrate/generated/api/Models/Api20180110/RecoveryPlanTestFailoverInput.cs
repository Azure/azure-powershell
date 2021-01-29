namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan test failover input.</summary>
    public partial class RecoveryPlanTestFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputInternal
    {

        /// <summary>The failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).FailoverDirection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).FailoverDirection = value ; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanTestFailoverInputProperties()); set { {_property = value;} } }

        /// <summary>The Id of the network to be used for test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string NetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).NetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).NetworkId = value ?? null; }

        /// <summary>The network type to be used for test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string NetworkType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).NetworkType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).NetworkType = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputProperties _property;

        /// <summary>The recovery plan test failover input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryPlanTestFailoverInputProperties()); set => this._property = value; }

        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).ProviderSpecificDetail = value ?? null /* arrayOf */; }

        /// <summary>A value indicating whether the test failover cleanup is to be skipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SkipTestFailoverCleanup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).SkipTestFailoverCleanup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal)Property).SkipTestFailoverCleanup = value ?? null; }

        /// <summary>Creates an new <see cref="RecoveryPlanTestFailoverInput" /> instance.</summary>
        public RecoveryPlanTestFailoverInput()
        {

        }
    }
    /// Recovery plan test failover input.
    public partial interface IRecoveryPlanTestFailoverInput :
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
        /// <summary>The Id of the network to be used for test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the network to be used for test failover.",
        SerializedName = @"networkId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkId { get; set; }
        /// <summary>The network type to be used for test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The network type to be used for test failover.",
        SerializedName = @"networkType",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkType { get; set; }
        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provider specific properties.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }
        /// <summary>A value indicating whether the test failover cleanup is to be skipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the test failover cleanup is to be skipped.",
        SerializedName = @"skipTestFailoverCleanup",
        PossibleTypes = new [] { typeof(string) })]
        string SkipTestFailoverCleanup { get; set; }

    }
    /// Recovery plan test failover input.
    internal partial interface IRecoveryPlanTestFailoverInputInternal

    {
        /// <summary>The failover direction.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get; set; }
        /// <summary>The Id of the network to be used for test failover.</summary>
        string NetworkId { get; set; }
        /// <summary>The network type to be used for test failover.</summary>
        string NetworkType { get; set; }
        /// <summary>The recovery plan test failover input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputProperties Property { get; set; }
        /// <summary>The provider specific properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }
        /// <summary>A value indicating whether the test failover cleanup is to be skipped.</summary>
        string SkipTestFailoverCleanup { get; set; }

    }
}