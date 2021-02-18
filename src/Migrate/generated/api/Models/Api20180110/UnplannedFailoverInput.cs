namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input definition for planned failover.</summary>
    public partial class UnplannedFailoverInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputInternal
    {

        /// <summary>Failover direction.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FailoverDirection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).FailoverDirection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).FailoverDirection = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UnplannedFailoverInputProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputInternal.ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).ProviderSpecificDetail = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputProperties _property;

        /// <summary>Planned failover input properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UnplannedFailoverInputProperties()); set => this._property = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).ProviderSpecificDetailInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).ProviderSpecificDetailInstanceType = value ?? null; }

        /// <summary>Source site operations status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SourceSiteOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).SourceSiteOperation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputPropertiesInternal)Property).SourceSiteOperation = value ?? null; }

        /// <summary>Creates an new <see cref="UnplannedFailoverInput" /> instance.</summary>
        public UnplannedFailoverInput()
        {

        }
    }
    /// Input definition for planned failover.
    public partial interface IUnplannedFailoverInput :
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
        /// <summary>Source site operations status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source site operations status",
        SerializedName = @"sourceSiteOperations",
        PossibleTypes = new [] { typeof(string) })]
        string SourceSiteOperation { get; set; }

    }
    /// Input definition for planned failover.
    internal partial interface IUnplannedFailoverInputInternal

    {
        /// <summary>Failover direction.</summary>
        string FailoverDirection { get; set; }
        /// <summary>Planned failover input properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUnplannedFailoverInputProperties Property { get; set; }
        /// <summary>Provider specific settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput ProviderSpecificDetail { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>Source site operations status</summary>
        string SourceSiteOperation { get; set; }

    }
}