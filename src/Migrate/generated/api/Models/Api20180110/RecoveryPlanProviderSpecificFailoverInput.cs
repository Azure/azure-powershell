namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan provider specific failover input base class.</summary>
    public partial class RecoveryPlanProviderSpecificFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProviderSpecificFailoverInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>
        /// Creates an new <see cref="RecoveryPlanProviderSpecificFailoverInput" /> instance.
        /// </summary>
        public RecoveryPlanProviderSpecificFailoverInput()
        {

        }
    }
    /// Recovery plan provider specific failover input base class.
    public partial interface IRecoveryPlanProviderSpecificFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Recovery plan provider specific failover input base class.
    internal partial interface IRecoveryPlanProviderSpecificFailoverInputInternal

    {
        /// <summary>The class type.</summary>
        string InstanceType { get; set; }

    }
}