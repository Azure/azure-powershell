namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan test failover cleanup input properties.</summary>
    public partial class RecoveryPlanTestFailoverCleanupInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanTestFailoverCleanupInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Comment" /> property.</summary>
        private string _comment;

        /// <summary>The test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Comment { get => this._comment; set => this._comment = value; }

        /// <summary>
        /// Creates an new <see cref="RecoveryPlanTestFailoverCleanupInputProperties" /> instance.
        /// </summary>
        public RecoveryPlanTestFailoverCleanupInputProperties()
        {

        }
    }
    /// Recovery plan test failover cleanup input properties.
    public partial interface IRecoveryPlanTestFailoverCleanupInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test failover cleanup comments.",
        SerializedName = @"comments",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }

    }
    /// Recovery plan test failover cleanup input properties.
    internal partial interface IRecoveryPlanTestFailoverCleanupInputPropertiesInternal

    {
        /// <summary>The test failover cleanup comments.</summary>
        string Comment { get; set; }

    }
}