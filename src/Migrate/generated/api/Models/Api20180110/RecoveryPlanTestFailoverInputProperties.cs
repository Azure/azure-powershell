namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan test failover input properties.</summary>
    public partial class RecoveryPlanTestFailoverInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FailoverDirection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections _failoverDirection;

        /// <summary>The failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get => this._failoverDirection; set => this._failoverDirection = value; }

        /// <summary>Backing field for <see cref="NetworkId" /> property.</summary>
        private string _networkId;

        /// <summary>The Id of the network to be used for test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkId { get => this._networkId; set => this._networkId = value; }

        /// <summary>Backing field for <see cref="NetworkType" /> property.</summary>
        private string _networkType;

        /// <summary>The network type to be used for test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkType { get => this._networkType; set => this._networkType = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] _providerSpecificDetail;

        /// <summary>The provider specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get => this._providerSpecificDetail; set => this._providerSpecificDetail = value; }

        /// <summary>Backing field for <see cref="SkipTestFailoverCleanup" /> property.</summary>
        private string _skipTestFailoverCleanup;

        /// <summary>A value indicating whether the test failover cleanup is to be skipped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SkipTestFailoverCleanup { get => this._skipTestFailoverCleanup; set => this._skipTestFailoverCleanup = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanTestFailoverInputProperties" /> instance.</summary>
        public RecoveryPlanTestFailoverInputProperties()
        {

        }
    }
    /// Recovery plan test failover input properties.
    public partial interface IRecoveryPlanTestFailoverInputProperties :
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
    /// Recovery plan test failover input properties.
    internal partial interface IRecoveryPlanTestFailoverInputPropertiesInternal

    {
        /// <summary>The failover direction.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PossibleOperationsDirections FailoverDirection { get; set; }
        /// <summary>The Id of the network to be used for test failover.</summary>
        string NetworkId { get; set; }
        /// <summary>The network type to be used for test failover.</summary>
        string NetworkType { get; set; }
        /// <summary>The provider specific properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput[] ProviderSpecificDetail { get; set; }
        /// <summary>A value indicating whether the test failover cleanup is to be skipped.</summary>
        string SkipTestFailoverCleanup { get; set; }

    }
}