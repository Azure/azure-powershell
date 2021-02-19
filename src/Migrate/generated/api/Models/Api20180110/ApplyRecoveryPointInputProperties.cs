namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input properties to apply recovery point.</summary>
    public partial class ApplyRecoveryPointInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointInputPropertiesInternal
    {

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointProviderSpecificInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointInputPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ApplyRecoveryPointProviderSpecificInput()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointProviderSpecificInput _providerSpecificDetail;

        /// <summary>Provider specific input for applying recovery point.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointProviderSpecificInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ApplyRecoveryPointProviderSpecificInput()); set => this._providerSpecificDetail = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointProviderSpecificInputInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointProviderSpecificInputInternal)ProviderSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="RecoveryPointId" /> property.</summary>
        private string _recoveryPointId;

        /// <summary>The recovery point Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryPointId { get => this._recoveryPointId; set => this._recoveryPointId = value; }

        /// <summary>Creates an new <see cref="ApplyRecoveryPointInputProperties" /> instance.</summary>
        public ApplyRecoveryPointInputProperties()
        {

        }
    }
    /// Input properties to apply recovery point.
    public partial interface IApplyRecoveryPointInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The recovery point Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point Id.",
        SerializedName = @"recoveryPointId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointId { get; set; }

    }
    /// Input properties to apply recovery point.
    internal partial interface IApplyRecoveryPointInputPropertiesInternal

    {
        /// <summary>Provider specific input for applying recovery point.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IApplyRecoveryPointProviderSpecificInput ProviderSpecificDetail { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The recovery point Id.</summary>
        string RecoveryPointId { get; set; }

    }
}