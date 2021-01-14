namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input for test migrate.</summary>
    public partial class TestMigrateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestMigrateInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputProperties _property;

        /// <summary>Test migrate input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestMigrateInputProperties()); set => this._property = value; }

        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateProviderSpecificInput ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputPropertiesInternal)Property).ProviderSpecificDetail = value ; }

        /// <summary>Creates an new <see cref="TestMigrateInput" /> instance.</summary>
        public TestMigrateInput()
        {

        }
    }
    /// Input for test migrate.
    public partial interface ITestMigrateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The provider specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The provider specific details.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateProviderSpecificInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
    /// Input for test migrate.
    internal partial interface ITestMigrateInputInternal

    {
        /// <summary>Test migrate input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateInputProperties Property { get; set; }
        /// <summary>The provider specific details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateProviderSpecificInput ProviderSpecificDetail { get; set; }

    }
}