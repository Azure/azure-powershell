namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input definition for planned failover input properties.</summary>
    public partial class PlannedFailoverInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPlannedFailoverInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPlannedFailoverInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FailoverDirection" /> property.</summary>
        private string _failoverDirection;

        /// <summary>Failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FailoverDirection { get => this._failoverDirection; set => this._failoverDirection = value; }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPlannedFailoverInputPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificFailoverInput()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput _providerSpecificDetail;

        /// <summary>Provider specific settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificFailoverInput()); set => this._providerSpecificDetail = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)ProviderSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Creates an new <see cref="PlannedFailoverInputProperties" /> instance.</summary>
        public PlannedFailoverInputProperties()
        {

        }
    }
    /// Input definition for planned failover input properties.
    public partial interface IPlannedFailoverInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Failover direction.",
        SerializedName = @"failoverDirection",
        PossibleTypes = new [] { typeof(string) })]
        string FailoverDirection { get; set; }
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get; set; }

    }
    /// Input definition for planned failover input properties.
    internal partial interface IPlannedFailoverInputPropertiesInternal

    {
        /// <summary>Failover direction.</summary>
        string FailoverDirection { get; set; }
        /// <summary>Provider specific settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput ProviderSpecificDetail { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }

    }
}